using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Patterns.Application.Messages
{
    public abstract class AbstractIdentityPredicate
    {
        protected AbstractIdentityPredicate()
        {
        }

        [FromQuery]
        public IdentityMode IdentityMode { get; set; }
    }
}
