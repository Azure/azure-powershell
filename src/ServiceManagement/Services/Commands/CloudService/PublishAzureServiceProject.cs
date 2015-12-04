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

using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.CloudService
{
    /// <summary>
    /// Create a new deployment. Note that there shouldn't be a deployment 
    /// of the same name or in the same slot when executing this command.
    /// </summary>
    [Cmdlet(VerbsData.Publish, "AzureServiceProject", DefaultParameterSetName = ServicePublishParamSet), OutputType(typeof(Deployment))]
    public class PublishAzureServiceProjectCommand : AzureSMCmdlet
    {
        private const string ServicePublishParamSet = "PublishFromServiceDefinition";
        private const string PackagePublishParamSet = "PublishFromPackage";
        public ICloudServiceClient CloudServiceClient { get; set; }

        [Parameter(Mandatory = false, Position = 0, ParameterSetName = ServicePublishParamSet, ValueFromPipelineByPropertyName = true)]
        [Alias("sv")]
        public string ServiceName { get; set; }

        [Parameter(Mandatory = false, Position = 0, ParameterSetName = PackagePublishParamSet, ValueFromPipelineByPropertyName = true)]
        [Alias("sp")]
        public string Package { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = PackagePublishParamSet, ValueFromPipelineByPropertyName = true)]
        [Alias("cc")]
        public string Configuration { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("st")]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("l")]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("sl")]
        public string Slot { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("ln")]
        public SwitchParameter Launch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("ag")]
        public string AffinityGroup { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("dn")]
        public string DeploymentName { get; set; }

        [Parameter(Mandatory = false)]
        [Alias("f")]
        public SwitchParameter ForceUpgrade { get; set; }

        /// <summary>
        /// Execute the command.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            CloudServiceClient = CloudServiceClient ?? new CloudServiceClient(
                Profile,
                Profile.Context.Subscription,
                SessionState.Path.CurrentLocation.Path,
                WriteDebug,
                WriteVerbose,
                WriteWarning);

            Deployment deployment;

            if (!string.IsNullOrEmpty(Package))
            {
                deployment = CloudServiceClient.PublishCloudService(
                    Package,
                    Configuration,
                    Slot,
                    Location,
                    AffinityGroup,
                    StorageAccountName,
                    DeploymentName,
                    Launch,
                    ForceUpgrade);
            }
            else
            {
                deployment = CloudServiceClient.PublishCloudService(
                    ServiceName,
                    Slot,
                    Location,
                    AffinityGroup,
                    StorageAccountName,
                    DeploymentName,
                    Launch,
                    ForceUpgrade);
            }

            WriteObject(deployment);
        }
    }
}
