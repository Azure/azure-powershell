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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.ServiceFabric;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ServiceFabricApplicationTypeVersion", DefaultParameterSetName = ByResourceGroup, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzServiceFabricApplicationTypeVersion : ProxyResourceCmdletBase
    {
        private const string ByResourceGroup = "ByResourceGroup";
        private const string ByInputObject = "ByInputObject";
        private const string ByResourceId = "ByResourceId";

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.ServiceFabric/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceGroup, HelpMessage = "Specify the name of the application type.")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationTypeName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceGroup, HelpMessage = "Specify the application type version.")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationTypeVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Arm ResourceId of the application type version.")]
        [ResourceIdCompleter("Microsoft.ServiceFabric/clusters")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByInputObject, ValueFromPipeline = true,
            HelpMessage = "The application type version resource.")]
        public PSApplicationTypeVersion InputObject { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup)]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject)]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup, HelpMessage = "Remove without prompt.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject, HelpMessage = "Remove without prompt.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId, HelpMessage = "Remove without prompt.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ByInputObject:
                    this.ResourceId = InputObject.Id;
                    SetParametersByResourceId();
                    break;
                case ByResourceId:
                    SetParametersByResourceId();
                    break;
                case ByResourceGroup:
                    // intentionally left empty
                    break;
                default:
                    throw new PSArgumentException("Invalid ParameterSetName");
            }

            var resourceMessage = string.Format("ApplicationType '{0}' in resource group '{1}', cluster name {2}", this.Name, this.ResourceGroupName, this.ClusterName);
            if (ShouldProcess(target: this.ResourceGroupName, action: string.Format("Remove {0}", resourceMessage)))
            {
                ConfirmAction(Force.IsPresent,
                    "Do you want to remove the application type version? Please remove all applications under this resource before running this command.",
                    "Removing application type version.",
                    resourceMessage,
                    () =>
                    {
                        try
                        {
                            this.SFRPClient.ApplicationTypeVersions.Delete(this.ResourceGroupName, this.ClusterName, this.Name, this.Version);
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

        private void SetParametersByResourceId()
        {
            ResourceIdentifier appTypeVersionRId = new ResourceIdentifier(this.ResourceId);
            this.ResourceGroupName = appTypeVersionRId.ResourceGroupName;
            string subscription = appTypeVersionRId.Subscription;
            ResourceIdentifier appTypeRId = new ResourceIdentifier($"/subscriptions/{subscription}/resourceGroups/{this.ResourceGroupName}/providers/Microsoft.ServiceFabric/{appTypeVersionRId.ParentResource}");
            ResourceIdentifier clusterRId = new ResourceIdentifier($"/subscriptions/{subscription}/resourceGroups/{this.ResourceGroupName}/providers/Microsoft.ServiceFabric/{appTypeRId.ParentResource}");
            if (!appTypeVersionRId.ResourceType.EndsWith(Constants.applicationTypeVersionProvider)
                || !appTypeRId.ResourceType.EndsWith(Constants.applicationTypeProvider)
                || !clusterRId.ResourceType.EndsWith(Constants.clusterProvider))
            {
                throw new PSArgumentException(string.Format("invalid resource id {0}", this.ResourceId));
            }
            
            this.ClusterName = clusterRId.ResourceName;
            this.Name = appTypeRId.ResourceName;
            this.Version = appTypeVersionRId.ResourceName;
        }
    }
}
