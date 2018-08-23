namespace SoftUniStore.ViewModels
{
    public class AdminGameVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Size { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
           var html = $"                     <tr>\r\n" +
                      $"                        <td>{this.Title}</td>\r\n" +
                      $"                        <td>{this.Size:f2} GB</td>\r\n" +
                      $"                        <td>{this.Price:f2} &euro;</td>\r\n" +
                      $"                        <td>\r\n" +
                      $"                            <a href=\"/game/edit?id={this.Id}\" class=\"btn btn-warning btn-sm\">Edit</a>\r\n" +
                      $"                            <a href=\"/game/delete?id={this.Id}\" class=\"btn btn-danger btn-sm\">Delete</a>\r\n" +
                      $"                        </td>\r\n" +
                      $"                    </tr>";
            return html;
        }
    }
}