using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Domain.ParticipantFeature.Factories
{
    public class ParticipantFactory

    {
        public Participant Create(
                                int barbecueID,
                                string name,
                                decimal? contributionAmount,
                                bool? isPaid,
                                bool? isWithDrink,
                                string observation
            )
        {
            return new Participant()
            {
                BarbecueID = barbecueID,
                Name = name,
                ContributionAmount = contributionAmount ?? 0,
                IsPaid = isPaid ?? false,
                IsWithDrink = isWithDrink ?? false,
                Observation = observation,
            };
        }

        public Participant Update(Participant entity,
                                    string name,
                                    decimal? contributionAmount,
                                    bool? isPaid,
                                    bool? isWithDrink,
                                    string observation
            )
        {
            entity.BarbecueID = entity.BarbecueID;
            entity.Name = name ?? entity.Name;
            entity.ContributionAmount = contributionAmount ?? entity.ContributionAmount;
            entity.IsPaid = isPaid ?? entity.IsPaid;
            entity.IsWithDrink = isWithDrink ?? entity.IsWithDrink;
            entity.Observation = observation ?? entity.Observation;

            return entity;
        }
    }
}
