using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ManagementGroups.Common;
using Microsoft.Azure.Management.ManagementGroups.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Cmdlets
{
    /// <summary>
    /// Remove-AzureRmManagementGroupSubscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmManagementGroupSubscription",
         DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet,
         SupportsShouldProcess = false, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(string))]
    public class RemoveAzureRmManagementGroupSubscription : AzureManagementGroupsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; } = null;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.SubscriptionId, Position = 1)]
        [ValidateNotNullOrEmpty]
        public Guid SubscriptionId { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                ManagementGroupsApiClient.GroupId = GroupName;
                ManagementGroupsApiClient.SubscriptionId = SubscriptionId.ToString();

                var response = ManagementGroupsApiClient.ManagementGroupSubscriptions.DeleteWithHttpMessagesAsync()
                    .GetAwaiter().GetResult();
                WriteObject(response.Response.ReasonPhrase);
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
