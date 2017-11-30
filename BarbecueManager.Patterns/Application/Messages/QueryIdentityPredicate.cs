namespace BarbecueManager.Patterns.Application.Messages
{
    public class QueryIdentityPredicate
    {
        QueryPredicateMode Mode { get; set; }
        public string Identity { get; set; }
    }
}
