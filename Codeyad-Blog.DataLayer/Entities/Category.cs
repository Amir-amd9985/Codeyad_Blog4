using System.ComponentModel.DataAnnotations;

namespace Codeyad_Blog4.DataLayer.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public int? ParentId { get; set; }


        public ICollection<Post> Posts { get; set; }
    }
}
