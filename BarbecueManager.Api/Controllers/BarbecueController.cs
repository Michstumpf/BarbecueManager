using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BarbecueManager.Application.BarbecueFeature.Interfaces;
using BarbecueManager.Domain.BarbecueFeature.Predicates;
using BarbecueManager.Patterns.Application.Messages;
using BarbecueManager.Domain.BarbecueFeature;
using BarbecueManager.Application.BarbecueFeature.Messages;
using BarbecueManager.Patterns.Net.HttpResponse;

namespace BarbecueManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Barbecue")]
    public class BarbecueController : Controller
    {
        private readonly IBarbecueApp _app;

        public BarbecueController(IBarbecueApp app)
        {
            _app = app;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get([FromQuery] BarbecueQueryPredicate predicate)
        {
            var request = new QueryPredicateRequest<BarbecueQueryPredicate>()
            {
                Predicate = predicate,
                User = new UserRequest()
                {
                    Principal = this.User,
                    IpAddress = this.HttpContext.Connection.RemoteIpAddress
                }
            };

            var response = _app.Query(request);

            var responseMessage = new ApplicationResult<Barbecue[]>(response);

            return responseMessage;
        }

        // GET api/values/5
        [HttpGet("{BarbecueIdentity}")]
        public ActionResult Get([FromRoute][FromQuery]BarbecueIdentityPredicate predicate)
        {
            var request = new QueryIdentityRequest<BarbecueIdentityPredicate>()
            {
                Predicate = predicate
            };

            var response = _app.Query(request);

            return new ApplicationResult<Barbecue>(response);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]BarbecueMessage message)
        {
            var request = new InsertRequest<BarbecueMessage>()
            {
                Message = message,
                User = new UserRequest()
                {
                    Principal = this.User,
                    IpAddress = this.HttpContext.Connection.RemoteIpAddress

                }
            };

            var response = _app.Insert(request);

            return new ApplicationResult<Barbecue>(response);
        }

        // PUT api/values/5
        [HttpPut("{BarbecueIdentity}")]
        public ActionResult Put([FromRoute][FromQuery]BarbecueIdentityPredicate predicate, [FromBody]BarbecueMessage message)
        {
            var request = new UpdateRequest<BarbecueIdentityPredicate, BarbecueMessage>()
            {
                Identity = predicate,
                Message = message
            };

            var response = _app.Update(request);
            return new ApplicationResult<Barbecue>(response);
        }

        // DELETE api/values/5
        [HttpDelete("{BarbecueIdentity}")]
        public ActionResult Delete([FromRoute][FromQuery]BarbecueIdentityPredicate predicate)
        {
            var request = new DeleteRequest<BarbecueIdentityPredicate>()
            {
                Identity = predicate,
            };

            var response = _app.Delete(request);
            return new ApplicationResult<Barbecue>(response);
        }
    }
}