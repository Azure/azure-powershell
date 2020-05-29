using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    public class PSResourceManagerErrorFormatter
    {
        public static string Format(PSResourceManagerError error)
        {
            if (error == null)
            {
                return string.Empty;
            }

            IList<string> messages = new List<string>
            {
                $"{error.Code} - {error.Message}"
            };

            if (error.Details != null)
            {
                foreach (var innerError in error.Details)
                {
                    messages.Add(Format(innerError));
                }
            }

            return string.Join(Environment.NewLine, messages);
        }
    }
}
