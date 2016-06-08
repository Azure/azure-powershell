﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Network;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Network
{
    /// <summary>
    /// Migrate ASM virtual network to ARM
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "AzureVirtualNetwork"), OutputType(typeof(OperationStatusResponse))]
    public class MoveVirtualNetworkCommand : ServiceManagementBaseCmdlet
    {
        private const string AbortParameterSetName = "AbortMigrationParameterSet";
        private const string CommitParameterSetName = "CommitMigrationParameterSet";
        private const string PrepareParameterSetName = "PrepareMigrationParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = AbortParameterSetName,
            HelpMessage = "Abort migration")]
        public SwitchParameter Abort
        {
            get;
            set;
        }

        [Parameter(Position = 0,
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
            HelpMessage = "Virtual network name")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName
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
                () => this.NetworkClient.Networks.AbortMigration(this.VirtualNetworkName));
            }
            else if (this.Commit.IsPresent)
            {
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.NetworkClient.Networks.CommitMigration(this.VirtualNetworkName));
            }
            else
            {
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.NetworkClient.Networks.PrepareMigration(this.VirtualNetworkName));
            }
        }
    }
}