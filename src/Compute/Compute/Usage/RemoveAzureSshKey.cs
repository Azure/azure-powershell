using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SshKey", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSOperationStatusResponse))]
    public partial class RemoveAzureSshKey : ComputeAutomationBaseCmdlet
    {
        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";
        private const string ResourceIDParameterSet = "ResourceIDParameterSet";

        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/SshPublicKeys", "ResourceGroupName")]
        [SupportsWildcards]
        [Alias("sshkeyName")]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ParameterSetName = ResourceIDParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource ID for your SSH Public Key Resource.")]
        [ResourceIdCompleter("Microsoft.Compute/SshPublicKeys")]
        public string ResourceId { get; set; }

        [Alias("SshKey")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PowerShell Ssh Public Key Object")]
        [ValidateNotNullOrEmpty]
        public PSSshPublicKeyResource InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string sshKeyName;

                switch (this.ParameterSetName)
                {
                    case ResourceIDParameterSet:
                        resourceGroupName = GetResourceGroupName(this.ResourceId);
                        sshKeyName = GetResourceName(this.ResourceId, "Microsoft.Compute/SshPublicKeys");
                        break;
                    case InputObjectParameterSet:
                        resourceGroupName = GetResourceGroupName(this.InputObject.Id);
                        sshKeyName = GetResourceName(this.InputObject.Id, "Microsoft.Compute/SshPublicKeys");
                        break;
                    default:
                        resourceGroupName = this.ResourceGroupName;
                        sshKeyName = this.Name;
                        break;
                }

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
