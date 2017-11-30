using BarbecueManager.Application.ParticipantFeature.Messages;
using BarbecueManager.Domain.ParticipantFeature;
using BarbecueManager.Domain.ParticipantFeature.Predicates;
using BarbecueManager.Patterns.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Application.ParticipantFeature.Interfaces
{
    public interface IParticipantApp : IApp<Participant, ParticipantIdentityPredicate, ParticipantMessage, ParticipantQueryPredicate>
    {
    }
}
