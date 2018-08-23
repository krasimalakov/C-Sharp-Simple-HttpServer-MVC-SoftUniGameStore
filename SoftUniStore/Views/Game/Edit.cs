namespace SoftUniStore.Views.Game
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class Edit : IRenderable<EditGameVM>
    {
        public string Render()
        {
            var html = new StringBuilder();
            html.Append(File.ReadAllText(Constants.HeaderHtmlPath));
            html.Append(File.ReadAllText(Constants.NavLoggedHtmlPath));
            var body = File.ReadAllText(Constants.EditGameHtmlPath);
            html.Append(string.Format(body, this.Model));
            html.Append(File.ReadAllText(Constants.FooterHtmlPath));

            return html.ToString();
        }

        public EditGameVM Model { get; set; }
    }
}