using BarbecueManager.Domain.ParticipantFeature;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarbecueManager.Domain.BarbecueFeature
{
    [Table("barbecue")]
    public class Barbecue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BarbecueID { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public string Observation { get; set; }
        public decimal AmountWithDrink { get; set; }
        public decimal AmountWithoutDrink { get; set; }
        public List<Participant> Participants { get; set; }
    }

    public class BarbecueValidator : AbstractValidator<Barbecue>
    {
        public BarbecueValidator()
        {
            //BarbecueID
            this.RuleFor(x => x.BarbecueID);

            //Date
            this.RuleFor(x => x.Date);

            //Reason
            this.RuleFor(x => x.Reason)
                .Length(1, 200)
                .NotNull()
                .NotEmpty();

            this.RuleFor(x => x.Observation);

            this.RuleFor(x => x.AmountWithDrink);

            this.RuleFor(x => x.AmountWithoutDrink);
        }
    }
}
