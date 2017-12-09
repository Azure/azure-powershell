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
            HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; } = null;

        public override void ExecuteCmdlet()
        {
            try
            {
                ManagementGroupsApiClient.GroupId = GroupName;
                var response = ManagementGroupsApiClient.ManagementGroups.DeleteWithHttpMessagesAsync()
                        .GetAwaiter().GetResult();
                WriteObject(JsonConvert.SerializeObject(response.Response.ReasonPhrase));
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
