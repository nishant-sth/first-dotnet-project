using Microsoft.AspNetCore.Mvc;
using first_dotnet_project.Models;

namespace first_dotnet_project.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> productList = new List<Product>();
        static int nextId = 1;

        [HttpGet("product")]
        public IActionResult Products()
        {
            return View(productList);
        }

        [HttpGet("product/add")]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost("product/add")]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = nextId++;
                productList.Add(product);
                return RedirectToAction("Products");
            }
            return View(product);
        }

        [HttpGet("product/edit/{id}")]
        public IActionResult EditProduct(int id)
        {
            var product = productList.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost("product/edit/{id}")]
        public IActionResult EditProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existingProduct = productList.FirstOrDefault(p => p.Id == id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                }
                return RedirectToAction("Products");
            }
            return View(product);
        }

        [HttpPost("product/delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = productList.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                productList.Remove(product);
            }
            return RedirectToAction("Products");
        }
    }
}