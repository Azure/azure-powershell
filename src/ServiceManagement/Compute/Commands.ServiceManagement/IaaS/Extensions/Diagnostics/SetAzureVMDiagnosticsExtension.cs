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
using System.Management.Automation;
using System.Text;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Common.Storage;
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
        protected const string SetExtParamSetName = "SetDiagnosticsExtension";
        protected const string SetExtRefParamSetName = "SetDiagnosticsWithReferenceExtension";
        private const string PublicConfigurationTemplate = "\"xmlCfg\":\"{0}\", \"StorageAccount\":\"{1}\" ";
        private readonly string PrivateConfigurationTemplate = "\"storageAccountName\":\"{0}\", \"storageAccountKey\":\"{1}\", \"storageAccountEndPoint\":\"{2}\"";
        private readonly string XmlNamespace = "http://schemas.microsoft.com/ServiceHosting/2010/10/DiagnosticsConfiguration";
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
            ValidateStorageAccount();
            ValidateConfiguration();
            ExtensionName = DiagnosticsExtensionType;
            Publisher = DiagnosticsExtensionNamespace;
        }

        private void ValidateStorageAccount()
        {
            StorageAccountName = StorageContext.StorageAccountName;
            StorageKey = GetStorageKey();
            // We need the suffix, NOT the full account endpoint.
            Endpoint = "https://" + StorageContext.EndPointSuffix;
        }

        private void ValidateConfiguration()
        {
            // Public configuration must look like:
            // { "xmlCfg":"base-64 encoded string", "StorageAccount":"account_name", "localResourceDirectory":{ "path":"some_path", "expandResourceDirectory":<true|false> }}
            //
            // localResourceDirectory is optional
            //
            // What we have in is something like:
            //
            // <?xml version="1.0" encoding="utf-8"?>     
            //  <PublicConfig ...>
            //    <WadCfg>
            //      <DiagnosticsMonitorCofiguration> ... </DiagnosticsMonitorCofiguration>
            //    </WadCfg>
            //  </PublicConfig

            string config;
            using (StreamReader sr = new StreamReader(DiagnosticsConfigurationPath))
            {
                // find the <WadCfg> element and extract it
                string fullConfig = sr.ReadToEnd();
                int wadCfgBeginIndex = fullConfig.IndexOf("<WadCfg>");
                if (wadCfgBeginIndex == -1)
                {
                    throw new ArgumentException(Resources.IaasDiagnosticsBadConfigNoWadCfg);
                }

                int wadCfgEndIndex = fullConfig.IndexOf("</WadCfg>");
                if(wadCfgEndIndex == -1)
                {
                    throw new ArgumentException(Resources.IaasDiagnosticsBadConfigNoEndWadCfg);
                }

                if(wadCfgEndIndex <= wadCfgBeginIndex)
                {
                    throw new ArgumentException(Resources.IaasDiagnosticsBadConfigNoMatchingWadCfg);
                }

                config = fullConfig.Substring(wadCfgBeginIndex, wadCfgEndIndex + "</WadCfg>".Length - wadCfgBeginIndex);
                config = Convert.ToBase64String(Encoding.UTF8.GetBytes(config.ToCharArray()));
            }

            // Now extract the local resource directory element
            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", XmlNamespace);
            doc.Load(DiagnosticsConfigurationPath);
            var node = doc.SelectSingleNode("//ns:LocalResourceDirectory", ns);
            string localDirectory = (node != null && node.Attributes != null) ? node.Attributes["path"].Value : null;
            string localDirectoryExpand = (node != null && node.Attributes != null) ? node.Attributes["expandEnvironment"].Value : null;
            if (localDirectoryExpand == "0")
            {
                localDirectoryExpand = "false";
            }
            if (localDirectoryExpand == "1")
            {
                localDirectoryExpand = "true";
            }

            PublicConfiguration = "{ ";
            PublicConfiguration += string.Format(PublicConfigurationTemplate, config, StorageAccountName);

            if (!string.IsNullOrEmpty(localDirectory))
            {
                PublicConfiguration += ", \"localResourceDirectory\":{ \"path\":\"" + localDirectory + "\", \"expandResourceDirectory\":" + localDirectoryExpand + "}";
            }

            PublicConfiguration += "}";   

            // Private configuration must look like:
            // { "storageAccountName":"your_account_name", "storageAccountKey":"your_key", "storageAccountEndPoint":"end_point" }
            PrivateConfiguration = "{ ";
            PrivateConfiguration += string.Format(PrivateConfigurationTemplate, StorageAccountName, StorageKey, Endpoint);
            PrivateConfiguration += "}";
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