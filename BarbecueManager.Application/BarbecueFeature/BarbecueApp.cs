using BarbecueManager.Application.BarbecueFeature.Interfaces;
using BarbecueManager.Application.BarbecueFeature.Messages;
using BarbecueManager.Domain.BarbecueFeature;
using BarbecueManager.Domain.BarbecueFeature.Factories;
using BarbecueManager.Domain.BarbecueFeature.Interfaces;
using BarbecueManager.Domain.BarbecueFeature.Predicates;
using BarbecueManager.Patterns.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Application.BarbecueFeature
{
    public class BarbecueApp : AbstractApp<Barbecue, BarbecueIdentityPredicate, BarbecueMessage, BarbecueQueryPredicate>, IBarbecueApp
    {
        private readonly BarbecueFactory _barbecueFactory;
        public BarbecueApp(IBarbecueRepository repository, IValidator<Barbecue> validator)
            : base(repository, validator)
        {
            _barbecueFactory = new BarbecueFactory();
        }
        public override Barbecue CreateFromMessage(BarbecueMessage message)
        {
            return _barbecueFactory.Create(message.Date,
                                                message.Reason,
                                                message.Observation,
                                                message.AmountWithDrink,
                                                message.AmountWithoutDrink);
        }

        public override Barbecue UpdateFromMessage(Barbecue entity, BarbecueMessage message)
        {
            return _barbecueFactory.Update(entity,
                                                message.BarbecueID,
                                                message.Date,
                                                message.Reason,
                                                message.Observation,
                                                message.AmountWithDrink,
                                                message.AmountWithoutDrink);
        }
    }
}
