namespace BarbecueManager.Patterns.Application.Messages
{
    public class InsertResponse<TEntity>
        : AbstractResponse
    {
        public TEntity Payload { get; set; }
    }
}