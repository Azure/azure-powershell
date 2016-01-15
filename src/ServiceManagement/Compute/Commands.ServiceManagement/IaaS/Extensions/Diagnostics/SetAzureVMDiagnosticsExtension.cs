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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

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
            HelpMessage = "The storage account name")]
        [Parameter(ParameterSetName = SetExtRefParamSetName,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage account name")]
        public string StorageAccountName
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = SetExtParamSetName,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage account key")]
        [Parameter(ParameterSetName = SetExtRefParamSetName,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage account key")]
        public string StorageAccountKey
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = SetExtParamSetName,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage account endpoint")]
        [Parameter(ParameterSetName = SetExtRefParamSetName,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage account endpoint")]
        public string StorageAccountEndpoint
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = SetExtParamSetName,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage connection context")]
        [Parameter(ParameterSetName = SetExtRefParamSetName,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage connection context")]
        public AzureStorageContext StorageContext
        {
            get;
            set;
        }

        [Parameter(
        ParameterSetName = SetExtParamSetName,
        Position = 5,
        ValueFromPipelineByPropertyName = false,
        HelpMessage = "WAD Version")]
        [Parameter(
        ParameterSetName = SetExtRefParamSetName,
        Position = 5,
        ValueFromPipelineByPropertyName = false,
        HelpMessage = "WAD Version")]
        public override string Version { get; set; }

        [Parameter(
            ParameterSetName = SetExtParamSetName,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To Set the Extension State to 'Disable'.")]
        [Parameter(
            ParameterSetName = SetExtRefParamSetName,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To Set the Extension State to 'Disable'.")]
        public override SwitchParameter Disable { get; set; }

        [Parameter(
            ParameterSetName = SetExtRefParamSetName,
            Position = 7,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To specify the reference name.")]
        public override string ReferenceName { get; set; }

        public override string PublicConfiguration
        {
            get
            {
                if (string.IsNullOrEmpty(this.publicConfiguration))
                {
                    this.publicConfiguration = DiagnosticsHelper.GetJsonSerializedPublicDiagnosticsConfigurationFromFile(this.DiagnosticsConfigurationPath,
                            this.StorageAccountName);
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
                    this.privateConfiguration = DiagnosticsHelper.GetJsonSerializedPrivateDiagnosticsConfiguration(this.StorageAccountName, this.StorageAccountKey,
                            this.StorageAccountEndpoint);
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
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            ExtensionName = DiagnosticsExtensionType;
            Publisher = DiagnosticsExtensionNamespace;
            Version = Version ?? DefaultVersion;

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

            ValidateStorageAccountName();
            ValidateStorageAccountKey();
            ValidateStorageAccountEndpoint();
        }

        private void ValidateStorageAccountName()
        {
            this.StorageAccountName = this.StorageAccountName ??
                DiagnosticsHelper.InitializeStorageAccountName(this.StorageContext, this.DiagnosticsConfigurationPath);

            if (string.IsNullOrEmpty(this.StorageAccountName))
            {
                throw new ArgumentException(Resources.DiagnosticsExtensionNullStorageAccountName);
            }
        }

        private void ValidateStorageAccountKey()
        {
            this.StorageAccountKey = this.StorageAccountKey ??
                DiagnosticsHelper.InitializeStorageAccountKey(this.StorageClient, this.StorageAccountName, this.DiagnosticsConfigurationPath);

            if (string.IsNullOrEmpty(this.StorageAccountKey))
            {
                throw new ArgumentException(Resources.DiagnosticsExtensionNullStorageAccountKey);
            }
        }

        private void ValidateStorageAccountEndpoint()
        {
            this.StorageAccountEndpoint = this.StorageAccountEndpoint ??
                DiagnosticsHelper.InitializeStorageAccountEndpoint(this.StorageAccountName, this.StorageAccountKey, this.StorageClient,
                    this.StorageContext, this.DiagnosticsConfigurationPath, this.DefaultContext);

            if (string.IsNullOrEmpty(this.StorageAccountEndpoint))
            {
                throw new ArgumentNullException(Resources.DiagnosticsExtensionNullStorageAccountEndpoint);
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExecuteCommand();
        }
    }
}