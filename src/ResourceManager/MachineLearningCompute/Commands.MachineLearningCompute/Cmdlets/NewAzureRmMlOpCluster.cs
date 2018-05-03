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
using System.Management.Automation;
using Microsoft.Azure.Management.MachineLearningCompute;
using Microsoft.Azure.Management.MachineLearningCompute.Models;
using Microsoft.Azure.Commands.MachineLearningCompute.Models;
using System.Collections;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.MachineLearningCompute.Cmdlets
{
    [Cmdlet(VerbsCommon.New, CmdletSuffix, SupportsShouldProcess = true)]
    [OutputType(typeof(PSOperationalizationCluster))]
    public class NewAzureRmMlOpCluster : MachineLearningComputeCmdletBase
    {
        protected const string CreateFromObjectParameterSet = "CreateWithInputObject";

        protected const string CreateFromCmdletParametersParameterSet = "CreateWithParameters";

        [Parameter(Mandatory = true, 
            HelpMessage = ResourceGroupParameterHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, 
            HelpMessage = NameParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        // Create using an op cluster object
        [Parameter(ParameterSetName = CreateFromObjectParameterSet,
            Mandatory = true, 
            HelpMessage = ClusterParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        [Alias(ClusterInputObjectAlias)]
        public PSOperationalizationCluster InputObject { get; set; }

        // Create using cmdlet parameters
        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = true, 
            HelpMessage = LocationParameterHelpMessage)]
        [LocationCompleter("Microsoft.MachineLearningCompute/operationalizationClusters")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = true, 
            HelpMessage = ClusterTypeParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ClusterType { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = OrchestratorTypeParameterHelpMessage)]
        public string OrchestratorType { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = ClientIdParameterHelpMessage)]
        public string ClientId { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = SecretParameterHelpMessage)]
        public string Secret { get; set; }

        // Additional settings for non-local cluster
        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = DescriptionParameterHelpMessage)]
        public string Description { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = MasterCountParameterHelpMessage)]
        public int? MasterCount { get; set; } 

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = AgentCountParameterHelpMessage)]
        public int? AgentCount { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = AgentCountParameterHelpMessage)]
        public string AgentVmSize { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = ETagParameterHelpMessage)]
        public string GlobalServiceConfigurationETag { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = SslStatusParameterHelpMessage)]
        public string SslStatus { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = SslCertificateParameterHelpMessage)]
        public string SslCertificate { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = SslKeyParameterHelpMessage)]
        public string SslKey { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = SslCNameParameterHelpMessage)]
        public string SslCName { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = GlobalServiceConfigurationAdditionalPropertiesHelpMessage)]
        public Hashtable GlobalServiceConfigurationAdditionalProperties;

        // BYO options
        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = StorageAccountParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string StorageAccount { get; set; }

        [Parameter(ParameterSetName = CreateFromCmdletParametersParameterSet,
            Mandatory = false,
            HelpMessage = AzureContainerRegistryParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AzureContainerRegistry { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, @"Creating operationalization cluster..."))
            {
                var cluster = new OperationalizationCluster();

                if (string.Equals(this.ParameterSetName, CreateFromObjectParameterSet, StringComparison.OrdinalIgnoreCase))
                {
                    cluster = InputObject.ConvertToOperationalizationCluster();
                }
                else if (string.Equals(this.ParameterSetName, CreateFromCmdletParametersParameterSet, StringComparison.OrdinalIgnoreCase))
                {
                    cluster.Location = Location;
                    cluster.ClusterType = ClusterType;
                    cluster.Description = Description;

                    if (StorageAccount != null)
                    {
                        cluster.StorageAccount = new StorageAccountProperties(StorageAccount);
                    }

                    if (AzureContainerRegistry != null)
                    {
                        cluster.ContainerRegistry = new ContainerRegistryProperties(AzureContainerRegistry);
                    }

                    if (GlobalServiceConfigurationETag != null)
                    {
                        cluster.GlobalServiceConfiguration = cluster.GlobalServiceConfiguration ?? new GlobalServiceConfiguration();
                        cluster.GlobalServiceConfiguration.Etag = GlobalServiceConfigurationETag;
                    }

                    if (GlobalServiceConfigurationAdditionalProperties != null)
                    {
                        cluster.GlobalServiceConfiguration = cluster.GlobalServiceConfiguration ?? new GlobalServiceConfiguration();
                        cluster.GlobalServiceConfiguration.AdditionalProperties = GlobalServiceConfigurationAdditionalProperties.Cast<DictionaryEntry>().ToDictionary(kvp => (string)kvp.Key, kvp => kvp.Value);
                    }

                    if (SslStatus != null)
                    {
                        cluster.GlobalServiceConfiguration.Ssl = cluster.GlobalServiceConfiguration.Ssl ?? new SslConfiguration();
                        cluster.GlobalServiceConfiguration.Ssl.Status = SslStatus;
                    }

                    if (SslCertificate != null)
                    {
                        cluster.GlobalServiceConfiguration.Ssl = cluster.GlobalServiceConfiguration.Ssl ?? new SslConfiguration();
                        cluster.GlobalServiceConfiguration.Ssl.Cert = SslCertificate;
                    }

                    if (SslKey != null)
                    {
                        cluster.GlobalServiceConfiguration.Ssl = cluster.GlobalServiceConfiguration.Ssl ?? new SslConfiguration();
                        cluster.GlobalServiceConfiguration.Ssl.Key = SslKey;
                    }

                    if (SslCName != null)
                    {
                        cluster.GlobalServiceConfiguration.Ssl = cluster.GlobalServiceConfiguration.Ssl ?? new SslConfiguration();
                        cluster.GlobalServiceConfiguration.Ssl.Cname = SslCName;
                    }

                    switch (ClusterType)
                    {
                        case Management.MachineLearningCompute.Models.ClusterType.ACS:

                            cluster.ContainerService = new AcsClusterProperties
                            {
                                OrchestratorType = OrchestratorType,
                                MasterCount = MasterCount,
                                AgentCount = AgentCount,
                                AgentVmSize = AgentVmSize
                            };

                            switch (OrchestratorType)
                            {
                                case Management.MachineLearningCompute.Models.OrchestratorType.Kubernetes:
                                    if (ClientId != null || Secret != null)
                                    {
                                        cluster.ContainerService.OrchestratorProperties = new KubernetesClusterProperties()
                                        {
                                            ServicePrincipal = new ServicePrincipalProperties
                                            {
                                                ClientId = ClientId,
                                                Secret = Secret
                                            }
                                        };
                                    }
                                    break;
                                case Management.MachineLearningCompute.Models.OrchestratorType.None:
                                    break;
                                default:
                                    break;
                            }

                            break;

                        case Management.MachineLearningCompute.Models.ClusterType.Local:
                            break;
                        default:
                            break;
                    }

                }

                try
                {
                    WriteObject(new PSOperationalizationCluster(MachineLearningComputeManagementClient.OperationalizationClusters.CreateOrUpdate(ResourceGroupName, Name, cluster)));
                }
                catch (Exception e)
                {
                    HandleNestedExceptionMessages(e);
                }
            }
        }
    }
}
