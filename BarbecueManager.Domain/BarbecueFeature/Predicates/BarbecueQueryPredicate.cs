using BarbecueManager.Patterns.Application.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Domain.BarbecueFeature.Predicates
{
    public class BarbecueQueryPredicate : AbstractQueryPredicate
    {
        public string Reason { get; set; }
    }
}
