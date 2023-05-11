using SincomBlog.Shared.Entities.Abstract;

namespace SincomBlog.EntityLayer.Concrete
{
    public class Role:EntityBase,IEntity
    {//6
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
