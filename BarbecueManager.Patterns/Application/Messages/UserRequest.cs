using System.Security.Claims;

namespace BarbecueManager.Patterns.Application.Messages
{
    public class UserRequest
    {
        public ClaimsPrincipal Principal { get; set; }
        public System.Net.IPAddress IpAddress { get; set; }
    }
}