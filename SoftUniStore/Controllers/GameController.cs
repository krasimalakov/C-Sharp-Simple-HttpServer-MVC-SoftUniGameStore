namespace SoftUniStore.Controllers
{
    using System.CodeDom.Compiler;
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

    public class GameController : Controller
    {
        private readonly GameService service = new GameService();

        [HttpGet]
        public IActionResult<DetailsGameVM> Details(HttpResponse response, HttpSession session, int id)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            var detailsGameVM = this.service.GetDetailsGameVMById(id);
            if (detailsGameVM == null)
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            return this.View(detailsGameVM);
        }

        [HttpPost]
        public IActionResult Buy(HttpResponse response, HttpSession session, BuyGameBM model)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            var game = this.service.GetGameById(model.Id);
            if (game == null)
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            this.service.BuyGame(game, AuthenticationManager.GetCurrentUser(session));
            
            this.Redirect(response, "/home/owned");
            return null;
        }

        [HttpGet]
        public IActionResult<IEnumerable<AdminGameVM>> Admin(HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!AuthenticationManager.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }


            IEnumerable<AdminGameVM> games = this.service.GetAdminAllGameVMs();

            return this.View(games);
        }

        [HttpGet]
        public IActionResult Add(HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!AuthenticationManager.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }


            return this.View();
        }

        [HttpPost]
        public IActionResult Add(HttpResponse response, HttpSession session, AddGameBM model)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!AuthenticationManager.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            if (!this.service.IsValidGameAddBM(model))
            {
                this.Redirect(response, "/game/add");
                return null;
            }

            this.service.AddGameFromBM(model);

            this.Redirect(response, "/game/admin");
            return null;
        }

        [HttpGet]
        public IActionResult<DeleteGameVM> Delete(HttpResponse response, HttpSession session, int id)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!AuthenticationManager.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            var deleteGameVM = this.service.GetDeleteGameVMById(id);
            if (deleteGameVM == null)
            {
                this.Redirect(response, "/game/admin");
                return null;
            }

            return this.View(deleteGameVM);
        }

        [HttpPost]
        public IActionResult<DeleteGameVM> Delete(
            HttpResponse response, HttpSession session, DeleteGameBM model)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!AuthenticationManager.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            var game = this.service.GetGameById(model.Id);
            if (game != null)
            {
                this.service.GetDeleteGame(game);
            }

            this.Redirect(response, "/game/admin");
            return null;
        }

        [HttpGet]
        public IActionResult<EditGameVM> Edit(HttpResponse response, HttpSession session, int id)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!AuthenticationManager.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            var editGameVM = this.service.GetEditGameVMById(id);
            if (editGameVM == null)
            {
                this.Redirect(response, "/game/admin");
                return null;
            }

            return this.View(editGameVM);
        }

        [HttpPost]
        public IActionResult<DeleteGameVM> Edit(
            HttpResponse response, HttpSession session, EditGameBM model)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!AuthenticationManager.IsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            if (!this.service.IsValidGameEditBM(model))
            {
                this.Redirect(response, "/game/edit");
                return null;
            }

            this.service.UpdateGameFromBM(model);

            this.Redirect(response, "/game/admin");
            return null;
        }
    }
}