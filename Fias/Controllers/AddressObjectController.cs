using System.Linq;
using DatabaseAPI.Interfaces;
using DatabaseAPI.Services;
using Fias.Infrastructure.Mappers;
using Fias.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fias.Controllers
{
    public class AddressObjectController : Controller
    {
        private const int PAGE_SIZE = 50;

        private readonly IAddressObjectService _addressObjectService;
        private readonly AddressObjectMapper _addressObjectMapper;

        public AddressObjectController(IAddressObjectService addressObjectService)
        {
            _addressObjectService = addressObjectService;
            _addressObjectMapper = new AddressObjectMapper();
        }

        public ActionResult List(int page = 1)
        {
            var aos = _addressObjectService.ListByPage(page, PAGE_SIZE);

            var pageingInfo = new PagingViewModel
            {
                CurrentPage = page,
                TotalItems = aos.Count,// _addressObjectService.List().Count,
                ItemsPerPage = PAGE_SIZE
            };

            var list = new ListViewModel
            {
                AddressObjects = aos.Select(ao => _addressObjectMapper.Map(ao)),
                PagingInfo = pageingInfo
            };

            return View(list);
        }
    }
}
