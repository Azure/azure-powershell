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
    [OutputType(typeof(PSOperationStatusResponse))]
    public partial class DedicatedHostRestartMethod : ComputeAutomationBaseCmdlet
    {
        private const string DefaultParameterSetName = "DefaultParameterSet", ResourceIdParamSet = "ResourceIdParameterSet", ObjectParamSet = "ObjectParameterSet";

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the dedicated host group.")]
        public string HostGroupName { get; set; }

        [Alias("HostName")]
        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the dedicated host.")]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParamSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ARM resource id of the dedicated host.")]
        public string ResourceId { get; set; }

        [Alias("Host")]
        [Parameter(
            ParameterSetName = ObjectParamSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The dedicated host object.")]
        [ValidateNotNullOrEmpty]
        public PSHost InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.Remove))
                {
                    string resourceGroupName;
                    string hostGroupName;
                    string hostName;
                    switch (this.ParameterSetName)
                    {
                        case ResourceIdParamSet:
                            resourceGroupName = GetResourceGroupName(this.ResourceId);
                            hostGroupName = GetResourceName(this.ResourceId, "Microsoft.Compute/hostGroups", "hosts");
                            hostName = GetInstanceId(this.ResourceId, "Microsoft.Compute/hostGroups", "hosts");
                            break;
                        case ObjectParamSet:
                            resourceGroupName = GetResourceGroupName(this.InputObject.Id);
                            hostGroupName = GetResourceName(this.InputObject.Id, "Microsoft.Compute/hostGroups", "hosts");
                            hostName = GetInstanceId(this.InputObject.Id, "Microsoft.Compute/hostGroups", "hosts");
                            break;
                        default:
                            resourceGroupName = this.ResourceGroupName;
                            hostGroupName = this.HostGroupName;
                            hostName = this.Name;
                            break;
                    }

                    var result = DedicatedHostsClient.RestartWithHttpMessagesAsync(resourceGroupName, hostGroupName, hostName).GetAwaiter().GetResult();

                    PSOperationStatusResponse output = new PSOperationStatusResponse
                    {
                        StartTime = this.StartTime,
                        EndTime = DateTime.Now
                    };

                    if (result != null && result.Request != null && result.Request.RequestUri != null)
                    {
                        output.Name = GetOperationIdFromUrlString(result.Request.RequestUri.ToString());
                    }

                    WriteObject(output);
                }
            });
        }
    }
}
