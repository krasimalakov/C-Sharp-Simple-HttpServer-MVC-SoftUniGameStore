namespace SoftUniStore.ViewModels
{
    public class EditGameVM : DetailsGameVM
    {
        public override string ToString()
        {

            var html = $"                 <form method=\"post\" id=\"new-game-form\">\r\n" +
                       $"                    <input type=\"hidden\" name=\"id\" value=\"{this.Id}\"/>\r\n" +
                       $"                    <div class=\"form-group row\">\r\n" +
                       $"                        <label for=\"name\" class=\"form-control-label\">Title</label>\r\n" +
                       $"                        <input type=\"text\" maxlength=\"100\" minlength=\"3\" id=\"name\" name=\"title\" value=\"{this.Title}\" class=\"form-control\" placeholder=\"Enter Game Name\" />\r\n" +
                       $"                    </div>\r\n\r\n" +
                       $"                    <div class=\"form-group row\">\r\n" +
                       $"                        <label for=\"desc\" class=\"form-control-label\">Description</label>\r\n" +
                       $"                        <textarea id=\"desc\" class=\"form-control\"  name=\"description\" placeholder=\"Description ...\" minlength=\"20\">{this.Description}</textarea>\r\n" +
                       $"                    </div>\r\n\r\n" +
                       $"                    <div class=\"form-group row\">\r\n" +
                       $"                        <label for=\"thumbnail\" class=\"form-control-label\">Thumbnail</label>\r\n" +
                       $"                        <input type=\"url\" id=\"thumbnail\" name=\"imageThumbnail\" value=\"{this.ImageThumbnail}\" required=\"required\" class=\"form-control\" placeholder=\"Enter URL to Image\" />\r\n" +
                       $"                    </div>\r\n\r\n" +
                       $"                    <div class=\"form-group row\">\r\n" +
                       $"                        <label for=\"price\" class=\"form-control-label\">Price</label>\r\n" +
                       $"                        <div class=\"input-group\">\r\n" +
                       $"                            <input type=\"number\" name=\"price\" value=\"{this.Price}\" step=\"0.01\" min=\"0.01\" id=\"price\" class=\"form-control\" placeholder=\"Enter Price\" />\r\n" +
                       $"                            <span class=\"input-group-addon\" id=\"addon2\">&euro;</span>\r\n" +
                       $"                        </div>\r\n" +
                       $"                    </div>\r\n\r\n" +
                       $"                    <div class=\"form-group row\">\r\n" +
                       $"                        <label for=\"size\" class=\"form-control-label\">Size</label>\r\n" +
                       $"                        <div class=\"input-group\">\r\n" +
                       $"                            <input type=\"number\" name=\"size\" value=\"{this.Size}\" step=\"0.01\" min=\"0.01\" id=\"size\" class=\"form-control\" placeholder=\"Enter Size\" />\r\n" +
                       $"                            <span class=\"input-group-addon\" id=\"addon3\">GB</span>\r\n" +
                       $"                        </div>\r\n" +
                       $"                    </div>\r\n\r\n" +
                       $"                    <div class=\"form-group row\">\r\n" +
                       $"                        <label for=\"video\" class=\"form-control-label\">YouTube Video URL</label>\r\n" +
                       $"                        <div class=\"input-group\">\r\n" +
                       $"                            <span class=\"input-group-addon\" id=\"addon\">https://www.youtube.com/watch?v=</span>\r\n" +
                       $"                            <input type=\"text\" name=\"trailer\" value=\"{this.Trailer}\" class=\"form-control\" id=\"video\" minlength=\"11\" maxlength=\"11\" />\r\n" +
                       $"                        </div>\r\n" +
                       $"                    </div>\r\n\r\n" +
                       $"                    <div class=\"form-group row\">\r\n" +
                       $"                        <label for=\"date\" class=\"form-control-label\">Release Date</label>\r\n" +
                       $"                        <input type=\"date\" name=\"releaseDate\" id=\"date\" value=\"{this.ReleaseDate}\" class=\"form-control\" placeholder=\"dd/MM/yyyy\" />\r\n" +
                       $"                    </div>\r\n\r\n" +
                       $"                    <input type=\"submit\" id=\"btn-edit-game\" class=\"btn btn-outline-warning btn-lg btn-block\" value=\"Edit Game\" />\r\n" +
                       $"                </form>";
            return html;
        }
    }
}