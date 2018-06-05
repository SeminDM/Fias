using System;
using DatabaseAPI.Models;
using Fias.ViewModels;

namespace Fias.Infrastructure.Mappers
{
    public class AddressObjectMapper
    {
        public AddressObject Map(AddressObjectViewModel source)
        {
            if (source == null)
            {
                return null;
            }
            return new AddressObject
            {
                //AOID = source.Id?.Value,
                // ToDo: make AOGUID as Guid
                //AOGUID = source.Guid.ToString(),
                //PARENTGUID = source.ParentGuid.ToString(),
                AOLEVEL = (int)source.Level,
                ACTSTATUS = source.Status,
                POSTALCODE = source.PostalCode,
                UPDATEDATE = source.UpdateDate,
                FORMALNAME = source.FormalName,
                SHORTNAME = source.ShortName,
                REGIONCODE = source.RegionCode
            };
        }

        public AddressObjectViewModel Map(AddressObject source)
        {
            if (source == null)
            {
                return null;
            }
            return new AddressObjectViewModel
            {
                Id = source.AOID,
                Guid = string.IsNullOrEmpty(source.AOGUID) ? Guid.Empty : Guid.Parse(source.AOGUID),
                ParentGuid = string.IsNullOrEmpty(source.PARENTGUID) ? Guid.Empty : Guid.Parse(source.PARENTGUID),
                Level = source.AOLEVEL != null ? (AddressObjectLevel)Enum.ToObject(typeof(AddressObjectLevel), source.AOLEVEL) : AddressObjectLevel.Undefined,
                Status = source.ACTSTATUS,
                PostalCode = source.POSTALCODE,
                UpdateDate = source.UPDATEDATE,
                FormalName = source.FORMALNAME,
                ShortName = source.SHORTNAME,
                RegionCode = source.REGIONCODE
            };
        }
    }
}
