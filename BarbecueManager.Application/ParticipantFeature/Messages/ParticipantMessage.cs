using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Application.ParticipantFeature.Messages
{
    public class ParticipantMessage
    {
        public int? ParticipantID { get; set; }
        public int BarbecueID { get; set; }
        public string Name { get; set; }
        public decimal? ContributionAmount { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsWithDrink { get; set; }
        public string Observation { get; set; }
    }
}
