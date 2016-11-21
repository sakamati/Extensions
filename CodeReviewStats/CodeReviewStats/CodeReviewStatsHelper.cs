using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Discussion.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodeReviewStats
{
    public class CodeReviewStatsHelper
    {
        public static IList<CodeReviewComment> RetrieveComments(IDiscussionManager discussionManager, int codeReviewRequestId, string reviewedBy)
        {
            List<CodeReviewComment> comments = new List<CodeReviewComment>();
            var result = discussionManager.BeginQueryByCodeReviewRequest(codeReviewRequestId, QueryStoreOptions.ServerAndLocal, null, null);
            var output = discussionManager.EndQueryByCodeReviewRequest(result);

            foreach (DiscussionThread thread in output)
            {
                if (thread.RootComment != null
                && thread.RootComment.PublishedDate > DateTime.MinValue
                && reviewedBy.Contains(thread.RootComment.Author.DisplayName)
                )
                {
                    CodeReviewComment comment = new CodeReviewComment();
                    comment.Author = thread.RootComment.Author.DisplayName;
                    comment.CommentType = thread.RootComment.CommentType.ToString();
                    comment.Comment = thread.RootComment.Content;
                    comment.PublishDate = thread.RootComment.PublishedDate.ToShortDateString();
                    comment.ItemName = thread.ItemPath;
                    comments.Add(comment);
                }
            }

            return comments;
        }
        
        public static IEnumerable<CodeReviewResponse> RetrieveCodeReviewResponsesByFilter(CodeReviewResponseFilter filter)
        {
            var server = new TfsTeamProjectCollection(new Uri(formCodeReviewStats.TeamProjectCollectionUrl), CredentialCache.DefaultNetworkCredentials);
            var _workItemStore = server.GetService<WorkItemStore>();

            TeamFoundationDiscussionService service = new TeamFoundationDiscussionService();
            service.Initialize(server);
            var discussionManager = service.CreateDiscussionManager();

            var query = "SELECT * FROM workitems "
                     + "WHERE [System.WorkItemType] = 'Code Review Response' "
                     + "AND [Microsoft.VSTS.CodeReview.ClosedStatusCode] In (1, 2, 3) "
                     + "AND [Microsoft.VSTS.Common.ClosedDate] >= '{0}' "
                     + "AND [Microsoft.VSTS.Common.ClosedDate] <= '{1}' ";

            query = string.Format(query, filter.StartDate.ToString("MM/dd/yyyy"), filter.EndDate.ToString("MM/dd/yyyy"));

            if(!string.IsNullOrWhiteSpace(filter.Reviewer))
            {
                query += "AND [Microsoft.VSTS.Common.ReviewedBy] Contains '{0}' ";
                query = string.Format(query, filter.Reviewer);
            }

            var codeReviews = _workItemStore.Query(query).OfType<WorkItem>()                
                .Select(r => new CodeReviewResponse
                {
                    Id = r.Id,
                    CreatedBy = r.CreatedBy,
                    ReviewedBy = r.Fields.OfType<Field>().First(x => x.ReferenceName == "Microsoft.VSTS.Common.ReviewedBy").Value.ToString(),
                    Title = r.Title,
                    CreatedDate = r.Fields.OfType<Field>().First(x => x.ReferenceName == "System.CreatedDate").Value.ToString(),
                    ClosedDate = r.Fields.OfType<Field>().First(x => x.ReferenceName == "Microsoft.VSTS.Common.ClosedDate").Value.ToString(),
                    ClosedStatus = r.Fields.OfType<Field>().First(x => x.ReferenceName == "Microsoft.VSTS.CodeReview.ClosedStatus").Value.ToString(),
                    CodeReviewRequestId = r.WorkItemLinks.OfType<WorkItemLink>().First().TargetId,
                    CodeReviewComments = RetrieveComments(discussionManager, r.WorkItemLinks.OfType<WorkItemLink>().First().TargetId, r.Fields.OfType<Field>().First(x => x.ReferenceName == "Microsoft.VSTS.Common.ReviewedBy").Value.ToString())
                });

            return codeReviews;
        }
    }
}
