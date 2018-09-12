using System;
using DatabaseAPI.Models;
using Fias.ViewModels;

namespace Fias.Infrastructure.Mappers
{
    public class AddressObjectMapper
    {
        public AddressObject Map(AddressObjectViewModel source)
        {
            if (source == null) return null;

            return new AddressObject
            {
                Id = source.Id ?? Guid.Empty,
                GUID = source.Guid ?? Guid.Empty,
                ParentGUID = source.ParentGuid ?? Guid.Empty,
                Level = (int)source.Level,
                ActualStatus = source.Status,
                PostalCode = source.PostalCode,
                UpdateDate = source.UpdateDate,
                FormalName = source.FormalName,
                ShortName = source.ShortName,
                RegionCode = source.RegionCode
            };
        }

        public AddressObjectViewModel Map(AddressObject source)
        {
            if (source == null) return null;

            return new AddressObjectViewModel
            {
                Id = source.Id,
                Guid = source.GUID,
                ParentGuid = source.ParentGUID,
                Level = source.Level != null ? (AddressObjectLevel)Enum.ToObject(typeof(AddressObjectLevel), source.Level) : AddressObjectLevel.Undefined,
                Status = source.ActualStatus,
                PostalCode = source.PostalCode,
                UpdateDate = source.UpdateDate?.ToLocalTime(),
                FormalName = source.FormalName,
                ShortName = source.ShortName,
                RegionCode = source.RegionCode
            };
        }
    }
}
