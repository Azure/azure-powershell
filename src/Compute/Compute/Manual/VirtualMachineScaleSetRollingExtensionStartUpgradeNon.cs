using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Threading.Tasks;


namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssRollingExtensionUpgradeNon", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSOperationStatusResponse))]
    public partial class VirtualMachineScaleSetRollingExtensionStartUpgradeNon : ComputeAutomationBaseCmdlet
    {
        private const string ByResourceIdParamSet = "ByResourceId",
            ByInputObjectParamSet = "ByInputObject";

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachineScaleSets", "ResourceGroupName")]
        //[Alias("Name")]
        public string VMScaleSetName { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParamSet,
            Mandatory = true,
            ValueFromPipeline = true)]
        public PSVirtualMachineScaleSet VirtualMachineScaleSet { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParamSet,
            Mandatory = true,
            ValueFromPipeline = true)]
        public Uri ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            
            switch (ParameterSetName)
            {
                case ByInputObjectParamSet:

                    break;

                case ByResourceIdParamSet:

                    break;

                default:
                    
                    ExecuteClientAction(() =>
                    {
                        if (ShouldProcess(this.VMScaleSetName, VerbsLifecycle.Start))
                        {
                            string resourceGroupName = this.ResourceGroupName;
                            string vmScaleSetName = this.VMScaleSetName;

                            //var resultOld = VirtualMachineScaleSetRollingUpgradesClient.StartOSUpgradeWithHttpMessagesAsync(resourceGroupName, vmScaleSetName).GetAwaiter().GetResult();//other cmdlet line
                            var result = VirtualMachineScaleSetRollingUpgradesClient.StartExtensionUpgradeWithHttpMessagesAsync(resourceGroupName, vmScaleSetName).GetAwaiter().GetResult();
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
                    break;
            }
        }
    }
}
