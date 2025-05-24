using FluentValidation;
using SignalR.DtoLayer.BookingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.BookingName)
                .NotEmpty().WithMessage("Booking name cannot be empty.")
                .Length(2, 50).WithMessage("Booking name must be between 2 and 50 characters long.");
            RuleFor(x => x.BookingPhone)
                .NotEmpty().WithMessage("Booking phone cannot be empty.");
            RuleFor(x => x.BookingMail).NotEmpty()
                .WithMessage("Booking email cannot be empty.")
                .EmailAddress().WithMessage("Booking email must be a valid email address.");
            RuleFor(x => x.BookingPersonCount).NotEmpty()
                .WithMessage("Booking person count cannot be empty.")
                .GreaterThan(0).WithMessage("Booking person count must be greater than 0.")
                .LessThan(8).WithMessage("Booking person count must be less than 8.");
        }
    }
}
