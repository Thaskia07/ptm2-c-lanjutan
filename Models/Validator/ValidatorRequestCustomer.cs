using FluentValidation;
using pertemuan_2.Models.DB;
using pertemuan_2.Models.DTO;
using System.Net;
using System.Text.RegularExpressions;
namespace pertemuan_2.Models.Validator
{
    public class ValidatorRequestCustomer : AbstractValidator<CustomerRequestDTO>
    {
        public ValidatorRequestCustomer()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(5).WithMessage("Name is not valid!");
            RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(9).MaximumLength(13).Must(ValidPhoneNumber);
            //RuleFor(x => x.Address).NotEmpty().Must(ValidAddress);
        }

        //public bool ValidAddress (string address)
        //{

        //    //regex untuk cek validasi date
        //    return true;
        //}

        public bool ValidPhoneNumber(string phoneNumber)
        {
            string regexNumberOnly = @"^\d+$";
            if (Regex.IsMatch(phoneNumber, regexNumberOnly))

                return true;

            else
                return false;

        }
    }
}
