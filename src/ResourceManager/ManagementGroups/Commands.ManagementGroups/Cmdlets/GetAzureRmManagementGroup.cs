using System.Management.Automation;
using Microsoft.Azure.Commands.ManagementGroups.Common;
using Microsoft.Azure.Commands.ManagementGroups.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Cmdlets
{
    using System.Linq;

    /// <summary>
    /// Get-AzureRmManagementGroup Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get,"AzureRmManagementGroup", DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(string))]
    public class GetAzureRmManagementGroup : AzureManagementGroupsCmdletBase
    {
        /// <summary>
        /// Get-AzureRmManagementGroup Cmdlet
        /// </summary>
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false, HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        public string GroupName { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.Expand)]
        public SwitchParameter Expand;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.Recurse)]
        public SwitchParameter Recurse;

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!string.IsNullOrEmpty(GroupName))
                {
                    var response = ManagementGroupsApiClient.ManagementGroups.Get(GroupName, Expand.IsPresent?"children":null, Recurse.IsPresent);
                    if (!Expand.IsPresent)
                    {
                        WriteObject(new PSManagementGroupNoChildren(response));
                    }
                    else
                    {
                        WriteObject(new PSManagementGroup(response));
                    }
                }
                else
                {
                    var response = ManagementGroupsApiClient.ManagementGroups.List();
                    var items = response.Select(managementGroup => new PSManagementGroupInfo(managementGroup))
                        .ToList();
                    WriteObject(items);
                }
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
