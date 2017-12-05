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
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.ManagementGroups.Cmdlets
{
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
                var response = ManagementGroupsApiClient.ManagementGroups.DeleteWithHttpMessagesAsync(GroupId)
                        .GetAwaiter().GetResult();
                WriteObject(JsonConvert.SerializeObject(response.Response.ReasonPhrase));

            }
            catch (ErrorResponseException ex)
            {
                WriteWarning(ex.Message);
            }
        }
    }
}
