using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BarbecueManager.Application.ParticipantFeature.Interfaces;
using BarbecueManager.Domain.ParticipantFeature.Predicates;
using BarbecueManager.Patterns.Application.Messages;
using BarbecueManager.Patterns.Net.HttpResponse;
using BarbecueManager.Domain.ParticipantFeature;
using BarbecueManager.Application.ParticipantFeature.Messages;

namespace ParticipantManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Participant/{BarbecueIdentity}/")]
    public class ParticipantController : Controller
    {
        private readonly IParticipantApp _app;

        public ParticipantController(IParticipantApp app)
        {
            _app = app;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get([FromQuery] ParticipantQueryPredicate predicate)
        {
            var request = new QueryPredicateRequest<ParticipantQueryPredicate>()
            {
                Predicate = predicate,
                User = new UserRequest()
                {
                    Principal = this.User,
                    IpAddress = this.HttpContext.Connection.RemoteIpAddress
                }
            };

            var response = _app.Query(request);

            var responseMessage = new ApplicationResult<Participant[]>(response);

            return responseMessage;
        }

        // GET api/values/5
        [HttpGet("{ParticipantIdentity}")]
        public ActionResult Get([FromRoute][FromQuery]ParticipantIdentityPredicate predicate)
        {
            var request = new QueryIdentityRequest<ParticipantIdentityPredicate>()
            {
                Predicate = predicate
            };

            var response = _app.Query(request);

            return new ApplicationResult<Participant>(response);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]ParticipantMessage message)
        {
            var request = new InsertRequest<ParticipantMessage>()
            {
                Message = message,
                User = new UserRequest()
                {
                    Principal = this.User,
                    IpAddress = this.HttpContext.Connection.RemoteIpAddress

                }
            };

            var response = _app.Insert(request);

            return new ApplicationResult<Participant>(response);
        }

        // PUT api/values/5
        [HttpPut("{ParticipantIdentity}")]
        public ActionResult Put([FromRoute][FromQuery]ParticipantIdentityPredicate predicate, [FromBody]ParticipantMessage message)
        {
            var request = new UpdateRequest<ParticipantIdentityPredicate, ParticipantMessage>()
            {
                Identity = predicate,
                Message = message
            };

            var response = _app.Update(request);
            return new ApplicationResult<Participant>(response);
        }

        // DELETE api/values/5
        [HttpDelete("{ParticipantIdentity}")]
        public ActionResult Delete([FromRoute][FromQuery]ParticipantIdentityPredicate predicate)
        {
            var request = new DeleteRequest<ParticipantIdentityPredicate>()
            {
                Identity = predicate,
            };

            var response = _app.Delete(request);
            return new ApplicationResult<Participant>(response);
        }
    }
}