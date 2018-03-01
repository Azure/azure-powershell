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
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Compute.Common
{
    public static class DiagnosticsHelper
    {
        private static string XmlNamespace = "http://schemas.microsoft.com/ServiceHosting/2010/10/DiagnosticsConfiguration";
        private static string EncodedXmlCfg = "xmlCfg";
        private static string WadCfg = "WadCfg";
        private static string StorageAccount = "storageAccount";
        private static string Path = "path";
        private static string ExpandResourceDirectory = "expandResourceDirectory";
        private static string LocalResourceDirectory = "localResourceDirectory";
        private static string StorageAccountNameTag = "storageAccountName";
        private static string StorageAccountKeyTag = "storageAccountKey";
        private static string StorageAccountEndPointTag = "storageAccountEndPoint";

        public static string DiagnosticsConfigurationElemStr = "DiagnosticsConfiguration";
        public static string PublicConfigElemStr = "PublicConfig";
        public static string PrivateConfigElemStr = "PrivateConfig";
        public static string StorageAccountElemStr = "StorageAccount";
        public static string PrivConfNameAttr = "name";
        public static string PrivConfKeyAttr = "key";
        public static string PrivConfEndpointAttr = "endpoint";

        public enum ConfigFileType
        {
            Unknown,
            Json,
            Xml
        }

        public static ConfigFileType GetConfigFileType(string configurationPath)
        {
            if (!string.IsNullOrEmpty(configurationPath))
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(configurationPath);
                    return ConfigFileType.Xml;
                }
                catch
                { }

                try
                {
                    JsonConvert.DeserializeObject(File.ReadAllText(configurationPath));
                    return ConfigFileType.Json;
                }
                catch
                { }
            }

            return ConfigFileType.Unknown;
        }

        public static Hashtable GetPublicDiagnosticsConfigurationFromFile(string configurationPath,
            string storageAccountName)
        {
            switch (GetConfigFileType(configurationPath))
            {
                case ConfigFileType.Xml:
                    return GetPublicConfigFromXmlFile(configurationPath, storageAccountName);
                case ConfigFileType.Json:
                    return GetPublicConfigFromJsonFile(configurationPath, storageAccountName);
                default:
                    throw new ArgumentException(Properties.Resources.DiagnosticsExtensionInvalidConfigFileFormat);
            }
        }

        private static Hashtable GetPublicConfigFromXmlFile(string configurationPath, string storageAccountName)
        {
            var config = File.ReadAllText(configurationPath);

            // find the <WadCfg> element and extract it
            int wadCfgBeginIndex = config.IndexOf("<WadCfg>");
            if (wadCfgBeginIndex == -1)
            {
                throw new ArgumentException(Properties.Resources.DiagnosticsExtensionXmlConfigNoWadCfgStartTag);
            }

            int wadCfgEndIndex = config.IndexOf("</WadCfg>");
            if (wadCfgEndIndex == -1)
            {
                throw new ArgumentException(Properties.Resources.DiagnosticsExtensionXmlConfigNoWadCfgEndTag);
            }

            if (wadCfgEndIndex <= wadCfgBeginIndex)
            {
                throw new ArgumentException(Properties.Resources.DiagnosticsExtensionXmlConfigWadCfgTagNotMatch);
            }

            string encodedConfiguration = Convert.ToBase64String(
                Encoding.UTF8.GetBytes(
                    config.Substring(
                        wadCfgBeginIndex, wadCfgEndIndex + "</WadCfg>".Length - wadCfgBeginIndex).ToCharArray()));

            // Now extract the local resource directory element
            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("ns", XmlNamespace);
            doc.LoadXml(config);
            var node = doc.SelectSingleNode("//ns:LocalResourceDirectory", ns);
            string localDirectory = (node != null && node.Attributes != null) ? node.Attributes[Path].Value : null;
            string localDirectoryExpand = (node != null && node.Attributes != null)
                ? node.Attributes["expandEnvironment"].Value
                : null;
            if (localDirectoryExpand == "0")
            {
                localDirectoryExpand = "false";
            }
            if (localDirectoryExpand == "1")
            {
                localDirectoryExpand = "true";
            }

            var hashTable = new Hashtable();
            hashTable.Add(EncodedXmlCfg, encodedConfiguration);
            hashTable.Add(StorageAccount, storageAccountName);
            if (!string.IsNullOrEmpty(localDirectory))
            {
                var localDirectoryHashTable = new Hashtable();
                localDirectoryHashTable.Add(Path, localDirectory);
                localDirectoryHashTable.Add(ExpandResourceDirectory, localDirectoryExpand);
                hashTable.Add(LocalResourceDirectory, localDirectoryHashTable);
            }

            return hashTable;
        }

        private static Hashtable GetPublicConfigFromJsonFile(string configurationPath, string storageAccountName)
        {
            var publicConfig = GetPublicConfigJObjectFromJsonFile(configurationPath);
            var properties = publicConfig.Properties().Select(p => p.Name);
            var wadCfgProperty = properties.FirstOrDefault(p => p.Equals(WadCfg, StringComparison.OrdinalIgnoreCase));
            var xmlCfgProperty = properties.FirstOrDefault(p => p.Equals(EncodedXmlCfg, StringComparison.OrdinalIgnoreCase));

            var hashTable = new Hashtable();
            hashTable.Add(StorageAccount, storageAccountName);

            if (wadCfgProperty != null)
            {
                hashTable.Add(wadCfgProperty, publicConfig[wadCfgProperty]);
            }
            else if (xmlCfgProperty != null)
            {
                hashTable.Add(xmlCfgProperty, publicConfig[xmlCfgProperty]);
            }
            else
            {
                throw new ArgumentException(Properties.Resources.DiagnosticsExtensionConfigNoWadCfgOrXmlCfg);
            }

            return hashTable;
        }

        public static Hashtable GetPrivateDiagnosticsConfiguration(string storageAccountName,
            string storageKey, string endpoint)
        {
            var privateConfig = new Hashtable();
            privateConfig.Add(StorageAccountNameTag, storageAccountName);
            privateConfig.Add(StorageAccountKeyTag, storageKey);
            privateConfig.Add(StorageAccountEndPointTag, endpoint);

            return privateConfig;
        }

        public static XElement GetPublicConfigXElementFromXmlFile(string configurationPath)
        {
            XElement publicConfig = null;

            if (!string.IsNullOrEmpty(configurationPath))
            {
                var xmlConfig = XElement.Load(configurationPath);

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

            return publicConfig;
        }

        public static JObject GetPublicConfigJObjectFromJsonFile(string configurationPath)
        {
            var config = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(configurationPath));
            var properties = config.Properties().Select(p => p.Name);

            // If the json config has the public config as a property, we extract it. Otherwise, the root object is the public config.
            var publicConfigProperty = properties.FirstOrDefault(p => p.Equals(PublicConfigElemStr, StringComparison.OrdinalIgnoreCase));
            var publicConfig = publicConfigProperty == null ? config : config[publicConfigProperty] as JObject;

            return publicConfig;
        }

        public static string GetStorageAccountInfoFromPrivateConfig(string configurationPath, string attributeName)
        {
            string value = null;
            var configFileType = GetConfigFileType(configurationPath);

            if (configFileType == ConfigFileType.Xml)
            {
                var xmlConfig = XElement.Load(configurationPath);

                if (xmlConfig.Name.LocalName == DiagnosticsConfigurationElemStr)
                {
                    var privateConfigElem = xmlConfig.Elements().FirstOrDefault(ele => ele.Name.LocalName == PrivateConfigElemStr);
                    var storageAccountElem = privateConfigElem == null ? null : privateConfigElem.Elements().FirstOrDefault(ele => ele.Name.LocalName == StorageAccountElemStr);
                    var attribute = storageAccountElem == null ? null : storageAccountElem.Attributes().FirstOrDefault(a => string.Equals(a.Name.LocalName, attributeName));
                    value = attribute == null ? null : attribute.Value;
                }
            }
            else if (configFileType == ConfigFileType.Json)
            {
                var jsonConfig = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(configurationPath));
                var properties = jsonConfig.Properties().Select(p => p.Name);

                var privateConfigProperty = properties.FirstOrDefault(p => p.Equals(PrivateConfigElemStr, StringComparison.OrdinalIgnoreCase));
                if (privateConfigProperty != null)
                {
                    var privateConfig = jsonConfig[privateConfigProperty] as JObject;
                    properties = privateConfig.Properties().Select(p => p.Name);

                    var attributeProperty = properties.FirstOrDefault(p => p.Equals(attributeName, StringComparison.OrdinalIgnoreCase));
                    value = attributeProperty == null ? null : privateConfig[attributeProperty].Value<string>();
                }
            }

            return value;
        }

        /// <summary>
        /// Initialize the storage account name if it's not specified.
        /// It can be defined in multiple places, we only take the one with higher precedence. And the precedence is:
        /// 1. The one get from StorageContext parameter
        /// 2. The one parsed from the diagnostics configuration file
        /// </summary>
        public static string InitializeStorageAccountName(IStorageContext storageContext = null, string configurationPath = null)
        {
            string storageAccountName = null;
            var configFileType = GetConfigFileType(configurationPath);

            if (storageContext != null)
            {
                storageAccountName = storageContext.StorageAccountName;
            }
            else if (configFileType == ConfigFileType.Xml)
            {
                var publicConfig = GetPublicConfigXElementFromXmlFile(configurationPath);
                var storageNode = publicConfig == null ? null : publicConfig.Elements().FirstOrDefault(ele => ele.Name.LocalName == StorageAccountElemStr);
                storageAccountName = storageNode == null ? null : storageNode.Value;
            }
            else if (configFileType == ConfigFileType.Json)
            {
                var publicConfig = GetPublicConfigJObjectFromJsonFile(configurationPath);
                var properties = publicConfig.Properties().Select(p => p.Name);
                var storageAccountProperty = properties.FirstOrDefault(p => p.Equals(StorageAccount, StringComparison.OrdinalIgnoreCase));
                storageAccountName = storageAccountProperty == null ? null : publicConfig[storageAccountProperty].Value<string>();
            }

            return storageAccountName;
        }

        /// <summary>
        /// Initialize the storage account key if it's not specified.
        /// It can be defined in multiple places, we only take the one with higher precedence. And the precedence is:
        /// 1. The one we try to resolve within current subscription
        /// 2. The one defined in PrivateConfig in the configuration file
        /// </summary>
        public static string InitializeStorageAccountKey(IStorageManagementClient storageClient, string storageAccountName = null, string configurationPath = null)
        {
            string storageAccountKey = null;
            StorageAccount storageAccount = null;

            if (TryGetStorageAccount(storageClient, storageAccountName, out storageAccount))
            {
                // Help user retrieve the storage account key
                var psStorageAccount = new PSStorageAccount(storageAccount);
                var credentials = StorageUtilities.GenerateStorageCredentials(storageClient, psStorageAccount.ResourceGroupName, psStorageAccount.StorageAccountName);
                storageAccountKey = credentials.ExportBase64EncodedKey();
            }
            else
            {
                // Use the one defined in PrivateConfig
                storageAccountKey = GetStorageAccountInfoFromPrivateConfig(configurationPath, PrivConfKeyAttr);
            }

            return storageAccountKey;
        }

        /// <summary>
        /// Initialize the storage account endpoint if it's not specified.
        /// We can get the value from multiple places, we only take the one with higher precedence. And the precedence is:
        /// 1. The one get from StorageContext parameter
        /// 2. The one get from the storage account
        /// 3. The one get from PrivateConfig element in config file
        /// 4. The one get from current Azure Environment
        /// </summary>
        public static string InitializeStorageAccountEndpoint(string storageAccountName, string storageAccountKey, IStorageManagementClient storageClient,
            IStorageContext storageContext = null, string configurationPath = null, IAzureContext defaultContext = null)
        {
            string storageAccountEndpoint = null;
            StorageAccount storageAccount = null;

            if (storageContext != null)
            {
                // Get value from StorageContext
                storageAccountEndpoint = GetEndpointFromStorageContext(storageContext);
            }
            else if (TryGetStorageAccount(storageClient, storageAccountName, out storageAccount))
            {
                // Get value from StorageAccount
                var endpoints = storageAccount.PrimaryEndpoints;
                var context = CreateStorageContext(endpoints.Blob, endpoints.Queue, endpoints.Table, endpoints.File, storageAccountName, storageAccountKey);
                storageAccountEndpoint = GetEndpointFromStorageContext(context);
            }
            else if (!string.IsNullOrEmpty(
                storageAccountEndpoint = GetStorageAccountInfoFromPrivateConfig(configurationPath, PrivConfEndpointAttr)))
            {
                // We can get the value from PrivateConfig
            }
            else if (defaultContext != null && defaultContext.Environment != null)
            {
                // Get value from default azure environment. Default to use https
                Uri blobEndpoint = defaultContext.Environment.GetStorageBlobEndpoint(storageAccountName);
                Uri queueEndpoint = defaultContext.Environment.GetStorageQueueEndpoint(storageAccountName);
                Uri tableEndpoint = defaultContext.Environment.GetStorageTableEndpoint(storageAccountName);
                Uri fileEndpoint = defaultContext.Environment.GetStorageFileEndpoint(storageAccountName);
                var context = CreateStorageContext(blobEndpoint, queueEndpoint, tableEndpoint, fileEndpoint, storageAccountName, storageAccountKey);
                storageAccountEndpoint = GetEndpointFromStorageContext(context);
            }

            return storageAccountEndpoint;
        }

        private static bool TryGetStorageAccount(IStorageManagementClient storageClient, string storageAccountName, out StorageAccount storageAccount)
        {
            try
            {
                var storageAccounts = storageClient.StorageAccounts.List().StorageAccounts;
                storageAccount = storageAccounts == null ? null : storageAccounts.FirstOrDefault(account => account.Name.Equals(storageAccountName));
            }
            catch
            {
                storageAccount = null;
            }

            return storageAccount != null;
        }

        private static AzureStorageContext CreateStorageContext(Uri blobEndpoint, Uri queueEndpoint, Uri tableEndpoint, Uri fileEndpoint,
            string storageAccountName, string storageAccountKey)
        {
            var credentials = new StorageCredentials(storageAccountName, storageAccountKey);
            var cloudStorageAccount = new CloudStorageAccount(credentials, blobEndpoint, queueEndpoint, tableEndpoint, fileEndpoint);
            return new AzureStorageContext(cloudStorageAccount);
        }

        private static string GetEndpointFromStorageContext(IStorageContext context)
        {
            var scheme = context.BlobEndPoint.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? "https://" : "http://";
            return scheme + context.EndPointSuffix;
        }
    }
}
