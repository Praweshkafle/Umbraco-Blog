using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Simple.Blog.Models
{
    [BsonIgnoreExtraElements]
    public class ContactViewModel
    {
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
