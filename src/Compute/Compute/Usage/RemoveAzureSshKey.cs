using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SshKey", SupportsShouldProcess = true)]
    [OutputType(typeof(PSOperationStatusResponse))]
    public partial class RemoveAzureSshKey : ComputeAutomationBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/SshPublicKeys", "ResourceGroupName")]
        [SupportsWildcards]
        [Alias("sshkeyName")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName = this.ResourceGroupName;
                string sshKeyName = this.Name;

                var result = SshPublicKeyClient.DeleteWithHttpMessagesAsync(resourceGroupName, sshKeyName).GetAwaiter().GetResult();
                PSOperationStatusResponse output = new PSOperationStatusResponse
                {
                    StartTime = this.StartTime,
                    EndTime = DateTime.Now
                };

                if (result != null && result.Request != null && result.Request.RequestUri != null)
                {
                    output.Name = result.Request.RequestUri.ToString();
                }

                WriteObject(output);
            });
        }
    }
}
