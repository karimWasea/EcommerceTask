using IRepositories;

using Microsoft.AspNetCore.Mvc;

using RepositoryServices;

using System.Linq;

using Vmodels;

namespace Ecommerce.Areas.Adminmiatration.Controllers
{
    [Area("Adminmiatration")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly lookupServess _Ilookup;
        public ProductController(UnitOfWork unitOfWork, lookupServess ilookup)
        {
            _unitOfWork = unitOfWork;
            _Ilookup = ilookup;
        }

        // GET: Categries
        [HttpGet]
        public ActionResult Index(string Filterby, int? page)
        {
            var categorySm = new ProductSm();
            categorySm.Filterby = Filterby;
            categorySm.PagNumber = page;

            var pagedPatients = _unitOfWork.Product.Search(categorySm);
            return View(pagedPatients);


        }
        public ActionResult productDetails(Guid productid)
        {

            var pagedPatients = _unitOfWork.Product.productDetails(productid);
            return View(pagedPatients);


        }



        public IActionResult Save(Guid id)
        {

            try
            {
                if (id != Guid.Empty || id != null)
                {
                    // Retrieve the model with the given id
                    var model = _unitOfWork.Product.GetById(id);
                    if (model != null)
                    {
                        model.catagory = _Ilookup.AllParentcatagory();
                        // Return the model to the view for editing
                        return View(model);
                    }
                    else
                    {
                        var SubcategoryViewModel = new ProductViewModel();
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
        public IActionResult Save(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.catagory = _Ilookup.AllParentcatagory();
                return View(model);
            }

            //model.CatagoryImgURL= CatagoryImgURL;   
            if (model.Id == Guid.Empty || model.Id == null)
            {

                _unitOfWork.Product.Add(model);
                TempData["Message"] = $"Successfully added: {model.Title}!";
                TempData["MessageType"] = "Add";
            }
            else
            {
                _unitOfWork.Product.Update(model);
                TempData["Message"] = $"Successfully updated: {model.Title}!";
                TempData["MessageType"] = "updated";
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(Guid id)
        {
            _unitOfWork.Product.Delete(id);
            return RedirectToAction(nameof(Index));

        }




        #region API Call

        [HttpGet]
        public IActionResult GetLastProductInDatabase()
        {
            var ObjProduct = _unitOfWork.Product.GetLastProductInDatabase();
            return Json(new { data = ObjProduct });
        }
        #endregion
    }
}
