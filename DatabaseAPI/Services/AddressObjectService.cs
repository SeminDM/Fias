using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            // example of stored procedures use
            SqlParameter param1 = new SqlParameter("@addressObjectId", "EEC1C98F-8A29-410B-B6B7-8C96B63670ED");
            var employee = _context.AddressObjects.FromSql("spFindMainParentAddressObject @addressObjectId", param1);

            return _context.AddressObjects.AsNoTracking().ToList();
        }

        public IList<AddressObject> ListByPage(int page, int pageSize)
        {
            var aos = _context.AddressObjects
                .AsNoTracking()
                .OrderByDescending(ao => ao.UpdateDate)
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
            if (addressObject.Id.Equals(Guid.Empty))
                throw new Exception("Id is empty.");

            var ao = _context.AddressObjects.Find(addressObject.Id);
            if (ao == null)
            {
                throw new Exception("Can not fand address object with specified id.");
            }
            ao.Id = addressObject.Id;
            ao.ActualStatus = addressObject.ActualStatus;
            ao.Level = addressObject.Level;
            ao.FormalName = addressObject.FormalName;
            ao.ShortName = addressObject.ShortName;
            ao.PostalCode = addressObject.PostalCode;
            ao.RegionCode = addressObject.RegionCode;
            ao.UpdateDate = addressObject.UpdateDate;
            _context.SaveChanges();
        }

        public void Create(AddressObject addressObject)
        {
            addressObject.Id = Guid.NewGuid();
            _context.AddressObjects.Add(addressObject);
            _context.SaveChanges();
        }
    }
}
