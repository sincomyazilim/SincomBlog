using SincomBlog.Shared.Entities.Abstract;

namespace SincomBlog.EntityLayer.Concrete
{
    public class User:EntityBase,IEntity
    {//6
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Username { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Article> Articles { get; set; }

    }
}
