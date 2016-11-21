using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReviewStats
{
    public class CodeReviewResponse
    {
        private IList<CodeReviewComment> codeReviewComments = new List<CodeReviewComment>();
        
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string ReviewedBy { get; set; }
        public string Title { get; set; }
        public string CreatedDate { get; set; }
        public string ClosedDate { get; set; }
        public string ClosedStatus { get; set; }
        public int CodeReviewRequestId { get; set; }
        public int CodeReviewCommentCount { get; set; }
        public IList<CodeReviewComment> CodeReviewComments
        {
            get
            {
                return codeReviewComments;
            }
            set
            {
                codeReviewComments = value;
                CodeReviewCommentCount = value.Count;
            }
        }
    }
}
