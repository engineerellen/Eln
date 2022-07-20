using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATS.Domain.Validator
{
    public class DataValidator : ValidationAttribute
    {
        public DataValidator()
           : base("{0} não é uma data correta!")
        {
        }

        private static bool DataCompleta(string data)
        {
            Regex ok = new Regex(@"(\d{2}\/\d{2}\/\d{4} \d{2}:\d{2})");
            return ok.Match(data).Success;
        }
        private static bool DataPura(string data)
        {
            Regex ok = new Regex(@"(\d{2}\/\d{2}\/\d{4})");
            return ok.Match(data).Success;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if(!( DataCompleta(value.ToString()) || DataPura(value.ToString())))
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
