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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ServiceFabricApplicationTypeVersion", SupportsShouldProcess = true), OutputType(typeof(PSApplicationTypeVersion))]
    public class NewAzServiceFabricApplicationTypeVersion : ProxyResourceCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.ServiceFabric/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2,
            HelpMessage = "Specify the name of the application type")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationTypeName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 3,
            HelpMessage = "Specify the application type version")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationTypeVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the url of the application package sfpkg file")]
        [ValidateNotNullOrEmpty()]
        public string PackageUrl { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the default values of the application parameters as key/value pairs. These parameters must exist in the application manifest.")]
        [ValidateNotNullOrEmpty()]
        public Hashtable DefaultParameter { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Continue without prompts")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.ResourceGroupName, action: string.Format("Create new application type version. typename: {0}, version {1}", this.Name, this.Version)))
            {
                try
                {
                    CreateApplicationType(this.Name);
                    var appTypeVersion = CreateApplicationTypeVersion(this.Name, this.Version, this.PackageUrl, this.Force.IsPresent, this.DefaultParameter);
                    WriteObject(new PSApplicationTypeVersion(appTypeVersion), false);
                }
                catch (ErrorModelException ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }
    }
}
