using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMDscExtension",DefaultParameterSetName = GetDscExtensionParamSetName),OutputType(typeof(VirtualMachineDscExtensionContext))]
    public class GetAzureVMDscExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
<<<<<<< HEAD
        private const string GetDscExtensionParamSetName = "GetDscExtension";
=======
        private const string GetDscExtensionParamSetName = "GetDscExtension",
            VMParameterSetName = "VMParameterSet";
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
<<<<<<< HEAD
=======
            ParameterSetName = GetDscExtensionParamSetName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
<<<<<<< HEAD
=======
            ParameterSetName = GetDscExtensionParamSetName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            Position = 2,
            ValueFromPipelineByPropertyName = true,
<<<<<<< HEAD
=======
            ParameterSetName = GetDscExtensionParamSetName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = "Name of the ARM resource that represents the extension. The Set-AzVMDscExtension cmdlet sets this name to  " +
            "'Microsoft.Powershell.DSC', which is the same value used by Get-AzVMDscExtension. Specify this parameter only if you changed " +
            "the default name in the Set cmdlet or used a different resource name in an ARM template.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines/extensions", "ResourceGroupName", "VMName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To show the status.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Status { get; set; }

<<<<<<< HEAD
=======
        [Parameter(
            ParameterSetName = VMParameterSetName,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the virtual machine object the extension is on.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

<<<<<<< HEAD
=======
            string virtualMachineName = "";
            string resourceGroup = "";
            if (this.ParameterSetName.Equals(VMParameterSetName))
            {
                virtualMachineName = this.VM.Name;
                if (this.VM.ResourceGroupName == null)
                {
                    WriteError("The incoming virtual machine must have a 'resourceGroupName'.", this.VM);
                }
                resourceGroup = this.VM.ResourceGroupName;
            }
            else
            {
                virtualMachineName = VMName;
                resourceGroup = ResourceGroupName;
            }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            if (String.IsNullOrEmpty(Name))
            {
                Name = DscExtensionCmdletConstants.ExtensionPublishedNamespace + "." + DscExtensionCmdletConstants.ExtensionPublishedName;
            }

            if (Status)
            {
<<<<<<< HEAD
                var result = VirtualMachineExtensionClient.GetWithInstanceView(ResourceGroupName, VMName, Name);
                var extension = result.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName);
=======
                var result = VirtualMachineExtensionClient.GetWithInstanceView(resourceGroup, virtualMachineName, Name);
                var extension = result.ToPSVirtualMachineExtension(resourceGroup, virtualMachineName);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

                if (
                    extension.Publisher.Equals(DscExtensionCmdletConstants.ExtensionPublishedNamespace,
                        StringComparison.InvariantCultureIgnoreCase) &&
                    extension.ExtensionType.Equals(DscExtensionCmdletConstants.ExtensionPublishedName,
                        StringComparison.InvariantCultureIgnoreCase))
                {
                    WriteObject(GetDscExtensionContext(extension));
                }
                else
                {
                    WriteObject(null);
                }
            }
            else
            {
<<<<<<< HEAD
                var result = VirtualMachineExtensionClient.Get(ResourceGroupName, VMName, Name);
                var extension = result.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName);
=======
                var result = VirtualMachineExtensionClient.Get(resourceGroup, virtualMachineName, Name);
                var extension = result.ToPSVirtualMachineExtension(resourceGroup, virtualMachineName);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

                if (
                    extension.Publisher.Equals(
                        DscExtensionCmdletConstants.ExtensionPublishedNamespace,
                        StringComparison.InvariantCultureIgnoreCase) &&
                    extension.ExtensionType.Equals(
                        DscExtensionCmdletConstants.ExtensionPublishedName,
                        StringComparison.InvariantCultureIgnoreCase))
                {
                    WriteObject(GetDscExtensionContext(extension));
                }
                else
                {
                    WriteObject(null);
                }
            }
        }

        private VirtualMachineDscExtensionContext GetDscExtensionContext(PSVirtualMachineExtension extension)
        {
            var context = new VirtualMachineDscExtensionContext
            {
                ResourceGroupName = extension.ResourceGroupName,
                Name = extension.Name,
                Location = extension.Location,
                Etag = extension.Etag,
                Publisher = extension.Publisher,
                ExtensionType = extension.ExtensionType,
                TypeHandlerVersion = extension.TypeHandlerVersion,
                Id = extension.Id,
                PublicSettings = extension.PublicSettings,
                ProtectedSettings = extension.ProtectedSettings,
                ProvisioningState = extension.ProvisioningState,
                Statuses = extension.Statuses
            };

            DscExtensionPublicSettings extensionPublicSettings = null;
            try
            {
                extensionPublicSettings = DscExtensionSettingsSerializer.DeserializePublicSettings(extension.PublicSettings);
            }
            catch (JsonException e)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                        new JsonException(
                            String.Format(
                                CultureInfo.CurrentUICulture,
                                Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscWrongSettingsFormat,
                                extension.PublicSettings),
                            e),
                        string.Empty,
                        ErrorCategory.ParserError,
                        null));
            }

            if (extensionPublicSettings == null)
            {
                context.ModulesUrl = string.Empty;
                context.ConfigurationFunction = string.Empty;
                context.Properties = null;
            }
            else
            {
                context.ModulesUrl = extensionPublicSettings.ModulesUrl;
                context.ConfigurationFunction = extensionPublicSettings.ConfigurationFunction;
                if (extensionPublicSettings.Properties != null)
                {
                    context.Properties =
                        new Hashtable(extensionPublicSettings.Properties.ToDictionary(x => x.Name, x => x.Value));
                }
            }

            return context;
        }
<<<<<<< HEAD
=======

        private void WriteError(string message, params object[] args)
        {
            base.WriteError(new ErrorRecord(new Exception(String.Format(message, args)), "Error", ErrorCategory.NotSpecified, null));
        }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
