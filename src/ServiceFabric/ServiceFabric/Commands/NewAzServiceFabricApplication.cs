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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ServiceFabricApplication", SupportsShouldProcess = true, DefaultParameterSetName = SkipAppTypeVersion), OutputType(typeof(PSApplication))]
    public class NewAzServiceFabricApplication : ProxyResourceCmdletBase
    {
        protected const string SkipAppTypeVersion = "SkipAppTypeVersion";
        protected const string CreateAppTypeVersion = "CreateAppTypeVersion";

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true, ParameterSetName = SkipAppTypeVersion,
                   HelpMessage = "Specify the name of the application type")]
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true, ParameterSetName = CreateAppTypeVersion,
                   HelpMessage = "Specify the name of the application type")]
        [ValidateNotNullOrEmpty()]
        public string ApplicationTypeName { get; set; }

        [Parameter(Mandatory = true, Position = 3, ValueFromPipeline = true, ParameterSetName = SkipAppTypeVersion,
                   HelpMessage = "Specify the application type version")]
        [Parameter(Mandatory = true, Position = 3, ValueFromPipeline = true, ParameterSetName = CreateAppTypeVersion,
                   HelpMessage = "Specify the application type version")]
        [ValidateNotNullOrEmpty()]
        public string ApplicationTypeVersion { get; set; }

        [Parameter(Mandatory = true, Position = 4, ValueFromPipeline = true, ParameterSetName = SkipAppTypeVersion,
                   HelpMessage = "Specify the name of the application")]
        [Parameter(Mandatory = true, Position = 4, ValueFromPipeline = true, ParameterSetName = CreateAppTypeVersion,
                   HelpMessage = "Specify the name of the application")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = true, ParameterSetName = SkipAppTypeVersion,
                   HelpMessage = "Specify the application parameters as key/value pairs. These parameters must exist in the application manifest.")]
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = true, ParameterSetName = CreateAppTypeVersion,
                   HelpMessage = "Specify the application parameters as key/value pairs. These parameters must exist in the application manifest.")]
        [ValidateNotNullOrEmpty()]
        public Hashtable ApplicationParameter { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateAppTypeVersion,
                   HelpMessage = "Specify the url of the application package sfpkg file")]
        [ValidateNotNullOrEmpty()]
        public string PackageUrl { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = SkipAppTypeVersion,
                   HelpMessage = "Specifies the minimum number of nodes where Service Fabric will reserve capacity for this application")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = CreateAppTypeVersion,
                   HelpMessage = "Specifies the minimum number of nodes where Service Fabric will reserve capacity for this application")]
        [ValidateNotNullOrEmpty()]
        long? MinimumNodes { get; set; }
        
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = SkipAppTypeVersion,
                   HelpMessage = "Specifies the maximum number of nodes on which to place an application")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = CreateAppTypeVersion,
                   HelpMessage = "Specifies the maximum number of nodes on which to place an application")]
        [ValidateNotNullOrEmpty()]
        long? MaximumNodes { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Continue without prompts")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.ResourceGroupName, action: string.Format("Create new application. name {0}, typename: {1}, version {2}", this.Name, this.ApplicationTypeName, this.ApplicationTypeVersion)))
            {
                try
                {
                    if (ParameterSetName == CreateAppTypeVersion)
                    {
                        CreateApplicationType(this.ApplicationTypeName);
                        CreateApplicationTypeVersion(this.ApplicationTypeName, this.ApplicationTypeVersion, this.PackageUrl, this.Force.IsPresent);
                    }

                    var app = CreateApplication();
                    WriteObject(app);
                }
                catch (ErrorModelException ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private ApplicationResource CreateApplication()
        {
            var app = SafeGetResource(() =>
                this.SFRPClient.Applications.Get(
                    this.ResourceGroupName,
                    this.ClusterName,
                    this.ApplicationTypeName),
                false);

            if (app != null)
            {
                WriteVerbose(string.Format("Application '{0}' already exists.", this.Name));
                return app;
            }

            WriteVerbose(string.Format("Creating application '{0}'", this.Name));
            ApplicationResource appParams = new ApplicationResource(
                    name: this.Name,
                    typeName: this.ApplicationTypeName,
                    typeVersion: this.ApplicationTypeVersion,
                    parameters: this.ApplicationParameter?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string),
                    minimumNodes: this.MinimumNodes,
                    maximumNodes: this.MaximumNodes);

            return StartRequestAndWait<ApplicationResource>(
                () => this.SFRPClient.Applications.BeginCreateOrUpdateWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    this.ClusterName,
                    this.Name,
                    appParams),
                () => string.Format("Provisioning state: {0}", GetAppProvisioningStatus() ?? "Not found"));
        }

        protected string GetAppProvisioningStatus()
        {
            var resource = SafeGetResource(() =>
                this.SFRPClient.Applications.Get(
                    this.ResourceGroupName,
                    this.ClusterName,
                    this.Name),
                true);

            if (resource != null)
            {
                return resource.ProvisioningState;
            }

            return null;
        }
    }
}
