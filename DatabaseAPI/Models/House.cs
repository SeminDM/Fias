using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAPI.Models
{
    public class House
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AddressObjectId { get; set; }
        public Guid GUID { get; set; }
        public string PostalCode { get; set; }
        public string RegionCode { get; set; }
        public string IFNSFL { get; set; }
        public string TERRIFNSFL { get; set; }
        public string IFNSUL { get; set; }
        public string TERRIFNSUL { get; set; }
        public string OKATO { get; set; }
        public string OKTMO { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string HouseNumber { get; set; }
        public int? EstStatus { get; set; }
        public string BuildingNumber { get; set; }
        public string StructureNumber { get; set; }
        public int? StrStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? StatStatus { get; set; }
        public int? Counter { get; set; }
        public string CadNumber { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
