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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedClusterApplicationTypeVersion", SupportsShouldProcess = true), OutputType(typeof(PSManagedApplicationTypeVersion))]
    public class NewAzServiceFabricManagedClustersApplicationTypeVersion : ManagedApplicationCmdletBase
    {
        #region Paramters
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2,
            HelpMessage = "Specify the name of the managed application type")]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationTypeName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 3,
            HelpMessage = "Specify the managed application type version")]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationTypeVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the url of the application package sfpkg file")]
        [ValidateNotNullOrEmpty]
        public string PackageUrl { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Specify the tags as key/value pairs.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Continue without prompts")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.Version, action: $"Create new managed application type version. typename: {this.Name}, version {this.Version} in resource group {this.ResourceGroupName}"))
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
                        CreateManagedApplicationType(this.Name, cluster.Location, errorIfPresent: false);
                        var managedAppTypeVersion = CreateManagedApplicationTypeVersion(
                            applicationTypeName: this.Name,
                            typeVersion: this.Version,
                            location: cluster.Location,
                            packageUrl: this.PackageUrl,
                            force: this.Force.IsPresent,
                            tags: this.Tag);
                        WriteObject(new PSManagedApplicationTypeVersion(managedAppTypeVersion), false);
                    }
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }
    }
}
