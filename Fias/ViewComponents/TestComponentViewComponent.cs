using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Interfaces;
using DatabaseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fias.ViewComponents
{
    public class TestComponentViewComponent : ViewComponent
    {
        private readonly IAddressObjectService _addressObjectService;

        public TestComponentViewComponent(IAddressObjectService addressObjectService)
        {
            _addressObjectService = addressObjectService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int top = 5)
        {
            var aos = _addressObjectService.ListByPage(1, top);
            return View(aos);
        }
    }
}
