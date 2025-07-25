using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SshKey", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSSshPublicKeyResource))]
    public partial class UpdateAzureSshKey : ComputeAutomationBaseCmdlet
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

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string PublicKey { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string sshKeyName;
                string publicKey = this.PublicKey;

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

                SshPublicKeyUpdateResource sshkeyUpdateResource = new SshPublicKeyUpdateResource();
                sshkeyUpdateResource.PublicKey = publicKey;
                var result = SshPublicKeyClient.Update(resourceGroupName, sshKeyName, sshkeyUpdateResource);
                var psObject = new PSSshPublicKeyResource();
                ComputeAutomationAutoMapperProfile.Mapper.Map<SshPublicKeyResource, PSSshPublicKeyResource>(result, psObject);
                WriteObject(psObject);

            });
        }
    }
}
