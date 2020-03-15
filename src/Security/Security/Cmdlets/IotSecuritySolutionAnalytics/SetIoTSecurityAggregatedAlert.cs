using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics;
using Microsoft.Azure.Management.Security;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.IotSecuritySolutionAnalytics
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotSecurityAnalyticsAggregatedAlerts", DefaultParameterSetName = ParameterSetNames.SolutionLevelResource), OutputType(typeof(bool))]
    public class SetIoTSecurityAggregatedAlert : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SolutionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SolutionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.SolutionName)]
        [ValidateNotNullOrEmpty]
        public string SolutionName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SolutionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.SolutionLevelResource:
                    if (ShouldProcess(Name, VerbsCommon.Set))
                    {
                        SecurityCenterClient.IotSecuritySolutionsAnalyticsAggregatedAlert.DismissWithHttpMessagesAsync(ResourceGroupName, SolutionName, Name).GetAwaiter().GetResult();
                    }
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
