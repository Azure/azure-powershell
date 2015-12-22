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
using System.Xml;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    public abstract class BaseAzureServiceDiagnosticsExtensionCmdlet : BaseAzureServiceExtensionCmdlet
    {
        protected const string DiagnosticsConfigurationElemStr = "DiagnosticsConfiguration";
        protected const string PublicConfigElemStr = "PublicConfig";
        protected const string PrivateConfigElemStr = "PrivateConfig";
        protected const string StorageAccountElemStr = "StorageAccount";
        protected const string LocalResourceDirElemStr = "LocalResourceDirectory";
        protected const string StorageNameAttrStr = "name";
        protected const string PrivConfNameAttr = "name";
        protected const string PrivConfKeyAttr = "key";
        protected const string PrivConfEndpointAttr = "endpoint";
        protected const string StorageKeyElemStr = "StorageKey";
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
                    new XElement(configNameSpace + StorageAccountElemStr,
                    new XAttribute(PrivConfNameAttr, string.Empty),
                    new XAttribute(PrivConfKeyAttr, string.Empty),
                    new XAttribute(PrivConfEndpointAttr, string.Empty)
                ))
            );
        }

        protected void ValidateStorageAccount()
        {
            ValidateStorageAccountName();

            StorageAccount storageAccount = null;
            try
            {
                storageAccount = this.StorageClient.StorageAccounts.Get(StorageAccountName).StorageAccount;
            }
            catch
            {
            }

            ValidateStorageAccountKey(storageAccount);
            ValidateStorageAccountEndpoint(storageAccount);
        }

        /// <summary>
        /// Make sure the storage account name is set.
        /// It can be defined in multiple places, we only take the one with higher precedence. And the precedence is:
        /// 1. Directly specified from command line parameter
        /// 2. The one get from StorageContext parameter
        /// 3. The one parsed from the diagnostics configuration file
        /// </summary>
        private void ValidateStorageAccountName()
        {
            if (string.IsNullOrEmpty(this.StorageAccountName))
            {
                if (this.StorageContext != null)
                {
                    this.StorageAccountName = this.StorageContext.StorageAccountName;
                }
                else if (!string.IsNullOrEmpty(this.DiagnosticsConfigurationPath))
                {
                    var publicConfig = GetPublicConfigElement();
                    var storageNode = publicConfig == null ? null : publicConfig.Elements().FirstOrDefault(ele => ele.Name.LocalName == StorageAccountElemStr);
                    if (storageNode == null)
                    {
                        throw new ArgumentNullException(Properties.Resources.PaaSDiagnosticsNullStorageAccount);
                    }
                    else
                    {
                        this.StorageAccountName = storageNode.Value;
                    }
                }
                else
                {
                    throw new ArgumentNullException(Properties.Resources.PaaSDiagnosticsNullStorageAccount);
                }
            }
        }

        /// <summary>
        /// Try to fill in the storage key.
        /// It can be defined in multiple places, we only take the one with higher precedence. And the precedence is:
        /// 1. Directly specified from command line parameter
        /// 2. The one we try to resolve within current subscription
        /// 3. The one defined in PrivateConfig in the configuration file
        /// </summary>
        private void ValidateStorageAccountKey(StorageAccount storageAccount)
        {
            if (string.IsNullOrEmpty(this.StorageAccountKey))
            {
                if (storageAccount != null)
                {
                    // Help user retrieve the storage account key
                    var keys = this.StorageClient.StorageAccounts.GetKeys(storageAccount.Name);
                    if (keys != null)
                    {
                        this.StorageAccountKey = !string.IsNullOrEmpty(keys.PrimaryKey) ? keys.PrimaryKey : keys.SecondaryKey;
                    }
                }
                else
                {
                    // Use the one defined in PrivateConfig
                    this.StorageAccountKey = GetStorageAccountInfoFromPrivateConfig(PrivConfKeyAttr);
                }
            }

            if (string.IsNullOrEmpty(this.StorageAccountKey))
            {
                throw new ArgumentException(Resources.PaaSDiagnosticsNullStorageAccountKey);
            }
        }

        /// <summary>
        /// Make sure we set the correct storage account endpoint.
        /// We can get the value from multiple places, we only take the one with higher precedence. And the precedence is:
        /// 1. Directly specified from command line parameter
        /// 2. The one get from StorageContext parameter
        /// 3. The one get from the storage account
        /// 4. The one get from PrivateConfig element in config file
        /// 5. The one get from current Azure Environment
        /// </summary>
        /// <param name="storageAccount">The storage account to help get the endpoint.</param>
        private void ValidateStorageAccountEndpoint(StorageAccount storageAccount)
        {
            if (string.IsNullOrEmpty(this.StorageAccountEndpoint))
            {
                if (this.StorageContext != null)
                {
                    // Get value from StorageContext
                    this.StorageAccountEndpoint = GetEndpointFromStorageContext(this.StorageContext);
                }
                else if (storageAccount != null && storageAccount.Properties.Endpoints.Count >= 4)
                {
                    // Get value from StorageAccount
                    var endpoints = storageAccount.Properties.Endpoints;
                    var context = CreateStorageContext(endpoints[0], endpoints[1], endpoints[2], endpoints[3]);
                    this.StorageAccountEndpoint = GetEndpointFromStorageContext(context);
                }
                else if (!string.IsNullOrEmpty(GetStorageAccountInfoFromPrivateConfig(PrivConfEndpointAttr)))
                {
                    // Get value from PrivateConfig
                    this.StorageAccountEndpoint = GetStorageAccountInfoFromPrivateConfig(PrivConfEndpointAttr);
                }
                else if (this.DefaultContext != null && this.DefaultContext.Environment != null)
                {
                    // Get value from default azure environment. Default to use https
                    Uri blobEndpoint = DefaultContext.Environment.GetStorageBlobEndpoint(this.StorageAccountName);
                    Uri queueEndpoint = DefaultContext.Environment.GetStorageQueueEndpoint(this.StorageAccountName);
                    Uri tableEndpoint = DefaultContext.Environment.GetStorageTableEndpoint(this.StorageAccountName);
                    Uri fileEndpoint = DefaultContext.Environment.GetStorageFileEndpoint(this.StorageAccountName);
                    var context = CreateStorageContext(blobEndpoint, queueEndpoint, tableEndpoint, fileEndpoint);
                    this.StorageAccountEndpoint = GetEndpointFromStorageContext(context);
                }
            }

            if (string.IsNullOrEmpty(this.StorageAccountEndpoint))
            {
                throw new ArgumentNullException(Properties.Resources.PaaSDiagnosticsNullStorageAccountEndpoint);
            }
        }

        private AzureStorageContext CreateStorageContext(Uri blobEndpoint, Uri queueEndpoint, Uri tableEndpoint, Uri fileEndpoint)
        {
            var credentials = new StorageCredentials(this.StorageAccountName, this.StorageAccountKey);
            var cloudStorageAccount = new CloudStorageAccount(credentials, blobEndpoint, queueEndpoint, tableEndpoint, fileEndpoint);
            return new AzureStorageContext(cloudStorageAccount);
        }

        private string GetEndpointFromStorageContext(AzureStorageContext context)
        {
            var scheme = context.BlobEndPoint.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? "https://" : "http://";
            return scheme + context.EndPointSuffix;
        }

        protected override void ValidateConfiguration()
        {
            using (StreamReader sr = new StreamReader(DiagnosticsConfigurationPath))
            {
                string header = sr.ReadLine();
                // make sure it is the header
                if (!header.Trim().StartsWith("<?xml"))
                {
                    throw new ArgumentException(Resources.PaaSDiagnosticsWrongHeader);
                }
            }

            var publicConfigElem = GetPublicConfigElement();
            if (publicConfigElem == null)
            {
                throw new ArgumentException(Resources.PaaSDiagnosticsNullPublicConfig);
            }
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
                if (!string.IsNullOrEmpty(node.InnerText) && string.Compare(node.InnerText, StorageAccountName, true) != 0)
                {
                    throw new ArgumentException(Resources.PassDiagnosticsNoMatchStorageAccount);
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
            var privateConfigStorageAccountName = GetStorageAccountInfoFromPrivateConfig(PrivConfNameAttr);
            if (!string.IsNullOrEmpty(privateConfigStorageAccountName)
                && !string.Equals(StorageAccountName, privateConfigStorageAccountName, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(Resources.PassDiagnosticsNoMatchPrivateStorageAccount);
            }

            PrivateConfigurationXml = new XDocument(PrivateConfigurationXmlTemplate);
            SetPrivateConfigAttribute(StorageAccountElemStr, PrivConfNameAttr, StorageAccountName);
            SetPrivateConfigAttribute(StorageAccountElemStr, PrivConfKeyAttr, StorageAccountKey);
            SetPrivateConfigAttribute(StorageAccountElemStr, PrivConfEndpointAttr, StorageAccountEndpoint);
            PrivateConfiguration = PrivateConfigurationXml.ToString();
        }

        private XElement GetPublicConfigElement()
        {
            XElement publicConfig = null;

            if (!string.IsNullOrEmpty(this.DiagnosticsConfigurationPath))
            {
                var xmlConfig = XElement.Load(this.DiagnosticsConfigurationPath);

                if (xmlConfig.Name.LocalName == PublicConfigElemStr)
                {
                    // The passed in config file is public config
                    publicConfig = xmlConfig;
                }
                else if (xmlConfig.Name.LocalName == DiagnosticsConfigurationElemStr)
                {
                    // The passed in config file is .wadcfgx file
                    publicConfig = xmlConfig.Elements().FirstOrDefault(ele => ele.Name.LocalName == PublicConfigElemStr);
                }
            }

            if (publicConfig != null)
            {
                publicConfig.SetAttributeValue("xmlns", XmlNamespace);
            }

            return publicConfig;
        }

        private string GetStorageAccountInfoFromPrivateConfig(string attributeName)
        {
            string value = null;

            if (!string.IsNullOrEmpty(this.DiagnosticsConfigurationPath))
            {
                var xmlConfig = XElement.Load(this.DiagnosticsConfigurationPath);

                if (xmlConfig.Name.LocalName == DiagnosticsConfigurationElemStr)
                {
                    var privateConfigElem = xmlConfig.Elements().FirstOrDefault(ele => ele.Name.LocalName == PrivateConfigElemStr);
                    var storageAccountElem = privateConfigElem == null ? null : privateConfigElem.Elements().FirstOrDefault(ele => ele.Name.LocalName == StorageAccountElemStr);
                    var attribute = storageAccountElem == null ? null : storageAccountElem.Attributes().FirstOrDefault(a => string.Equals(a.Name.LocalName, attributeName));
                    value = attribute == null ? null : attribute.Value;
                }
            }

            return value;
        }
    }
}