namespace BarbecueManager.Patterns.Application.Messages
{
    public class UpdateRequest<TIdentity, TMessage>
        : AbstractRequest
    {
        public TIdentity Identity { get; set; }
        public TMessage Message { get; set; }
    }
}