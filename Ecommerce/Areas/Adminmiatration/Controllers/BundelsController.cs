using IRepositories;

using Microsoft.AspNetCore.Mvc;

using RepositoryServices;

using System.Linq;

using Vmodels;

namespace Ecommerce.Areas.Adminmiatration.Controllers
{
    [Area("Adminmiatration")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class BundelsController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly lookupServess _Ilookup;
        public BundelsController(UnitOfWork unitOfWork , lookupServess ilookup)
        {
            _unitOfWork = unitOfWork;
            _Ilookup = ilookup;  
        }

        // GET: Categries
        [HttpGet]
        public ActionResult Index(string Filterby, int? page)
        {
            var categorySm = new BundelsViewModel();
            categorySm.Filterby = Filterby; 
             categorySm.PagNumber = page;

            var pagedPatients = _unitOfWork.Bundels.Search(categorySm);
            return View(pagedPatients);


        }



        public IActionResult Save(Guid id, Guid ProductId)
        {
            try
            {
                if (id != Guid.Empty && id != null) // Change || to &&
                {
                    // Retrieve the model with the given id
                    var model = _unitOfWork.Bundels.GetById(id);

                    model.ProductId = ProductId;
                    model.ProductName = _unitOfWork.Bundels?.GetProductdataById(ProductId)?.Select(i => i.CatagoryName)?.FirstOrDefault();
                    model.MultiCatagoryNameforOneproduct = _unitOfWork.Bundels.GetProductdataById(ProductId).Select(i => i.CatagoryName).ToList();
                    model.catagory = _Ilookup.AllParentcatagory();
                    model.Pakgesids = _Ilookup.AllPakages();

                    // Return the model to the view for editing
                    return View(model);
                }
                else
                {
                    var Addnew = new BundelsViewModel();
                    Addnew.catagory = _Ilookup.AllParentcatagory();
                    Addnew.ProductId = ProductId;
                    Addnew.ProductName = _unitOfWork.Bundels?.GetProductdataById(ProductId)?.Select(i => i.CatagoryName)?.FirstOrDefault();
                    Addnew.MultiCatagoryNameforOneproduct = _unitOfWork.Bundels.GetProductdataById(ProductId).Select(i => i.CatagoryName).ToList();
                    Addnew.Pakgesids = _Ilookup.AllPakages();

                    return View(Addnew);
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
        public IActionResult Save(BundelsViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    model.catagory = _Ilookup.AllParentcatagory();
            //    return View(model);
            //}

            //model.CatagoryImgURL= CatagoryImgURL;   
            if ( model.Id == Guid.Empty || model.Id == null)
            {

                _unitOfWork.Bundels.Add(model);
                TempData["Message"] = $"Successfully added:  !";
                TempData["MessageType"] = "Add";
            }
            else
            {
                _unitOfWork.Bundels.Update(model);
                TempData["Message"] = $"Successfully updated!";
                TempData["MessageType"] = "updated";
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete( Guid id)
        {
            _unitOfWork.Bundels.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
