using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;
using ProductCatalog.Repository;
using System.Security.Claims;

namespace ProductCatalog.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProductOpertionController : Controller
    {
        private readonly IProduct _product;
        private readonly ICrudOperation<Category> _category;

        public ProductOpertionController(IProduct _product,ICrudOperation<Category> _category)
        {
            this._product = _product;
            this._category = _category;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult getall()
        {
            try
            {
                List<Product> products = _product.GetAll(c => c.category);
                return View(products);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public IActionResult Create()
        {
            try
            {
                ViewData["categories"] = _category.GetAll();
                return View();
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                product.CreatedByUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (ModelState.IsValid)
                {
                    _product.insert(product);
                    _product.save();
                    return RedirectToAction("getall");
                }
                ViewData["categories"] = _category.GetAll();
                return View(product);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public IActionResult Edite(int id)
        {
            try
            {
                Product product = _product.GetById(id);
                ViewData["categories"] = _category.GetAll();
                return View(product);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult Edite(Product product)
        {
            try
            {
                product.CreatedByUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (product != null)
                {
                    _product.update(product);
                    _product.save();
                    return RedirectToAction("getall");
                }
                ViewData["categories"] = _category.GetAll();
                return View(product);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _product.Delete(id);
                _product.save();
                return RedirectToAction("getall");
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }
    }
}
