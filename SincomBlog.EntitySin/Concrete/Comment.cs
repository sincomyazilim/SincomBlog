using SincomBlog.Shared.Entities.Abstract;

namespace SincomBlog.EntityLayer.Concrete
{
    public class Comment:EntityBase,IEntity
    {//7
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
