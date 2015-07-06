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
        private const string GetDscExtensionParamSetName = "GetDscExtension";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension handler name.")]
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

            if (String.IsNullOrEmpty(Name))
            {
                Name = ExtensionNamespace + "." + ExtensionName;
            }

            if (Status)
            {
                var result = VirtualMachineExtensionClient.GetWithInstanceView(ResourceGroupName, VMName, Name);
                var extension = result.ToPSVirtualMachineExtension(ResourceGroupName);

                if (
                    extension.Publisher.Equals(ExtensionNamespace,
                        StringComparison.InvariantCultureIgnoreCase) &&
                    extension.ExtensionType.Equals(ExtensionName,
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
                var result = VirtualMachineExtensionClient.Get(ResourceGroupName, VMName, Name);
                var extension = result.ToPSVirtualMachineExtension(ResourceGroupName);

                if (
                    extension.Publisher.Equals(ExtensionNamespace,
                        StringComparison.InvariantCultureIgnoreCase) &&
                    extension.ExtensionType.Equals(ExtensionName,
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

            DscExtensionPublicSettings publicSettings;
            try
            {
                publicSettings = string.IsNullOrEmpty(extension.PublicSettings) ? null
                                    : JsonConvert.DeserializeObject<DscExtensionPublicSettings>(extension.PublicSettings);
            }
            catch (Exception)
            {
                // Try deserialize as version 1.0
                try
                {
                    var publicSettingsV1 =
                        JsonConvert.DeserializeObject<DscExtensionPublicSettings.Version1>(extension.PublicSettings);
                    publicSettings = publicSettingsV1.ToCurrentVersion();
                }
                catch (JsonException)
                {
                    throw;
                } 
            }
            
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
