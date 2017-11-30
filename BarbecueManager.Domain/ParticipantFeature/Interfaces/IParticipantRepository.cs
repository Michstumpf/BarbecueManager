using BarbecueManager.Domain.ParticipantFeature.Predicates;
using BarbecueManager.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Domain.ParticipantFeature.Interfaces
{
    public interface IParticipantRepository : IRepository<Participant, ParticipantIdentityPredicate, ParticipantQueryPredicate>
    {
    }
}
