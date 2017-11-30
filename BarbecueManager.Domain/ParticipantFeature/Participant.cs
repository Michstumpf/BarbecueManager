using BarbecueManager.Domain.BarbecueFeature;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BarbecueManager.Domain.ParticipantFeature
{
    [Table("participant")]
    public class Participant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParticipantID { get; set; }

        [ForeignKey("Barbecue")]
        public int BarbecueID { get; set; }
        public Barbecue Barbecue { get; set; }

        public string Name { get; set; }

        public decimal ContributionAmount { get; set; }

        public bool IsPaid { get; set; }

        public bool IsWithDrink { get; set; }

        public string Observation { get; set; }
    }

    public class ParticipantValidator : AbstractValidator<Participant>
    {
        public ParticipantValidator()
        {
            //ParticipantID
            this.RuleFor(x => x.ParticipantID);

            //BarbecueID
            this.RuleFor(x => x.BarbecueID);

            //Name
            this.RuleFor(x => x.Name)
                .Length(1, 200)
                .NotNull()
                .NotEmpty();

            //ContributionAmount
            this.RuleFor(x => x.ContributionAmount);

            //IsPaid
            this.RuleFor(x => x.IsPaid);

            //IsWithDrink
            this.RuleFor(x => x.IsWithDrink);

            //Observation
            this.RuleFor(x => x.Observation);
        }
    }
}
