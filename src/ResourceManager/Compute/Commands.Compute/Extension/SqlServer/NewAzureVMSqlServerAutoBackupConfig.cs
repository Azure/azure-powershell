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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using System;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Helper cmdlet to construct instance of AutoBackup settings class
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        ProfileNouns.VirtualMachineSqlServerAutoBackupConfig,
        DefaultParameterSetName = StorageUriParamSetName),
    OutputType(
        typeof(AutoBackupSettings))]
    public class NewAzureVMSqlServerAutoBackupConfigCommand : AzureRMCmdlet
    {
        protected const string StorageContextParamSetName = "StorageContextSqlServerAutoBackup";
        protected const string StorageUriParamSetName = "StorageUriSqlServerAutoBackup";

        [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable Automatic Backup.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Enable { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Backup Retention period in days.")]
        [ValidateNotNullOrEmpty]
        public int RetentionPeriodInDays { get; set; }

        [Parameter(
             Mandatory = false,
             Position = 3,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Enable Backup Encryption.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableEncryption { get; set; }

        [Parameter(
             Mandatory = false,
             Position = 4,
             ValueFromPipelineByPropertyName = false,
             HelpMessage = "Certificate password.")]
        public SecureString CertificatePassword { get; set; }

        [Parameter(
            ParameterSetName = StorageContextParamSetName,
            Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage connection context")]
        [ValidateNotNullOrEmpty]
        public AzureStorageContext StorageContext
        {
            get;
            set;
        }

        [Parameter(
             Mandatory = false,
             Position = 4,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The storage uri")]
        [ValidateNotNullOrEmpty]
        public Uri StorageUri
        {
            get;
            set;
        }

        [Parameter(
          Mandatory = false,
          Position = 5,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The storage access key")]
        [ValidateNotNullOrEmpty]
        public SecureString StorageKey
        {
            get;
            set;
        }

        [Parameter(
          Mandatory = false,
          Position = 6,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Backup system databases")]
        public SwitchParameter BackupSystemDbs
        {
            get;
            set;
        }

        [Parameter(
          Mandatory = false,
          Position = 7,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Backup schedule type, manual or automated")]
        [ValidateSet("Manual", "Automatic")]
        public string BackupScheduleType
        {
            get;
            set;
        }

        [Parameter(
          Mandatory = false,
          Position = 8,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Sql Server Full Backup frequency, daily or weekly")]
        [ValidateSet("Daily", "Weekly")]
        public string FullBackupFrequency
        {
            get;
            set;
        }

        [Parameter(
          Mandatory = false,
          Position = 9,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Hour of the day (0-23) when the Sql Server Full Backup should start")]
        [ValidateRange(0,23)]
        public int FullBackupStartHour
        {
            get;
            set;
        }

        [Parameter(
          Mandatory = false,
          Position = 10,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Sql Server Full Backup window in hours")]
        [ValidateRange(1, 23)]
        public int FullBackupWindowInHours
        {
            get;
            set;
        }

        [Parameter(
          Mandatory = false,
          Position = 11,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Sql Server Log Backup frequency, once every 1-60 minutes")]
        [ValidateRange(1, 60)]
        public int LogBackupFrequencyInMinutes
        {
            get;
            set;
        }

        /// <summary>
        /// Initialzies a new instance of the <see cref="NewAzureVMSqlServerAutoBackupConfigCommand"/> class.
        /// </summary>
        public NewAzureVMSqlServerAutoBackupConfigCommand()
        {
        }

        /// <summary>
        /// Creates and returns <see cref="AutoBackupSettings"/> object.
        /// </summary>
        protected override void ProcessRecord()
        {
            AutoBackupSettings autoBackupSettings = new AutoBackupSettings();

            autoBackupSettings.Enable = (Enable.IsPresent) ? Enable.ToBool() : false;
            autoBackupSettings.EnableEncryption = (EnableEncryption.IsPresent) ? EnableEncryption.ToBool() : false;
            autoBackupSettings.RetentionPeriod = RetentionPeriodInDays;

            switch (ParameterSetName)
            {
                case StorageContextParamSetName:
                    autoBackupSettings.StorageUrl = StorageContext.BlobEndPoint;
                    autoBackupSettings.StorageAccessKey = this.GetStorageKey();
                    break;

                case StorageUriParamSetName:
                    autoBackupSettings.StorageUrl = (StorageUri == null) ? null : StorageUri.ToString();
                    autoBackupSettings.StorageAccessKey = (StorageKey == null) ? null : ConvertToUnsecureString(StorageKey);
                    break;
            }

            // Check if certificate password was set
            autoBackupSettings.Password = (CertificatePassword == null) ? null : ConvertToUnsecureString(CertificatePassword);

            autoBackupSettings.BackupSystemDbs = BackupSystemDbs.IsPresent ? BackupSystemDbs.ToBool() : false;
            autoBackupSettings.BackupScheduleType = BackupScheduleType;

            // Set other Backup schedule settings only if BackUpSchedule type is Manual.
            if (!string.IsNullOrEmpty(BackupScheduleType) && BackupScheduleType == "Manual") {
                autoBackupSettings.FullBackupFrequency = FullBackupFrequency;
                autoBackupSettings.FullBackupStartTime = FullBackupStartHour;
                autoBackupSettings.FullBackupWindowHours = FullBackupWindowInHours;
                autoBackupSettings.LogBackupFrequency = LogBackupFrequencyInMinutes;
            }

            WriteObject(autoBackupSettings);
        }

        protected string GetStorageKey()
        {
            string storageKey = string.Empty;
            string storageName = (this.StorageContext == null) ? null : this.StorageContext.StorageAccountName;

            if (!string.IsNullOrEmpty(storageName))
            {
                var storageClient = AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.Context,
                        AzureEnvironment.Endpoint.ResourceManager);

                var storageAccount = storageClient.StorageAccounts.GetProperties(this.ResourceGroupName, storageName);

                if (storageAccount != null)
                {
                    var keys = storageClient.StorageAccounts.ListKeys(this.ResourceGroupName, storageName);

                    if (keys != null)
                    {
                        storageKey = !string.IsNullOrEmpty(keys.Key1) ?
                            keys.Key1 :
                            keys.Key2;
                    }
                }
            }

            return storageKey;
        }

        /// <summary>
        /// convert secure string to regular string
        /// $Issue -  for ARM cmdlets, check if there is a similair helper class library like Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers
        /// </summary>
        /// <param name="securePassword"></param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
            {
                throw new ArgumentNullException("securePassword");
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
