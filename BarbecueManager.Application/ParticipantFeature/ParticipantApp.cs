using BarbecueManager.Application.ParticipantFeature.Interfaces;
using BarbecueManager.Application.ParticipantFeature.Messages;
using BarbecueManager.Domain.ParticipantFeature;
using BarbecueManager.Domain.ParticipantFeature.Factories;
using BarbecueManager.Domain.ParticipantFeature.Interfaces;
using BarbecueManager.Domain.ParticipantFeature.Predicates;
using BarbecueManager.Patterns.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParticipantManager.Application.ParticipantFeature
{
    public class ParticipantApp : AbstractApp<Participant, ParticipantIdentityPredicate, ParticipantMessage, ParticipantQueryPredicate>, IParticipantApp
    {
        private readonly ParticipantFactory _ParticipantFactory;
        public ParticipantApp(IParticipantRepository repository, IValidator<Participant> validator)
            : base(repository, validator)
        {
            _ParticipantFactory = new ParticipantFactory();
        }
        public override Participant CreateFromMessage(ParticipantMessage message)
        {
            return _ParticipantFactory.Create(message.BarbecueID,
                                                message.Name,
                                                message.ContributionAmount,
                                                message.IsPaid,
                                                message.IsWithDrink,
                                                message.Observation);
        }

        public override Participant UpdateFromMessage(Participant entity, ParticipantMessage message)
        {
            return _ParticipantFactory.Update(entity,
                                                message.Name,
                                                message.ContributionAmount,
                                                message.IsPaid,
                                                message.IsWithDrink,
                                                message.Observation);
        }
    }
}
