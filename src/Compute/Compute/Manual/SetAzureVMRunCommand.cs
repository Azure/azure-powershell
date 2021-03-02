using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + "VMRunCommand", DefaultParameterSetName = VMNameParameterSet)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMRunCommand : ComputeAutomationBaseCmdlet//VirtualMachineBaseCmdlet
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
            ParameterSetName = VMNameParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = VMNameParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the run command.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the run command.")]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet)]
        [Parameter(
            ParameterSetName = VMNameParameterSet)]
        public string Location { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete.")]
        public bool? AsyncExecution { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Specifies the script content to be executed on the VM.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "Specifies the script content to be executed on the VM.")]
        public string Script { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet)]
        [Parameter(
            ParameterSetName = VMNameParameterSet)]
        public string ScriptPath { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Specifies the script download location.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "Specifies the script download location.")]
        public string ScriptUri { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Specifies a commandId of predefined built-in script.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "Specifies a commandId of predefined built-in script.")]
        public string CommandId { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The parameters used by the script.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "The parameters used by the script.")]
        public IList<RunCommandInputParameter> Parameter { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The parameters used by the script.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "The parameters used by the script.")]
        public IList<RunCommandInputParameter> ProtectedParameter { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Specifies the user account on the VM when executing the run command.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "Specifies the user account on the VM when executing the run command.")]
        public string RunAsUser { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Specifies the user account password on the VM when executing the run command.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "Specifies the user account password on the VM when executing the run command.")]
        public string RunAsPassword { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The timeout in seconds to execute the run command.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "The timeout in seconds to execute the run command.")]
        public int? TimeoutInSeconds { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Specifies the Azure storage blob where script output stream will be uploaded.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "Specifies the Azure storage blob where script output stream will be uploaded.")]
        public string OutputBlobUri { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the Azure storage blob where script error stream will be uploaded.")]
        [Parameter(
            ParameterSetName = VMNameParameterSet,
            HelpMessage = "Specifies the Azure storage blob where script error stream will be uploaded.")]
        public string ErrorBlobUri { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
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

            //PSVirtualMachineRunCommand to = new PSVirtualMachineRunCommand();

            VirtualMachineRunCommandScriptSource scriptSource = new VirtualMachineRunCommandScriptSource();//TODO: why can't I use the PSVirtualMachineRunCommandScriptSource object? Error occurs. 
            if (this.Script != null || this.ScriptUri != null || this.CommandId != null)
            {
                
                if (this.Script != null)
                {
                    scriptSource.Script = this.Script;
                }
                if (this.ScriptUri != null)
                {
                    scriptSource.ScriptUri = this.ScriptUri;
                }
                if (this.CommandId != null)
                {
                    scriptSource.CommandId = this.CommandId;
                }
            }


            
            PSVirtualMachineRunCommand parameters = new PSVirtualMachineRunCommand
            {
                Source = scriptSource, //unable to use PS version here for some reason
                //name ? 
                // location? 
                AsyncExecution = (this.AsyncExecution != null) ? this.AsyncExecution : null,
                Parameters = (this.Parameter != null) ? this.Parameter : null,
                ProtectedParameters = (this.ProtectedParameter != null) ? this.ProtectedParameter : null,
                RunAsUser = (this.RunAsUser != null) ? this.RunAsUser : null,
                RunAsPassword = (this.RunAsPassword != null) ? this.RunAsPassword : null,
                TimeoutInSeconds = (this.TimeoutInSeconds != null) ? this.TimeoutInSeconds : null,
                OutputBlobUri = (this.OutputBlobUri != null) ? this.OutputBlobUri : null,
                ErrorBlobUri = (this.ErrorBlobUri != null) ? this.ErrorBlobUri : null

                ,Id = null,
                Type = null,
                Name = null,
                Location = null,
                Tags = null
            };

            //this.ComputeClient.ComputeManagementClient.VirtualMachineRunCommands.CreateOrUpdate();
            this.ComputeClient.ComputeManagementClient.VirtualMachineRunCommands.CreateOrUpdateWithHttpMessagesAsync(resourceGroup, virtualMachineName, this.Name, parameters);


        }
    }
}
