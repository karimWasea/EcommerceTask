using DataAccessLayer;

using IRepositories;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Reflection;

namespace RepositoryServices
{
    public class lookupServess : Ilookup
    {
        private readonly ApplicationDbContext _applicationDBcontext;
        //private readonly UserManager<Applicaionuser> _user;


        public lookupServess(/*UserManager<Applicaionuser> userManager,*/ ApplicationDbContext applicationDBcontext)
        {
            _applicationDBcontext = applicationDBcontext;
            //_user = userManager;



        }
     


        //public List<SelectListItem> GEnder()
        //{
        //    var weekdays = Enum.GetValues(typeof(Gender))
        //                       .Cast<Gender>()
        //                       .Select(d => new SelectListItem
        //                       {
        //                           Value = ((int)d).ToString(),
        //                           Text = d.ToString()
        //                       })
        //                       .ToList();

        //    return weekdays;
        //}






        public IQueryable<SelectListItem> AllParentcatagory()
        {
            IQueryable<SelectListItem>? applicationuser = _applicationDBcontext.Categories.
                Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .OrderBy(c => c.Text).AsNoTracking();
            return applicationuser;
        }
     





    }
}