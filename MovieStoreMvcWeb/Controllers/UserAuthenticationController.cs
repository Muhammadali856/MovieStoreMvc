using Microsoft.AspNetCore.Mvc;
using MovieStoreMvcWeb.Models.DTO;
using MovieStoreMvcWeb.Repositories.Abstract;

namespace MovieStoreMvcWeb.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService _userAuthenticationService)
        {
                this.authService = _userAuthenticationService;
        }
        /* We will create a user with admin rights, after that we are going to comment
         * this method because we need only one user in this application.
         * If you need other users, you can implement this registration methos with view.
         */


        // We are not going to use this method in the applicatiin after creating a user.
        //public async Task<IActionResult> Register()
        //{
        //    var model = new RegistrationModel
        //    {
        //        Email = "admin@gmail.com",
        //        UserName = "admin",
        //        Name = "Ali",
        //        Password = "Admin@123",
        //        PasswordConfirm = "Admin@123",
        //        Role = "Admin"
        //    };
        //    // If you want to register with user, Change role = "User"

        //    var result = await authService.RegisterAsync(model);

        //    return Ok(result.Message);
        //}


        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = "Could not logged in..";
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
