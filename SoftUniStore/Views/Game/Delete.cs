namespace SoftUniStore.Views.Game
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class Delete : IRenderable<DeleteGameVM>
    {
        public string Render()
        {
            var html = new StringBuilder();
            html.Append(File.ReadAllText(Constants.HeaderHtmlPath));
            html.Append(File.ReadAllText(Constants.NavLoggedHtmlPath));
            var body = File.ReadAllText(Constants.DeleteGameHtmlPath);
            html.Append(string.Format(body, this.Model.Id, this.Model.Title));
            html.Append(File.ReadAllText(Constants.FooterHtmlPath));

            return html.ToString();
        }

        public DeleteGameVM Model { get; set; }
    }
}