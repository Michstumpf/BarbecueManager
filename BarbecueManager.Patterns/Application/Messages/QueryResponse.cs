namespace BarbecueManager.Patterns.Application.Messages
{
    public class QueryResponse<TPayload>
        : AbstractResponse
    {
        public TPayload Payload { get; set; }
    }
}