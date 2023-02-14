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
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiskAccess", DefaultParameterSetName = DefaultParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSOperationStatusResponse))]
    public partial class RemoveAzureDiskAccess : ComputeAutomationBaseCmdlet
    {

        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";
        private const string ResourceIDParameterSet = "ResourceIDParameterSet";

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/diskAccesses", "ResourceGroupName")]
        [Alias("DiskAccessName")]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ResourceIDParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource ID for your disk access.")]
        [ResourceIdCompleter("Microsoft.Compute/diskAccesses")]
        public string ResourceId { get; set; }

        [Alias("DiskAccess")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PowerShell Disk Access Object")]
        [ValidateNotNullOrEmpty]
        public PSDiskAccess InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.Remove))
                {
                    string resourceGroupName;
                    string diskAccessName;
                    switch (this.ParameterSetName)
                    {
                        case ResourceIDParameterSet:
                            resourceGroupName = GetResourceGroupName(this.ResourceId);
                            diskAccessName = GetResourceName(this.ResourceId, "Microsoft.Compute/diskAccesses");
                            break;
                        case InputObjectParameterSet:
                            resourceGroupName = GetResourceGroupName(this.InputObject.Id);
                            diskAccessName = GetResourceName(this.InputObject.Id, "Microsoft.Compute/diskAccesses");
                            break;
                        default:
                            resourceGroupName = this.ResourceGroupName;
                            diskAccessName = this.Name;
                            break;
                    }

                    var result = DiskAccessesClient.DeleteWithHttpMessagesAsync(resourceGroupName, diskAccessName).GetAwaiter().GetResult();
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