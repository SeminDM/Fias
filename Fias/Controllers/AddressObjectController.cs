using System;
using System.IO;
using System.Linq;
using DatabaseAPI.Interfaces;
using Fias.Infrastructure.Mappers;
using Fias.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fias.Controllers
{
    public class AddressObjectController : Controller
    {
        private const int PAGE_SIZE = 10;

        private readonly IAddressObjectService _addressObjectService;
        private readonly AddressObjectMapper _addressObjectMapper;

        public AddressObjectController(IAddressObjectService addressObjectService, AddressObjectMapper addressObjectMapper)
        {
            _addressObjectService = addressObjectService;
            _addressObjectMapper = addressObjectMapper;
        }

        public ActionResult List(int page = 1)
        {
            var aos = _addressObjectService.ListByPage(page, PAGE_SIZE);

            var pageingInfo = new PagingViewModel
            {
                CurrentPage = page,
                TotalItems = _addressObjectService.List().Count,
                ItemsPerPage = PAGE_SIZE
            };

            var list = new ListViewModel 
            {
                AddressObjects = aos.Select(ao => _addressObjectMapper.Map(ao)),
                PagingInfo = pageingInfo
            };

            return View(list);
        }

        [HttpGet]
        public ActionResult Get(string id)
        {
            var addressObject = _addressObjectService.Get(id);
            return PartialView("_Modal", _addressObjectMapper.Map(addressObject));
        }

        [HttpPost]
        public ActionResult Post(AddressObjectViewModel addressObject)
        {
            if (!ModelState.IsValid)
                return PartialView("_Modal", addressObject);

            try
            {
                addressObject.UpdateDate = DateTime.Now;
                var dto = _addressObjectMapper.Map(addressObject);
                if (!addressObject.Id.HasValue)
                {
                    _addressObjectService.Create(dto);
                }
                else
                {
                    _addressObjectService.Edit(dto);
                }
                return Ok();
            }
            catch
            {
                return PartialView("_Modal", addressObject);
            }
        }

        [HttpPost]
        public void Delete([FromForm]string[] ids)
        {
            _addressObjectService.Delete(ids);
        }
    }
}
