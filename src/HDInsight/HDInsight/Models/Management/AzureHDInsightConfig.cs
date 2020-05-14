﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.HDInsight.Models.Management;
using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightConfig
    {
        /// <summary>
        /// Gets additional Azure Storage Account that you want to enable access to.
        /// </summary>
        public Dictionary<string, string> AdditionalStorageAccounts { get; private set; }

        /// <summary>
        /// Gets or sets the StorageType for the default Azure Storage Account.
        /// </summary>
        public StorageType DefaultStorageAccountType { get; set; }

        /// <summary>
        /// Gets or sets the StorageName for the default Azure Storage Account.
        /// </summary>
        public string DefaultStorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets the storage key for the default Azure Storage Account.
        /// </summary>
        public string DefaultStorageAccountKey { get; set; }

        /// <summary>
        /// Gets or sets the size of the Head Node.
        /// </summary>
        public string HeadNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the Data Node.
        /// </summary>
        public string WorkerNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the Edge Node if supported by the cluster type.
        /// </summary>
        public string EdgeNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the Zookeeper Node.
        /// </summary>
        public string ZookeeperNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the flavor for a cluster.
        /// </summary>
        public string ClusterType { get; set; }

        /// <summary>
        /// Gets or sets the component version of a service in the cluster
        /// </summary>
        public Dictionary<string, string> ComponentVersion { get; set; }

        /// <summary>
        /// Gets or sets the cluster tier.
        /// </summary>
        public Tier ClusterTier { get; set; }

        /// <summary>
        /// Gets or sets the database to store the metadata for Oozie.
        /// </summary>
        public AzureHDInsightMetastore OozieMetastore { get; set; }

        /// <summary>
        /// Gets or sets the database to store the metadata for Hive.
        /// </summary>
        public AzureHDInsightMetastore HiveMetastore { get; set; }

        /// <summary>
        /// Gets Object id of the service principal. 
        /// </summary>
        public Guid ObjectId { get; set; }

        /// <summary>
        /// Gets Application id of the service principal. 
        /// </summary>
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// Gets the file path of the client certificate file contents associated with the service principal.
        /// </summary>
        public byte[] CertificateFileContents { get; set; }

        /// <summary>
        /// Gets the file path of the client certificate file associated with the service principal.
        /// </summary>
        public string CertificateFilePath { get; set; }

        /// <summary>
        /// Gets client certificate password associated with service principal.
        /// </summary>
        public string CertificatePassword { get; set; }

        /// <summary>
        /// Gets AAD tenant uri of the service principal
        /// </summary>
        public Guid AADTenantId { get; set; }

        /// <summary>
        /// Gets the configurations of this HDInsight cluster.
        /// </summary>
        public Dictionary<string, Hashtable> Configurations { get; private set; }

        /// <summary>
        /// Gets config actions for the cluster.
        /// </summary>
        public Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions { get; private set; }

        /// <summary>
        /// Gets or sets the security profile.
        /// </summary>
        /// <value>
        /// The security profile.
        /// </value>
        public AzureHDInsightSecurityProfile SecurityProfile { get; set; }

        /// <summary>
        /// Gets or sets the number of disks for worker node role for the cluster.
        /// </summary>
        public int DisksPerWorkerNode { get; set; }

        /// <summary>
        /// Gets or sets the minimal supported TLS version.
        /// </summary>
        public string MinSupportedTlsVersion { get; set; }

        /// <summary>
        /// Gets or sets the assigned identity.
        /// </summary>
        public string AssignedIdentity { get; set; }

        /// <summary>
        /// Gets or sets the encryption algorithm.
        /// </summary>
        public string EncryptionAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets the encryption key name.
        /// </summary>
        public string EncryptionKeyName { get; set; }

        /// <summary>
        /// Gets or sets the encryption key version.
        /// </summary>
        public string EncryptionKeyVersion { get; set; }

        /// <summary>
        /// Gets or sets the encryption vault uri.
        /// </summary>
        public string EncryptionVaultUri { get; set; }

        public AzureHDInsightConfig()
        {
            ClusterType = Constants.Hadoop;
            AdditionalStorageAccounts = new Dictionary<string, string>();
            Configurations = new Dictionary<string, Hashtable>();
            ScriptActions = new Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>>();
            ComponentVersion = new Dictionary<string, string>();
        }
    }
}
