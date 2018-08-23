namespace SoftUniStore.Views.Home
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class Home : IRenderable<IEnumerable<GameVM>>
    {
        public string Render()
        {
            var html = new StringBuilder();
            html.Append(File.ReadAllText(Constants.HeaderHtmlPath));
                html.Append(File.ReadAllText(Constants.NavLoggedHtmlPath));
            
            var body=new StringBuilder(File.ReadAllText(Constants.HomeHtmlPath));

            var gamesHtml=new StringBuilder();
            gamesHtml.AppendLine("                <div class=\"card-group\">");
            var count = 0;
            foreach (var gameVm in this.Model)
            {
                if (count == 3)
                {
                    count = 0;
                    gamesHtml.AppendLine("                </div>");
                    gamesHtml.AppendLine("                <div class=\"card-group\">");

                }
                gamesHtml.Append(gameVm);
                count++;
            }

            gamesHtml.AppendLine("                </div>");

            html.AppendLine(string.Format(body.ToString(), gamesHtml.ToString()));

            html.Append(File.ReadAllText(Constants.FooterHtmlPath));

            return html.ToString();

        }

        public IEnumerable<GameVM> Model { get; set; }
    }
}