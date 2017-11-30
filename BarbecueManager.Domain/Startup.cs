using BarbecueManager.Domain.BarbecueFeature;
using BarbecueManager.Domain.ParticipantFeature;
using FluentValidation;
using SimpleInjector;
using System;

namespace BarbecueManager.Domain
{
    public static class Startup
    {
        public static void Configure(Container container)
        {
            container.Register<IValidator<Barbecue>, BarbecueValidator>(Lifestyle.Scoped);
            container.Register<IValidator<Participant>, ParticipantValidator>(Lifestyle.Scoped);
        }
    }
}
