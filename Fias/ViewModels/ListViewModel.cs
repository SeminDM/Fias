using System.Collections.Generic;

namespace Fias.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<AddressObjectViewModel> AddressObjects { get; set; }
        public PagingViewModel PagingInfo { get; set; }
    }
}
