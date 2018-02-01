using System.Management.Automation;
using Microsoft.Azure.Commands.ManagementGroups.Common;
using Microsoft.Azure.Commands.ManagementGroups.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Cmdlets
{
    [Cmdlet("Update", "AzureRmManagementGroup", DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(string))]
    public class UpdateAzureRmManagementGroup : AzureManagementGroupsCmdletBase
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

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.Force, Position = 3)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (Force.IsPresent || ShouldProcess(
                        string.Format(Resource.UpdateManagementGroupShouldProcessTarget, GroupName),
                        string.Format(Resource.UpdateManagementGroupShouldProcessAction, GroupName)))
                {
                    CreateGroupRequest createGroupRequest = new CreateGroupRequest(DisplayName, ParentId);
                    var response = ManagementGroupsApiClient.ManagementGroups.Update(GroupName, createGroupRequest);
                    WriteObject(new PSManagementGroupNoChildren(response));

                }
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
