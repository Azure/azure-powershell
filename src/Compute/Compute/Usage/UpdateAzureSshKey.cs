using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SshKey", SupportsShouldProcess = true)]
    [OutputType(typeof(PSSshPublicKeyResource))]
    public partial class UpdateAzureSshKey : ComputeAutomationBaseCmdlet
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
        
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string PublicKey { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName = this.ResourceGroupName;
                string sshKeyName = this.Name;
                string publicKey = this.PublicKey;

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
