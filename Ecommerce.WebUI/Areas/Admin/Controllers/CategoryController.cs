using Ecommerce.WebUI.DAL.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace BrandMatrix.PresentationLayer.Areas.Admin.Controllers
{

    [Area("Admin")]
    //[CustomAuthorization]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> logger;
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository categoryRepository)
        {
            this.logger = logger;
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> Manage()
        {
            try
            {

                var categories = await categoryRepository.GetAll();

                return View(categories);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message.ToString();
                return RedirectToAction(nameof(Manage));
            }
        }

        //[HttpGet]
        //[ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client)]
        //public async Task<IActionResult> CreateOrEdit(int? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            ViewData["Title"] = "Create Category";
        //            ViewData["button-color"] = "btn btn-primary";
        //            return View();
        //        }
        //        else
        //        {
        //            ViewData["Title"] = "Update Category";
        //            ViewData["button-color"] = "btn btn-success";

                    
        //            return View();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Error"] = ex.Message;
        //        return RedirectToAction("Manage");
        //    }
        //}

        //[HttpPost]
        //[ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client)]

        //public async Task<IActionResult> CreateOrEdit()
        //{
        //    try
        //    {
        //        bool res = false;
        //        if ()
        //        {
        //            res = await orgRepository.UpdateAsync("spUpdateCategory", parameters);
        //        }
        //        else
        //        {
        //            res = await orgRepository.CreateAsync("spCreateCategory", parameters);
        //        }
        //        if (res is false) TempData["Error"] = $"{model.CategoryName} - Category Didn't Saved!";
        //        else TempData["Success"] = $"{model.CategoryName} - Category Saved!";
        //        return RedirectToAction("Manage");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Error"] = ex.Message;
        //        return RedirectToAction("Manage");
        //    }
        //}


        //[HttpGet]
        //[ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client)]
        //public async Task<IActionResult> DeleteOrDetails(int? id, string page)
        //{
        //    try
        //    {
        //        var model = await orgRepository.GetByIdAsync("spFetchCategoryById", new List<SqlParameter>
        //        {
        //             new SqlParameter("@CategoryId", SqlDbType.Int)
        //             {
        //                   Direction = ParameterDirection.Input,
        //                   Value = id
        //             }
        //        });

        //        if (page.ToLower() is "delete")
        //        {
        //            ViewData["Title"] = "Delete Category";
        //            ViewData["button-color"] = "btn btn-danger";
        //        }
        //        else
        //        {
        //            ViewData["Title"] = "Details Category";
        //            ViewData["button-color"] = "btn btn-warning";
        //        }
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Error"] = ex.Message;
        //        return RedirectToAction("Manage");
        //    }
        //}

        //[HttpPost]
        //[ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client)]
        //public async Task<IActionResult> DeleteOrDetails(Categorys model)
        //{
        //    try
        //    {
        //        var res = await orgRepository.DeleteAsync("spDeleteCategory", new List<SqlParameter>
        //        {
        //             new SqlParameter("@CategoryId", SqlDbType.Int)
        //             {
        //                   Direction = ParameterDirection.Input,
        //                   Value = model.CategoryId
        //             }
        //        });
        //        if (res is false) TempData["Error"] = $"{model.CategoryName} - Category Didn't Deleted!";
        //        else TempData["Success"] = $"{model.CategoryName} - Category Deleted Permanently!";
        //        return RedirectToAction("Manage");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Error"] = ex.Message;
        //        return RedirectToAction("Manage");
        //    }
        //}
    }
}
