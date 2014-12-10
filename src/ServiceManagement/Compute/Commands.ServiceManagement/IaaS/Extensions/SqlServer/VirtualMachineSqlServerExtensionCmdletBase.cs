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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// Base class for SQL extension specific cmdlets
    /// </summary>
    public class VirtualMachineSqlServerExtensionCmdletBase : VirtualMachineExtensionCmdletBase
    {
        protected const string VirtualMachineSqlServerExtensionNoun = "AzureVMSqlServerExtension";

        /// <summary>
        /// Extension's publisher name 
        /// </summary>
        protected const string ExtensionDefaultPublisher = "Microsoft.SqlServer.Management";

        /// <summary>
        /// Extension's name - 
        /// </summary>
        protected const string ExtensionDefaultName = "SqlIaaSAgent";

        /// <summary>
        /// Extension's default version 
        /// </summary>
        protected const string ExtensionDefaultVersion = "1.0";

        /// <summary>
        /// value of Auto-patching settings object that can be set by derived classes
        /// </summary>
        public virtual AutoPatchingSettings AutoPatchingSettings { get; set; }

        /// <summary>
        /// value of Auto-backup settings object that can be set by derived classes
        /// </summary>
        public virtual AutoBackupSettings AutoBackupSettings { get; set; }

        /// <summary>
        /// Sets extension's publisher and name
        /// </summary>
        public VirtualMachineSqlServerExtensionCmdletBase()
        {
            base.publisherName = ExtensionDefaultPublisher;
            base.extensionName = ExtensionDefaultName;
        }

        /// <summary>
        /// Returns the public configuration as string
        /// </summary>
        /// <returns></returns>
        protected string GetPublicConfiguration()
        {
            return JsonUtilities.TryFormatJson(JsonConvert.SerializeObject(
               new SqlServerPublicSettings
               {
                   AutoPatchingSettings = this.AutoPatchingSettings,
                   AutoBackupSettings = this.AutoBackupSettings
               }));
        }

        /// <summary>
        /// Returns private configuration as string
        /// </summary>
        /// <returns></returns>
        protected string GetPrivateConfiguration()
        {
            return JsonUtilities.TryFormatJson(JsonConvert.SerializeObject(
                       new SqlServerPrivateSettings
                       {
                           StorageUrl = (this.AutoBackupSettings == null)? string.Empty: this.AutoBackupSettings.StorageUrl,
                           StorageAccessKey = (this.AutoBackupSettings == null) ? string.Empty : this.AutoBackupSettings.StorageAccessKey,
                           Password = (this.AutoBackupSettings == null) ? string.Empty : this.AutoBackupSettings.Password
                       }));

        }
    }
}
