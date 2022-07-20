using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATS.Domain.Validator
{
    public class EmailValidator : ValidationAttribute
    {
        public EmailValidator()
           : base("{0} não é um email correto!")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if( !Regex.IsMatch(value.ToString(),
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
             , new string[] { validationContext.MemberName });
                }
                else
                {
                    return null;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return null;
            }


        }
    }
}
