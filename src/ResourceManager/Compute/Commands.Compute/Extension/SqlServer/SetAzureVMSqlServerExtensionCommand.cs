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
using AutoMapper;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.VirtualMachineSqlServerExtension)]
    public class SetAzureSqlServerExtensionCommand : VirtualMachineExtensionBaseCmdlet
    {
        /// <summary>
        /// The specific version of the SqlServer extension that Set-AzureRmVMSqlServerExtension will 
        /// apply the settings to. 
        /// </summary>
        [Alias("HandlerVersion")]
        [Parameter(
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The version of the SqlServer extension that Set-AzureRmVMSqlServerExtension will apply the settings to. " +
                          "Allowed format N.N")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 2,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the virtual machine where Sql Server extension handler would be installed.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = "Name of the ARM resource that represents the extension. This is defaulted to 'Microsoft.SqlServer.Management.SqlIaaSAgent'.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
          Mandatory = false,
          Position = 5,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The Automatic Patching configuration.")]
        [ValidateNotNullOrEmpty]
        public AutoPatchingSettings AutoPatchingSettings { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Automatic Backup configuration.")]
        [ValidateNotNullOrEmpty]
        public AutoBackupSettings AutoBackupSettings { get; set; }

        [Parameter(
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of the resource.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var parameters = new VirtualMachineExtension
            {
                Location = this.Location,
                Name = Name ?? VirtualMachineSqlServerExtensionContext.ExtensionPublishedNamespace + "." + VirtualMachineSqlServerExtensionContext.ExtensionPublishedName,
                Type = VirtualMachineExtensionType,
                Publisher = VirtualMachineSqlServerExtensionContext.ExtensionPublishedNamespace,
                ExtensionType = VirtualMachineSqlServerExtensionContext.ExtensionPublishedName,
                TypeHandlerVersion = string.IsNullOrEmpty(this.Version) ? VirtualMachineSqlServerExtensionContext.ExtensionDefaultVersion : this.Version,
                Settings = this.GetPublicConfiguration(),
                ProtectedSettings = this.GetPrivateConfiguration(),
            };

            // Add retry logic due to CRP service restart known issue CRP bug: 3564713
            // Similair approach taken in DSC cmdlet as well
            var count = 1;
            ComputeLongRunningOperationResponse op = null;
            while (count <= 2)
            {
                op = VirtualMachineExtensionClient.CreateOrUpdate(
                        ResourceGroupName,
                        VMName,
                        parameters);

                if (ComputeOperationStatus.Failed.Equals(op.Status) && op.Error != null && "InternalExecutionError".Equals(op.Error.Code))
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            var result = Mapper.Map<PSComputeLongRunningOperation>(op);
            WriteObject(result);
        }

        /// <summary>
        /// Returns the public configuration as string
        /// </summary>
        /// <returns></returns>
        private string GetPublicConfiguration()
        {
            return JsonConvert.SerializeObject(
               new SqlServerPublicSettings
               {
                   AutoPatchingSettings = this.AutoPatchingSettings,
                   AutoBackupSettings = this.AutoBackupSettings,
                   AutoTelemetrySettings = new AutoTelemetrySettings() { Region = this.Location}
               });
        }

        /// <summary>
        /// Returns private configuration as string
        /// </summary>
        /// <returns></returns>
        private string GetPrivateConfiguration()
        {
            return JsonConvert.SerializeObject(
                       new SqlServerPrivateSettings
                       {
                           StorageUrl = (this.AutoBackupSettings == null) ? string.Empty : this.AutoBackupSettings.StorageUrl,
                           StorageAccessKey = (this.AutoBackupSettings == null) ? string.Empty : this.AutoBackupSettings.StorageAccessKey,
                           Password = (this.AutoBackupSettings == null) ? string.Empty : this.AutoBackupSettings.Password
                       });
        }
    }
}
