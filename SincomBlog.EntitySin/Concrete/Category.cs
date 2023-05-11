using SincomBlog.Shared.Entities.Abstract;

namespace SincomBlog.EntityLayer.Concrete
{
    public class Category:EntityBase,IEntity
    {//4
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Article> Articles { get; set; }//ilişki kodu bıre cok,bir kategornın cok makelesı olabılır
    }
}
