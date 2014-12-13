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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    public abstract class BaseAzureServiceDiagnosticsExtensionCmdlet : BaseAzureServiceExtensionCmdlet
    {
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

        protected string StorageKey { get; set; }
        protected string ConnectionQualifiers { get; set; }
        protected string DefaultEndpointsProtocol { get; set; }
        protected string Endpoint { get; set; }

        public virtual AzureStorageContext StorageContext { get; set; }
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
            StorageKey = GetStorageKey();
            Endpoint = "https://" + StorageContext.EndPointSuffix;
       }

        protected string GetStorageKey()
        {
            string storageKey = string.Empty;

            if (!string.IsNullOrEmpty(StorageContext.StorageAccountName))
            {
                var storageAccount = this.StorageClient.StorageAccounts.Get(StorageContext.StorageAccountName);
                if (storageAccount != null)
                {
                    var keys = this.StorageClient.StorageAccounts.GetKeys(StorageContext.StorageAccountName);
                    if (keys != null)
                    {
                        storageKey = !string.IsNullOrEmpty(keys.PrimaryKey) ? keys.PrimaryKey : keys.SecondaryKey;
                    }
                }
            }

            return storageKey;
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

                PublicConfiguration = sr.ReadToEnd();
            }

            // the element <StorageAccount> is not meant to be set by teh user in the public config. 
            // Make sure it matches the storage account in the private config.
            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", XmlNamespace);
            doc.Load(DiagnosticsConfigurationPath);
            var node = doc.SelectSingleNode("//ns:StorageAccount", ns);
            if(node != null)
            {
                if(node.InnerText == null)
                {
                    throw new ArgumentException(Resources.PaaSDiagnosticsNullStorageAccount);
                }
                if (string.Compare(node.InnerText, StorageContext.StorageAccountName, true) != 0)
                {
                    throw new ArgumentException(Resources.PassDiagnosticsNoMatchStorageAccount);
                }
            }
            else
            {
                // the StorageAccount is not there. we must set it
                string storageAccountElem = "\n<StorageAccount>" + StorageContext.StorageAccountName + "</StorageAccount>\n";
                // insert it after </WadCfg>
                int wadCfgEndIndex = PublicConfiguration.IndexOf("</WadCfg>");
                PublicConfiguration = PublicConfiguration.Insert(wadCfgEndIndex + "</WadCfg>".Length, storageAccountElem);
            }

            PrivateConfigurationXml = new XDocument(PrivateConfigurationXmlTemplate);
            SetPrivateConfigAttribute(StorageAccountElemStr, PrivConfNameAttr, StorageContext.StorageAccountName);
            SetPrivateConfigAttribute(StorageAccountElemStr, PrivConfKeyAttr, StorageKey);
            SetPrivateConfigAttribute(StorageAccountElemStr, PrivConfEndpointAttr, Endpoint);
            PrivateConfiguration = PrivateConfigurationXml.ToString();

        }
    }
}