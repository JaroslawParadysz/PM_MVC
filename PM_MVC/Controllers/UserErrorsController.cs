using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PM_MVC.Models;
using PM_MVC.ViewModels;

namespace PM_MVC.Controllers
{
    public class UserErrorsController : Controller
    {
        private List<UserErrorViewModel> _userErrorViewModels;
        public UserErrorsController()
        {
            _userErrorViewModels = new List<UserErrorViewModel>()
            {
                new UserErrorViewModel()
                {
                    UserErrorId = Guid.NewGuid(),
                    CreatedTime = DateTime.Now.AddDays(-1),
                    Notes = "Test notes 1"
                },
                new UserErrorViewModel()
                {
                    UserErrorId = Guid.NewGuid(),
                    CreatedTime = DateTime.Now.AddDays(-2),
                    Notes = "Test notes 2"
                },
                new UserErrorViewModel()
                {
                    UserErrorId = Guid.NewGuid(),
                    CreatedTime = DateTime.Now.AddDays(-3),
                    Notes = "Test notes 3"
                }
            };
        }
        public IActionResult Index()
        {
            return View(_userErrorViewModels[0]);
        }
    }
}