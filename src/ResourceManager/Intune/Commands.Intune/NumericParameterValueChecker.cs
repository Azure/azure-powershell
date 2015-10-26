using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Intune
{
    public class NumericParameterValueChecker
    {
        public static void CheckIfNegativeAndThrowException(Dictionary<string, int> parameters)
        {
            foreach (KeyValuePair<string, int> pair in parameters)
            {
                if (pair.Value < 0)
                {
                    throw new PSArgumentOutOfRangeException(pair.Key, pair.Value, "Please specify value greater than or equal to 0");
                }
            }
        }
    }
}
