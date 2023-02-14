using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssRollingExtensionUpgrade", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSOperationStatusResponse))]
    public partial class VirtualMachineScaleSetRollingExtensionStartUpgrade : ComputeAutomationBaseCmdlet
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
        [Alias("Name")]
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
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {

            base.ExecuteCmdlet();
            switch (ParameterSetName)
            {

                case ByInputObjectParamSet:
                    ExecuteClientAction(() =>
                    {
                        this.StartRollingUpdate(this.VirtualMachineScaleSet.ResourceGroupName, this.VirtualMachineScaleSet.Name);
                    });
                    break;

                case ByResourceIdParamSet:

                    ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);

                    ExecuteClientAction(() =>
                    {
                        this.StartRollingUpdate(identifier.ResourceGroupName, identifier.ResourceName);
                    });
                    
                    break;

                default:
                    
                    ExecuteClientAction(() =>
                    {
                        this.StartRollingUpdate(this.ResourceGroupName, this.VMScaleSetName);
                    });
                    break;
            }
        }

        private void StartRollingUpdate(string ResourceGroup, string vmssName)
        {
            if (ShouldProcess(vmssName, VerbsLifecycle.Start))
            {
                
                var result = VirtualMachineScaleSetRollingUpgradesClient.StartExtensionUpgradeWithHttpMessagesAsync(ResourceGroup, vmssName).GetAwaiter().GetResult();
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
        }
    }
}
