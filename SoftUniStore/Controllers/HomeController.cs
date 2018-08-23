namespace SoftUniStore.Controllers
{
    using System.Collections.Generic;
    using BindingModels;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class HomeController : Controller
    {
        private readonly HomeService service = new HomeService();

        [HttpGet]
        public IActionResult Index(HttpResponse response, HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/all");
                return null;
            }

            this.Redirect(response, "/home/login");
            return null;
        }

        [HttpGet]
        public IActionResult Register(HttpResponse response, HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/all");
                return null;
            }
            
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, HttpSession session, RegisterUserBM model)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/all");
                return null;
            }

            if (!this.service.IsValidRegiterUserBM(model))
            {
                this.Redirect(response, "/home/register");
                return null;
            }

            this.service.AddUser(model);

            this.Redirect(response, "/home/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/all");
                return null;
            }


            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBM model)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/all");
                return null;
            }

            var user = this.service.GetUserIfValidLoginUserBM(model);
            if (user==null)
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            AuthenticationManager.Login(user, session.Id);

            this.Redirect(response, "/home/login");
            return null;
        }

        [HttpPost]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            AuthenticationManager.Logout(response, session.Id);

            this.Redirect(response, "/home/login");
            return null;
        }

        [HttpGet]
        public IActionResult<IEnumerable<GameVM>> All(HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            var allGamesVM = this.service.GetAllGamesVM();

            return this.View(allGamesVM);
        }

        [HttpGet]
        public IActionResult<IEnumerable<GameVM>> Owned(HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            var ownerGamesVM = this.service.GetCurrentUserGamesVM(session);

            return this.View(ownerGamesVM);
        }
    }
}