using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vmodels
{
    public class SubCategorySm : BaseSm
    {
 
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

         public Guid CategoryId { get; set; }
        public IFormFile? ImgURL { get; set; }
        public IFormCollection? CollectionImgURL { get; set; }

    }
}