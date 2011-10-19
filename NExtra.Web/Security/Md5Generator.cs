using System.Web.Security;
using NExtra.Security.Abstractions;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class can be used to generate MD5 hash values.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class Md5Generator : ICanGenerateHashValue
    {
        /// <summary>
        /// Generate an MD5 hash value for an object.
        /// </summary>
        /// <param name="value">The object to create a hash value for.</param>
        /// <returns>The resulting hash value.</returns>
        public string GenerateHashValue(object value)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(value.ToString(), "md5");
        }
    }
}