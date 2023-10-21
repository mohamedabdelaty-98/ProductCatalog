using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;
using ProductCatalog.Repository;

namespace ProductCatalog.Controllers
{
    [Authorize]
    
    public class ProductUserController : Controller
    {
        private readonly IProduct _product;
        private readonly ICrudOperation<Category> _category;

        public ProductUserController(IProduct _product,
            ICrudOperation<Category> _category)
        {
            this._product = _product;
            this._category = _category;
        }
        public IActionResult Index()
        {
            try
            {
                List<Product> products = _product.getproductbydate(DateTime.Now);
                ViewData["categories"] = _category.GetAll();
                return View(products);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public IActionResult getall()
        {
            try
            {
                List<Product> products = _product.getproductbydate(DateTime.Now);
                ViewData["categories"] = _category.GetAll();
                return PartialView("_getallPartial", products);
            }
            catch (Exception ex) 
            {
                return View("Error");
            }
        }
        
        public IActionResult details(int id)
        {
            try
            {
                Product product = _product.getdetailsbyid(id);
                if(product != null)
                    return View(product);
                return Content("ProductNotFound");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public IActionResult getproductbycat(int id)
        {
            List<Product> products = _product.getproductbycategroy(id);
            if(products!= null)
                return PartialView("_getproductbycategoryPartial", products);
            return Content("ProductNotFound");
        }
    }
}
