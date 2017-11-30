using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Domain.BarbecueFeature.Factories
{
    public class BarbecueFactory
    {
        public Barbecue Create(
            DateTime? date,
            string reason,
            string observation,
            decimal? amountWithDrink,
            decimal? amountWithoutDrink
            )
        {
            return new Barbecue()
            {
                Date = date ?? DateTime.Today.AddDays(7),
                Reason = reason,
                Observation = observation,
                AmountWithDrink = amountWithDrink ?? 0,
                AmountWithoutDrink = amountWithoutDrink ?? 0
            };
        }

        public Barbecue Update(Barbecue entity,
            int? BarbecueID,
            DateTime? date,
            string reason,
            string observation,
            decimal? amountWithDrink,
            decimal? amountWithoutDrink
            )
        {
            entity.Date = date ?? entity.Date;
            entity.Reason = reason ?? entity.Reason;
            entity.Observation = observation ?? entity.Observation;
            entity.AmountWithDrink = amountWithDrink ?? entity.AmountWithDrink;
            entity.AmountWithoutDrink = amountWithoutDrink ?? entity.AmountWithoutDrink;

            return entity;
        }
    }
}
