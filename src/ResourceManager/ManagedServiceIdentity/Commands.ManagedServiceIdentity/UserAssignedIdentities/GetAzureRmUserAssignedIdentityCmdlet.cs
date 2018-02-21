using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ManagedServiceIdentity.Common;
using Microsoft.Azure.Commands.ManagedServiceIdentity.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ManagedServiceIdentity.UserAssignedIdentities
{
    [Cmdlet(VerbsCommon.Get, "AzureRmUserAssignedIdentity", DefaultParameterSetName = SubscriptionParameterSet)]
    [OutputType(typeof (PsUserAssignedIdentity))]
    public class GetAzureRmUserAssignedIdentityCmdlet : MsiBaseCmdlet
    {
        private const string SubscriptionParameterSet = "SubscriptionParameterSet";
        private const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        private const string IdentityParameterSet = "IdentityParameterSet";

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = ResourceGroupParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = IdentityParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Identity name.",
            ParameterSetName = IdentityParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if(ParameterSetName.Equals(SubscriptionParameterSet))
                {
                    var result =
                        this.MsiClient.UserAssignedIdentities
                            .ListBySubscriptionWithHttpMessagesAsync().GetAwaiter().GetResult();
                    var resultList = result.Body.ToList();
                    var nextPageLink = result.Body.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult =
                            this.MsiClient.UserAssignedIdentities
                                .ListBySubscriptionNextWithHttpMessagesAsync(nextPageLink).GetAwaiter().GetResult();
                        resultList.AddRange(pageResult.Body.ToList());
                        nextPageLink = pageResult.Body.NextPageLink;
                    }

                    WriteIdentityList(resultList);
                }
                else if (ParameterSetName.Equals(ResourceGroupParameterSet))
                {
                    var result =
                        this.MsiClient.UserAssignedIdentities
                            .ListByResourceGroupWithHttpMessagesAsync(this.ResourceGroupName).GetAwaiter().GetResult();
                    var resultList = result.Body.ToList();
                    var nextPageLink = result.Body.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = this.MsiClient.UserAssignedIdentities
                            .ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink).GetAwaiter().GetResult();
                        resultList.AddRange(pageResult.Body.ToList());
                        nextPageLink = pageResult.Body.NextPageLink;
                    }

                    WriteIdentityList(resultList);
                }
                else if(ParameterSetName.Equals(IdentityParameterSet))
                {
                    var result =
                        this.MsiClient.UserAssignedIdentities.GetWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name).GetAwaiter().GetResult();
                    WriteIdentity(result.Body);
                }
            });
        }
    }
}
