using BarbecueManager.Application.BarbecueFeature;
using BarbecueManager.Application.BarbecueFeature.Interfaces;
using BarbecueManager.Application.ParticipantFeature.Interfaces;
using ParticipantManager.Application.ParticipantFeature;
using SimpleInjector;
using System;

namespace BarbecueManager.Application
{
    public static class Startup
    {
        public static void Configure(Container container)
        {
            container.Register<IBarbecueApp, BarbecueApp>(Lifestyle.Scoped);
            container.Register<IParticipantApp, ParticipantApp>(Lifestyle.Scoped);
        }
    }
}
