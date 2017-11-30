namespace BarbecueManager.Patterns.Application.Messages
{
    public class UpdateResponse<TPayload>
        : AbstractResponse
    {
        public TPayload Payload { get; set; }
    }
}