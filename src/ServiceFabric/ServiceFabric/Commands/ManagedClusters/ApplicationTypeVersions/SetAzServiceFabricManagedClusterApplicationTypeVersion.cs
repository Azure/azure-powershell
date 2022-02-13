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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedClusterApplicationTypeVersion", DefaultParameterSetName = ByResourceGroup, SupportsShouldProcess = true), OutputType(typeof(PSManagedApplicationTypeVersion))]
    public class SetAzServiceFabricManagedClustersApplicationTypeVersion : ManagedApplicationCmdletBase
    {
        private const string ByResourceGroup = "ByResourceGroup";
        private const string ByInputObject = "ByInputObject";
        private const string ByResourceId = "ByResourceId";

        #region Paramters
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

        [Parameter(Mandatory = true, ParameterSetName = ByResourceGroup, Position = 2,
            HelpMessage = "Specify the name of the managed application type")]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationTypeName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceGroup, Position = 3,
            HelpMessage = "Specify the managed application type version")]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationTypeVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the url of the application package sfpkg file")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the url of the application package sfpkg file")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the url of the application package sfpkg file")]
        [ValidateNotNullOrEmpty]
        public string PackageUrl { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroup, HelpMessage = "Specify the tags as key/value pairs.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceId, HelpMessage = "Specify the tags as key/value pairs.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ByInputObject, HelpMessage = "Specify the tags as key/value pairs.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Arm ResourceId of the managed application type version.")]
        [ResourceIdCompleter(Constants.ManagedClustersFullType)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByInputObject, ValueFromPipeline = true,
            HelpMessage = "The managed application type version resource.")]
        public PSManagedApplicationTypeVersion InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Continue without prompts")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                this.SetParams();
                ApplicationTypeVersionResource updatedAppTypeVersionParams = null;
                switch (ParameterSetName)
                {
                    case ByResourceGroup:
                    case ByResourceId:
                        updatedAppTypeVersionParams = this.GetUpdatedAppTypeVersionParams();
                        break;
                    case ByInputObject:
                        updatedAppTypeVersionParams = this.GetUpdatedAppTypeVersionParams(this.InputObject);
                        break;
                    default:
                        throw new ArgumentException("Invalid parameter set", ParameterSetName);
                }

                if (updatedAppTypeVersionParams != null && ShouldProcess(target: this.Version, action: $"Update managed application type version. typename: {this.Name}, version {this.Version} in resource group {this.ResourceGroupName}"))
                {
                    var beginRequestResponse = this.SfrpMcClient.ApplicationTypeVersions.BeginCreateOrUpdateWithHttpMessagesAsync(
                        this.ResourceGroupName, this.ClusterName, this.Name, this.Version, updatedAppTypeVersionParams).GetAwaiter().GetResult();

                    var managedAppTypeVersion = this.PollLongRunningOperation(beginRequestResponse);

                    WriteObject(new PSManagedApplicationTypeVersion(managedAppTypeVersion), false);
                }
            }
            catch (Exception ex)
            {
                PrintSdkExceptionDetail(ex);
                throw;
            }
        }

        private ApplicationTypeVersionResource GetUpdatedAppTypeVersionParams(ApplicationTypeVersionResource inputObject = null)
        {
            ApplicationTypeVersionResource currentAppTypeVersion;

            if (inputObject == null)
            {
                currentAppTypeVersion = SafeGetResource(() =>
                    this.SfrpMcClient.ApplicationTypeVersions.Get(
                        this.ResourceGroupName, 
                        this.ClusterName, 
                        this.Name, 
                        this.Version),
                    false);

                if (currentAppTypeVersion == null)
                {
                    WriteError(new ErrorRecord(new InvalidOperationException($"Managed application type version '{this.Name}' does not exist."),
                        "ResourceDoesNotExist", ErrorCategory.InvalidOperation, null));
                    return currentAppTypeVersion;
                }
            }
            else
            {
                currentAppTypeVersion = inputObject;
            }

            if (this.IsParameterBound(c => c.PackageUrl))
            {
                currentAppTypeVersion.AppPackageUrl = this.PackageUrl;
            }
            if (this.IsParameterBound(c => c.Tag))
            {
                currentAppTypeVersion.Tags = this.Tag?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
            }

            return currentAppTypeVersion;
        }

        private void SetParams()
        {
            switch (ParameterSetName)
            {
                case ByResourceGroup:
                    break;
                case ByInputObject:
                    if (string.IsNullOrEmpty(this.InputObject?.Id))
                    {
                        throw new ArgumentException("ResourceId is null.");
                    }
                    SetParametersByResourceId(this.InputObject.Id);
                    break;
                case ByResourceId:
                    SetParametersByResourceId(this.ResourceId);
                    break;
            }
        }

        private void SetParametersByResourceId(string resourceId)
        {
            this.GetParametersByResourceId(resourceId, Constants.applicationTypeVersionProvider, out string resourceGroup, out string resourceName, out string parentResourceName, out string grandParentResourceName);
            this.ResourceGroupName = resourceGroup;
            this.Name = parentResourceName;
            this.Version = resourceName;
            this.ClusterName = grandParentResourceName;
        }
    }
}
