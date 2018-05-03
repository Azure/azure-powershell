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

using Microsoft.Azure.Commands.MachineLearningCompute.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.MachineLearningCompute;
using Microsoft.Azure.Management.MachineLearningCompute.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.MachineLearningCompute.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, CmdletSuffix, SupportsShouldProcess = true, DefaultParameterSetName = CmdletParametersParameterSet)]
    [OutputType(typeof(PSOperationalizationCluster))]
    public class SetAzureRmMlOpCluster : MachineLearningComputeCmdletBase
    {
        protected const string ObjectParameterSet = "SetByInputObject";

        protected const string ResourceIdParameterSet = "SetByResourceId";

        protected const string CmdletParametersParameterSet = "SetByIndividualParameters";

        [Parameter(ParameterSetName = ObjectParameterSet,
            Mandatory = true, 
            ValueFromPipeline = true,
            HelpMessage = ClusterParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        [Alias(ClusterInputObjectAlias)]
        public PSOperationalizationCluster InputObject { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = ResourceIdParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = CmdletParametersParameterSet,
            Mandatory = true,
            HelpMessage = ResourceGroupParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = CmdletParametersParameterSet,
            Mandatory = true, 
            HelpMessage = NameParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ObjectParameterSet,
            Mandatory = false, 
            ValueFromPipeline = true,
            HelpMessage = AgentCountParameterHelpMessage)]
        [Parameter(ParameterSetName = CmdletParametersParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AgentCountParameterHelpMessage)]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AgentCountParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        public int? AgentCount { get; set; }

        [Parameter(ParameterSetName = ObjectParameterSet,
            Mandatory = false, 
            ValueFromPipeline = true,
            HelpMessage = SslStatusParameterHelpMessage)]
        [Parameter(ParameterSetName = CmdletParametersParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = SslStatusParameterHelpMessage)]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = SslStatusParameterHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SslStatus { get; set; }

        [Parameter(ParameterSetName = ObjectParameterSet,
            Mandatory = false, 
            ValueFromPipeline = true,
            HelpMessage = SslCertificateParameterHelpMessage)]
        [Parameter(ParameterSetName = CmdletParametersParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = SslCertificateParameterHelpMessage)]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = SslCertificateParameterHelpMessage)]
        public string SslCertificate { get; set; }

        [Parameter(ParameterSetName = ObjectParameterSet,
            Mandatory = false, 
            ValueFromPipeline = true,
            HelpMessage = SslKeyParameterHelpMessage)]
        [Parameter(ParameterSetName = CmdletParametersParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = SslKeyParameterHelpMessage)]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = SslKeyParameterHelpMessage)]
        public string SslKey { get; set; }

        [Parameter(ParameterSetName = ObjectParameterSet,
            Mandatory = false, 
            ValueFromPipeline = true,
            HelpMessage = SslCNameParameterHelpMessage)]
        [Parameter(ParameterSetName = CmdletParametersParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = SslCNameParameterHelpMessage)]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = SslCNameParameterHelpMessage)]
        public string SslCName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.Equals(this.ParameterSetName, ObjectParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;
            }
            else if (string.Equals(this.ParameterSetName, ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;
            }

            if (ShouldProcess(Name, @"Updating operationalization cluster..."))
            {
                OperationalizationCluster clusterToUpdate;

                if (string.Equals(this.ParameterSetName, ObjectParameterSet, StringComparison.OrdinalIgnoreCase))
                {
                    clusterToUpdate = InputObject.ConvertToOperationalizationCluster();
                }
                else
                {
                    clusterToUpdate = MachineLearningComputeManagementClient.OperationalizationClusters.Get(ResourceGroupName, Name);
                }

                switch (clusterToUpdate.ClusterType)
                {
                    case ClusterType.ACS:
                        if (AgentCount != null)
                        {
                            clusterToUpdate.ContainerService.AgentCount = AgentCount;
                        }
                        break;
                    case ClusterType.Local:
                        break;
                    default:
                        break;
                }

                if (SslStatus != null || SslCertificate != null || SslKey != null || SslCName != null)
                {
                    if (clusterToUpdate.GlobalServiceConfiguration == null)
                    {
                        clusterToUpdate.GlobalServiceConfiguration = new GlobalServiceConfiguration();
                    }

                    if (clusterToUpdate.GlobalServiceConfiguration.Ssl == null)
                    {
                        clusterToUpdate.GlobalServiceConfiguration.Ssl = new SslConfiguration();
                    }

                    if (SslStatus != null)
                    {
                        clusterToUpdate.GlobalServiceConfiguration.Ssl.Status = SslStatus;
                    }

                    if (SslCertificate != null)
                    {
                        clusterToUpdate.GlobalServiceConfiguration.Ssl.Cert = SslCertificate;
                    }

                    if (SslKey != null)
                    {
                        clusterToUpdate.GlobalServiceConfiguration.Ssl.Key = SslKey;
                    }

                    if (SslCName != null)
                    {
                        clusterToUpdate.GlobalServiceConfiguration.Ssl.Cname = SslCName;
                    }
                }

                try
                {
                    WriteObject(new PSOperationalizationCluster(MachineLearningComputeManagementClient.OperationalizationClusters.CreateOrUpdate(ResourceGroupName, Name, clusterToUpdate)));
                }
                catch (Exception e)
                {
                    HandleNestedExceptionMessages(e);
                }
            }
        }
    }
}
