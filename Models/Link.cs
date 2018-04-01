using System.ComponentModel.DataAnnotations;
namespace webdev.Models
{
    public class Link
    {
        public int Id { get;set; }
        [Url]
        [Required(ErrorMessage="Please provide URL address")]
        public string FullLink { get; set; }
        public string ShortLink { get; set; }
    }
}