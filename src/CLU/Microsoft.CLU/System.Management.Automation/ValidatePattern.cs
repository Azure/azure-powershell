using System.Text.RegularExpressions;

namespace System.Management.Automation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidatePatternAttribute : ValidateEnumeratedArgumentsAttribute
    {
        public ValidatePatternAttribute(string regexPattern) { RegexPattern = regexPattern; }

        public RegexOptions Options { get; set; }
        public string RegexPattern { get; private set; }

        protected override void ValidateElement(object element)
        {
            if (element != null)
            {
                string strVal = null;

                if (element is string)
                {
                    strVal = element as string;
                }

                if (strVal != null)
                {
                    if (Regex.IsMatch(strVal, RegexPattern, Options))
                        return;
                }
            }

            throw new ValidationException("is not one of the valid values");
        }
    }
}
