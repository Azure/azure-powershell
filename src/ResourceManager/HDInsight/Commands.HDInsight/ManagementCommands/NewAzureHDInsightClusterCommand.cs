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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Commands.HDInsight.Models.Management;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.New,
        Constants.CommandNames.AzureHDInsightCluster,
        DefaultParameterSetName = DefaultParameterSet),
    OutputType(
        typeof(AzureHDInsightCluster))]
    public class NewAzureHDInsightClusterCommand : HDInsightCmdletBase
    {
        private ClusterCreateParameters parameters;
        private const string CertificateFilePathSet = "CertificateFilePath";
        private const string CertificateFileContentsSet = "CertificateFileContents";
        private const string DefaultParameterSet = "Default";

        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the datacenter location for the cluster.")]
        public string Location
        {
            get { return parameters.Location; }
            set { parameters.Location = value; }
        }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = "Gets or sets the number of workernodes for the cluster.")]
        public int ClusterSizeInNodes
        {
            get { return parameters.ClusterSizeInNodes; }
            set { parameters.ClusterSizeInNodes = value; }
        }

        [Parameter(
            Position = 4,
            Mandatory = true,
            HelpMessage = "Gets or sets the login for the cluster's user.")]
        public PSCredential HttpCredential { get; set; }

        [Parameter(
            Position = 5,
            HelpMessage = "Gets or sets the StorageName for the default Azure Storage Account.")]
        public string DefaultStorageAccountName
        {
            get { return parameters.DefaultStorageAccountName; }
            set { parameters.DefaultStorageAccountName = value; }
        }

        [Parameter(
            Position = 6,
            HelpMessage = "Gets or sets the StorageKey for the default Azure Storage Account.")]
        public string DefaultStorageAccountKey
        {
            get { return parameters.DefaultStorageAccountKey; }
            set { parameters.DefaultStorageAccountKey = value; }
        }

        [Parameter(ValueFromPipeline = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster.")]
        public AzureHDInsightConfig Config
        {
            get
            {
                var result = new AzureHDInsightConfig
                {
                    ClusterType = parameters.ClusterType,
                    ClusterTier = parameters.ClusterTier,
                    DefaultStorageAccountName = parameters.DefaultStorageAccountName,
                    DefaultStorageAccountKey = parameters.DefaultStorageAccountKey,
                    WorkerNodeSize = parameters.WorkerNodeSize,
                    HeadNodeSize = parameters.HeadNodeSize,
                    ZookeeperNodeSize = parameters.ZookeeperNodeSize,
                    HiveMetastore = HiveMetastore,
                    OozieMetastore = OozieMetastore,
                    ObjectId = ObjectId,
                    AADTenantId = AadTenantId,
                    CertificateFileContents = CertificateFileContents,
                    CertificateFilePath = CertificateFilePath,
                    CertificatePassword = CertificatePassword
                };
                foreach (
                    var storageAccount in
                        parameters.AdditionalStorageAccounts.Where(
                            storageAccount => !result.AdditionalStorageAccounts.ContainsKey(storageAccount.Key)))
                {
                    result.AdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
                }
                foreach (var val in parameters.Configurations.Where(val => !result.Configurations.ContainsKey(val.Key)))
                {
                    result.Configurations.Add(val.Key, DictionaryToHashtable(val.Value));
                }
                foreach (var action in parameters.ScriptActions.Where(action => !result.ScriptActions.ContainsKey(action.Key)))
                {
                    result.ScriptActions.Add(action.Key, action.Value.Select(a => new AzureHDInsightScriptAction(a)).ToList());
                }
                return result;
            }
            set
            {
                parameters.ClusterType = value.ClusterType;
                parameters.ClusterTier = value.ClusterTier;
                if (parameters.DefaultStorageAccountName == null)
                {
                    parameters.DefaultStorageAccountName = value.DefaultStorageAccountName;
                }
                if (parameters.DefaultStorageAccountKey == null)
                {
                    parameters.DefaultStorageAccountKey = value.DefaultStorageAccountKey;
                }
                parameters.WorkerNodeSize = value.WorkerNodeSize;
                parameters.HeadNodeSize = value.HeadNodeSize;
                parameters.ZookeeperNodeSize = value.ZookeeperNodeSize;
                HiveMetastore = value.HiveMetastore;
                OozieMetastore = value.OozieMetastore;
                CertificateFileContents = value.CertificateFileContents;
                CertificateFilePath = value.CertificateFilePath;
                AadTenantId = value.AADTenantId;
                ObjectId = value.ObjectId;
                CertificatePassword = value.CertificatePassword;

                foreach (
                    var storageAccount in
                        value.AdditionalStorageAccounts.Where(
                            storageAccount => !parameters.AdditionalStorageAccounts.ContainsKey(storageAccount.Key)))
                {
                    parameters.AdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
                }
                foreach (var val in value.Configurations.Where(val => !parameters.Configurations.ContainsKey(val.Key)))
                {
                    parameters.Configurations.Add(val.Key, HashtableToDictionary(val.Value));
                }
                foreach (var action in value.ScriptActions.Where(action => !parameters.ScriptActions.ContainsKey(action.Key)))
                {
                    parameters.ScriptActions.Add(action.Key, action.Value.Select(a => a.GetScriptActionFromPSModel()).ToList());
                }
            }
        }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Oozie.")]
        public AzureHDInsightMetastore OozieMetastore { get; set; }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Hive.")]
        public AzureHDInsightMetastore HiveMetastore { get; set; }

        [Parameter(HelpMessage = "Gets additional Azure Storage Account that you want to enable access to.")]
        public Dictionary<string, string> AdditionalStorageAccounts { get; private set; }

        [Parameter(HelpMessage = "Gets the configurations of this HDInsight cluster.")]
        public Dictionary<string, Dictionary<string, string>> Configurations { get; private set; }

        [Parameter(HelpMessage = "Gets config actions for the cluster.")]
        public Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions { get; private set; }

        [Parameter(HelpMessage = "Gets or sets the StorageContainer for the default Azure Storage Account.")]
        public string DefaultStorageContainer
        {
            get { return parameters.DefaultStorageContainer; }
            set { parameters.DefaultStorageContainer = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the version of the HDInsight cluster.")]
        public string Version
        {
            get { return parameters.Version; }
            set { parameters.Version = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Head Node.")]
        public string HeadNodeSize
        {
            get { return parameters.HeadNodeSize; }
            set { parameters.HeadNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Data Node.")]
        public string WorkerNodeSize
        {
            get { return parameters.WorkerNodeSize; }
            set { parameters.WorkerNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Zookeeper Node.")]
        public string ZookeeperNodeSize
        {
            get { return parameters.ZookeeperNodeSize; }
            set { parameters.ZookeeperNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the flavor for a cluster.")]
        public string ClusterType
        {
            get { return parameters.ClusterType; }
            set { parameters.ClusterType = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the virtual network guid for this HDInsight cluster.")]
        public string VirtualNetworkId
        {
            get { return parameters.VirtualNetworkId; }
            set { parameters.VirtualNetworkId = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the subnet name for this HDInsight cluster.")]
        public string SubnetName
        {
            get { return parameters.SubnetName; }
            set { parameters.SubnetName = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the type of operating system installed on cluster nodes.")]
        public OSType OSType
        {
            get { return parameters.OSType; }
            set { parameters.OSType = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the cluster tier for this HDInsight cluster.")]
        public Tier ClusterTier
        {
            get { return parameters.ClusterTier; }
            set { parameters.ClusterTier = value; }
        }

        [Parameter(HelpMessage = "Gets or sets SSH credential.")]
        public PSCredential SshCredential { get; set; }

        [Parameter(HelpMessage = "Gets or sets the public key to be used for SSH.")]
        public string SshPublicKey { get; set; }

        [Parameter(HelpMessage = "Gets or sets the credential for RDP access to the cluster.")]
        public PSCredential RdpCredential { get; set; }

        [Parameter(HelpMessage = "Gets or sets the expiry DateTime for RDP access on the cluster.")]
        public DateTime RdpAccessExpiry
        {
            get { return parameters.RdpAccessExpiry; }
            set { parameters.RdpAccessExpiry = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Object Id for accessing Azure Data Lake.")]
        public Guid ObjectId { get; set; }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Certificate file path for accessing Azure Data Lake.",
            ParameterSetName = CertificateFilePathSet)]
        public string CertificateFilePath { get; set; }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Certificate file contents for accessing Azure Data Lake.",
            ParameterSetName = CertificateFileContentsSet)]
        public byte[] CertificateFileContents { get; set; }

        [Parameter(HelpMessage = "Gets or sets the Service Principal Certificate Password for accessing Azure Data Lake.")]
        public string CertificatePassword { get; set; }

        [Parameter(HelpMessage = "Gets or sets the Service Principal AAD Tenant Id for accessing Azure Data Lake.")]
        public Guid AadTenantId { get; set; }

        #endregion


        public NewAzureHDInsightClusterCommand()
        {
            parameters = new ClusterCreateParameters();
            AdditionalStorageAccounts = new Dictionary<string, string>();
            Configurations = new Dictionary<string, Dictionary<string, string>>();
            ScriptActions = new Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>>();
        }

        public override void ExecuteCmdlet()
        {
            parameters.UserName = HttpCredential.UserName;
            parameters.Password = HttpCredential.Password.ConvertToString();

            if (RdpCredential != null)
            {
                parameters.RdpUsername = RdpCredential.UserName;
                parameters.RdpPassword = RdpCredential.Password.ConvertToString();
            }

            if (OSType == OSType.Linux && SshCredential != null)
            {
                parameters.SshUserName = SshCredential.UserName;
                if (!string.IsNullOrEmpty(SshCredential.Password.ConvertToString()))
                {
                    parameters.SshPassword = SshCredential.Password.ConvertToString();
                }
                if (!string.IsNullOrEmpty(SshPublicKey))
                {
                    parameters.SshPublicKey = SshPublicKey;
                }
            }

            foreach (
                var storageAccount in
                    AdditionalStorageAccounts.Where(
                        storageAccount => !parameters.AdditionalStorageAccounts.ContainsKey(storageAccount.Key)))
            {
                parameters.AdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
            }
            foreach (var config in Configurations.Where(config => !parameters.Configurations.ContainsKey(config.Key)))
            {
                parameters.Configurations.Add(config.Key, config.Value);
            }
            foreach (var action in ScriptActions.Where(action => parameters.ScriptActions.ContainsKey(action.Key)))
            {
                parameters.ScriptActions.Add(action.Key,
                    action.Value.Select(a => a.GetScriptActionFromPSModel()).ToList());
            }
            if (OozieMetastore != null)
            {
                var metastore = OozieMetastore;
                parameters.OozieMetastore = new Metastore(metastore.SqlAzureServerName, metastore.DatabaseName, metastore.Credential.UserName, metastore.Credential.Password.ConvertToString());
            }
            if (HiveMetastore != null)
            {
                var metastore = HiveMetastore;
                parameters.HiveMetastore = new Metastore(metastore.SqlAzureServerName, metastore.DatabaseName, metastore.Credential.UserName, metastore.Credential.Password.ConvertToString());
            }
            if (!string.IsNullOrEmpty(CertificatePassword))
            {
                if (!string.IsNullOrEmpty(CertificateFilePath))
                {
                    CertificateFileContents = File.ReadAllBytes(CertificateFilePath);
                }
                var servicePrincipal = new Management.HDInsight.Models.ServicePrincipal(
                    GetApplicationId(), GetTenantId(AadTenantId), CertificateFileContents,
                    CertificatePassword);

                parameters.Principal = servicePrincipal;
            }

            var cluster = HDInsightManagementClient.CreateNewCluster(ResourceGroupName, ClusterName, parameters);

            if (cluster != null)
            {
                WriteObject(new AzureHDInsightCluster(cluster.Cluster));
            }
        }

        private static Hashtable DictionaryToHashtable(Dictionary<string, string> dictionary)
        {
            return new Hashtable(dictionary);
        }

        private static Dictionary<string, string> HashtableToDictionary(Hashtable table)
        {
            return table
              .Cast<DictionaryEntry>()
              .ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value);
        }

        //Get TenantId for the subscription if user doesn't provide this parameter
        private Guid GetTenantId(Guid tenantId)
        {
            if (tenantId != Guid.Empty)
            {
                return tenantId;
            }

            var tenantIdStr = DefaultProfile.Context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants).FirstOrDefault();
            return new Guid(tenantIdStr);
        }

        //Get ApplicationId for the given ObjectId.
        private Guid GetApplicationId()
        {
            GraphRbacManagementClient graphClient = AzureSession.ClientFactory.CreateArmClient<GraphRbacManagementClient>(
                DefaultProfile.Context, AzureEnvironment.Endpoint.Graph);

            graphClient.TenantID = DefaultProfile.Context.Tenant.Id.ToString();

            Microsoft.Azure.Graph.RBAC.Models.ServicePrincipal sp = graphClient.ServicePrincipals.Get(ObjectId.ToString());

            var applicationId = Guid.Empty;
            Guid.TryParse(sp.AppId, out applicationId);
            Debug.Assert(applicationId != Guid.Empty);
            return applicationId;
        }
    }
}
