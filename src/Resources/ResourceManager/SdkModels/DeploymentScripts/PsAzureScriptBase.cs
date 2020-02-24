using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PsAzureScriptBase : PsAzureResourceBase
    {
        public string CleanupPreference { get; set; }
        public string ProvisioningState { get; private set; }
        public Status 
        Outputs 
        PrimaryScriptUri 
        SupportingScriptUris
        ScriptContent 
        Arguments 
        EnvironmentVariables 
        ForceUpdateTag 
        RetentionInterval 
        Timeout 
        AzCliVersion 
    }
}
