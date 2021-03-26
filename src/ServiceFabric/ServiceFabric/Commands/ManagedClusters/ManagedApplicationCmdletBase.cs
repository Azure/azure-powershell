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
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ManagedApplicationCmdletBase : ServiceFabricManagedCmdletBase
    {
        #region TEST
        internal static bool RunningTest = false;
        #endregion

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Specify the name of the cluster.")]
        [ValidateNotNullOrEmpty]
        public virtual string ClusterName { get; set; }

        protected ApplicationTypeResource CreateManagedApplicationType(string applicationTypeName, string location, Hashtable tags = null, bool errorIfPresent = true)
        {
            ApplicationTypeResource applicationType = SafeGetResource(() => this.SfrpMcClient.ApplicationTypes.Get(this.ResourceGroupName, this.ClusterName, applicationTypeName));
            if (applicationType != null)
            {
                if (errorIfPresent)
                {
                    WriteError(new ErrorRecord(new InvalidOperationException($"Managed app type '{applicationTypeName}' already exists."),
                        "ResourceAlreadyExists", ErrorCategory.InvalidOperation, null));
                }
                else
                {
                    WriteVerbose($"Managed app type '{applicationTypeName}' already exists.");
                }

                return applicationType;
            }
            else
            {
                WriteVerbose($"Creating managed app type '{applicationTypeName}'.");
                ApplicationTypeResource newAppTypeParams = this.GetNewAppTypeParameters(location, tags:tags);
                return this.SfrpMcClient.ApplicationTypes.CreateOrUpdate(this.ResourceGroupName, this.ClusterName, applicationTypeName, newAppTypeParams);
            }
        }

        private ApplicationTypeResource GetNewAppTypeParameters(string location, Hashtable tags = null)
        {
            return new ApplicationTypeResource(
                location: location,
                tags: tags?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string));
        }

        protected ApplicationTypeVersionResource CreateManagedApplicationTypeVersion(string applicationTypeName, string typeVersion, string location, string packageUrl, bool force, Hashtable tags = null)
        {
            var appTypeVersion = SafeGetResource(() =>
                this.SfrpMcClient.ApplicationTypeVersions.Get(
                    this.ResourceGroupName,
                    this.ClusterName,
                    applicationTypeName,
                    typeVersion),
                false);

            if (appTypeVersion != null)
            {
                if (appTypeVersion.ProvisioningState == "Failed")
                {
                    WriteVerbose($"Managed application type version '{applicationTypeName}':{typeVersion} already exists.");
                    string resourceMessage = $"Managed ApplicationTypeVersion {applicationTypeName}:{typeVersion}";
                    ConfirmAction(force,
                        $"{resourceMessage} already exits but provisioning is in Failed state. Do you want to recreate the resource?",
                        "Recreating managed application type version.",
                        resourceMessage,
                        () =>
                        {
                            appTypeVersion = CreateOrUpdateApplicationTypeVersion(
                                applicationTypeName: applicationTypeName,
                                typeVersion: typeVersion,
                                location: location,
                                packageUrl: packageUrl,
                                tags: tags);
                        });
                }
                else
                {
                    WriteError(new ErrorRecord(new InvalidOperationException($"Managed app type version '{applicationTypeName}' already exists."),
                        "ResourceAlreadyExists", ErrorCategory.InvalidOperation, null));
                }
            }
            else
            {
                appTypeVersion = CreateOrUpdateApplicationTypeVersion(
                    applicationTypeName: applicationTypeName,
                    typeVersion: typeVersion,
                    location: location,
                    packageUrl: packageUrl,
                    tags: tags);
            }

            if (appTypeVersion.ProvisioningState == "Failed")
            {
                throw new PSInvalidOperationException($"Managed ApplicationTypeVersion {applicationTypeName}:{typeVersion} is in provisioning state {appTypeVersion.ProvisioningState}");
            }

            return appTypeVersion;
        }

        private ApplicationTypeVersionResource CreateOrUpdateApplicationTypeVersion(string applicationTypeName, string typeVersion, string location, string packageUrl, Hashtable tags)
        {
            WriteVerbose($"Creating managed app type version '{applicationTypeName}':{typeVersion}.");
            ApplicationTypeVersionResource managedAppTypeVersionParams = this.GetNewAppTypeVersionParameters(applicationTypeName, location, packageUrl, tags);

            var beginRequestResponse = this.SfrpMcClient.ApplicationTypeVersions.BeginCreateOrUpdateWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    this.ClusterName,
                    applicationTypeName,
                    typeVersion,
                    managedAppTypeVersionParams).GetAwaiter().GetResult();

            return this.PollLongRunningOperation(beginRequestResponse);
        }

        private ApplicationTypeVersionResource GetNewAppTypeVersionParameters(string applicationTypeName, string location, string packageUrl, Hashtable tags)
        {
            return new ApplicationTypeVersionResource(
                    appPackageUrl: packageUrl,
                    name: this.ClusterName,
                    type: applicationTypeName,
                    location: location,
                    tags: tags?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string));
        }
    }
}
