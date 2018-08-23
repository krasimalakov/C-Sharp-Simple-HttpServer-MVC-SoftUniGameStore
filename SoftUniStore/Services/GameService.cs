namespace SoftUniStore.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using BindingModels;
    using Models;
    using ViewModels;

    public class GameService : Service
    {
        public DetailsGameVM GetDetailsGameVMById(int gameId)
        {
            var game = this.Context.Games.Find(gameId);
            if (game == null)
            {
                return null;
            }

            var detailsGameVM = new DetailsGameVM
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Price = game.Price,
                Size = game.Size,
                ImageThumbnail = game.ImageThumbnail,
                Trailer = game.Trailer,
                ReleaseDate = game.ReleaseDate
            };

            return detailsGameVM;
        }

        public Game GetGameById(int gameId)
        {
            return this.Context.Games.Find(gameId);
        }


        public void BuyGame(Game game, User currentUser)
        {
            if (currentUser.Games.Contains(game))
            {
                return;
            }

            currentUser.Games.Add(game);
            this.Context.SaveChanges();
        }

        public IEnumerable<AdminGameVM> GetAdminAllGameVMs()
        {
            IQueryable<AdminGameVM> games = this.Context.Games.All().Select(
                g => new AdminGameVM
                {
                    Id = g.Id,
                    Title = g.Title,
                    Price = g.Price,
                    Size = g.Size
                });

            return games;
        }

        public bool IsValidGameAddBM(AddGameBM model)
        {
            if (string.IsNullOrEmpty(model.Title) ||
                string.IsNullOrEmpty(model.Description) ||
                string.IsNullOrEmpty(model.ImageThumbnail) ||
                string.IsNullOrEmpty(model.Trailer) ||
                model.Price <= 0 ||
                model.Size <= 0)
            {
                return false;
            }

            if (model.Title.Length > 100 ||
                model.Title.Length < 3 ||
                !model.Title[0].ToString().Equals(model.Title[0].ToString().ToUpper()))
            {
                return false;
            }

            if (model.Trailer.Length!=11)
            {
                return false;
            }

            if (!Regex.IsMatch(model.ImageThumbnail, @"^(https:\/\/)|(http:\/\/).+$"))
            {
                return false;
            }

            if (model.Description.Length < 20)
            {
                return false;
            }

            return true;
        }


        public void AddGameFromBM(AddGameBM model)
        {
            var game=new Game()
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                Size = model.Size,
                ImageThumbnail = model.ImageThumbnail,
                Trailer = model.Trailer,
                ReleaseDate = model.ReleaseDate
            };

            this.Context.Games.Add(game);
            this.Context.SaveChanges();
        }

        public DeleteGameVM GetDeleteGameVMById(int gameId)
        {
            var game = this.Context.Games.Find(gameId);
            if (game == null)
            {
                return null;
            }

            var deleteGameVM = new DeleteGameVM
            {
                Id = game.Id,
                Title = game.Title,
            };

            return deleteGameVM;
        }

        public EditGameVM GetEditGameVMById(int gameId)
        {
            var game = this.Context.Games.Find(gameId);
            if (game == null)
            {
                return null;
            }

            var editGameVM = new EditGameVM()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Price = game.Price,
                Size = game.Size,
                ImageThumbnail = game.ImageThumbnail,
                Trailer = game.Trailer,
                ReleaseDate = game.ReleaseDate
            };

            return editGameVM;
        }

        public void GetDeleteGame(Game game)
        {
            this.Context.Games.Remove(game);
            this.Context.SaveChanges();
        }

        public bool IsValidGameEditBM(EditGameBM model)
        {
            if (this.Context.Games.Find(model.Id) == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.Title) ||
                string.IsNullOrEmpty(model.Description) ||
                string.IsNullOrEmpty(model.ImageThumbnail) ||
                string.IsNullOrEmpty(model.Trailer) ||
                model.Price <= 0 ||
                model.Size <= 0)
            {
                return false;
            }

            if (model.Title.Length > 100 ||
                model.Title.Length < 3 ||
                !model.Title[0].ToString().Equals(model.Title[0].ToString().ToUpper()))
            {
                return false;
            }

            if (model.Trailer.Length != 11)
            {
                return false;
            }

            if (!Regex.IsMatch(model.ImageThumbnail, @"^(https:\/\/)|(http:\/\/).+$"))
            {
                return false;
            }

            if (model.Description.Length < 20)
            {
                return false;
            }

            return true;
        }

        public void UpdateGameFromBM(EditGameBM model)
        {
            var game = this.Context.Games.Find(model.Id);
            if (game==null) { return;}

            game.Title = model.Title;
            game.Description = model.Description;
            game.Price = model.Price;
            game.Size = model.Size;
            game.ImageThumbnail = model.ImageThumbnail;
            game.Trailer = model.Trailer;
            game.ReleaseDate = model.ReleaseDate;

            this.Context.SaveChanges();
        }
    }
}