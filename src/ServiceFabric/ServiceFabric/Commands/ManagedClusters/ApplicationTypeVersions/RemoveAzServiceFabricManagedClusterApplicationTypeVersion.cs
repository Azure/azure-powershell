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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedClusterApplicationTypeVersion", DefaultParameterSetName = ByResourceGroup, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzServiceFabricManagedClusterApplicationTypeVersion : ManagedApplicationCmdletBase
    {
        private const string ByResourceGroup = "ByResourceGroup";
        private const string ByInputObject = "ByInputObject";
        private const string ByResourceId = "ByResourceId";

        #region Parameters
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceGroup, HelpMessage = "Specify the name of the managed application type.")]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationTypeName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceGroup, HelpMessage = "Specify the managed application type version.")]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationTypeVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Arm ResourceId of the managed application type version.")]
        [ResourceIdCompleter(Constants.ManagedClustersFullType)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByInputObject, ValueFromPipeline = true,
            HelpMessage = "The managed application type version resource.")]
        public PSManagedApplicationTypeVersion InputObject { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup)]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject)]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup, HelpMessage = "Remove without prompt.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject, HelpMessage = "Remove without prompt.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId, HelpMessage = "Remove without prompt.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ByInputObject:
                    if (string.IsNullOrEmpty(this.InputObject?.Id))
                    {
                        throw new ArgumentException("ResourceId is null.");
                    }
                    this.ResourceId = InputObject.Id;
                    SetParametersByResourceId(this.ResourceId);
                    break;
                case ByResourceId:
                    SetParametersByResourceId(this.ResourceId);
                    break;
                case ByResourceGroup:
                    // intentionally left empty
                    break;
                default:
                    throw new PSArgumentException("Invalid ParameterSetName");
            }

            var resourceMessage = $"Managed ApplicationType '{this.Name}' in resource group '{this.ResourceGroupName}', cluster name {this.ClusterName}";
            if (ShouldProcess(target: this.Version, action: $"Remove {resourceMessage}"))
            {
                ConfirmAction(Force.IsPresent,
                    "Do you want to remove the managed application type version? Please remove all managed applications under this resource before running this command.",
                    "Removing managed application type version.",
                    resourceMessage,
                    () =>
                    {
                        try
                        {
                            var beginRequestResponse = this.SfrpMcClient.ApplicationTypeVersions.BeginDeleteWithHttpMessagesAsync(
                                    this.ResourceGroupName,
                                    this.ClusterName,
                                    this.Name,
                                    this.Version).GetAwaiter().GetResult();

                            this.PollLongRunningOperation(beginRequestResponse);
                            if (PassThru)
                            {
                                WriteObject(true);
                            }
                        }
                        catch (Exception ex)
                        {
                            this.PrintSdkExceptionDetail(ex);
                            throw;
                        }
                    });
            }
        }

        private void SetParametersByResourceId(string resourceId)
        {
            this.GetParametersByResourceId(resourceId, Constants.applicationTypeVersionProvider, out string resourceGroup, out string resourceName, out string parentResourceName, out string grandParentResourceName);
            this.ResourceGroupName = resourceGroup;
            this.Name = resourceName;
            this.ClusterName = parentResourceName;
            this.Version = grandParentResourceName;
        }
    }
}
