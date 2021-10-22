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

using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Commands.HDInsight.Models.Management;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightClusterConfig"),OutputType(typeof(AzureHDInsightConfig))]
    public class NewAzureHDInsightClusterConfigCommand : HDInsightCmdletBase
    {
        private readonly AzureHDInsightConfig _config;

        #region Input Parameter Definitions

        [Parameter(HelpMessage = "Gets or sets the storage account resource id.")]
        public string StorageAccountResourceId
        {
            get { return _config.StorageAccountResourceId; }
            set { _config.StorageAccountResourceId = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the storage account access key.")]
        public string StorageAccountKey
        {
            get { return _config.StorageAccountKey; }
            set { _config.StorageAccountKey = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the type of the default storage account.")]
        public StorageType StorageAccountType
        {
            get { return _config.StorageAccountType; }
            set { _config.StorageAccountType = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Oozie.")]
        public AzureHDInsightMetastore OozieMetastore
        {
            get { return _config.OozieMetastore; }
            set { _config.OozieMetastore = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Hive.")]
        public AzureHDInsightMetastore HiveMetastore
        {
            get { return _config.HiveMetastore; }
            set { _config.HiveMetastore = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Head Node.")]
        public string HeadNodeSize
        {
            get { return _config.HeadNodeSize; }
            set { _config.HeadNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Data Node.")]
        public string WorkerNodeSize
        {
            get { return _config.WorkerNodeSize; }
            set { _config.WorkerNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Edge Node if available for the cluster type.")]
        public string EdgeNodeSize
        {
            get { return _config.EdgeNodeSize; }
            set { _config.EdgeNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Zookeeper Node.")]
        public string ZookeeperNodeSize
        {
            get { return _config.ZookeeperNodeSize; }
            set { _config.ZookeeperNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the flavor for a cluster.")]
        public string ClusterType
        {
            get { return _config.ClusterType; }
            set { _config.ClusterType = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the cluster tier for this HDInsight cluster.")]
        [PSArgumentCompleter(Tier.Standard, Tier.Premium)]
        public string ClusterTier
        {
            get { return _config.ClusterTier; }
            set { _config.ClusterTier = value; }
        }


        [Parameter(HelpMessage = "Gets or sets the Service Principal Object Id for accessing Azure Data Lake.")]
        public Guid ObjectId
        {
            get { return _config.ObjectId; }
            set { _config.ObjectId = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Application Id for accessing Azure Data Lake.")]
        public Guid ApplicationId
        {
            get { return _config.ApplicationId; }
            set { _config.ApplicationId = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Certificate file contents for accessing Azure Data Lake.")]
        public byte[] CertificateFileContents
        {
            get { return _config.CertificateFileContents; }
            set { _config.CertificateFileContents = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Certificate file path for accessing Azure Data Lake.")]
        public string CertificateFilePath
        {
            get { return _config.CertificateFilePath; }
            set { _config.CertificateFilePath = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Certificate Password for accessing Azure Data Lake.")]
        public string CertificatePassword
        {
            get { return _config.CertificatePassword; }
            set { _config.CertificatePassword = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the Service Principal AAD Tenant Id for accessing Azure Data Lake.")]
        public Guid AadTenantId
        {
            get { return _config.AADTenantId; }
            set { _config.AADTenantId = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the minimal supported TLS version.")]
        public string MinSupportedTlsVersion
        {
            get { return _config.MinSupportedTlsVersion; }
            set { _config.MinSupportedTlsVersion = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the assigned identity.")]
        public string AssignedIdentity
        {
            get { return _config.AssignedIdentity; }
            set { _config.AssignedIdentity = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the encryption algorithm.")]
        [PSArgumentCompleter(JsonWebKeyEncryptionAlgorithm.RSAOAEP, JsonWebKeyEncryptionAlgorithm.RSAOAEP256, JsonWebKeyEncryptionAlgorithm.RSA15)]
        public string EncryptionAlgorithm
        {
            get { return _config.EncryptionAlgorithm; }
            set { _config.EncryptionAlgorithm = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the encryption key name.")]
        public string EncryptionKeyName
        {
            get { return _config.EncryptionKeyName; }
            set { _config.EncryptionKeyName = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the encryption key version.")]
        public string EncryptionKeyVersion
        {
            get { return _config.EncryptionKeyVersion; }
            set { _config.EncryptionKeyVersion = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the encryption vault uri.")]
        public string EncryptionVaultUri
        {
            get { return _config.EncryptionVaultUri; }
            set { _config.EncryptionVaultUri = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the flag which indicates whether enable encryption in transit or not.")]
        public bool? EncryptionInTransit
        {
            get { return _config.EncryptionInTransit; }
            set { _config.EncryptionInTransit = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the flag which indicates whether enable encryption at host or not.")]
        public bool? EncryptionAtHost
        {
            get { return _config.EncryptionAtHost; }
            set { _config.EncryptionAtHost = value; }
        }

        #endregion

        public NewAzureHDInsightClusterConfigCommand()
        {
            _config = new AzureHDInsightConfig();
        }

        public override void ExecuteCmdlet()
        {
            WriteObject(_config);
        }
    }
}
