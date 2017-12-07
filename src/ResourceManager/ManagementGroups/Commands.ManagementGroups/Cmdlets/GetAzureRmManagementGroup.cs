using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ManagementGroups.Common;
using Microsoft.Azure.Management.ManagementGroups;
using Microsoft.Azure.Management.ManagementGroups.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.ManagementGroups.Cmdlets
{
    /// <summary>
    /// Get-AzureRmManagementGroup Cmdlet
    /// </summary>
     
    [Cmdlet(VerbsCommon.Get,"AzureRmManagementGroup", DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, SupportsShouldProcess = false, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(string))]
    public class GetAzureRmManagementGroup : AzureManagementGroupsCmdletBase
    {
        /// <summary>
        /// Get-AzureRmManagementGroup Cmdlet
        /// </summary>
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false, HelpMessage = Constants.HelpMessages.GroupId, Position = 0)]
        public string GroupId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.GroupId)]
        public SwitchParameter Expand;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.GroupId)]
        public SwitchParameter Recurse;

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!string.IsNullOrEmpty(GroupId))
                {
                    ManagementGroupsApiClient.GroupId = GroupId;
                    var response = ManagementGroupsApiClient.ManagementGroups.Get(Expand.IsPresent?"children":null, Recurse.IsPresent);
                    WriteObject(JsonConvert.SerializeObject(response));
                }
                else
                {
                    var response = ManagementGroupsApiClient.ManagementGroups.List();
                    WriteObject(JsonConvert.SerializeObject(response));
                }
            }
            catch (ErrorResponseException ex)
            {
                WriteWarning(ex.Message);
            }
        }
    }
}
