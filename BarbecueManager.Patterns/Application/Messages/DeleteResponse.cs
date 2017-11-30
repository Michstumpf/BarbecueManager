namespace BarbecueManager.Patterns.Application.Messages
{
    public class DeleteResponse<TPayload>
        : AbstractResponse
    {
        public TPayload Payload { get; set; }
    }
}