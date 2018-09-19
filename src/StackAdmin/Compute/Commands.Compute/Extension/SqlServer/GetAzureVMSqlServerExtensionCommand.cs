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
using System.Collections.Generic;
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
        protected const string SqlConfigurationSubStatusCode = "ComponentStatus/SQL Configuration/succeeded";

        // These maps are needed due to mismatch in the values while we set/get these parameters.
        protected static readonly Dictionary<string, string> AutoBackupScheduleTypeMap =
            new Dictionary<string, string>() 
            {
                { "NOTSET" , null },
                { "SYSTEM" , "Automated" },
                { "CUSTOM" , "Manual" }
            };
        protected static readonly Dictionary<string, string> AutoPatchingCategoryMap =
            new Dictionary<string, string>() 
            {
                { "WindowsMandatoryUpdates" , "Important" },
            };


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
                    Name = VirtualMachineSqlServerExtensionContext.ExtensionPublishedName;
                }
            }

            var result = VirtualMachineExtensionClient.GetWithInstanceView(ResourceGroupName, VMName, Name);
            var extension = result.ToPSVirtualMachineExtension(this.ResourceGroupName, this.VMName);

            if (
                extension.Publisher.Equals(VirtualMachineSqlServerExtensionContext.ExtensionPublishedNamespace,
                    StringComparison.InvariantCultureIgnoreCase) &&
                extension.ExtensionType.Equals(VirtualMachineSqlServerExtensionContext.ExtensionPublishedType,
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
            
            // Extract sql configuration information from one of the sub statuses
            if (extension.SubStatuses == null
                || extension.SubStatuses.FirstOrDefault(s =>
                    s.Code.Equals(SqlConfigurationSubStatusCode, StringComparison.InvariantCultureIgnoreCase)) == null)
            {
                ThrowTerminatingError(
                   new ErrorRecord(
                       new Exception(
                           String.Format(
                               CultureInfo.CurrentUICulture,
                               Properties.Resources.AzureVMSqlServerSqlConfigurationNotFound,
                               extension.SubStatuses)),
                   string.Empty,
                   ErrorCategory.ParserError,
                   null));
            }

            string sqlConfiguration = extension.SubStatuses.First(s => s.Code.Equals(SqlConfigurationSubStatusCode, StringComparison.InvariantCultureIgnoreCase)).Message;
            
            try
            {
                AzureVMSqlServerConfiguration settings = JsonConvert.DeserializeObject<AzureVMSqlServerConfiguration>(sqlConfiguration);

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
                    AutoBackupSettings = settings.AutoBackup == null ? null : new AutoBackupSettings()
                    {
                        Enable = settings.AutoBackup.Enable,
                        EnableEncryption = settings.AutoBackup.EnableEncryption,
                        RetentionPeriod = settings.AutoBackup.RetentionPeriod,
                        StorageUrl = settings.AutoBackup.StorageAccountUrl,
                        BackupSystemDbs = settings.AutoBackup.BackupSystemDbs,
                        BackupScheduleType = string.IsNullOrEmpty(settings.AutoBackup.BackupScheduleType) ? null : AutoBackupScheduleTypeMap[settings.AutoBackup.BackupScheduleType],
                        FullBackupFrequency = settings.AutoBackup.FullBackupFrequency,
                        FullBackupStartTime = settings.AutoBackup.FullBackupStartTime,
                        FullBackupWindowHours = settings.AutoBackup.FullBackupWindowHours,
                        LogBackupFrequency = settings.AutoBackup.LogBackupFrequency
                    },
                    AutoPatchingSettings = settings.AutoPatching == null ? null : new AutoPatchingSettings()
                    {
                        Enable = settings.AutoPatching.Enable,
                        DayOfWeek = settings.AutoPatching.DayOfWeek,
                        MaintenanceWindowDuration = settings.AutoPatching.MaintenanceWindowDuration,
                        MaintenanceWindowStartingHour = settings.AutoPatching.MaintenanceWindowStartingHour,
                        PatchCategory = string.IsNullOrEmpty(settings.AutoPatching.PatchCategory) ? null : AutoPatchingCategoryMap[settings.AutoPatching.PatchCategory]
                    },
                    KeyVaultCredentialSettings = settings.AzureKeyVault == null ? null : new KeyVaultCredentialSettings()
                    {
                        Enable = settings.AzureKeyVault.Enable,
                        Credentials = settings.AzureKeyVault.CredentialsList
                    },
                    AutoTelemetrySettings = settings.AutoTelemetryReport == null ? null : new AutoTelemetrySettings()
                    {
                        Region = settings.AutoTelemetryReport.Location,
                    },
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
                                Properties.Resources.AzureVMSqlServerWrongConfigFormat,
                                sqlConfiguration),
                            e),
                        string.Empty,
                        ErrorCategory.ParserError,
                        null));
            }

            return context;
        }
    }
}
