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
using System.Collections.Generic;
using System.Linq;
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
    [Cmdlet(VerbsCommon.Get, "AzureWebsiteDeployment"), OutputType(typeof(List<DeployResult>))]
    public class GetAzureWebsiteDeploymentCommand : DeploymentBaseCmdlet
    {
        internal const int DefaultMaxResults = 20;

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The maximum number of results to display.")]
        [ValidateNotNullOrEmpty]
        public string CommitId
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The maximum number of results to display.")]
        [ValidateNotNullOrEmpty]
        public int? MaxResults
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "show deployment details")]
        public SwitchParameter Details
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureWebsiteDeploymentCommand class.
        /// </summary>
        public GetAzureWebsiteDeploymentCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureWebsiteDeploymentCommand class.
        /// </summary>
        /// <param name="deploymentChannel">
        /// Channel used for communication with the git repository.
        /// </param>
        public GetAzureWebsiteDeploymentCommand(IDeploymentServiceManagement deploymentChannel)
        {
            DeploymentChannel = deploymentChannel;
        }

        internal void SetDetails(DeployResult deployResult)
        {
            InvokeInDeploymentOperationContext(() => { deployResult.Logs = DeploymentChannel.GetDeploymentLogs(deployResult.Id); });
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            InvokeInDeploymentOperationContext(() =>
            {
                List<DeployResult> deployments = DeploymentChannel.GetDeployments(MaxResults ?? DefaultMaxResults);

                if (CommitId != null)
                {
                    DeployResult deployment = deployments.FirstOrDefault(d => d.Id.Equals(CommitId));
                    if (deployment == null)
                    {
                        throw new Exception(string.Format(Resources.InvalidDeployment, CommitId));
                    }

                    if (Details)
                    {
                        SetDetails(deployment);
                    }

                    deployments.Add(deployment);
                } 
                else if (Details)
                {
                    foreach (DeployResult deployResult in deployments)
                    {
                        SetDetails(deployResult);
                    }
                }

                WriteObject(deployments, true);
            });
        }
    }
}
