using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + "VMRunCommand", DefaultParameterSetName = VMNameParameterSet)]
    [OutputType(typeof(PSAzureOperationResponse), typeof(PSVirtualMachine))]//TODO: not sure which output
    class SetAzureVMRunCommand : VirtualMachineBaseCmdlet
    {
        private const string VMNameParameterSet = "VMNameParamSet";
        private const string ResourceIdParameterSet = "ResourceIdParamSet";

        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Run cmdlet in the background.")]
        [Parameter(Mandatory = false,
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Name of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Name of the run command.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Name of the run command.")]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true)]
        public string Location { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete.")]
        public bool? AsyncExecution { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the script content to be executed on the VM.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the script content to be executed on the VM.")]
        public string Script { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true)]
        public string ScriptPath { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the script download location.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the script download location.")]
        public string ScriptUri { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies a commandId of predefined built-in script.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies a commandId of predefined built-in script.")]
        public bool CommandId { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The parameters used by the script.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The parameters used by the script.")]
        public IList<RunCommandInputParameter> Parameter { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The parameters used by the script.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The parameters used by the script.")]
        public IList<RunCommandInputParameter> ProtectedParameter { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the user account on the VM when executing the run command.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the user account on the VM when executing the run command.")]
        public string RunAsUser { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the user account password on the VM when executing the run command.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the user account password on the VM when executing the run command.")]
        public string RunAsPassword { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The timeout in seconds to execute the run command.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The timeout in seconds to execute the run command.")]
        public int? TimeOutInSeconds { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the Azure storage blob where script output stream will be uploaded.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the Azure storage blob where script output stream will be uploaded.")]
        public string OutputBlobUri { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the Azure storage blob where script error stream will be uploaded.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the Azure storage blob where script error stream will be uploaded.")]
        public string ErrorBlobUri { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Resource id specifying the virtual machine object the extension is on.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }


        public override void ExecuteCmdlet()
        {
            string resourceGroup;
            string virtualMachineName;

            switch (ParameterSetName)
            {
                case ResourceIdParameterSet:
                    ResourceIdentifier identifier = new ResourceIdentifier(this.ResourceId);
                    resourceGroup = identifier.ResourceGroupName;
                    virtualMachineName = identifier.ResourceName;
                    break;

                default:
                    resourceGroup = this.ResourceGroupName;
                    virtualMachineName = this.VMName;
                    break;
            }

            //TODO: execute cmdlet 
        }
    }
}
