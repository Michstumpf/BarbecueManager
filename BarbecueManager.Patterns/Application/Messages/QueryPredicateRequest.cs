namespace BarbecueManager.Patterns.Application.Messages
{
    public class QueryPredicateRequest<TPredicate>
        : AbstractRequest
        where TPredicate : class
    {
        public TPredicate Predicate { get; set; }
    }
}