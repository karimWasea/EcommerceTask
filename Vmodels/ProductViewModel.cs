using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace Vmodels
{




















    public class ProductViewModel
         : BaseViewModel
    {


        public String Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        public string Author { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public double Price { get; set; }

        public string SKU { get; set; } = string.Empty;
        public DateTime Productiondate { get; set; }


        public IEnumerable<SelectListItem> catagory { get; set; } = Enumerable.Empty<SelectListItem>();

        public IFormCollection? ProductImgs { get; set; }
        public List<int> Selectedcatagory { get; set; } = default!;


    }













}