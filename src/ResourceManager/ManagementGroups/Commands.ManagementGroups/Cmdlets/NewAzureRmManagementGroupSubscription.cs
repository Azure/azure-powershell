using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ManagementGroups.Common;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Cmdlets
{
    /// <summary>
    /// Add-AzureRmManagementGroupSubscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmManagementGroupSubscription",
         DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet,
         SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(string))]
    public class NewAzureRmManagementGroupSubscription : AzureManagementGroupAutoRegisterCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; } = null;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.SubscriptionId, Position = 1)]
        [ValidateNotNullOrEmpty]
        public Guid SubscriptionId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.Force, Position = 2)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (Force.IsPresent || ShouldProcess(
                        string.Format(Resource.NewManagementGroupSubShouldProcessTarget, SubscriptionId, GroupName),
                        string.Format(Resource.NewManagementGroupSubShouldProcessAction, SubscriptionId, GroupName)))
                {
                    ManagementGroupsApiClient.ManagementGroupSubscriptions.Create(GroupName, SubscriptionId.ToString());
                }
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
