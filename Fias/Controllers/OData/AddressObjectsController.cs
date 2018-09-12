using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Interfaces;
using DatabaseAPI.Models;
using Fias.Infrastructure.Mappers;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Fias.Controllers.OData
{
    public class AddressObjectsController : ODataController
    {
        private readonly IAddressObjectService _addressObjectService;
        private readonly AddressObjectMapper _addressObjectMapper;

        public AddressObjectsController(IAddressObjectService addressObjectService, AddressObjectMapper addressObjectMapper)
        {
            _addressObjectService = addressObjectService;
            _addressObjectMapper = addressObjectMapper;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_addressObjectService.List());
        }

        [EnableQuery]
        public IActionResult Get(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                var ao = _addressObjectService.Get(key);
                if (ao != null)
                {
                    return Ok(ao);
                }
                else
                {
                    return NotFound();
                }
            }

            return NotFound();
        }

        [EnableQuery]
        public IActionResult Post([FromBody] AddressObject addressObject)
        {
            _addressObjectService.Create(addressObject);
            return Created(addressObject);
        }
    }
}