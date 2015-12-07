using System.Collections.Generic;
using System.Reflection;

namespace System.Management.Automation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateSetAttribute : ValidateEnumeratedArgumentsAttribute
    {
        public ValidateSetAttribute(params string[] validValues)
        {
            ValidValues = new List<string>();
            foreach (var str in validValues)
            {
                ValidValues.Add(str);
            }
        }

        public bool IgnoreCase { get; set; }
        public IList<string> ValidValues { get; private set; }

        protected override void ValidateElement(object element)
        {
            if (element != null)
            {
                string strVal = null;

                if (element.GetType().GetTypeInfo().IsEnum)
                {
                    strVal = element.ToString();
                }
                else if (element is string)
                {
                    strVal = element as string;
                }

                if (strVal != null)
                {
                    foreach (var valid in ValidValues)
                    {
                        if (strVal.Equals(valid, IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
                            return;
                    }
                }
            }

            throw new ValidationException("is not one of the valid values");
        }
    }
}
