using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Application.BarbecueFeature.Messages
{
    public class BarbecueMessage
    {
        public int? BarbecueID { get; set; }
        public DateTime? Date { get; set; }
        public string Reason { get; set; }
        public string Observation { get; set; }
        public decimal? AmountWithDrink { get; set; }
        public decimal? AmountWithoutDrink { get; set; }
    }
}
