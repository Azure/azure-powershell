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
using System.Xml;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    public abstract class BaseAzureServiceDiagnosticsExtensionCmdlet : BaseAzureServiceExtensionCmdlet
    {
        protected const string WadCfgElemStr = "WadCfg";
        protected const string PathAttr = "path";
        protected const string ExpandEnvAttr = "expandEnvironment";
        protected const string DiagnosticsExtensionNamespace = "Microsoft.Azure.Diagnostics";
        protected const string DiagnosticsExtensionType = "PaaSDiagnostics";
        protected readonly string XmlNamespace = "http://schemas.microsoft.com/ServiceHosting/2010/10/DiagnosticsConfiguration";

        protected string ConnectionQualifiers { get; set; }
        protected string DefaultEndpointsProtocol { get; set; }

        public virtual AzureStorageContext StorageContext { get; set; }
        public virtual string StorageAccountName { get; set; }
        public virtual string StorageAccountKey { get; set; }
        public virtual string StorageAccountEndpoint { get; set; }
        public virtual string DiagnosticsConfigurationPath { get; set; }


        public BaseAzureServiceDiagnosticsExtensionCmdlet()
            : base()
        {
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();

            XNamespace configNameSpace = "http://schemas.microsoft.com/ServiceHosting/2010/10/DiagnosticsConfiguration";
            ProviderNamespace = DiagnosticsExtensionNamespace;
            ExtensionName = DiagnosticsExtensionType;

            PrivateConfigurationXmlTemplate = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(configNameSpace + PrivateConfigStr,
                    new XElement(configNameSpace + DiagnosticsHelper.StorageAccountElemStr,
                    new XAttribute(DiagnosticsHelper.PrivConfNameAttr, string.Empty),
                    new XAttribute(DiagnosticsHelper.PrivConfKeyAttr, string.Empty),
                    new XAttribute(DiagnosticsHelper.PrivConfEndpointAttr, string.Empty)
                ))
            );
        }

        protected void ValidateStorageAccount()
        {
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

        protected override void ValidateConfiguration()
        {
            using (StreamReader sr = new StreamReader(DiagnosticsConfigurationPath))
            {
                string header = sr.ReadLine();
                // make sure it is the header
                if (!header.Trim().StartsWith("<?xml"))
                {
                    throw new ArgumentException(Resources.DiagnosticsExtensionWrongHeader);
                }
            }

            var publicConfigElem = DiagnosticsHelper.GetPublicConfigElement(this.DiagnosticsConfigurationPath);
            if (publicConfigElem == null)
            {
                throw new ArgumentException(Resources.DiagnosticsExtensionNullPublicConfig);
            }
            publicConfigElem.SetAttributeValue("xmlns", XmlNamespace);
            PublicConfiguration = publicConfigElem.ToString();

            // The element <StorageAccount> is not meant to be set by the user in the public config.
            // Make sure it matches the storage account in the private config.
            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", XmlNamespace);
            doc.Load(DiagnosticsConfigurationPath);
            var node = doc.SelectSingleNode("//ns:StorageAccount", ns);
            if(node != null)
            {
                // The StorageAccount is empty, we must set it
                if (string.IsNullOrEmpty(node.InnerText))
                {
                    var insertIndex = PublicConfiguration.IndexOf("</StorageAccount>");
                    PublicConfiguration = PublicConfiguration.Insert(insertIndex, StorageAccountName);
                }
                else if (!string.IsNullOrEmpty(node.InnerText) && string.Compare(node.InnerText, StorageAccountName, true) != 0)
                {
                    throw new ArgumentException(Resources.DiagnosticsExtensionNoMatchStorageAccount);
                }
            }
            else
            {
                // the StorageAccount is not there. we must set it
                string storageAccountElem = "\n<StorageAccount>" + StorageAccountName + "</StorageAccount>\n";
                // insert it after </WadCfg>
                int wadCfgEndIndex = PublicConfiguration.IndexOf("</WadCfg>");
                PublicConfiguration = PublicConfiguration.Insert(wadCfgEndIndex + "</WadCfg>".Length, storageAccountElem);
            }

            // Make sure the storage account name in PrivateConfig matches.
            var privateConfigStorageAccountName = DiagnosticsHelper.GetStorageAccountInfoFromPrivateConfig(this.DiagnosticsConfigurationPath, DiagnosticsHelper.PrivConfNameAttr);
            if (!string.IsNullOrEmpty(privateConfigStorageAccountName)
                && !string.Equals(StorageAccountName, privateConfigStorageAccountName, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(Resources.DiagnosticsExtensionNoMatchPrivateStorageAccount);
            }

            PrivateConfigurationXml = new XDocument(PrivateConfigurationXmlTemplate);
            SetPrivateConfigAttribute(DiagnosticsHelper.StorageAccountElemStr, DiagnosticsHelper.PrivConfNameAttr, StorageAccountName);
            SetPrivateConfigAttribute(DiagnosticsHelper.StorageAccountElemStr, DiagnosticsHelper.PrivConfKeyAttr, StorageAccountKey);
            SetPrivateConfigAttribute(DiagnosticsHelper.StorageAccountElemStr, DiagnosticsHelper.PrivConfEndpointAttr, StorageAccountEndpoint);
            PrivateConfiguration = PrivateConfigurationXml.ToString();
        }
    }
}