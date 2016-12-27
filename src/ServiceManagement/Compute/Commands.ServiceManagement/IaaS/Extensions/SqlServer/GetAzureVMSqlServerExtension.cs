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

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Commands.ServiceManagement;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    using NSM = Management.Compute.Models;
    using Hyak.Common;
    using System;

    /// <summary>
    /// Get-AzureVMSqlServerExtension implementation
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        VirtualMachineSqlServerExtensionNoun,
        DefaultParameterSetName = GetSqlServerExtensionParamSetName),
    OutputType(
        typeof(VirtualMachineSqlServerExtensionContext))]
    public class GetAzureVMSqlServerExtensionCommand : VirtualMachineSqlServerExtensionCmdletBase
    {
        protected const string GetSqlServerExtensionParamSetName = "GetSqlServerExtension";
        protected const string AutoPatchingStatusMessageName = "Automated Patching";
        protected const string AutoBackupStatusMessageName = "Automated Backup";
        protected const string KeyVaultCredentialStatusMessageName = "Key Vault Credential";
        protected const string SqlConfigurationStatusMessageName = "SQL Configuration";

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

        internal void ExecuteCommand()
        {
            var extensionRefs = GetPredicateExtensionList();
            WriteObject(
                extensionRefs == null ? null : extensionRefs.Select(
                r =>
                {
                    GetExtensionValues(r);

                    return this.GetExtensionContext(r);
                }), true);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            this.ExecuteCommand();
        }

        /// <summary>
        /// Get the SQL Extension's context
        /// </summary>
        /// <returns></returns>
        private VirtualMachineSqlServerExtensionContext GetExtensionContext(ResourceExtensionReference r)
        {
            string extensionName = VirtualMachineSqlServerExtensionCmdletBase.ExtensionPublishedNamespace + "."
                      + VirtualMachineSqlServerExtensionCmdletBase.ExtensionPublishedName;

            VirtualMachineSqlServerExtensionContext context = new VirtualMachineSqlServerExtensionContext
            {
                ExtensionName = r.Name,
                Publisher = r.Publisher,
                ReferenceName = r.ReferenceName,
                Version = r.Version,
                State = r.State,
                PublicConfiguration = PublicConfiguration,
                PrivateConfiguration = SecureStringHelper.GetSecureString(PrivateConfiguration),
                RoleName = VM.GetInstance().RoleName,
            };

            // gather extension status messages
            List<string> statusMessageList = new List<string>();

            List<NSM.ResourceExtensionStatus> extensionStatusList = this.GetResourceExtensionStatusList(context);

            // enumerate over extension status list and gather status for autopatching and autobackup
            // Note: valid reference to an extension status list is returned by GetResourceExtensionStatusList()
            foreach (NSM.ResourceExtensionStatus res in extensionStatusList)
            {
                // Expected ReferenceName = "Microsoft.SqlServer.Management.SqlIaaSAgent"
                if (!res.HandlerName.Equals(extensionName, System.StringComparison.InvariantCulture))
                {
                    // skip all non-sql extensions
                    continue;
                }

                WriteVerboseWithTimestamp("Found SQL Extension:" + r.ReferenceName);

                if (null != res.ExtensionSettingStatus)
                {
                    context.SubStatusList = res.ExtensionSettingStatus.SubStatusList;

                    // Gather status messages because
                    // #$ISSUE- extension.Statuses is always null, follow up with Azure team
                    foreach (NSM.ResourceExtensionSubStatus status in res.ExtensionSettingStatus.SubStatusList)
                    {
                        if (null != status.FormattedMessage)
                        {
                            statusMessageList.Add(status.FormattedMessage.Message);
                        }
                    }
                    context.StatusMessages = statusMessageList;

                    // Extract sql configuration information from one of the sub statuses
                    if (context.SubStatusList == null
                        || context.SubStatusList.FirstOrDefault(s =>
                            s.Name.Equals(SqlConfigurationStatusMessageName, StringComparison.InvariantCultureIgnoreCase)) == null)
                    {
                        WriteWarning(
                            String.Format(
                                CultureInfo.CurrentUICulture,
                                Properties.Resources.AzureVMSqlServerSqlConfigurationNotFound,
                                context.SubStatusList));

                        continue;
                    }

                    string sqlConfiguration = context.SubStatusList.First(s => s.Name.Equals(SqlConfigurationStatusMessageName, StringComparison.InvariantCultureIgnoreCase)).FormattedMessage.Message;

                    try
                    {
                        AzureVMSqlServerConfiguration settings = JsonConvert.DeserializeObject<AzureVMSqlServerConfiguration>(sqlConfiguration);

                        context.AutoBackupSettings = settings.AutoBackup == null ? null : new AutoBackupSettings()
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
                        };

                        context.AutoPatchingSettings = settings.AutoPatching == null ? null : new AutoPatchingSettings()
                        {
                            Enable = settings.AutoPatching.Enable,
                            DayOfWeek = settings.AutoPatching.DayOfWeek,
                            MaintenanceWindowDuration = settings.AutoPatching.MaintenanceWindowDuration,
                            MaintenanceWindowStartingHour = settings.AutoPatching.MaintenanceWindowStartingHour,
                            PatchCategory = string.IsNullOrEmpty(settings.AutoPatching.PatchCategory) ? null : AutoPatchingCategoryMap[settings.AutoPatching.PatchCategory]
                        };

                        context.KeyVaultCredentialSettings = settings.AzureKeyVault == null ? null : new KeyVaultCredentialSettings()
                        {
                            Enable = settings.AzureKeyVault.Enable,
                            Credentials = settings.AzureKeyVault.CredentialsList
                        };

                        context.AutoTelemetrySettings = settings.AutoTelemetryReport == null ? null : new AutoTelemetrySettings()
                        {
                            Region = settings.AutoTelemetryReport.Location,
                        };
                    }
                    catch (JsonException)
                    {
                        WriteWarning(
                            String.Format(
                                CultureInfo.CurrentUICulture,
                                Properties.Resources.AzureVMSqlServerWrongConfigFormat,
                                sqlConfiguration));
                    }
                }
            }

            return context;
        }


        /// <summary>
        /// Walks through hosted services and returns back the ResourceExtensionStatus reported by Azure guest agent
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private List<NSM.ResourceExtensionStatus> GetResourceExtensionStatusList(VirtualMachineSqlServerExtensionContext context)
        {
            List<NSM.ResourceExtensionStatus> extensionStatusList = new List<NSM.ResourceExtensionStatus>();

            // List all hosted services
            WriteVerboseWithTimestamp("Listing hosted services...");
            NSM.HostedServiceListResponse response = this.ComputeClient.HostedServices.List();
            WriteVerboseWithTimestamp("Listing hosted services completed.");

            foreach (var service in response)
            {
                NSM.DeploymentGetResponse deployment = null;

                try
                {
                    deployment = this.ComputeClient.Deployments.GetBySlot(
                        service.ServiceName,
                        NSM.DeploymentSlot.Production);
                }
                catch (CloudException e)
                {
                    if (e.Response.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw;
                    }
                }

                if (deployment != null)
                {
                    // Enumerate Role instances , check if role name exists
                    foreach (NSM.RoleInstance ri in deployment.RoleInstances)
                    {
                        if (ri.RoleName.Equals(context.RoleName, System.StringComparison.InvariantCulture))
                        {
                            WriteVerboseWithTimestamp("Found Role Instance:" + context.RoleName);
                            extensionStatusList = new List<NSM.ResourceExtensionStatus>(ri.ResourceExtensionStatusList);
                            return extensionStatusList;
                        }
                    }
                }
            }

            if (extensionStatusList.Count == 0)
            {
                WriteVerboseWithTimestamp("Could not locate role instance for role name:" + context.RoleName);
            }

            return extensionStatusList;
        }

        private AutoPatchingSettings DeSerializeAutoPatchingSettings(string category, string input)
        {
            AutoPatchingSettings aps = new AutoPatchingSettings();

            if (!string.IsNullOrEmpty(input))
            {
                try
                {
                    aps = JsonConvert.DeserializeObject<AutoPatchingSettings>(input);
                    aps.PatchCategory = this.ResolvePatchCategoryStringforPowerShell(aps.PatchCategory);
                }
                catch (JsonReaderException jre)
                {
                    WriteVerboseWithTimestamp("Category:" + category);
                    WriteVerboseWithTimestamp("Message:" + input);
                    WriteVerboseWithTimestamp(jre.ToString());
                }
            }

            return aps;
        }

        private AutoBackupSettings DeSerializeAutoBackupSettings(string category, string input)
        {
            AutoBackupSettings autoBackupSettings = new AutoBackupSettings();

            if (!string.IsNullOrEmpty(input))
            {
                try
                {
                    PublicAutoBackupSettings publicAutoBackupSettings = JsonConvert.DeserializeObject<PublicAutoBackupSettings>(input);

                    if(publicAutoBackupSettings != null)
                    {
                        autoBackupSettings.Enable = publicAutoBackupSettings.Enable;
                        autoBackupSettings.EnableEncryption = publicAutoBackupSettings.EnableEncryption;
                        autoBackupSettings.RetentionPeriod = publicAutoBackupSettings.RetentionPeriod;
                        autoBackupSettings.StorageAccessKey = "***";
                        autoBackupSettings.StorageUrl = "***";

                        if (autoBackupSettings.EnableEncryption)
                        {
                            autoBackupSettings.Password = "***";
                        }
                    }
                }
                catch (JsonReaderException jre)
                {
                    WriteVerboseWithTimestamp("Category:" + category);
                    WriteVerboseWithTimestamp("Message:" + input);
                    WriteVerboseWithTimestamp(jre.ToString());
                }
            }

            return autoBackupSettings;
        }

        private KeyVaultCredentialSettings DeSerializeKeyVaultCredentialSettings(string category, string input)
        {
            KeyVaultCredentialSettings kvtSettings = new KeyVaultCredentialSettings();

            if (!string.IsNullOrEmpty(input))
            {
                try
                {
                    // we only print the public settings
                    PublicKeyVaultCredentialSettings publicSettings = JsonConvert.DeserializeObject<PublicKeyVaultCredentialSettings>(input);

                    if (publicSettings != null)
                    {
                        kvtSettings.CredentialName = publicSettings.CredentialName;
                        kvtSettings.Enable = publicSettings.Enable;

                        if (kvtSettings.Enable)
                        {
                            kvtSettings.ServicePrincipalName = "***";
                            kvtSettings.ServicePrincipalSecret = "***";
                            kvtSettings.AzureKeyVaultUrl = "***";
                        }
                    }
                }
                catch (JsonReaderException jre)
                {
                    WriteVerboseWithTimestamp("Category:" + category);
                    WriteVerboseWithTimestamp("Message:" + input);
                    WriteVerboseWithTimestamp(jre.ToString());
                }
            }

            return kvtSettings;
        }

        /// <summary>
        /// Map strings Auto-patching public settings -> Powershell API
        ///      "WindowsMandatoryUpdates" -> "Important"
        /// </summary>
        /// <param name="patchCategory"></param>
        /// <returns></returns>
        private string ResolvePatchCategoryStringforPowerShell(string category)
        {
            string patchCategory = string.Empty;

            if (!string.IsNullOrEmpty(category))
            {
                switch (category.ToLower())
                {
                    case "windowsmandatoryupdates":
                        patchCategory = AzureVMSqlServerAutoPatchingPatchCategoryEnum.Important.ToString("G");
                        break;

                    default:
                        break;
                }
            }

            return patchCategory;
        }
    }
}
