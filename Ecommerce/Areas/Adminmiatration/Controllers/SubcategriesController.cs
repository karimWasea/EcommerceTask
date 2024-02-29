using IRepositories;

using Microsoft.AspNetCore.Mvc;

using RepositoryServices;

using System.Linq;

using Vmodels;

namespace Ecommerce.Areas.Adminmiatration.Controllers
{
    [Area("Adminmiatration")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class SubcategriesController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly lookupServess _Ilookup;
        public SubcategriesController(UnitOfWork unitOfWork , lookupServess ilookup)
        {
            _unitOfWork = unitOfWork;
            _Ilookup = ilookup;  
        }

        // GET: Categries
        [HttpGet]
        public ActionResult Index(SubCategorySm categorySm ,int? page)
        {
             categorySm.PagNumber = page;

            var pagedPatients = _unitOfWork.Isubcategory.Search(categorySm);
            return View(pagedPatients);


        }



        public IActionResult Save(Guid id)
        {
 
            try
            {
                if (id != Guid.Empty|| id!=null)
                {
                    // Retrieve the model with the given id
                    var model = _unitOfWork.Isubcategory.GetById(id);
                    if (model != null)
                    {
                        model.catagory = _Ilookup.AllParentcatagory();
                        // Return the model to the view for editing
                        return View(model);
                    }
                    else
                    {
                         var SubcategoryViewModel = new SubcategoryViewModel();
                        SubcategoryViewModel.catagory = _Ilookup.AllParentcatagory();


                        return View(SubcategoryViewModel);
                    }
                }
                else
                {
                    // Return an empty view for creating a new model
                    return View();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                // Log the exception
                // Return an error view or redirect to an error page
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        // POST: EmployeeController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Save(SubcategoryViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    model.catagory = _Ilookup.AllParentcatagory();
            //    return View(model);
            //}

            //model.CatagoryImgURL= CatagoryImgURL;   
            if ( model.Id == Guid.Empty || model.Id == null)
            {

                _unitOfWork.Isubcategory.Add(model);
                TempData["Message"] = $"Successfully added: {model.Name}!";
                TempData["MessageType"] = "Add";
            }
            else
            {
                _unitOfWork.Isubcategory.Update(model);
                TempData["Message"] = $"Successfully updated: {model.Name}!";
                TempData["MessageType"] = "updated";
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete( Guid id)
        {
            _unitOfWork.Isubcategory.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
