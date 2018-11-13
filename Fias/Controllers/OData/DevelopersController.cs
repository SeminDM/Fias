using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseAPI;
using DatabaseAPI.Models;
using Microsoft.AspNet.OData;

namespace Fias.Controllers.OData
{
    public class DevelopersController : ODataController
    {
        private readonly FiasDatabaseContext _context;

        public DevelopersController(FiasDatabaseContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Developers.ToListAsync());
        }

        [EnableQuery]
        public async Task<IActionResult> Get(string key)
        {
            if (key == null)
            {
                return NotFound();
            }

            int id;
            if (!int.TryParse(key, out id))
            {
                return NotFound();
            }

            var developer = await _context.Developers
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (developer == null)
            {
                return NotFound();
            }

            return Ok(developer);
        }

        [EnableQuery]
        public async Task<IActionResult> Post([FromBody] Developer developer)
        {
            _context.Add(developer);
            await _context.SaveChangesAsync();
            return Created(developer);
        }
    }
}
