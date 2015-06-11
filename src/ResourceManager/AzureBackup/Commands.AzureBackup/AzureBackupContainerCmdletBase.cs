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
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System.Net;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    public abstract class AzureBackupContainerCmdletBase : AzureBackupCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.AzureBackupContainer, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public AzureBackupContainer AzureBackupContainer { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            WriteDebug(String.Format("Cmdlet called for ResourceGroupName: {0}, ResourceName: {1}, Location: {2}", AzureBackupContainer.ResourceGroupName, AzureBackupContainer.ResourceName, AzureBackupContainer.Location));

            InitializeAzureBackupCmdlet(AzureBackupContainer.ResourceGroupName, AzureBackupContainer.ResourceName, AzureBackupContainer.Location);
        }
    }
}