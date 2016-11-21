using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReviewStats
{
    public class CodeReviewComment
    {
        public string Author { get; set; }
        public string Comment { get; set; }
        public string PublishDate { get; set; }
        public string ItemName { get; set; }
        public string CommentType { get; set; }
    }
}
