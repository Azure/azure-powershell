using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsLifecycle.Restart, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Host", DefaultParameterSetName = "DefaultParameterSet", SupportsShouldProcess = true)]
    public partial class DedicatedHostRestartMethod : ComputeAutomationBaseCmdlet
    {

        [Parameter(
            ParameterSetName = "DefaultParameterSet",
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameterSet",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string HostGroupName { get; set; }

        [Alias("HostName")]
        [Parameter(
            ParameterSetName = "DefaultParameterSet",
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                
            });
        }
    }
}
