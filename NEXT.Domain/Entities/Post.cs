using NEXT.Domain.Commons;

namespace NEXT.Domain.Entities
{
    public class Post : Auditable
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

