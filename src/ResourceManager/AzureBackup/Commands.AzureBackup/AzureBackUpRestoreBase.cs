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
using System.Collections.Generic;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.ServiceManagemenet.Common;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System.Net;
using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Cmdlets;

namespace Microsoft.Azure.Commands.AzureBackup
{
    public abstract class AzureBackupRestoreBase : AzureBackupCmdletBase
    {
        // ToDO:
        // Correct Help message and other attributes related to paameters
        [Parameter(Position = 0, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.AzureBackUpRecoveryPoint, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public AzureRMBackupRecoveryPoint RecoveryPoint { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            WriteDebug(String.Format(Resources.CmdletCalled, RecoveryPoint.ResourceGroupName, RecoveryPoint.ResourceName, RecoveryPoint.Location));
            InitializeAzureBackupCmdlet(RecoveryPoint.ResourceGroupName, RecoveryPoint.ResourceName);
        }
    }
}
