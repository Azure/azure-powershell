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
    // Correct the Commandlet
    // Correct the OperationResponse
    // Get Tracking API from Piyush and Get JobResponse
    // Get JobResponse Object from Aditya

    /// <summary>
    /// Enable Azure Backup protection
    /// </summary>
    [Cmdlet(VerbsLifecycle.Enable, "AzureBackupProtection"), OutputType(typeof(OperationResponse))]
    public class EnableAzureBackupProtection : AzureBackupItemCmdletBase
    {
        [Parameter(Position = 1, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.PolicyName)]
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
                if (AzureBackupItem.GetType() == ((AzureBackupItem)AzureBackupItem).GetType())
                {
                    input.ProtectableObjectType = (AzureBackupItem as AzureBackupItem).Type;
                    input.ProtectableObjects.Add((AzureBackupItem as AzureBackupItem).Name);
                }
                else if (AzureBackupItem.GetType() == ((AzureBackupContainer)AzureBackupItem).GetType())
                {
                    if((AzureBackupItem as AzureBackupContainer).ContainerType == ContainerType.IaasVMContainer.ToString())
                    {
                        input.ProtectableObjectType = DataSourceType.VM.ToString();
                        input.ProtectableObjects.Add((AzureBackupItem as AzureBackupContainer).ContainerUniqueName);
                    }
                }
                else
                {

                }

                var enableAzureBackupProtection = AzureBackupClient.DataSource.EnableProtectionAsync(GetCustomRequestHeaders(), input, CmdletCancellationToken).Result;

                WriteVerbose("Received policy response");
                WriteVerbose("Converting response");
                WriteAzureBackupProtectionPolicy(enableAzureBackupProtection);
            });
        }

        public void WriteAzureBackupProtectionPolicy(OperationResponse sourceOperationResponse)
        {
            // this needs to be uncommented once we have proper constructor
            //this.WriteObject(new AzureBackupRecoveryPoint(ResourceGroupName, ResourceName, sourceOperationResponse));
        }

        public void WriteAzureBackupProtectionPolicy(IEnumerable<OperationResponse> sourceOperationResponseList)
        {
            List<OperationResponse> targetList = new List<OperationResponse>();

            foreach (var sourceOperationResponse in sourceOperationResponseList)
            {
                // this needs to be uncommented once we have proper constructor
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
            Invalid = 0,

            [EnumMember]
            VM

            // TODO: fix GetJobTypes() in PortalMetadataInternalEP.cs
            // [EnumMember]
            // AzureStorageAccount
        }
    }
}
