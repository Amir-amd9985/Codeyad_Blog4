using System.ComponentModel.DataAnnotations;

namespace Codeyad_Blog4.DataLayer.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRole Role { get; set; }


        public ICollection<Post> Posts { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
    }

    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}
