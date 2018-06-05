using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseAPI.Models
{
    public class AddressObject
    {
        [Key]
        public System.Guid AOID { get; set; }
        public string AOGUID { get; set; }
        public string FORMALNAME { get; set; }
        public string REGIONCODE { get; set; }
        public string AUTOCODE { get; set; }
        public string AREACODE { get; set; }
        public string CITYCODE { get; set; }
        public string CTARCODE { get; set; }
        public string PLACECODE { get; set; }
        public string PLANCODE { get; set; }
        public string STREETCODE { get; set; }
        public string OFFNAME { get; set; }
        public string POSTALCODE { get; set; }
        public string IFNSFL { get; set; }
        public string TERRIFNSFL { get; set; }
        public string IFNSUL { get; set; }
        public string TERRIFNSUL { get; set; }
        public string OKATO { get; set; }
        public string OKTMO { get; set; }
        public Nullable<System.DateTime> UPDATEDATE { get; set; }
        public string SHORTNAME { get; set; }
        public Nullable<int> AOLEVEL { get; set; }
        public string PARENTGUID { get; set; }
        public string CODE { get; set; }
        public string PLAINCODE { get; set; }
        public Nullable<int> ACTSTATUS { get; set; }
        public Nullable<int> CENTSTATUS { get; set; }
        public Nullable<int> OPERSTATUS { get; set; }
        public Nullable<int> CURRSTATUS { get; set; }
        public Nullable<System.DateTime> STARTDATE { get; set; }
        public Nullable<System.DateTime> ENDDATE { get; set; }
        public Nullable<int> LIVESTATUS { get; set; }
    }
}
