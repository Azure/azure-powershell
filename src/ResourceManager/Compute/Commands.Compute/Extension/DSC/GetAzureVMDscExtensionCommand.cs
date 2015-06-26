using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.VirtualMachineDscExtension,
        DefaultParameterSetName = GetDscExtensionParamSetName),
     OutputType(
         typeof(VirtualMachineDscExtensionContext))]
    public class GetAzureVMDscExtensionCommand : VirtualMachineDscExtensionBaseCmdlet
    {
        protected const string GetDscExtensionParamSetName = "GetDscExtension";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To show the status.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Status { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Status)
            {
                var result = this.VirtualMachineExtensionClient.GetWithInstanceView(this.ResourceGroupName, this.VMName,
                    this.Name);
                var extension = result.ToPSVirtualMachineExtension(this.ResourceGroupName);

                if (
                    extension.Publisher.Equals(this.ExtensionNamespace,
                        StringComparison.InvariantCultureIgnoreCase) &&
                    extension.ExtensionType.Equals(this.ExtensionName,
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
                var result = this.VirtualMachineExtensionClient.Get(this.ResourceGroupName, this.VMName, this.Name);
                var extension = result.ToPSVirtualMachineExtension(this.ResourceGroupName);

                if (
                    extension.Publisher.Equals(this.ExtensionNamespace,
                        StringComparison.InvariantCultureIgnoreCase) &&
                    extension.ExtensionType.Equals(this.ExtensionName,
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

            var publicSettings = string.IsNullOrEmpty(extension.PublicSettings) ? null
                                    : JsonConvert.DeserializeObject<DscExtensionPublicSettings>(extension.PublicSettings);

            if (publicSettings == null)
            {
                context.ModulesUrl = string.Empty;
                context.ConfigurationFunction = string.Empty;
                context.Properties = null;
            }
            else
            {
                context.ModulesUrl = publicSettings.ModulesUrl;
                context.ConfigurationFunction = publicSettings.ConfigurationFunction;
                context.Properties = new Hashtable(publicSettings.Properties.ToDictionary( x => x.Name, x => x.Value ));
            }

            return context;
        }
    }
}
