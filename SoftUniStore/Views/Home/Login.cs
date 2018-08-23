namespace SoftUniStore.Views.Home
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;

    public class Login : IRenderable
    {
        public string Render()
        {
            var html = new StringBuilder();
            html.Append(File.ReadAllText(Constants.HeaderHtmlPath));
            html.Append(File.ReadAllText(Constants.NavNotLoggedHtmlPath));
            html.AppendLine(File.ReadAllText(Constants.LoginHtmlPath));
            html.Append(File.ReadAllText(Constants.FooterHtmlPath));

            return html.ToString();
        }
    }
}