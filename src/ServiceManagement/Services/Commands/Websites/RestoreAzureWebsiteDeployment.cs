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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    /// <summary>
    /// Gets the git deployments.
    /// </summary>
    [Cmdlet(VerbsData.Restore, "AzureWebsiteDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High), OutputType(typeof(List<DeployResult>))]
    public class RestoreAzureWebsiteDeploymentCommand : DeploymentBaseCmdlet
    {
        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The maximum number of results to display.")]
        [ValidateNotNullOrEmpty]
        public string CommitId
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "Do not confirm redeploy")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the RestoreAzureWebsiteDeploymentCommand class.
        /// </summary>
        public RestoreAzureWebsiteDeploymentCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RestoreAzureWebsiteDeploymentCommand class.
        /// </summary>
        /// <param name="deploymentChannel">
        /// Channel used for communication with the git repository.
        /// </param>
        public RestoreAzureWebsiteDeploymentCommand(IDeploymentServiceManagement deploymentChannel)
        {
            DeploymentChannel = deploymentChannel;
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!Force.IsPresent &&
                !ShouldProcess("", string.Format(Resources.RedeployCommit, CommitId),
                                Resources.ShouldProcessCaption))
            {
                return;
            }

            InvokeInDeploymentOperationContext(() => DeploymentChannel.Deploy(CommitId));

            // List new deployments
            InvokeInDeploymentOperationContext(() =>
            {
                List<DeployResult> deployments = DeploymentChannel.GetDeployments(GetAzureWebsiteDeploymentCommand.DefaultMaxResults);
                WriteObject(deployments, true);
            });
        }
    }
}