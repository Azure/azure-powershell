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

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedClusterApplication", SupportsShouldProcess = true, DefaultParameterSetName = SkipAppTypeVersion), OutputType(typeof(PSManagedApplication))]
    public class NewAzServiceFabricManagedClusterApplication : ManagedApplicationCmdletBase
    {
        protected const string SkipAppTypeVersion = "SkipAppTypeVersion";
        protected const string CreateAppTypeVersion = "CreateAppTypeVersion";

        protected const string AppTypeArmResourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.ServiceFabric/managedclusters/{2}/applicationTypes/{3}/versions/{4}";

        #region Parameters
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SkipAppTypeVersion, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = CreateAppTypeVersion, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SkipAppTypeVersion, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = CreateAppTypeVersion, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = SkipAppTypeVersion,
            HelpMessage = "Specify the name of the managed application type")]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = CreateAppTypeVersion,
            HelpMessage = "Specify the name of the managed application type")]
        [ValidateNotNullOrEmpty]
        public string ApplicationTypeName { get; set; }

        [Parameter(Mandatory = true, Position = 3, ParameterSetName = SkipAppTypeVersion,
            HelpMessage = "Specify the managed application type version")]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = CreateAppTypeVersion,
            HelpMessage = "Specify the managed application type version")]
        [ValidateNotNullOrEmpty]
        public string ApplicationTypeVersion { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SkipAppTypeVersion,
            HelpMessage = "Specify the name of the managed application")]
        [Parameter(Mandatory = true, ParameterSetName = CreateAppTypeVersion,
            HelpMessage = "Specify the name of the managed application")]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = SkipAppTypeVersion,
            HelpMessage = "Specify the application parameters as key/value pairs. These parameters must exist in the application manifest.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = CreateAppTypeVersion,
            HelpMessage = "Specify the application parameters as key/value pairs. These parameters must exist in the application manifest.")]
        [ValidateNotNullOrEmpty]
        public Hashtable ApplicationParameter { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = CreateAppTypeVersion,
            HelpMessage = "Specify the url of the application package sfpkg file")]
        [ValidateNotNullOrEmpty]
        public string PackageUrl { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = SkipAppTypeVersion, HelpMessage = "Specify the tags as key/value pairs.")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = CreateAppTypeVersion, HelpMessage = "Specify the tags as key/value pairs.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Continue without prompts")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.Name, action:
                $"Create new application. name {this.Name}, typename: {this.ApplicationTypeName}, version {this.ApplicationTypeVersion}, in resource group {this.ResourceGroupName}"))
            {
                try
                {
                    ManagedCluster cluster = SafeGetResource(() => this.SfrpMcClient.ManagedClusters.Get(this.ResourceGroupName, this.ClusterName));
                    if (cluster == null)
                    {
                        WriteError(new ErrorRecord(new InvalidOperationException($"Parent cluster '{this.ClusterName}' does not exist."),
                            "ResourceDoesNotExist", ErrorCategory.InvalidOperation, null));
                    }
                    else
                    {
                        if (ParameterSetName == CreateAppTypeVersion)
                        {
                            CreateManagedApplicationType(this.ApplicationTypeName, cluster.Location);
                            CreateManagedApplicationTypeVersion(
                                applicationTypeName: this.ApplicationTypeName,
                                typeVersion: this.ApplicationTypeVersion,
                                location: cluster.Location,
                                packageUrl: this.PackageUrl,
                                force: this.Force.IsPresent);
                        }

                        var managedApp = CreateManagedApplication(cluster.Location);
                        WriteObject(new PSManagedApplication(managedApp), false);
                    }
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private ApplicationResource CreateManagedApplication(string location)
        {
            var managedApp = SafeGetResource(() =>
                this.SfrpMcClient.Applications.Get(
                    this.ResourceGroupName,
                    this.ClusterName,
                    this.Name),
                false);

            if (managedApp != null)
            {
                WriteError(new ErrorRecord(new InvalidOperationException($"Managed application '{this.Name}' already exists."),
                    "ResourceAlreadyExists", ErrorCategory.InvalidOperation, null));
                return managedApp;
            }

            WriteVerbose($"Creating managed application '{this.Name}'");

            ApplicationResource appParams = GetNewAppParameters(location);

            var beginRequestResponse = this.SfrpMcClient.Applications.BeginCreateOrUpdateWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    this.ClusterName,
                    this.Name,
                    appParams).GetAwaiter().GetResult();

            return this.PollLongRunningOperation(beginRequestResponse);
        }

        private ApplicationResource GetNewAppParameters(string location)
        {
            return new ApplicationResource(
                    name: this.Name,
                    version: this.GetAppTypeArmResourceId(this.DefaultContext.Subscription.Id, this.ResourceGroupName, this.ClusterName, this.ApplicationTypeName, this.ApplicationTypeVersion),
                    parameters: this.ApplicationParameter?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string),
                    location: location,
                    tags: this.Tag?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string));
        }

        private string GetAppTypeArmResourceId(string subscriptionId, string resourceGroup, string clusterName, string appTypeName, string appTypeVersion)
        {
            return string.Format(AppTypeArmResourceIdFormat, subscriptionId, resourceGroup, clusterName, appTypeName, appTypeVersion);
        }
    }
}
