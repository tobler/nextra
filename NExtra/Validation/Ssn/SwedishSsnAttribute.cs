﻿using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation.Ssn
{
	/// <summary>
	/// This attribute can be used to validate whether or not a string
	/// represents a valid Swedish Social Security Number, on the form
	/// yymmdd-xxxx or yymmddxxxx.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// The SSN must conform to the Luhn algorithm. To validate a more
    /// complex scenario like correct sex or region, create a separate
    /// class and override the IsValid method.
	/// </remarks>
	public class SwedishSsnAttribute : RegularExpressionAttribute, IValidator
    {
        private const string dashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])[-+]\\d{4}\\b$";
        private const string noDashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])\\d{4}\\b$";
        private const string optionalDashExpression = "^\\b\\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\\d|3[01])[-+]?\\d{4}\\b$";

	    private readonly IValidator checksumValidator;


        public SwedishSsnAttribute(UseSeparator useDash)
            : this(useDash, new SwedishSsnChecksumValidator()) { }

        public SwedishSsnAttribute(UseSeparator useDash, IValidator checksumValidator)
            : base(Expression(useDash))
        {
            this.checksumValidator = checksumValidator;
        }


        public static string Expression(UseSeparator useDash)
        {
            switch (useDash)
            {
                case UseSeparator.No:
                    return noDashExpression;
                case UseSeparator.Yes:
                    return dashExpression;
                default:
                    return optionalDashExpression;
            }
        }

		public override bool IsValid(object value)
        {
            // Use the default RegularExpressionAttribute behavior
            if (value == null || value.ToString() == string.Empty)
                return true;

            return base.IsValid(value) && checksumValidator.IsValid(value);
		}
	}
}
