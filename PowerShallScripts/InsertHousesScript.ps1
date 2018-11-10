[String]$global:connectionString = "Data Source=ds;Initial Catalog=FiasDatabaseCore;Integrated Security=SSPI;";
[System.Data.DataTable]$global:dt = New-Object System.Data.DataTable;
[System.Xml.XmlTextReader]$global:xmlReader = New-Object System.Xml.XmlTextReader("E:\FIAS\fias_xml\AS_HOUSE_20180304_a75ac32a-c8e2-4720-b72c-9165ccd691fb.xml");
[Int32]$global:batchSize = 100000;

Function Add-FileRow() {

    # filter out-date entries
    [datetime]$enddate = $global:xmlReader.GetAttribute("ENDDATE");
    $now = Get-Date;
    if($enddate -lt $now)
    {
        return;
    }

    $newRow = $dt.NewRow();
    $null = $dt.Rows.Add($newRow);
    $newRow["PostalCode"] = $global:xmlReader.GetAttribute("POSTALCODE");
    $newRow["RegionCode"] = $global:xmlReader.GetAttribute("REGIONCODE");
    $newRow["IFNSFL"] = $global:xmlReader.GetAttribute("IFNSFL");
    $newRow["TERRIFNSFL"] = $global:xmlReader.GetAttribute("TERRIFNSFL");
    $newRow["IFNSUL"] = $global:xmlReader.GetAttribute("IFNSUL");
    $newRow["TERRIFNSUL"] = $global:xmlReader.GetAttribute("TERRIFNSUL");
    $newRow["OKATO"] = $global:xmlReader.GetAttribute("OKATO");
    $newRow["OKTMO"] = $global:xmlReader.GetAttribute("OKTMO");
    $newRow["UpdateDate"] = $global:xmlReader.GetAttribute("UPDATEDATE");
    $newRow["HouseNumber"] = $global:xmlReader.GetAttribute("HOUSENUM");
    $newRow["EstStatus"] = $global:xmlReader.GetAttribute("ESTSTATUS");
    $newRow["BuildingNumber"] = $global:xmlReader.GetAttribute("BUILDNUM");
    $newRow["StructureNumber"] = $global:xmlReader.GetAttribute("STRUCNUM");
    $newRow["StrStatus"] = $global:xmlReader.GetAttribute("STRSTATUS");
    $newRow["Id"] = $global:xmlReader.GetAttribute("HOUSEID");
    $newRow["GUID"] = $global:xmlReader.GetAttribute("HOUSEGUID");
    $newRow["AddressObjectId"] = $global:xmlReader.GetAttribute("AOGUID");
    $newRow["StartDate"] = $global:xmlReader.GetAttribute("STARTDATE");
    $newRow["EndDate"] = $global:xmlReader.GetAttribute("ENDDATE");
    $newRow["StatStatus"] = $global:xmlReader.GetAttribute("STATSTATUS");
    $newRow["Counter"] = $global:xmlReader.GetAttribute("COUNTER");
    $newRow["CadNumber"] = $global:xmlReader.GetAttribute("CADNUM");
}

try
{

    # init data table schema
    $da = New-Object System.Data.SqlClient.SqlDataAdapter("SELECT * FROM dbo.Houses WHERE 0 = 1;", $global:connectionString);
    $null = $da.Fill($global:dt);
    $bcp = New-Object System.Data.SqlClient.SqlBulkCopy($global:connectionString);
    $bcp.DestinationTableName = "dbo.Houses";

    $recordCount = 0;
    
    while($xmlReader.Read() -eq $true)
    {

        if(($xmlReader.NodeType -eq [System.Xml.XmlNodeType]::Element) -and ($xmlReader.Name -eq "House"))
        {
           

            Add-FileRow -xmlReader $xmlReader;
            $recordCount += 1;
            if(($recordCount % $global:batchSize) -eq 0) 
            {
                $bcp.WriteToServer($dt);
                $dt.Rows.Clear();
                Write-Host "$recordCount file elements processed so far";
            }
        }

    }

    if($dt.Rows.Count -gt 0)
    {
        $bcp.WriteToServer($dt);
    }

    $bcp.Close();
    $xmlReader.Close();

    Write-Host "$recordCount file elements imported";

}
catch
{
    throw;
}