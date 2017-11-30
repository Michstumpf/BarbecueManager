using BarbecueManager.Domain.BarbecueFeature;
using BarbecueManager.Domain.BarbecueFeature.Predicates;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Infrastructure.BarbecueFeature.Factories
{
    public class BarbecuePredicateFactory
    {
        public Barbecue Create(BarbecueIdentityPredicate predicate)
        {
            Barbecue barbecue = new Barbecue();

            if (predicate.IdentityMode == Patterns.Application.Messages.IdentityMode.Identity)
            {
                if (int.TryParse(predicate.BarbecueIdentity, out int n))
                    barbecue.BarbecueID = n;
            }
            else
                barbecue.Reason = predicate.BarbecueIdentity;

            return barbecue;
        }

        public FormattableString Create(BarbecueQueryPredicate predicate)
        {
            var queryFragments = new List<string>();

            if (!string.IsNullOrEmpty(predicate.Reason))
                queryFragments.Add($"{nameof(predicate.Reason):C}=@{nameof(predicate.Reason):C}");

            if (queryFragments.Count == 0)
                return null;

            string query = string.Concat(string.Join(" AND ", queryFragments));

            return $"{query}";
        }
    }
}
