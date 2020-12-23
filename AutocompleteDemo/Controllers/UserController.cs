using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutocompleteDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutocompleteDemo.Controllers
{
    public class UserController : Controller
    {
        [Produces("application/json")]
        public IActionResult SearchUserName(string term = null)
        {
            List<UserViewModel> users = GetUsers();

            var result = users
                .Where(u => u.Name.ToLower().Contains(term.ToLower()))
                .Select(u => u.Name).ToList();
            return Json(result);
        }

        [Produces("application/json")]
        public IActionResult SearchUser(string term = null)
        {
            List<UserViewModel> users = GetUsers();

            var result = users
                .Where(u => u.Name.ToLower().Contains(term.ToLower()))
                .ToList();
            return Json(result);
        }

        private static List<UserViewModel> GetUsers()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            users.Add(new UserViewModel() { ID = 1, Name = "Lucas Nguyen", EmailAddress = "lucas@lucasology.com" });
            users.Add(new UserViewModel() { ID = 2, Name = "Eric Lu", EmailAddress = "eric@lucasology.com" });
            users.Add(new UserViewModel() { ID = 3, Name = "Rachel Horseman", EmailAddress = "rachel@lucasology.com" });
            return users;
        }
    }
}
