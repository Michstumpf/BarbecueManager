using BarbecueManager.Application.BarbecueFeature.Messages;
using BarbecueManager.Domain.BarbecueFeature;
using BarbecueManager.Domain.BarbecueFeature.Predicates;
using BarbecueManager.Patterns.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Application.BarbecueFeature.Interfaces
{
    public interface IBarbecueApp : IApp<Barbecue, BarbecueIdentityPredicate, BarbecueMessage, BarbecueQueryPredicate>
    {
    }
}
