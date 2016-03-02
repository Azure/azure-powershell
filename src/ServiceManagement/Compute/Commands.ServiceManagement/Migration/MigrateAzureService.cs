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
using System.Management.Automation;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.HostedServices
{
    /// <summary>
    /// Migrate ASM deployment to ARM
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "AzureService"), OutputType(typeof(OperationStatusResponse))]
    public class MigrateAzureServiceCommand : ServiceManagementBaseCmdlet
    {
        private const string AbortParameterSetName = "AbortMigrationParameterSet";
        private const string CommitParameterSetName = "CommitMigrationParameterSet";
        private const string PrepareParameterSetName = "PrepareMigrationParameterSet";

        [Parameter(
            Position =0,
            Mandatory = true,
            ParameterSetName = AbortParameterSetName,
            HelpMessage = "Abort migration")]
        public SwitchParameter Abort
        {
            get;
            set;
        }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = CommitParameterSetName,
            HelpMessage = "Commit migration")]
        public SwitchParameter Commit
        {
            get;
            set;
        }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = PrepareParameterSetName,
            HelpMessage = "Prepare migration")]
        public SwitchParameter Prepare
        {
            get;
            set;
        }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName
        {
            get;
            set;
        }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Deployment name")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName
        {
            get;
            set;
        }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ParameterSetName = PrepareParameterSetName,
            HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateSet(DestinationVirtualNetwork.Default, DestinationVirtualNetwork.New, DestinationVirtualNetwork.Existing)]
        public string DestinationVNetType
        {
            get;
            set;
        }


        [Parameter(
            Position = 4,
            Mandatory = false,
            ParameterSetName = PrepareParameterSetName,
            HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName
        {
            get;
            set;
        }


        [Parameter(
            Position = 5,
            Mandatory = false,
            ParameterSetName = PrepareParameterSetName,
            HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName
        {
            get;
            set;
        }

        [Parameter(
            Position = 6,
            Mandatory = false,
            ParameterSetName = PrepareParameterSetName, 
            HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateNotNullOrEmpty]
        public string SubnetName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (this.Abort.IsPresent)
            {
                
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.Deployments.AbortMigration(this.ServiceName, DeploymentName));
            }
            else if (this.Commit.IsPresent)
            {
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.Deployments.CommitMigration(this.ServiceName, DeploymentName));
            }
            else
            {
                var parameter = new PrepareDeploymentMigrationParameters
                {
                    DestinationVirtualNetwork = this.DestinationVNetType
                };

                if (this.DestinationVNetType.Equals(DestinationVirtualNetwork.Existing))
                {
                    parameter.ResourceGroupName = this.ResourceGroupName;
                    parameter.SubNetName = this.SubnetName;
                    parameter.VirtualNetworkName = this.VirtualNetworkName;
                }

                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.Deployments.PrepareMigration(this.ServiceName, DeploymentName, parameter));
            }
            
        }
    }
}