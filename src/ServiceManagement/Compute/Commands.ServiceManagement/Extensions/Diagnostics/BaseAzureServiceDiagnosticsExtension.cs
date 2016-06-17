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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Management.Compute;

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

            XNamespace configNameSpace = DiagnosticsHelper.XmlNamespace;
            ProviderNamespace = DiagnosticsExtensionNamespace;
            ExtensionName = DiagnosticsExtensionType;
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

            var doc = XDocument.Load(DiagnosticsConfigurationPath);
            var publicConfigElement = doc.Descendants().FirstOrDefault(d => d.Name.LocalName == "PublicConfig");
            if (publicConfigElement == null)
            {
                throw new ArgumentException(Resources.DiagnosticsExtensionNullPublicConfig);
            }

            var wadCfgElement = doc.Descendants().FirstOrDefault(d => d.Name.LocalName == "WadCfg");
            var wadCfgBlobElement = doc.Descendants().FirstOrDefault(d => d.Name.LocalName == "WadCfgBlob");
            if (wadCfgElement == null && wadCfgBlobElement == null)
            {
                throw new ArgumentException(Resources.DiagnosticsExtensionPaaSConfigElementNotDefined);
            }

            if (wadCfgElement != null)
            {
                DiagnosticsHelper.AutoFillMetricsConfig(wadCfgElement, GetResourceId(), cmdlet: this);
            }

            // The element <StorageAccount> is not meant to be set by the user in the public config.
            // Make sure it matches the storage account in the private config.
            var storageAccountElement = publicConfigElement.Elements().FirstOrDefault(d => d.Name.LocalName == "StorageAccount");
            if (storageAccountElement == null)
            {
                // The StorageAccount element is not there, we create one
                XNamespace ns = XmlNamespace;
                storageAccountElement = new XElement(ns + "StorageAccount", StorageAccountName);
                publicConfigElement.Add(storageAccountElement);
            }
            else
            {
                if (!string.IsNullOrEmpty(storageAccountElement.Value) && string.Compare(storageAccountElement.Value, StorageAccountName, true) != 0)
                {
                    WriteWarning(Resources.DiagnosticsExtensionNoMatchStorageAccount);
                }
                storageAccountElement.SetValue(StorageAccountName);
            }

            PublicConfiguration = publicConfigElement.ToString();

            // Make sure the storage account name in PrivateConfig matches.
            var privateConfigStorageAccountName = DiagnosticsHelper.GetConfigValueFromPrivateConfig(this.DiagnosticsConfigurationPath, DiagnosticsHelper.StorageAccountElemStr, DiagnosticsHelper.PrivConfNameAttr);
            if (!string.IsNullOrEmpty(privateConfigStorageAccountName)
                && !string.Equals(StorageAccountName, privateConfigStorageAccountName, StringComparison.OrdinalIgnoreCase))
            {
                WriteWarning(Resources.DiagnosticsExtensionNoMatchPrivateStorageAccount);
            }

            // Look for the PrivateConfig element in the user provided config file.
            // If it doesn't exist (e.g., a pure PublicConfig.xml), we create the private config for the user.
            var privateConfigElement = doc.Descendants().FirstOrDefault(d => d.Name.LocalName == "PrivateConfig");
            if (privateConfigElement == null)
            {
                XNamespace configNameSpace = DiagnosticsHelper.XmlNamespace;
                privateConfigElement = new XElement(configNameSpace + PrivateConfigStr,
                    new XElement(configNameSpace + DiagnosticsHelper.StorageAccountElemStr,
                    new XAttribute(DiagnosticsHelper.PrivConfNameAttr, string.Empty),
                    new XAttribute(DiagnosticsHelper.PrivConfKeyAttr, string.Empty),
                    new XAttribute(DiagnosticsHelper.PrivConfEndpointAttr, string.Empty)
                ));
            }

            PrivateConfigurationXml = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                privateConfigElement
                );

            SetPrivateConfigAttribute(DiagnosticsHelper.StorageAccountElemStr, DiagnosticsHelper.PrivConfNameAttr, StorageAccountName);
            SetPrivateConfigAttribute(DiagnosticsHelper.StorageAccountElemStr, DiagnosticsHelper.PrivConfKeyAttr, StorageAccountKey);
            SetPrivateConfigAttribute(DiagnosticsHelper.StorageAccountElemStr, DiagnosticsHelper.PrivConfEndpointAttr, StorageAccountEndpoint);

            PrivateConfiguration = PrivateConfigurationXml.ToString();
        }

        private string GetResourceId()
        {
            string resourceGroup = null;
            foreach (var service in this.ComputeClient.HostedServices.List())
            {
                if (service.ServiceName == ServiceName
                    && service.Properties != null
                    && service.Properties.ExtendedProperties != null
                    && service.Properties.ExtendedProperties.ContainsKey("ResourceGroup"))
                {
                    resourceGroup = service.Properties.ExtendedProperties["ResourceGroup"];
                    break;
                }
            }

            return !string.IsNullOrEmpty(resourceGroup)
                ? string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.ClassicCompute/domainNames/{2}",
                    Profile.DefaultSubscription.Id, resourceGroup, ServiceName)
                : null;
        }
    }
}