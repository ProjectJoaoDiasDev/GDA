using System.Text.RegularExpressions;

namespace GDA.Solution.Utils
{
    /// <summary>
    /// The base64 to string.
    /// </summary>
    public static class Base64ToString
    {
        /// <summary>
        /// Are the base64 string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>A bool.</returns>
        public static bool IsBase64String(this string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }
    }
}
