namespace SoftUniStore.Views.Game
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class Admin : IRenderable<IEnumerable<AdminGameVM>>
    {
        public string Render()
        {
            var html = new StringBuilder();
            html.Append(File.ReadAllText(Constants.HeaderHtmlPath));
                html.Append(File.ReadAllText(Constants.NavLoggedHtmlPath));
            
            var body=File.ReadAllText(Constants.AdminGamesHtmlPath);
            var gameHtml = new StringBuilder();
            foreach (var adminGameVM in this.Model)
            {
                gameHtml.AppendLine(adminGameVM.ToString());
            }
           

            html.AppendLine(string.Format(body, gameHtml));

            html.Append(File.ReadAllText(Constants.FooterHtmlPath));

            return html.ToString();

        }

        public IEnumerable<AdminGameVM> Model { get; set; }
    }
}