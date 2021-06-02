
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SshKey", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSSshPublicKeyResource))]
    public partial class GetAzureSshKey : ComputeAutomationBaseCmdlet
    {
        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string ResourceIDParameterSet = "ResourceIDParameterSet";

        [Parameter(
            Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
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
        [ResourceIdCompleter("Microsoft.Compute/sshPublicKeys")]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string sshKeyName;

                if (this.ParameterSetName == ResourceIDParameterSet)
                {
                    resourceGroupName = GetResourceGroupName(this.ResourceId);
                    sshKeyName = GetResourceName(this.ResourceId, "Microsoft.Compute/sshPublicKeys");
                }
                else
                {
                    resourceGroupName = this.ResourceGroupName;
                    sshKeyName = this.Name;
                }

                if (ShouldGetByName(resourceGroupName, sshKeyName))
                {
                    var result = SshPublicKeyClient.Get(resourceGroupName, sshKeyName);
                    var psObject = new PSSshPublicKeyResource();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<SshPublicKeyResource, PSSshPublicKeyResource>(result, psObject);
                    WriteObject(psObject);
                }
                else if (ShouldListByResourceGroup(resourceGroupName, sshKeyName))
                {
                    var result = SshPublicKeyClient.ListByResourceGroup(resourceGroupName);
                    var resultList = result.ToList();
                    var nextPageLink = result.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = SshPublicKeyClient.ListByResourceGroupNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }
                    var psObject = new List<PSSshPublicKeyResourceList>();
                    foreach (var r in resultList)
                    {
                        psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<SshPublicKeyResource, PSSshPublicKeyResourceList>(r));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, sshKeyName, psObject), true);
                }
                else
                {
                    var result = SshPublicKeyClient.ListBySubscription();
                    var resultList = result.ToList();
                    var nextPageLink = result.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = SshPublicKeyClient.ListBySubscriptionNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }
                    var psObject = new List<PSSshPublicKeyResourceList>();
                    foreach (var r in resultList)
                    {
                        psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<SshPublicKeyResource, PSSshPublicKeyResourceList>(r));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, sshKeyName, psObject), true);
                }
            });
        }
    }
}
