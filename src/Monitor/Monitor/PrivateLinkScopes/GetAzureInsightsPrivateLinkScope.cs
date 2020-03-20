using System;
using System.Collections.Generic;
using System.Text;
using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Monitor;

namespace Microsoft.Azure.Commands.Insights.PrivateLinkScopes
{
    /// <summary>
    /// Get or List private link scope(s)
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InsightsPrivateLinkScope"), OutputType(typeof(PSMonitorPrivateLinkScope))]
    class GetAzureInsightsPrivateLinkScope : ManagementCmdletBase
    {
        const string ByResourceGroupParameterSet = "ByResourceGroupParameterSet";
        const string ByResourceNameParameterSet = "ByResourceNameParameterSet";
        const string ByResourceIdParameterSet = "ByResourceIdParameterSet";

        #region Cmdlet parameters

        [Parameter(
            ParameterSetName = ByResourceGroupParameterSet,
            Mandatory = false,
            HelpMessage = "Resource Group Name")]
        [Parameter(
            ParameterSetName = ByResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ByResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "Private Link Scope Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion

















    }
}
