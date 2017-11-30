using BarbecueManager.Patterns.Application.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Domain.ParticipantFeature.Predicates
{
    public class ParticipantQueryPredicate : AbstractQueryPredicate
    {
        public string Name { get; set; }
    }
}
