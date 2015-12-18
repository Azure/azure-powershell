using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
                
                if (element is string)
                {
                    strVal = element as string;
                }
                else if (element.GetType().GetTypeInfo().IsEnum ||
                         element.GetType().GetTypeInfo().IsValueType)
                {
                    var cultureIndependentStringify = element.GetType()
                                                           .GetTypeInfo()
                                                           .GetDeclaredMethods("ToString")
                                                           .Where(m =>
                                                           {
                                                               var parameters = m.GetParameters();
                                                               if (parameters != null &&
                                                                   parameters.Count() == 1 &&
                                                                   parameters.First().ParameterType == typeof(IFormatProvider))
                                                               {
                                                                   return true;
                                                               }
                                                               return false;
                                                           }).FirstOrDefault();

                    if (cultureIndependentStringify != null)
                    {
                        strVal = (string)cultureIndependentStringify.Invoke(element, new[] { CultureInfo.InvariantCulture });
                    }
                    else
                    {
                        strVal = element.ToString();
                    }
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

            throw new ValidationException(
                string.Format(
                    "Cannot validate element '{0}' within ValidValues '{1}'", 
                    element, 
                    string.Join(", ", ValidValues.ToArray())
                    ));
        }
    }
}
