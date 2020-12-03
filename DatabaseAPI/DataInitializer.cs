using DatabaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DatabaseAPI
{
    internal sealed class DataInitializer
    {
        public void Go()
        {
            var number = 100;
            var filePath = @"E:\Programming\FIAS\fias_xml\AS_ADDROBJ_20180303_d91ba69a-52a1-4b29-bd4b-498587d55398.XML";
            var addressObjects = ReadAddressObjects(filePath, number).ToList();


        }

        private IEnumerable<AddressObject> ReadAddressObjects(string filePath, int number)
        {
            using (var reader = XmlReader.Create(filePath))
            {
                var i = 0;
                while (i < number && reader.Read())
                {
                    var nodeType = reader.NodeType;
                    if (nodeType != XmlNodeType.Element)
                    {
                        continue;
                    }
                    if (reader.LocalName == AddressObjectFields.ObjectNodeName)
                    {
                        var objectXml = reader.ReadOuterXml();
                        var objectDoc = new XmlDocument();
                        objectDoc.LoadXml(objectXml);
                        var objectNode = objectDoc.SelectSingleNode(AddressObjectFields.ObjectNodeName);

                        var aoidAttr = objectNode.Attributes[AddressObjectFields.AoId];
                        if (string.IsNullOrEmpty(aoidAttr.Value) || !Guid.TryParse(aoidAttr.Value, out var aoid))
                        {
                            continue;
                        };

                        var addressObject = new AddressObject
                        {
                            Id = aoid,
                            FormalName = objectNode.Attributes[AddressObjectFields.FormalName]?.Value,
                            AreaCode = objectNode.Attributes[AddressObjectFields.AreaCode]?.Value,
                            AutoCode = objectNode.Attributes[AddressObjectFields.AutoCode]?.Value,
                            CityCode = objectNode.Attributes[AddressObjectFields.CityCode]?.Value,
                            Code = objectNode.Attributes[AddressObjectFields.Code]?.Value,
                            CtarCode = objectNode.Attributes[AddressObjectFields.CtarCode]?.Value,
                            IFNSFL = objectNode.Attributes[AddressObjectFields.IFNSFL]?.Value,
                            IFNSUL = objectNode.Attributes[AddressObjectFields.IFNSUL]?.Value,
                            OfficialName = objectNode.Attributes[AddressObjectFields.OfficialName]?.Value,
                            OKATO = objectNode.Attributes[AddressObjectFields.OKATO]?.Value,
                            OKTMO = objectNode.Attributes[AddressObjectFields.OKTMO]?.Value,
                            PlaceCode = objectNode.Attributes[AddressObjectFields.PlaceCode]?.Value,
                            PlainCode = objectNode.Attributes[AddressObjectFields.PlainCode]?.Value,
                            PlanCode = objectNode.Attributes[AddressObjectFields.PlanCode]?.Value,
                            PostalCode = objectNode.Attributes[AddressObjectFields.PostalCode]?.Value,
                            ShortName = objectNode.Attributes[AddressObjectFields.ShortName]?.Value,
                            RegionCode = objectNode.Attributes[AddressObjectFields.RegionCode]?.Value,
                            StreetCode = objectNode.Attributes[AddressObjectFields.StreetCode]?.Value,
                            TERRIFNSFL = objectNode.Attributes[AddressObjectFields.TERRIFNSFL]?.Value,
                            TERRIFNSUL = objectNode.Attributes[AddressObjectFields.TERRIFNSUL]?.Value
                        };

                        var aoguidString = objectNode.Attributes[AddressObjectFields.AoGuid]?.Value;
                        if (!string.IsNullOrEmpty(aoguidString))
                        {
                            if (Guid.TryParse(aoguidString, out var aoguid))
                            {
                                addressObject.GUID = aoguid;
                            }
                        }

                        var parentString = objectNode.Attributes[AddressObjectFields.ParentGUID]?.Value;
                        if (!string.IsNullOrEmpty(parentString))
                        {
                            if (Guid.TryParse(parentString, out var val)) addressObject.ParentGUID = val;
                        }

                        var levelString = objectNode.Attributes[AddressObjectFields.Level]?.Value;
                        if (!string.IsNullOrEmpty(levelString))
                        {
                            if (int.TryParse(levelString, out var val)) addressObject.Level = val;
                        }

                        var actString = objectNode.Attributes[AddressObjectFields.ActualStatus]?.Value;
                        if (!string.IsNullOrEmpty(actString))
                        {
                            if (int.TryParse(actString, out var val)) addressObject.ActualStatus = val;
                        }

                        var centString = objectNode.Attributes[AddressObjectFields.CentStatus]?.Value;
                        if (!string.IsNullOrEmpty(centString))
                        {
                            if (int.TryParse(centString, out var val)) addressObject.CentStatus = val;
                        }

                        var currString = objectNode.Attributes[AddressObjectFields.CurrStatus]?.Value;
                        if (!string.IsNullOrEmpty(currString))
                        {
                            if (int.TryParse(currString, out var val)) addressObject.CurrStatus = val;
                        }

                        var liveString = objectNode.Attributes[AddressObjectFields.LiveStatus]?.Value;
                        if (!string.IsNullOrEmpty(liveString))
                        {
                            if (int.TryParse(liveString, out var val)) addressObject.LiveStatus = val;
                        }

                        var operString = objectNode.Attributes[AddressObjectFields.OperStatus]?.Value;
                        if (!string.IsNullOrEmpty(operString))
                        {
                            if (int.TryParse(operString, out var val)) addressObject.OperStatus = val;
                        }

                        var endString = objectNode.Attributes[AddressObjectFields.EndDate]?.Value;
                        if (!string.IsNullOrEmpty(endString))
                        {
                            if (DateTime.TryParse(endString, out var val)) addressObject.EndDate = val;
                        }

                        var startString = objectNode.Attributes[AddressObjectFields.StartDate]?.Value;
                        if (!string.IsNullOrEmpty(startString))
                        {
                            if (DateTime.TryParse(startString, out var val)) addressObject.StartDate = val;
                        }

                        var updateString = objectNode.Attributes[AddressObjectFields.UpdateDate]?.Value;
                        if (!string.IsNullOrEmpty(updateString))
                        {
                            if (DateTime.TryParse(updateString, out var val)) addressObject.UpdateDate = val;
                        }

                        i++;
                        yield return addressObject;
                    }
                }
            }
        }
    }

    internal class AddressObjectFields
    {
        public const string ObjectNodeName = "Object";

        public const string AoId = "AOID";
        public const string FormalName = "FORMALNAME";
        public const string AoGuid = "AOGUID";
        public const string RegionCode = "REGIONCODE";
        public const string AutoCode = "AUTOCODE";
        public const string AreaCode = "AREACODE";
        public const string CityCode = "CITYCODE";
        public const string CtarCode = "CTARCODE";
        public const string PlaceCode = "PLACECODE";
        public const string PlanCode = "PLANCODE";
        public const string StreetCode = "STREETCODE";
        public const string OfficialName = "OFFNAME";
        public const string PostalCode = "POSTALCODE";
        public const string IFNSFL = "IFNSFL";
        public const string TERRIFNSFL = "TERRIFNSFL";
        public const string IFNSUL = "IFNSUL";
        public const string TERRIFNSUL = "TERRIFNSUL";
        public const string OKATO = "OKATO";
        public const string OKTMO = "OKTMO";
        public const string UpdateDate = "UPDATEDATE";
        public const string ShortName = "SHORTNAME";
        public const string Level = "AOLEVEL";
        public const string ParentGUID = "PARENTGUID";
        public const string Code = "CODE";
        public const string PlainCode = "PLAINCODE";
        public const string ActualStatus = "ACTUALSTATUS";
        public const string CentStatus = "CENTSTATUS";
        public const string OperStatus = "OPERSTATUS";
        public const string CurrStatus = "CURRSTATUS";
        public const string StartDate = "STARTDATE";
        public const string EndDate = "ENDDATE";
        public const string LiveStatus = "LIVASTATUS";
    }
}
