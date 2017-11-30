using BarbecueManager.Domain.BarbecueFeature.Predicates;
using BarbecueManager.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Domain.BarbecueFeature.Interfaces
{
    public interface IBarbecueRepository : IRepository<Barbecue, BarbecueIdentityPredicate, BarbecueQueryPredicate>
    {
    }
}
