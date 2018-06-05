using System.Collections.Generic;
using DatabaseAPI.Models;

namespace DatabaseAPI.Interfaces
{
    public interface IAddressObjectService
    {
        AddressObject Get(string id);

        IList<AddressObject> List();

        IList<AddressObject> ListByPage(int page, int pageSize);

        void Create(AddressObject addressObject);

        void Edit(AddressObject addressObject);

        void Delete(string id);

        void Delete(string[] ids);
    }
}
