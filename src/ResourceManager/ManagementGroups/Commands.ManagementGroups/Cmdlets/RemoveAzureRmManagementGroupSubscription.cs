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
            HelpMessage = Constants.HelpMessages.GroupId, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string GroupId { get; set; } = null;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.GroupId, Position = 1)]
        [ValidateNotNullOrEmpty]
        public Guid SubscriptonId { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                ManagementGroupsApiClient.GroupId = GroupId;
                ManagementGroupsApiClient.SubscriptionId = SubscriptonId.ToString();

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
