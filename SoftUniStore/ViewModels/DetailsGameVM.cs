namespace SoftUniStore.ViewModels
{
    using System;

    public class DetailsGameVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public string ImageThumbnail { get; set; }

        public decimal Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }


        public override string ToString()
        {

            var html = $"                <h1 class=\"display-3\">{this.Title}</h1>\r\n" +
                       $"                <br/>\r\n" +
                       $"                <iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/{this.Trailer}\" frameborder=\"0\" allowfullscreen></iframe>\r\n" +
                       $"                <br/>\r\n" +
                       $"                <br/>\r\n" +
                       $"                <p>{this.Description}</p>\r\n" +
                       $"                <p><strong>Price</strong> - {this.Price:f2}&euro;</p>\r\n" +
                       $"                <p><strong>Size</strong> - {this.Size:f2} GB</p>\r\n" +
                       $"                <p><strong>Release Date</strong> - {this.ReleaseDate}</p>\r\n" +
                       $"                <a class=\"btn btn-outline-primary\" name=\"back\" href=\"/home/all\">Back</a>\r\n" +
                       $"                <form action=\"/game/buy\" method=\"post\">\r\n" +
                       $"                    <input type=\"number\" name=\"Id\" value=\"{this.Id}\" hidden=\"hidden\" />\r\n" +
                       $"                    <br/>\r\n" +
                       $"                    <input type=\"submit\" class=\"btn btn-success\" value=\"Buy\" />\r\n" +
                       $"                </form>\r\n" +
                       $"                <br/>\r\n" +
                       $"                <br/>\r\n";
            return html;
        }
    }
}