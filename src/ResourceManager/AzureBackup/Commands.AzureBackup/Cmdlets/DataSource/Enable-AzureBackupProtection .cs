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
using System.Linq;
using Microsoft.Azure.Management.BackupServices.Models;
using MBS = Microsoft.Azure.Management.BackupServices;
using System.Runtime.Serialization;
using Microsoft.Azure.Management.BackupServices;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    // ToDo:
    // Get Tracking API from Piyush and Get JobResponse

    /// <summary>
    /// Enable Azure Backup protection
    /// </summary>
    [Cmdlet(VerbsLifecycle.Enable, "AzureBackupProtection"), OutputType(typeof(OperationResponse))]
    public class EnableAzureBackupProtection : AzureBackupItemCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName)]
        [ValidateNotNullOrEmpty]
        public AzureBackupProtectionPolicy Policy { get; set; }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteVerbose("Making client call");
                SetProtectionRequestInput input = new SetProtectionRequestInput();
                input.PolicyId = Policy.InstanceId;
                if (Item.GetType() == typeof(AzureBackupItem))
                {
                    input.ProtectableObjectType = (Item as AzureBackupItem).Type;
                    input.ProtectableObjects.Add((Item as AzureBackupItem).Name);
                }
                else if (Item.GetType() == typeof(AzureBackupContainer))
                {
                    WriteVerbose("Input is container Type = "+Item.GetType());
                    if((Item as AzureBackupContainer).ContainerType == ContainerType.IaasVMContainer.ToString())
                    {
                        WriteVerbose("container Type = " + (Item as AzureBackupContainer).ContainerType);
                        input.ProtectableObjectType = DataSourceType.VM.ToString();
                        input.ProtectableObjects.Add((Item as AzureBackupContainer).ContainerUniqueName);
                    }
                    else
                    {
                        throw new Exception("Uknown item type");
                    }
                }
                else
                {
                    throw new Exception("Uknown item type");
                }

                var enableAzureBackupProtection = AzureBackupClient.DataSource.EnableProtectionAsync(GetCustomRequestHeaders(), input, CmdletCancellationToken).Result;

                WriteVerbose("Received response");
                WriteVerbose("Converting response");
                WriteAzureBackupProtectionPolicy(enableAzureBackupProtection);
            });
        }

        public void WriteAzureBackupProtectionPolicy(OperationResponse sourceOperationResponse)
        {
        }

        public void WriteAzureBackupProtectionPolicy(IEnumerable<OperationResponse> sourceOperationResponseList)
        {
            List<OperationResponse> targetList = new List<OperationResponse>();

            foreach (var sourceOperationResponse in sourceOperationResponseList)
            {
                targetList.Add(sourceOperationResponse);
            }

            this.WriteObject(targetList, true);
        }
        public enum ContainerType
        {
            [EnumMember]
            Invalid = 0,

            [EnumMember]
            Unknown,

            // used by fabric adapter to populate discovered VMs
            [EnumMember]
            IaasVMContainer,

            // used by fabric adapter to populate discovered services
            // VMs are child containers of services they belong to
            [EnumMember]
            IaasVMServiceContainer
        }
        public enum DataSourceType
        {
            [EnumMember]
            VM
        }
    }
}
