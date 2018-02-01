using System.Management.Automation;
using Microsoft.Azure.Commands.ManagementGroups.Common;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Cmdlets
{
    /// <summary>
    /// Remove-AzureRmManagementGroup Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmManagementGroup",
         DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet,
         SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(string))]
    public class RemoveAzureRmManagementGroup : AzureManagementGroupsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; } = null;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.Force, Position = 1)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {

            try
            {
                if (Force.IsPresent || ShouldProcess(
                        string.Format(Resource.RemoveManagementGroupShouldProcessTarget, GroupName),
                        string.Format(Resource.RemoveManagementGroupShouldProcessAction, GroupName)))
                {
                    ManagementGroupsApiClient.ManagementGroups.Delete(GroupName);
                }
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
