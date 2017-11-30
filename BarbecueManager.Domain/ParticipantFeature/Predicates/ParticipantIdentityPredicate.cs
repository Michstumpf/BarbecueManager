using BarbecueManager.Patterns.Application.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Domain.ParticipantFeature.Predicates
{
    public class ParticipantIdentityPredicate : AbstractIdentityPredicate
    {
        public string ParticipantIdentity { get; set; }
    }
}
