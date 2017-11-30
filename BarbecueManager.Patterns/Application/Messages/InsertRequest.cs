namespace BarbecueManager.Patterns.Application.Messages
{
    public class InsertRequest<TMessage>
        : AbstractRequest
    {
        public TMessage Message { get; set; }
    }
}