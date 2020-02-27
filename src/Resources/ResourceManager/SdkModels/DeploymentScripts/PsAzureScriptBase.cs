using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PsAzureScriptBase : PsAzureResourceBase
    {
        public string CleanupPreference { get; set; }

        public string ProvisioningState { get; set; }

        public ScriptStatus Status { get; set; }

        public IDictionary<string, object> Outputs { get; set; }

        public string PrimaryScriptUri { get; set; }

        public IList<string> SupportingScriptUris { get; set; }

        public string ScriptContent { get; set; }

        public string Arguments { get; set; }

        public IList<EnvironmentVariable> EnvironmentVariables { get; set; }

        public string ForceUpdateTag { get; set; }

        public TimeSpan RetentionInterval { get; set; }

        public TimeSpan? Timeout { get; set; }


    }
}
