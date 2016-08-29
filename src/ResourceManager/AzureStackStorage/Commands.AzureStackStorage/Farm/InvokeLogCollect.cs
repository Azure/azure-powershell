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

using Microsoft.AzureStack.Management.StorageAdmin;
using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Runtime.InteropServices;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsData.Export, Nouns.Log, SupportsShouldProcess = true)]
    public sealed class InvokeLogCollect : AdminCmdlet
    {
        /// <summary>
        ///     Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string FarmName { get; set; }

        /// <summary>
        /// StartTime
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Credential to run the log copy
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Blob Prefix for the uploaded logs
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string LogPrefix { get; set; }

        /// <summary>
        /// Azure blob name
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string AzureStorageContainer { get; set; }

        /// <summary>
        /// Azure Storage account name
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string AzureStorageAccountName { get; set; }

        /// <summary>
        /// Azure storage account key
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string AzureStorageAccountKey { get; set; }

        /// <summary>
        /// Azure SAS Token
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string AzureSasToken { get; set; }

        /// <summary>
        /// Target Share folder to save logs
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string TargetShareFolder { get; set; }

        protected override void Execute()
        {
            IntPtr valuePtr = IntPtr.Zero;
            string password;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(Credential.Password);
                password = Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }

            LogCollectParameters parameters = new LogCollectParameters
            {
                AzureBlobContainer = AzureStorageContainer,
                AzureSasToken = AzureSasToken,
                AzureStorageAccountKey = AzureStorageAccountKey,
                AzureStorageAccountName = AzureStorageAccountName,
                EndTime = EndTime,
                StartTime = StartTime,
                LogPrefix = LogPrefix,
                UserName = Credential.UserName,
                PlainPassword = password,
                TargetShareFolder = TargetShareFolder
            };

            var logCollectTask = Client.Farms.CollectLogAsync(ResourceGroupName, FarmName, parameters);

            WriteVerbose("Sending request to start a log Collect job, it will take some time...");

            var response = logCollectTask.Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new AdminException(string.Format(CultureInfo.InvariantCulture, Resources.OperationFailedErrorMessage, response.StatusCode));
            }

            WriteObject(response);
        }
    }
}

