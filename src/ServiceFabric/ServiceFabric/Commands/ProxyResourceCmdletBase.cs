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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ProxyResourceCmdletBase : ServiceFabricCmdletBase
    {
        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Specify the name of the cluster.")]
        [ValidateNotNullOrEmpty()]
        public virtual string ClusterName { get; set; }

        protected ApplicationTypeResource CreateApplicationType(string applicationTypeName)
        {
            var appTypeList = this.ReturnListByPageResponse(
                            this.SFRPClient.ApplicationTypes.List(this.ResourceGroupName, this.ClusterName),
                            this.SFRPClient.ApplicationTypes.ListNext); 

            var appType = appTypeList.FirstOrDefault(
                       type => type.Name.Equals(applicationTypeName, StringComparison.OrdinalIgnoreCase));

            if (appType != null)
            {
                WriteVerbose(string.Format("application type '{0}' already exists.", applicationTypeName));
                return appType;
            }

            WriteVerbose(string.Format("Creating app type '{0}'.", applicationTypeName));
            return this.SFRPClient.ApplicationTypes.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, applicationTypeName)
                .GetAwaiter().GetResult().Body;
        }

        protected ApplicationTypeVersionResource CreateApplicationTypeVersion(string applicationTypeName, string typeVersion, string packageUrl, bool force, Hashtable defaultParameters = null)
        {
            var appTypeVersion = SafeGetResource(() =>
                this.SFRPClient.ApplicationTypeVersions.Get(
                    this.ResourceGroupName,
                    this.ClusterName,
                    applicationTypeName,
                    typeVersion),
                false);

            if (appTypeVersion != null)
            {
                WriteVerbose(string.Format("application type version '{0}':{1} already exists.", applicationTypeName, typeVersion));
                if (appTypeVersion.ProvisioningState == "Failed")
                {
                    string resourceMessage = string.Format("ApplicationTypeVersion {0}:{1}", applicationTypeName, typeVersion);
                    ConfirmAction(force,
                        string.Format("{0} already exits but provisioning is in Failed state. Do you want to recreate the resource?", resourceMessage),
                        "Recreating application type version.",
                        resourceMessage,
                        () =>
                        {
                            appTypeVersion = CreateOrUpdateApplicationTypeVersion(applicationTypeName, typeVersion, packageUrl, defaultParameters);
                        });
                }
            }
            else
            {
                appTypeVersion = CreateOrUpdateApplicationTypeVersion(applicationTypeName, typeVersion, packageUrl, defaultParameters);
            }
            
            if (appTypeVersion.ProvisioningState == "Failed")
            {
                throw new PSInvalidOperationException(string.Format("ApplicationTypeVersion {0}:{1} is in provisioning state {2}", applicationTypeName, typeVersion, appTypeVersion.ProvisioningState));
            }

            return appTypeVersion;
        }

        private ApplicationTypeVersionResource CreateOrUpdateApplicationTypeVersion(string applicationTypeName, string typeVersion, string packageUrl, Hashtable defaultParameters)
        {
            WriteVerbose(string.Format("Creating app type version '{0}':{1}.", applicationTypeName, typeVersion));
            ApplicationTypeVersionResource appTypeVersionParams = new ApplicationTypeVersionResource(
                    appPackageUrl: packageUrl,
                    name: this.ClusterName,
                    type: applicationTypeName,
                    defaultParameterList: defaultParameters?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string));

            return StartRequestAndWait<ApplicationTypeVersionResource>(
                () => this.SFRPClient.ApplicationTypeVersions.BeginCreateOrUpdateWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    this.ClusterName,
                    applicationTypeName,
                    typeVersion,
                    appTypeVersionParams),
                () => string.Format("Provisioning state: {0}", GetAppTypeVersionProvisioningStatus(applicationTypeName, typeVersion) ?? "Not found"));
        }

        protected string GetAppTypeVersionProvisioningStatus(string applicationTypeName, string version)
        {
            var resource = SafeGetResource(() =>
                this.SFRPClient.ApplicationTypeVersions.Get(
                    this.ResourceGroupName,
                    this.ClusterName,
                    applicationTypeName,
                    version),
                true);

            if (resource != null)
            {
                return resource.ProvisioningState;
            }

            return null;
        }
    }
}
