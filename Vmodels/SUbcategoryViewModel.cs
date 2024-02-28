using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vmodels
{
    public class SubcategoryViewModel
        : BaseViewModel
    {

        public IEnumerable<SelectListItem> listGender { get; set; } = Enumerable.Empty<SelectListItem>();

        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }
        public IFormFile? ImgURL { get; set; }
     }
}