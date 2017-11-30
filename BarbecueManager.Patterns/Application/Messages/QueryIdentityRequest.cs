namespace BarbecueManager.Patterns.Application.Messages
{
    public class QueryIdentityRequest<TPredicate>
        : AbstractRequest
         where TPredicate : class
    {
        public TPredicate Predicate { get; set; }
    }
}