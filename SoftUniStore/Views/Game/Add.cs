namespace SoftUniStore.Views.Game
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;

    public class Add : IRenderable
    {
        public string Render()
        {
            var html = new StringBuilder();
            html.Append(File.ReadAllText(Constants.HeaderHtmlPath));
            html.Append(File.ReadAllText(Constants.NavLoggedHtmlPath));
            html.Append(File.ReadAllText(Constants.AddGameHtmlPath));
            html.Append(File.ReadAllText(Constants.FooterHtmlPath));

            return html.ToString();
        }
    }
}