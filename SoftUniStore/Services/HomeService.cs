namespace SoftUniStore.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using BindingModels;
    using Models;
    using Security;
    using SimpleHttpServer.Models;
    using ViewModels;

    public class HomeService : Service
    {
        public IEnumerable<GameVM> GetAllGamesVM()
        {
            IQueryable<GameVM> gamesVM = this.Context.Games.All().Select(
                g => new GameVM
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    ImageThumbnail = g.ImageThumbnail,
                    Price = g.Price,
                    Size = g.Size
                });

            return gamesVM;
        }

        public IEnumerable<GameVM> GetCurrentUserGamesVM(HttpSession session)
        {
            var user = AuthenticationManager.GetCurrentUser(session);
            IEnumerable<GameVM> gamesVM = user.Games
                .Select(
                g => new GameVM
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    ImageThumbnail = g.ImageThumbnail,
                    Price = g.Price,
                    Size = g.Size
                });

            return gamesVM;
        }
        public bool IsValidRegiterUserBM(RegisterUserBM model)
        {
            if (string.IsNullOrEmpty(model.Email) ||
                string.IsNullOrEmpty(model.Password) ||
                string.IsNullOrEmpty(model.Fullname) ||
                !model.Password.Equals(model.ConfirmPassword))
            {
                return false;
            }

            if (!model.Email.Contains(".") || !model.Email.Contains("@"))
            {
                return false;
            }

            if (!Regex.IsMatch(model.Password, "[a-z]{1,}") ||
                !Regex.IsMatch(model.Password, "[A-Z]{1,}") ||
                !Regex.IsMatch(model.Password, "[0-9]{1,}") ||
                model.Password.Length < 6)
            {
                return false;
            }

            return !this.Context.Users.All().Any(u => u.Email.Equals(model.Email));
        }

        public void AddUser(RegisterUserBM model)
        {
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
                Fullname = model.Fullname,
                IsAdmin = !this.Context.Users.All().Any()
            };

            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        public User GetUserIfValidLoginUserBM(LoginUserBM model)
        {
            var user = this.Context.Users.All()
                .FirstOrDefault(
                    u=> u.Email.Equals(model.Email) && u.Password.Equals(model.Password)
                );
            return user;
        }
    }
}