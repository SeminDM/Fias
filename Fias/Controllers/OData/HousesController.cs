using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseAPI;
using DatabaseAPI.Models;
using Microsoft.AspNet.OData;

namespace Fias.Controllers.OData
{
    public class HousesController : ODataController
    {
        private readonly FiasDatabaseContext _context;

        public HousesController(FiasDatabaseContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Houses.ToListAsync());
        }

        [EnableQuery]
        public async Task<IActionResult> Get(string key)
        {
            if (key == null)
            {
                return NotFound();
            }

            Guid id;
            if (!Guid.TryParse(key, out id))
            {
                return NotFound();
            }

            var house = await _context.Houses
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            return Ok(house);
        }

        [EnableQuery]
        public async Task<IActionResult> Post([FromBody] House house)
        {
            _context.Add(house);
            await _context.SaveChangesAsync();
            return Created(house);
        }
    }
}
