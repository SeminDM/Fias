using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseAPI.Interfaces;
using DatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.Services
{
    public class AddressObjectService : IAddressObjectService
    {
        private readonly FiasDatabaseContext _context;

        public AddressObjectService(FiasDatabaseContext fiasDatabaseContext)
        {
            _context = fiasDatabaseContext;
        }

        public AddressObject Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            if (!Guid.TryParse(id, out var aoid))
                throw new ArgumentException(id);

            var ao = _context.AddressObjects.Find(aoid);
            return ao;
        }

        public IList<AddressObject> List()
        {
            return _context.AddressObjects.AsNoTracking().ToList();
        }

        public IList<AddressObject> ListByPage(int page, int pageSize)
        {
            var aos = _context.AddressObjects
                .AsNoTracking()
                .OrderByDescending(ao => ao.UPDATEDATE)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            return aos;
        }

        public void Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(id);

            if (!Guid.TryParse(id, out var aoid))
                throw new ArgumentException(id);

            var ao = _context.AddressObjects.Find(aoid);
            if (ao != null)
            {
                _context.AddressObjects.Remove(ao);
                _context.SaveChanges();
            }
        }

        public void Delete(string[] ids)
        {
            foreach (var id in ids)
            {
                if (string.IsNullOrEmpty(id))
                    throw new ArgumentNullException(id);

                if (!Guid.TryParse(id, out var aoid))
                    throw new ArgumentException(id);

                var ao = _context.AddressObjects.Find(aoid);
                if (ao != null)
                {
                    _context.AddressObjects.Remove(ao);
                    _context.SaveChanges();
                }
            }
        }

        public void Edit(AddressObject addressObject)
        {
            if (addressObject.AOID.Equals(Guid.Empty))
                throw new Exception("Id is empty.");

            var ao = _context.AddressObjects.Find(addressObject.AOID);
            if (ao == null)
            {
                throw new Exception("Can not fand address object with specified id.");
            }
            ao.AOID = addressObject.AOID;
            ao.ACTSTATUS = addressObject.ACTSTATUS;
            ao.AOLEVEL = addressObject.AOLEVEL;
            ao.FORMALNAME = addressObject.FORMALNAME;
            ao.SHORTNAME = addressObject.SHORTNAME;
            ao.POSTALCODE = addressObject.POSTALCODE;
            ao.REGIONCODE = addressObject.REGIONCODE;
            ao.UPDATEDATE = addressObject.UPDATEDATE;
            _context.SaveChanges();
        }

        public void Create(AddressObject addressObject)
        {
            addressObject.AOID = Guid.NewGuid();
            _context.AddressObjects.Add(addressObject);
            _context.SaveChanges();
        }
    }
}
