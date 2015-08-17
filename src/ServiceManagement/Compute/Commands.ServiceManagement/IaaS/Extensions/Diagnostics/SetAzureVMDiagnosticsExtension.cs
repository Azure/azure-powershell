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

using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage;
using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    [Cmdlet(
        VerbsCommon.Set,
        VirtualMachineDiagnosticsExtensionNoun,
        DefaultParameterSetName = SetExtParamSetName),
    OutputType(
        typeof(IPersistentVM))]
    public class SetAzureVMDiagnosticsExtensionCommand : VirtualMachineDiagnosticsExtensionCmdletBase
    {
        private string publicConfiguration;
        private string privateConfiguration;
        private string storageKey;
        protected const string SetExtParamSetName = "SetDiagnosticsExtension";
        protected const string SetExtRefParamSetName = "SetDiagnosticsWithReferenceExtension";
        [Parameter(
            ParameterSetName = SetExtParamSetName,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "XML Diagnostics Configuration")]
        [Parameter(
            ParameterSetName = SetExtRefParamSetName,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "XML Diagnostics Configuration")]
        [ValidateNotNullOrEmpty]
        public string DiagnosticsConfigurationPath
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = SetExtParamSetName,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "The storage connection context")]
        [Parameter(ParameterSetName = SetExtRefParamSetName,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "The storage connection context")]
        [ValidateNotNullOrEmpty]
        public AzureStorageContext StorageContext
        {
            get;
            set;
        }
 

        [Parameter(
        ParameterSetName = SetExtParamSetName,
        Position = 2,
        ValueFromPipelineByPropertyName = false,
        HelpMessage = "WAD Version")]
        [Parameter(
        ParameterSetName = SetExtRefParamSetName,
        Position = 2,
        ValueFromPipelineByPropertyName = false,
        HelpMessage = "WAD Version")]
        public override string Version { get; set; }

        [Parameter(
            ParameterSetName = SetExtParamSetName,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To Set the Extension State to 'Disable'.")]
        [Parameter(
            ParameterSetName = SetExtRefParamSetName,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To Set the Extension State to 'Disable'.")]
        public override SwitchParameter Disable { get; set; }

        [Parameter(
            ParameterSetName = SetExtRefParamSetName,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To specify the reference name.")]
        public override string ReferenceName { get; set; }

        public string StorageAccountName
        {
            get
            {
                return this.StorageContext.StorageAccountName;
            }
        }

        public string Endpoint
        {
            get
            {
                return "https://" + this.StorageContext.EndPointSuffix;
            }
        }

        public string StorageKey
        {
            get
            {
                if (string.IsNullOrEmpty(this.storageKey))
                {
                    this.storageKey = GetStorageKey();
                }

                return this.storageKey;
            }
        }

        public override string PublicConfiguration
        {
            get
            {
                if (string.IsNullOrEmpty(this.publicConfiguration))
                {
                    this.publicConfiguration =
                        JsonConvert.SerializeObject(DiagnosticsHelper.GetPublicDiagnosticsConfigurationFromFile(this.DiagnosticsConfigurationPath,
                            this.StorageAccountName));
                }

                return this.publicConfiguration;
            }
        }

        public override string PrivateConfiguration
        {
            get
            {
                if (string.IsNullOrEmpty(this.privateConfiguration))
                {
                    this.privateConfiguration =
                        JsonConvert.SerializeObject(DiagnosticsHelper.GetPrivateDiagnosticsConfiguration(this.StorageAccountName, this.StorageKey,
                            this.Endpoint));
                }

                return this.privateConfiguration;
            }
        }


        internal void ExecuteCommand()
        {
            ValidateParameters();
            RemovePredicateExtensions();
            AddResourceExtension();
            WriteObject(VM);
            UpdateAzureVMCommand cmd = new UpdateAzureVMCommand();
        }

        protected override void ValidateParameters()
        {     
            base.ValidateParameters();
            ExtensionName = DiagnosticsExtensionType;
            Publisher = DiagnosticsExtensionNamespace;

            // If the user didn't specify an extension reference name and the input VM already has a diagnostics extension,
            // reuse its reference name
            if (string.IsNullOrEmpty(ReferenceName))
            {
                ResourceExtensionReference diagnosticsExtension = ResourceExtensionReferences.FirstOrDefault(ExtensionPredicate);
                if (diagnosticsExtension != null)
                {
                    ReferenceName = diagnosticsExtension.ReferenceName;
                }
            }
        }

        protected string GetStorageKey()
        {
            string storageKey = string.Empty;

            if (!string.IsNullOrEmpty(StorageAccountName))
            {
                var storageAccount = this.StorageClient.StorageAccounts.Get(StorageAccountName);
                if (storageAccount != null)
                {
                    var keys = this.StorageClient.StorageAccounts.GetKeys(StorageAccountName);
                    if (keys != null)
                    {
                        storageKey = !string.IsNullOrEmpty(keys.PrimaryKey) ? keys.PrimaryKey : keys.SecondaryKey;
                    }
                }
            }

            return storageKey;
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }
    }
}