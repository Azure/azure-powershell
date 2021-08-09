using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Cmdlets
{
    partial class GetAzAppConfigurationLabel_Get
    {
        partial void OnBeginProcessing()
        {
            //TODO: call management plane API to get connection string for encrypting request
            _extensibleParameters = new Dictionary<string, object>()
            {
                {"id", "uwAw-l0-s0:SvvSQHNEqAJ9ou67j6YW" },
                {"secret", Convert.FromBase64String("yU+QpLjsebf68spTqjo5+uLFeHn+QZ2On7KDBWf4f6I=") }
            };
        }
    }
}
