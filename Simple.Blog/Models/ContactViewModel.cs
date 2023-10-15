using MongoDB.Bson;
using MongoRepository;
using System.ComponentModel.DataAnnotations;

namespace Simple.Blog.Models
{
    public class ContactViewModel
    {

        public ObjectId Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(2500, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
