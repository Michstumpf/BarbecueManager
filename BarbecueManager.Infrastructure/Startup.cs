using BarbecueManager.Domain.BarbecueFeature.Interfaces;
using BarbecueManager.Domain.ParticipantFeature.Interfaces;
using BarbecueManager.Infrastructure.BarbecueFeature;
using BarbecueManager.Patterns.Infrastructure;
using BarbecueManager.Patterns.Infrastructure.Sql;
using ParticipantManager.Infrastructure.ParticipantFeature;
using SimpleInjector;
using System;

namespace BarbecueManager.Infrastructure
{
    public static class Startup
    {
        public static void Configure(Container container)
        {
            container.Register<IConnectionFactory>(() => new SqlEnvironmentConnectionFactory("BARBECUE_MANAGER_CONNECTION_STRING"), Lifestyle.Scoped);
            container.Register<IBarbecueRepository, BarbecueRepository>(Lifestyle.Scoped);
            container.Register<IParticipantRepository, ParticipantRepository>(Lifestyle.Scoped);
        }
    }
}
