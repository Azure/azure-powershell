// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedCluster", DefaultParameterSetName = ByObj, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveServiceFabricManagedCluster : ServiceFabricManagedCmdletBase
    {
        protected const string ByName = "ByName";
        protected const string ById = "ById";
        protected const string ByObj = "ByObj";

        #region Params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = ById,
            HelpMessage = "Managed Cluster resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = ByObj,
            HelpMessage = "Managed Cluster resource")]
        [ValidateNotNull]
        public PSManagedCluster InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            this.SetParams();
            if (ShouldProcess(target: this.ResourceGroupName, action: string.Format("Remove cluster {0} in resource group {1}.", this.Name, this.ResourceGroupName)))
            {
                try
                {
                    var beginRequestResponse = this.SfrpMcClient.ManagedClusters.BeginDeleteWithHttpMessagesAsync(
                                                    this.ResourceGroupName,
                                                    this.Name).GetAwaiter().GetResult();

                    this.PollLongRunningOperation(beginRequestResponse);

                    if (this.PassThru)
                    {
                        WriteObject(true);
                    }
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private void SetParams()
        {
            switch (ParameterSetName)
            {
                case ByObj:
                    if (string.IsNullOrEmpty(this.InputObject?.Id))
                    {
                        throw new ArgumentException("ResourceId is null.");
                    }

                    SetParametersByResourceId(this.InputObject.Id);
                    break;
                case ById:
                    SetParametersByResourceId(this.ResourceId);
                    break;
            }
        }

        private void SetParametersByResourceId(string resourceId)
        {
            this.GetParametersByResourceId(resourceId, Constants.ManagedClusterProvider, out string resourceGroup, out string resourceName);
            this.ResourceGroupName = resourceGroup;
            this.Name = resourceName;
        }
    }
}
