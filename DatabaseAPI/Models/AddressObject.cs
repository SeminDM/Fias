using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAPI.Models
{
    public class AddressObject
    {
        [Key]
        public Guid Id { get; set; }
        public Guid GUID { get; set; }
        public string FormalName { get; set; }
        public string RegionCode { get; set; }
        public string AutoCode { get; set; }
        public string AreaCode { get; set; }
        public string CityCode { get; set; }
        public string CtarCode { get; set; }
        public string PlaceCode { get; set; }
        public string PlanCode { get; set; }
        public string StreetCode { get; set; }
        public string OfficialName { get; set; }
        public string PostalCode { get; set; }
        public string IFNSFL { get; set; }
        public string TERRIFNSFL { get; set; }
        public string IFNSUL { get; set; }
        public string TERRIFNSUL { get; set; }
        public string OKATO { get; set; }
        public string OKTMO { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ShortName { get; set; }
        public int? Level { get; set; }
        public Guid? ParentGUID { get; set; }
        public string Code { get; set; }
        public string PlainCode { get; set; }
        public int? ActualStatus { get; set; }
        public int? CentStatus { get; set; }
        public int? OperStatus { get; set; }
        public int? CurrStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? LiveStatus { get; set; }
    }
}
