using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.AEM
{
    internal static class AEMStringExtensions
    {
        public static Match Match(this string text, string pattern)
        {
            return Regex.Match(text, pattern);
        }

        public static Match Match(this char text, string pattern)
        {
            return Regex.Match(text.ToString(), pattern);
        }

        public static bool Matches(this char text, string pattern)
        {
            return Regex.Match(text.ToString(), pattern).Success;
        }
    }
}
