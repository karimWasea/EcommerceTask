using Microsoft.AspNetCore.Mvc;

using RepositoryServices;
using Vmodels;

namespace Ecommerce.Areas.Adminmiatration.Controllers
{
    [Area("Adminmiatration")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CategriesController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public CategriesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Categries
        [HttpGet]
        public ActionResult Index(CategorySm categorySm ,int? page)
        {
             categorySm.PagNumber = page;

            var pagedPatients = _unitOfWork.Icategory.Search(categorySm);
            return View(pagedPatients);


        }



        public IActionResult Save(int id)
        {


            if (id > 0)
            {
                var model = _unitOfWork.Icategory.GetById(id);
                return View(model);
            }
            else
            {

                return View();
            }

        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Save(CategoryViewModel CategoryViewModele)
        {
            if (!ModelState.IsValid)

                return View(CategoryViewModele);


            if (CategoryViewModele.Id == Guid.Empty || CategoryViewModele.Id == null)
            {
                _unitOfWork.Icategory.Add(CategoryViewModele);
                TempData["Message"] = $"Successfully added: {CategoryViewModele.Name}!";
                TempData["MessageType"] = "Add";
            }
            else
            {
                _unitOfWork.Icategory.Update(CategoryViewModele);
                TempData["Message"] = $"Successfully updated: {CategoryViewModele.Name}!";
                TempData["MessageType"] = "updated";
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            _unitOfWork.Icategory.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
