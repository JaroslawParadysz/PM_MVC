using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PM_MVC.Filters.ActionFilters;
using PM_MVC.Filters.ExceptionFilters;
using PM_MVC.ViewModels;

namespace PM_MVC.Controllers
{
    [HeaderActionFilter]
    [TypeFilter(typeof(ProductCustomExceptionFilter))]
    public class ProductsController : Controller
    {
        IList<ProductViewModel> products = new List<ProductViewModel>
        {
            new ProductViewModel()
            {
                Name = "Name 1",
                Color = "red",
                Size = "XS"
            },
            new ProductViewModel()
            {
                Name = "Name 2",
                Color = "red",
                Size = "XS"
            },
            new ProductViewModel()
            {
                Name = "Name 3",
                Color = "red",
                Size = "XS"
            }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            ProductViewModel pvm = new ProductViewModel
            {
                Color = "red",
                Name = "My prodct",
                Size = "XS"
            };

            return View(pvm);
        }

        [HttpPost]
        public IActionResult Edit(int productId, ProductViewModel model)
        {
            return Redirect("/");
        }

        [HttpGet(Name = "ContentNegotiation")]
        public ObjectResult ContentNegotiation()
        {
            return new ObjectResult(products[0]);
        }

        [HttpGet(Name = "FailAction")]
        public ObjectResult FailAction()
        {
            throw new InvalidOperationException("My exception!");
        }
    }
}