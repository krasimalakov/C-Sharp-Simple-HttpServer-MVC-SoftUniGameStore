namespace SoftUniStore.ViewModels
{
    public class GameVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageThumbnail { get; set; }

        public decimal Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            var description = this.Description.Length > 300
                ? this.Description.Substring(0, 300)+"..."
                : this.Description;

            var html = $"                  <div class=\"card col-4 thumbnail\">\r\n" +
                       $"                    <img class=\"card-image-top img-fluid img-thumbnail\" src=\"{this.ImageThumbnail}\">\r\n" +
                       $"                    <div class=\"card-block\">\r\n" +
                       $"                      <h4 class=\"card-title\">{this.Title}</h4>\r\n" +
                       $"                      <p class=\"card-text\"><strong>Price</strong> - {this.Price:f2}&euro;</p>\r\n" +
                       $"                      <p class=\"card-text\"><strong>Size</strong> - {this.Size:f2} GB</p>\r\n" +
                       $"                      <p class=\"card-text\">{description}</p>\r\n" +
                       $"                    </div>\r\n  <div class=\"card-footer\">\r\n" +
                       $"                      <a class=\"card-button btn btn-outline-primary\" name=\"info\" href=\"/game/details?id={this.Id}\">Info</a>\r\n" +
                       $"                    </div>\r\n" +
                       $"                  </div>";
            return html;
        }
    }
}