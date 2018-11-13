[String]$global:connectionString = "Data Source=semin-pc\SQLEXPRESS;Initial Catalog=FiasDatabaseCore;Integrated Security=SSPI;";
[System.Data.DataTable]$global:dt = New-Object System.Data.DataTable;
[System.Xml.XmlTextReader]$global:xmlReader = New-Object System.Xml.XmlTextReader("D:\FIAS\XML\fias_xml\AS_ADDROBJ_20171126_922d2e73-a81d-4055-b8e8-3855a898f360.XML");
[Int32]$global:batchSize = 100000;

Function Add-FileRow() {
    # filter out-date entries
    [int]$liveStatus = $global:xmlReader.GetAttribute("LIVESTATUS");
    $now = Get-Date;
    if($liveStatus -lt 1)
    {
        return;
    }

    $newRow = $dt.NewRow();
    $null = $dt.Rows.Add($newRow);
    $parentGuid = $global:xmlReader.GetAttribute("PARENTGUID");
    $newRow["GUID"] = $global:xmlReader.GetAttribute("AOGUID");
    $newRow["FormalName"] = $global:xmlReader.GetAttribute("FORMALNAME");
    $newRow["RegionCode"] = $global:xmlReader.GetAttribute("REGIONCODE");
    $newRow["AutoCode"] = $global:xmlReader.GetAttribute("AUTOCODE");
    $newRow["AreaCode"] = $global:xmlReader.GetAttribute("AREACODE");
    $newRow["CityCode"] = $global:xmlReader.GetAttribute("CITYCODE");
    $newRow["CtarCode"] = $global:xmlReader.GetAttribute("CTARCODE");
    $newRow["PlaceCode"] = $global:xmlReader.GetAttribute("PLACECODE");
    $newRow["PlanCode"] = $global:xmlReader.GetAttribute("PLANCODE");
    $newRow["StreetCode"] = $global:xmlReader.GetAttribute("STREETCODE");
    $newRow["OfficialName"] = $global:xmlReader.GetAttribute("OFFNAME");
    $newRow["PostalCode"] = $global:xmlReader.GetAttribute("POSTALCODE");
    $newRow["IFNSFL"] = $global:xmlReader.GetAttribute("IFNSFL");
    $newRow["TERRIFNSFL"] = $global:xmlReader.GetAttribute("TERRIFNSFL");
    $newRow["IFNSUL"] = $global:xmlReader.GetAttribute("IFNSUL");
    $newRow["TERRIFNSUL"] = $global:xmlReader.GetAttribute("TERRIFNSUL");
    $newRow["OKATO"] = $global:xmlReader.GetAttribute("OKATO");
    $newRow["OKTMO"] = $global:xmlReader.GetAttribute("OKTMO");
    $newRow["UpdateDate"] = $global:xmlReader.GetAttribute("UPDATEDATE");
    $newRow["ShortName"] = $global:xmlReader.GetAttribute("SHORTNAME");
    $newRow["Level"] = $global:xmlReader.GetAttribute("AOLEVEL");
    $newRow["ParentGUID"] = if ([String]::IsNullOrWhiteSpace($parentGuid)) { [DBNull]::Value } else { $parentGuid };
    $newRow["Id"] = $global:xmlReader.GetAttribute("AOID");
    $newRow["Code"] = $global:xmlReader.GetAttribute("CODE");
    $newRow["PlainCode"] = $global:xmlReader.GetAttribute("PLAINCODE");
    $newRow["ActualStatus"] = $global:xmlReader.GetAttribute("ACTSTATUS");
    $newRow["CentStatus"] = $global:xmlReader.GetAttribute("CENTSTATUS");
    $newRow["OperStatus"] = $global:xmlReader.GetAttribute("OPERSTATUS");
    $newRow["CurrStatus"] = $global:xmlReader.GetAttribute("CURRSTATUS");
    $newRow["StartDate"] = $global:xmlReader.GetAttribute("STARTDATE");
    $newRow["EndDate"] = $global:xmlReader.GetAttribute("ENDDATE");
    $newRow["LiveStatus"] = $liveStatus;
}

try
{

    # init data table schema
    $da = New-Object System.Data.SqlClient.SqlDataAdapter("SELECT * FROM dbo.AddressObjects WHERE 0 = 1;", $global:connectionString);
    $null = $da.Fill($global:dt);
    $bcp = New-Object System.Data.SqlClient.SqlBulkCopy($global:connectionString);
    $bcp.DestinationTableName = "dbo.AddressObjects";

    $recordCount = 0;
    
    while($xmlReader.Read() -eq $true -and $recordCount -lt 100)
    {

        if(($xmlReader.NodeType -eq [System.Xml.XmlNodeType]::Element) -and ($xmlReader.Name -eq "Object"))
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