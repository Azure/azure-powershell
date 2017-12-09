using System.Management.Automation;
using Microsoft.Azure.Commands.ManagementGroups.Common;
using Microsoft.Azure.Management.ManagementGroups;
using Microsoft.Azure.Management.ManagementGroups.Models;
using Microsoft.Azure.Commands.ManagementGroups.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Cmdlets
{
    /// <summary>
    /// Add-AzureRmManagementGroup Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmManagementGroup", DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, SupportsShouldProcess = false, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(string))]
    public class AddAzureRmManagementGroup : AzureManagementGroupsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true, HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.DisplayName, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; } = null;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.ParentId, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string ParentId { get; set; } = null;

        public override void ExecuteCmdlet()
        {
            try
            {
                CreateGroupRequest createGroupRequest = new CreateGroupRequest(DisplayName, ParentId);
                ManagementGroupsApiClient.GroupId = GroupName;
                var response = ManagementGroupsApiClient.ManagementGroups.Create(createGroupRequest);
                WriteObject(new PSManagementGroup(response));
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
