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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssRollingExtensionUpgradeNon", SupportsShouldProcess = true)]
    [OutputType(typeof(PSOperationStatusResponse))]
    public partial class VirtualMachineScaleSetRollingExtensionStartUpgradeNon : ComputeAutomationBaseCmdlet
    {
        private const string ByResourceIdParamSet = "ByResourceId",
            ByInputObjectParamSet = "ByInputObject",
            DefaultParameterSetName = "DefaultParameter";
        private const string resourceGroups = "resourceGroups", 
            virtualMachineScaleSets = "virtualMachineScaleSets";

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
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
                    //var resourceIdSegments = this.ResourceId.Segments;
                    //ERROR: This operation is not supported for a relative URI
                    ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);

                    if (!String.IsNullOrEmpty(identifier.ResourceGroupName) & !String.IsNullOrEmpty(identifier.ResourceName))
                    {
                        ExecuteClientAction(() =>
                        {
                            this.StartRollingUpdate(identifier.ResourceGroupName, identifier.ResourceName);
                        });
                    }
                    /*else
                    {
                        //throw exception incorrectly used cmdlet?
                        //Might just call the api and let it error out actually. 
                        // TODO: test what happens when an empty value for RG or NAme is passed
                    }*/
                    
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
