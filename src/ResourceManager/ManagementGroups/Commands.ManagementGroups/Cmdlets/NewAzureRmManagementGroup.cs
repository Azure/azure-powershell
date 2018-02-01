using System.Management.Automation;
using Microsoft.Azure.Commands.ManagementGroups.Common;
using Microsoft.Azure.Commands.ManagementGroups.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Cmdlets
{
    /// <summary>
    /// New-AzureRmManagementGroup Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmManagementGroup", DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(string))]
    public class NewAzureRmManagementGroup : AzureManagementGroupsCmdletBase
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
                        string.Format(Resource.NewManagementGroupShouldProcessTarget, GroupName), 
                        string.Format(Resource.NewManagementGroupShouldProcessAction, GroupName)))
                {
                    CreateGroupRequest createGroupRequest = new CreateGroupRequest(DisplayName, ParentId);
                    var response = ManagementGroupsApiClient.ManagementGroups.CreateOrUpdate(GroupName, createGroupRequest);
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
