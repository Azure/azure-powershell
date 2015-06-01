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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Hadoop.Client;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators
{
    internal class AzureHDInsightClusterManagementClientSimulator : IHDInsightClient
    {
        internal static ClusterCreateParametersV2 LastCreateRequest;

        private static readonly Collection<SimulatorClusterContainer> Clusters = new Collection<SimulatorClusterContainer>
        {
            new SimulatorClusterContainer
            {
                Cluster =
                    new ClusterDetails
                    {
                        Name = "VersionLowerThanSupported",
                        State = ClusterState.Running,
                        ConnectionUrl = @"https://VersionLowerThanSupported.azurehdinsight.net",
                        CreatedDate = DateTime.UtcNow,
                        VersionStatus = VersionStatus.Obsolete,
                        Location = "East US 2",
                        Error = null,
                        Version =
                            new Version(HDInsightSDKSupportedVersions.MinVersion.Major, HDInsightSDKSupportedVersions.MinVersion.Minor - 1).ToString(),
                        VersionNumber =
                            new Version(HDInsightSDKSupportedVersions.MinVersion.Major, HDInsightSDKSupportedVersions.MinVersion.Minor - 1),
                        HttpUserName = "sa-po-svc",
                        ClusterSizeInNodes = 4,
                        DefaultStorageAccount = IntegrationTestBase.GetWellKnownStorageAccounts().First(),
                        AdditionalStorageAccounts = IntegrationTestBase.GetWellKnownStorageAccounts().Skip(1)
                    }
            },
            new SimulatorClusterContainer
            {
                Cluster =
                    new ClusterDetails
                    {
                        ConnectionUrl = @"https://VersionHigherThanSupported.azurehdinsight.net",
                        CreatedDate = DateTime.UtcNow,
                        Name = "VersionHigherThanSupported",
                        State = ClusterState.Running,
                        Location = "East US 2",
                        Error = null,
                        Version =
                            new Version(HDInsightSDKSupportedVersions.MaxVersion.Major, HDInsightSDKSupportedVersions.MaxVersion.Minor + 1).ToString(),
                        VersionStatus = VersionStatus.ToolsUpgradeRequired,
                        VersionNumber =
                            new Version(HDInsightSDKSupportedVersions.MaxVersion.Major, HDInsightSDKSupportedVersions.MaxVersion.Minor + 1),
                        HttpUserName = "sa-po-svc",
                        ClusterSizeInNodes = 4,
                        DefaultStorageAccount = IntegrationTestBase.GetWellKnownStorageAccounts().First(),
                        AdditionalStorageAccounts = IntegrationTestBase.GetWellKnownStorageAccounts().Skip(1)
                    }
            },
            new SimulatorClusterContainer
            {
                Cluster =
                    new ClusterDetails
                    {
                        ConnectionUrl = @"https://" + IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName + ".azurehdinsight.net",
                        CreatedDate = DateTime.UtcNow,
                        Name = IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName,
                        State = ClusterState.Running,
                        Location = "East US 2",
                        Error = null,
                        Version = IntegrationTestBase.TestCredentials.WellKnownCluster.Version,
                        VersionNumber = new Version(IntegrationTestBase.TestCredentials.WellKnownCluster.Version),
                        VersionStatus = VersionStatus.Compatible,
                        HttpUserName = IntegrationTestBase.TestCredentials.AzureUserName,
                        HttpPassword = IntegrationTestBase.TestCredentials.AzurePassword,
                        ClusterSizeInNodes = 4,
                        DefaultStorageAccount = IntegrationTestBase.GetWellKnownStorageAccounts().First(),
                        AdditionalStorageAccounts = IntegrationTestBase.GetWellKnownStorageAccounts().Skip(1)
                    }
            },
            new SimulatorClusterContainer
            {
                Cluster =
                    new ClusterDetails
                    {
                        Name = "NoHttpAccessCluster",
                        State = ClusterState.Running,
                        ConnectionUrl = @"https://NoHttpAccessCluster.azurehdinsight.net",
                        CreatedDate = DateTime.UtcNow,
                        Location = "East US 2",
                        Error = null,
                        VersionStatus = VersionStatus.Compatible,
                        Version =
                            new Version(HDInsightSDKSupportedVersions.MaxVersion.Major, HDInsightSDKSupportedVersions.MaxVersion.Minor).ToString(),
                        VersionNumber = new Version(HDInsightSDKSupportedVersions.MaxVersion.Major, HDInsightSDKSupportedVersions.MaxVersion.Minor),
                        ClusterSizeInNodes = 4,
                        DefaultStorageAccount = IntegrationTestBase.GetWellKnownStorageAccounts().First(),
                        AdditionalStorageAccounts = IntegrationTestBase.GetWellKnownStorageAccounts().Skip(1)
                    }
            },
            new SimulatorClusterContainer
            {
                Cluster =
                    new ClusterDetails
                    {
                        Name = "HttpAccessCluster",
                        ConnectionUrl = @"https://HttpAccessCluster.azurehdinsight.net",
                        CreatedDate = DateTime.UtcNow,
                        Location = "East US 2",
                        Error = null,
                        VersionStatus = VersionStatus.Compatible,
                        Version =
                            new Version(HDInsightSDKSupportedVersions.MaxVersion.Major, HDInsightSDKSupportedVersions.MaxVersion.Minor).ToString(),
                        VersionNumber = new Version(HDInsightSDKSupportedVersions.MaxVersion.Major, HDInsightSDKSupportedVersions.MaxVersion.Minor),
                        HttpUserName = IntegrationTestBase.TestCredentials.AzureUserName,
                        HttpPassword = IntegrationTestBase.TestCredentials.AzurePassword,
                        ClusterSizeInNodes = 4,
                        DefaultStorageAccount = IntegrationTestBase.GetWellKnownStorageAccounts().First(),
                        AdditionalStorageAccounts = IntegrationTestBase.GetWellKnownStorageAccounts().Skip(1)
                    }
            }
        };

        private readonly IHDInsightSubscriptionCredentials credentials;
        private readonly ILogger logger;

        private CancellationTokenSource cancellationTokenSource;

        public AzureHDInsightClusterManagementClientSimulator(IHDInsightSubscriptionCredentials credentials)
        {
            this.credentials = credentials;
            this.logger = new Logger();
        }

        public void Dispose()
        {
        }

        public event EventHandler<ClusterProvisioningStatusEventArgs> ClusterProvisioning;
        public CancellationToken CancellationToken { get; private set; }
        public IHDInsightSubscriptionCredentials Credentials { get; private set; }
        public TimeSpan PollingInterval { get; set; }

        public void AddLogWriter(ILogWriter logWriter)
        {
            this.logger.AddWriter(logWriter);
        }

        public void RemoveLogWriter(ILogWriter logWriter)
        {
            this.logger.RemoveWriter(logWriter);
        }

        public void Cancel()
        {
        }

      

        public ClusterDetails CreateCluster(ClusterCreateParameters cluster)
        {
            Task<ClusterDetails> createTask = this.CreateClusterAsync(
                new ClusterCreateParametersV2( cluster));
            createTask.Wait();
            return createTask.Result;
        }

        public ClusterDetails CreateCluster(ClusterCreateParameters cluster, TimeSpan timeout)
        {
            return this.CreateCluster(cluster);
        }

        public ClusterDetails CreateCluster(ClusterCreateParametersV2 cluster)
        {
            Task<ClusterDetails> createTask = this.CreateClusterAsync(cluster);
            createTask.Wait();
            return createTask.Result;
        }

        public ClusterDetails CreateCluster(ClusterCreateParametersV2 cluster, TimeSpan timeout)
        {
            return this.CreateCluster(cluster);
        }

        public Task<ClusterDetails> CreateClusterAsync(ClusterCreateParameters clusterCreateParameters)
        {
            return CreateClusterAsync(new ClusterCreateParametersV2(clusterCreateParameters));
        }

        public Task<ClusterDetails> CreateClusterAsync(ClusterCreateParametersV2 clusterCreateParameters)
        {
            this.LogMessage("Creating cluster '{0}' in location {1}", clusterCreateParameters.Name, clusterCreateParameters.Location);
            LastCreateRequest = clusterCreateParameters;
            var clusterDetails = new ClusterDetails();
            clusterDetails.Name = clusterCreateParameters.Name;
            clusterDetails.HttpPassword = clusterCreateParameters.Password;
            clusterDetails.HttpUserName = clusterCreateParameters.UserName;
            clusterDetails.Version = clusterCreateParameters.Version;
            clusterDetails.Location = clusterCreateParameters.Location;
            clusterDetails.State = ClusterState.Running;
            clusterDetails.AdditionalStorageAccounts = clusterCreateParameters.AdditionalStorageAccounts;
            clusterDetails.DefaultStorageAccount = new WabStorageAccountConfiguration(
                clusterCreateParameters.DefaultStorageAccountName,
                clusterCreateParameters.DefaultStorageAccountKey,
                clusterCreateParameters.DefaultStorageContainer);
            Clusters.Add(new SimulatorClusterContainer { Cluster = clusterDetails });
            return TaskEx2.FromResult(clusterDetails);
        }

        public void DeleteCluster(string dnsName)
        {
            this.DeleteClusterAsync(dnsName).Wait();
        }

        public void DeleteCluster(string dnsName, TimeSpan timeout)
        {
            this.DeleteClusterAsync(dnsName).Wait();
        }

        public void DeleteCluster(string dnsName, string location)
        {
            throw new NotImplementedException();
        }

        public void DeleteCluster(string dnsName, string location, TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteClusterAsync(string name)
        {
            ClusterDetails cluster = await this.GetClusterAsync(name);
            if (cluster == null)
            {
                throw new InvalidOperationException("The cluster '" + name + "' doesn't exist.");
            }

            this.LogMessage("Deleting cluster '{0}' in location {1}", name, cluster.Location);
            Clusters.Remove(GetClusterInternal(name));
        }

        public Task DeleteClusterAsync(string name, string location)
        {
            throw new NotImplementedException();
        }

        public void DisableHttp(string dnsName, string location)
        {
            this.DisableHttpAsync(dnsName, location).Wait();
        }

        public async Task DisableHttpAsync(string dnsName, string location)
        {
            ClusterDetails cluster = await this.GetClusterAsync(dnsName);
            Clusters.Remove(GetClusterInternal(dnsName));
            cluster.HttpUserName = string.Empty;
            cluster.HttpPassword = string.Empty;
            Clusters.Add(new SimulatorClusterContainer { Cluster = cluster });
        }

        public void DisableRdp(string dnsName, string location)
        {
            this.DisableRdpAsync(dnsName, location).Wait();
        }
        
        public async Task DisableRdpAsync(string dnsName, string location)
        {
            ClusterDetails cluster = await this.GetClusterAsync(dnsName);
            Clusters.Remove(GetClusterInternal(dnsName));
            cluster.RdpUserName = string.Empty;
            Clusters.Add(new SimulatorClusterContainer { Cluster = cluster });
        }

        public void EnableHttp(string dnsName, string location, string httpUserName, string httpPassword)
        {
            this.EnableHttpAsync(dnsName, location, httpUserName, httpPassword).Wait();
        }

        public async Task EnableHttpAsync(string dnsName, string location, string httpUserName, string httpPassword)
        {
            ClusterDetails cluster = await this.GetClusterAsync(dnsName);
            Clusters.Remove(GetClusterInternal(dnsName));
            cluster.HttpUserName = httpUserName;
            cluster.HttpPassword = httpPassword;
            Clusters.Add(new SimulatorClusterContainer { Cluster = cluster });
        }

        public void EnableRdp(string dnsName, string location, string rdpUserName, string rdpPassword, DateTime expiryDate)
        {
            this.EnableRdpAsync(dnsName, location, rdpUserName, rdpPassword, expiryDate).Wait();
        }

        public async Task EnableRdpAsync(string dnsName, string location, string rdpUserName, string rdpPassword, DateTime expiryDate)
        {
            ClusterDetails cluster = await this.GetClusterAsync(dnsName);
            Clusters.Remove(GetClusterInternal(dnsName));
            cluster.RdpUserName = rdpUserName;
            Clusters.Add(new SimulatorClusterContainer { Cluster = cluster });
        }

        public ClusterDetails GetCluster(string dnsName)
        {
            Task<ClusterDetails> getTask = this.GetClusterAsync(dnsName);
            getTask.Wait();
            return getTask.Result;
        }

        public ClusterDetails GetCluster(string dnsName, string location)
        {
            Task<ClusterDetails> getTask = this.GetClusterAsync(dnsName, location);
            getTask.Wait();
            return getTask.Result;
        }

        public async Task<ClusterDetails> GetClusterAsync(string name)
        {
            this.LogMessage("Getting hdinsight clusters for subscriptionid : {0}", this.credentials.SubscriptionId.ToString());
            ICollection<ClusterDetails> knownClusters = await this.ListClustersAsync();
            ClusterDetails cluster = knownClusters.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
            return cluster;
        }

        public Task<ClusterDetails> GetClusterAsync(string name, string location)
        {
            throw new NotImplementedException();
        }

        public ClusterDetails ChangeClusterSize(string dnsName, string location, int newSize)
        {
            return ChangeClusterSizeAsync(dnsName, location, newSize).WaitForResult();
        }

        public async Task<ClusterDetails> ChangeClusterSizeAsync(string dnsName, string location, int newSize)
        {
            LogMessage("Getting hdinsight clusters for subscriptionid : {0}", credentials.SubscriptionId.ToString());
            var knownClusters = await ListClustersAsync();
            var cluster = knownClusters.FirstOrDefault(c => string.Equals(c.Name, dnsName, StringComparison.OrdinalIgnoreCase));
            if (cluster == null)
            {
                return null;
            }
            cluster.ClusterSizeInNodes = newSize;
            return cluster;
        }

        public Collection<string> ListAvailableLocations()
        {
            return ListAvailableLocations(OSType.Windows);
        }

        public Task<Collection<string>> ListAvailableLocationsAsync()
        {
            return ListAvailableLocationsAsync(OSType.Windows);
        }

        public Collection<string> ListAvailableLocations(OSType osType)
        {
            Task<Collection<string>> listTask = this.ListAvailableLocationsAsync(osType);
            listTask.Wait();
            return listTask.Result;
        }

        public Task<Collection<string>> ListAvailableLocationsAsync(OSType osType)
        {
            return TaskEx2.FromResult(new Collection<string> { "East US", "East US 2", "West US", "North Europe" });
        }

        public Collection<HDInsightVersion> ListAvailableVersions()
        {
            Task<Collection<HDInsightVersion>> listTask = this.ListAvailableVersionsAsync();
            listTask.Wait();
            return listTask.Result;
        }

        public Task<Collection<HDInsightVersion>> ListAvailableVersionsAsync()
        {
            var versions = new Collection<HDInsightVersion>();
            versions.Add(new HDInsightVersion { Version = "1.2", VersionStatus = VersionStatus.Obsolete });
            versions.Add(new HDInsightVersion { Version = "1.5", VersionStatus = VersionStatus.Obsolete });
            versions.Add(new HDInsightVersion { Version = "1.6", VersionStatus = VersionStatus.Compatible });
            versions.Add(new HDInsightVersion { Version = "2.1", VersionStatus = VersionStatus.Compatible });
            return TaskEx2.FromResult(versions);
        }

        public ICollection<ClusterDetails> ListClusters()
        {
            Task<ICollection<ClusterDetails>> listTask = this.ListClustersAsync();
            listTask.Wait();
            return listTask.Result;
        }

        public Task<ICollection<ClusterDetails>> ListClustersAsync()
        {
            this.LogMessage("Getting hdinsight clusters for subscriptionid : {0}", this.credentials.SubscriptionId.ToString());
            ICollection<ClusterDetails> resultClusters = new Collection<ClusterDetails>(Clusters.Select(c => c.Cluster).ToList());
            foreach (ClusterDetails cluster in resultClusters)
            {
                cluster.SubscriptionId = this.credentials.SubscriptionId;
            }

            return TaskEx2.FromResult(resultClusters);
        }

        public IEnumerable<KeyValuePair<string, string>> ListResourceProviderProperties()
        {
            Task<IEnumerable<KeyValuePair<string, string>>> listTask = this.ListResourceProviderPropertiesAsync();
            listTask.Wait();
            return listTask.Result;
        }

        public Task<IEnumerable<KeyValuePair<string, string>>> ListResourceProviderPropertiesAsync()
        {
            var resourceProviderProperties = new List<KeyValuePair<string, string>>();
            resourceProviderProperties.Add(new KeyValuePair<string, string>("CAPABILITY_FEATURE_CUSTOM_ACTIONS_V2", "Custom Actions V2"));
            resourceProviderProperties.Add(new KeyValuePair<string, string>("CAPABILITY_REGION_EAST_US", "East US"));
            resourceProviderProperties.Add(new KeyValuePair<string, string>("CAPABILITY_REGION_EAST_US_2", "East US 2"));
            resourceProviderProperties.Add(new KeyValuePair<string, string>("CAPABILITY_REGION_NORTH_EUROPE", "North Europe"));
            resourceProviderProperties.Add(new KeyValuePair<string, string>("CAPABILITY_VERSION_1.2", "1.2.0.0.LargeSKU-amd64-134231"));
            resourceProviderProperties.Add(new KeyValuePair<string, string>("CAPABILITY_VERSION_2.1", "2.1.0.0.LargeSKU-amd64-134231"));
            resourceProviderProperties.Add(new KeyValuePair<string, string>("CAPABILITY_VERSION_1.5", "1.5.0.0.LargeSKU-amd64-134231"));
            resourceProviderProperties.Add(new KeyValuePair<string, string>("CAPABILITY_VERSION_1.6", "1.6.0.0.LargeSKU-amd64-134231"));

            resourceProviderProperties.Add(new KeyValuePair<string, string>("CONTAINERS_Count", "1"));

            resourceProviderProperties.Add(new KeyValuePair<string, string>("CONTAINERS_CoresUsed", "168"));

            resourceProviderProperties.Add(new KeyValuePair<string, string>("CONTAINERS_MaxCoresAllowed", "170"));

            return TaskEx2.FromResult(resourceProviderProperties.AsEnumerable());
        }

        public void RaiseClusterProvisioningEvent(object sender, ClusterProvisioningStatusEventArgs e)
        {
            if (this.ClusterProvisioning != null)
            {
                this.ClusterProvisioning(sender, e);
            }
        }

        public void SetCancellationSource(CancellationTokenSource tokenSource)
        {
            // tokenSource.ArgumentNotNull("tokenSource")
            this.cancellationTokenSource = tokenSource;
            this.CancellationToken = this.cancellationTokenSource.Token;
        }

        public bool IgnoreSslErrors { get; set; }

        internal static SimulatorClusterContainer GetClusterInternal(string clusterName)
        {
            SimulatorClusterContainer simulationCluster =
                Clusters.First(cluster => string.Equals(cluster.Cluster.Name, clusterName, StringComparison.OrdinalIgnoreCase));
            simulationCluster.Cluster.SubscriptionId = IntegrationTestBase.TestCredentials.SubscriptionId;
            return simulationCluster;
        }

        private void LogMessage(string content, params string[] args)
        {
            string message = content;
            if (args.Any())
            {
                message = string.Format(CultureInfo.InvariantCulture, content, args);
            }

            this.logger.LogMessage(message, Severity.Informational, Verbosity.Diagnostic);
        }

        internal class PendingOp
        {
            public PendingOp(UserChangeOperationStatusResponse response)
            {
                this.Response = response;
                this.Id = Guid.NewGuid();
            }

            public Guid Id { get; private set; }
            public UserChangeOperationStatusResponse Response { get; private set; }
        }

        internal class SimulatorClusterContainer
        {
            private readonly IDictionary<string, JobDetails> jobQueue;

            private readonly IDictionary<string, DateTime> markedForDeletionJobs;

            public SimulatorClusterContainer()
            {
                this.jobQueue = new Dictionary<string, JobDetails>();
                this.markedForDeletionJobs = new Dictionary<string, DateTime>();
            }

            public ClusterDetails Cluster { get; set; }

            public IDictionary<string, DateTime> JobDeletionQueue
            {
                get { return this.markedForDeletionJobs; }
            }

            public IDictionary<string, JobDetails> JobQueue
            {
                get
                {
                    if (!string.IsNullOrEmpty(this.Cluster.HttpUserName))
                    {
                        return this.jobQueue;
                    }

                    throw new UnauthorizedAccessException();
                }
            }
        }

        public ILogger Logger { get; private set; }
    }
}
