using BarbecueManager.Patterns.Application.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Domain.BarbecueFeature.Predicates
{
    public class BarbecueIdentityPredicate : AbstractIdentityPredicate
    {
        public string BarbecueIdentity { get; set; }
    }
}
