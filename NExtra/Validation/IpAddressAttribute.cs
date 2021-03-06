using System.ComponentModel.DataAnnotations;

namespace NExtra.Validation
{
	/// <summary>
    /// This attribute can be used to verify if a string
    /// represents a valid IP address.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public class IpAddressAttribute : RegularExpressionAttribute, IValidator
	{
        public IpAddressAttribute()
            : base(Expression) { }

	    public const string Expression =
	        @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
	}
}
