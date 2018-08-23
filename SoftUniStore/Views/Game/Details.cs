namespace SoftUniStore.Views.Game
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class Details : IRenderable<DetailsGameVM>
    {
        public string Render()
        {
            var html = new StringBuilder();
            html.Append(File.ReadAllText(Constants.HeaderHtmlPath));
                html.Append(File.ReadAllText(Constants.NavLoggedHtmlPath));
            
            var body=File.ReadAllText(Constants.GameDetailsHtmlPath);

           

            html.AppendLine(string.Format(body, this.Model));

            html.Append(File.ReadAllText(Constants.FooterHtmlPath));

            return html.ToString();

        }

        public DetailsGameVM Model { get; set; }
    }
}