namespace BarbecueManager.Patterns.Application.Messages
{
    public class DeleteRequest<TIdentity>
       : AbstractRequest
    {
        public TIdentity Identity { get; set; }
    }
}