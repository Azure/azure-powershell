using System.Management.Automation;
using Microsoft.Azure.Commands.ManagementGroups.Common;
using Microsoft.Azure.Management.ManagementGroups.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.ManagementGroups.Cmdlets
{
    /// <summary>
    /// Remove-AzureRmManagementGroup Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmManagementGroup",
         DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet,
         SupportsShouldProcess = false, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(string))]
    public class RemoveAzureRmManagementGroup : AzureManagementGroupsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.GroupId, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string GroupId { get; set; } = null;

        public override void ExecuteCmdlet()
        {
            try
            {
                ManagementGroupsApiClient.GroupId = GroupId;
                var response = ManagementGroupsApiClient.ManagementGroups.DeleteWithHttpMessagesAsync()
                        .GetAwaiter().GetResult();
                // TODO (sepancha 12/7/2017) - Revisit what to output
                WriteObject(JsonConvert.SerializeObject(response.Response.ReasonPhrase));

            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
