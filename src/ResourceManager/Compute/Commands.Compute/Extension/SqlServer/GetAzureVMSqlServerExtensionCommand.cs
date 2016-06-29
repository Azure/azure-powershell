// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.VirtualMachineSqlServerExtension,
        DefaultParameterSetName = GetSqlServerExtensionParamSetName),
    OutputType(
        typeof(VirtualMachineSqlServerExtensionContext))]
    public class GetAzureVMSqlServerExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        protected const string GetSqlServerExtensionParamSetName = "GetSqlServerExtension";

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
           Position = 2,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Name of the ARM resource that represents the extension. The Set-AzureRmVMSqlServerExtension cmdlet sets this name to  " +
           "'Microsoft.SqlServer.Management.SqlIaaSAgent', which is the same value used by Get-AzureRmVMSqlServerExtension. Specify this parameter only if you changed " +
           "the default name in the Set cmdlet or used a different resource name in an ARM template.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (String.IsNullOrEmpty(Name))
            {
                VirtualMachine vm = ComputeClient.ComputeManagementClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                if (vm != null)
                {
                    VirtualMachineExtension virtualMachineExtension = vm.Resources.Where(x => x.Publisher.Equals(VirtualMachineSqlServerExtensionContext.ExtensionPublishedNamespace)).FirstOrDefault();
                    if (virtualMachineExtension != null)
                    {
                        this.Name = virtualMachineExtension.Name;
                    }
                }

                if (String.IsNullOrEmpty(Name))
                {
                    Name = VirtualMachineSqlServerExtensionContext.ExtensionPublishedNamespace + "." + VirtualMachineSqlServerExtensionContext.ExtensionPublishedName;
                }
            }

            var result = VirtualMachineExtensionClient.GetWithInstanceView(ResourceGroupName, VMName, Name);
            var extension = result.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName);

            if (
                extension.Publisher.Equals(VirtualMachineSqlServerExtensionContext.ExtensionPublishedNamespace,
                    StringComparison.InvariantCultureIgnoreCase) &&
                extension.ExtensionType.Equals(VirtualMachineSqlServerExtensionContext.ExtensionPublishedName,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                WriteObject(GetSqlServerExtensionContext(extension));
            }
            else
            {
                WriteObject(null);
            }
        }

        private VirtualMachineSqlServerExtensionContext GetSqlServerExtensionContext(PSVirtualMachineExtension extension)
        {
            SqlServerPublicSettings extensionPublicSettings = null;
            VirtualMachineSqlServerExtensionContext context = null;

            try
            {
                extensionPublicSettings = string.IsNullOrEmpty(extension.PublicSettings) ? null
                                  : JsonConvert.DeserializeObject<SqlServerPublicSettings>(extension.PublicSettings);

                // #$ISSUE- extension.Statuses is always null, follow up with Azure team
                context = new VirtualMachineSqlServerExtensionContext
                {
                    ResourceGroupName = extension.ResourceGroupName,
                    Name = extension.Name,
                    Location = extension.Location,
                    Etag = extension.Etag,
                    Publisher = extension.Publisher,
                    ExtensionType = extension.ExtensionType,
                    TypeHandlerVersion = extension.TypeHandlerVersion,
                    Id = extension.Id,
                    PublicSettings = JsonConvert.SerializeObject(extensionPublicSettings),
                    ProtectedSettings = extension.ProtectedSettings,
                    ProvisioningState = extension.ProvisioningState,
                    AutoBackupSettings = extensionPublicSettings.AutoBackupSettings,
                    AutoPatchingSettings = extensionPublicSettings.AutoPatchingSettings,
                    KeyVaultCredentialSettings = extensionPublicSettings.KeyVaultCredentialSettings,
                    Statuses = extension.Statuses
                };

            }
            catch (JsonException e)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                        new JsonException(
                            String.Format(
                                CultureInfo.CurrentUICulture,
                                Properties.Resources.AzureVMSqlServerWrongSettingsFormat,
                                extension.PublicSettings),
                            e),
                        string.Empty,
                        ErrorCategory.ParserError,
                        null));
            }

            return context;
        }
    }
}
