using BarbecueManager.Domain.ParticipantFeature;
using BarbecueManager.Domain.ParticipantFeature.Predicates;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParticipantManager.Infrastructure.ParticipantFeature.Factories
{
    public class ParticipantPredicateFactory
    {
        public Participant Create(ParticipantIdentityPredicate predicate)
        {
            Participant Participant = new Participant();

            if (predicate.IdentityMode == BarbecueManager.Patterns.Application.Messages.IdentityMode.Identity)
            {
                if (int.TryParse(predicate.ParticipantIdentity, out int n))
                    Participant.ParticipantID = n;
            }
            else
                Participant.Name = predicate.ParticipantIdentity;

            return Participant;
        }

        public FormattableString Create(ParticipantQueryPredicate predicate)
        {
            var queryFragments = new List<string>();

            if (!string.IsNullOrEmpty(predicate.Name))
                queryFragments.Add($"{nameof(predicate.Name):C}=@{nameof(predicate.Name):C}");

            if (queryFragments.Count == 0)
                return null;

            string query = string.Concat(string.Join(" AND ", queryFragments));

            return $"{query}";
        }
    }
}
