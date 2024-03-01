using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vmodels
{
    public class ProductSm : BaseSm
    {
 
     

         public Guid CategoryId { get; set; }

        public String Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string CatagoryName { get; set; } = string.Empty;


        public string Author { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public double Price { get; set; }

        public string SKU { get; set; } = string.Empty;
        public DateTime Productiondate { get; set; }


        public IEnumerable<SelectListItem> catagory { get; set; } = Enumerable.Empty<SelectListItem>();

        public IFormCollection? ProductUrl { get; set; }
        public List<Guid> Selectedcatagory { get; set; } = default!;
        public  Guid  ProductImgsId { get; set; } = default!;
        public List<string> ProductImgs { get; set; } = default!;

    }
}