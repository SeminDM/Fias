using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseAPI.Interfaces;
using DatabaseAPI.Models;

namespace DatabaseAPI.Services
{
    public class AddressObjectService : IAddressObjectService
    {
        private readonly FiasDatabaseContext _context;

        private readonly List<AddressObject> _addressObjects = new List<AddressObject>
        {
            new AddressObject {AOID = Guid.NewGuid(), OFFNAME = "Mira", SHORTNAME = "street"},
            new AddressObject {AOID = Guid.NewGuid(), OFFNAME = "Gagarina", SHORTNAME = "street"},
            new AddressObject {AOID = Guid.NewGuid(), OFFNAME = "Lenina", SHORTNAME = "street"},
            new AddressObject {AOID = Guid.NewGuid(), OFFNAME = "Pavlova", SHORTNAME = "street"}
        };

        public AddressObjectService(FiasDatabaseContext fiasDatabaseContext)
        {
            _context = fiasDatabaseContext;
        }

        public AddressObject Get(string id)
        {
            throw new NotImplementedException();
        }

        public IList<AddressObject> List()
        {
            throw new NotImplementedException();
        }

        public IList<AddressObject> ListByPage(int page, int pageSize)
        {
            return _context.AddressObjects.ToList();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string[] ids)
        {
            throw new NotImplementedException();
        }

        public void Edit(AddressObject addressObject)
        {
            throw new NotImplementedException();
        }

        public void Create(AddressObject addressObject)
        {
            throw new NotImplementedException();
        }
    }
}
