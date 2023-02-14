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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using System.Collections.Generic;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Used for Data Source Move operation. Currently we only support vault level data move from one region to another.
    /// </summary>
    [Cmdlet("Initialize", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesDSMove", SupportsShouldProcess = true), OutputType(typeof(String))]
    public class InitializeAzureRMRecoveryServicesDSMove : RecoveryServicesBackupCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Source Vault for Data Move Operation
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.DSMove.SourceVault,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault SourceVault;

        /// <summary>
        /// Target Vault for Data Move Operation
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, HelpMessage = ParamHelpMsgs.DSMove.TargetVault,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault TargetVault;

        /// <summary>
        /// Retries data move only with unmoved containers in the source vault
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.DSMove.RetryOnlyFailed)]
        public SwitchParameter RetryOnlyFailed;

        #endregion Parameters

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {                  
                base.ExecuteCmdlet();

                // fetch source vault and target vault subscription
                Dictionary<CmdletModel.UriEnums, string> SourceVaultDict = HelperUtils.ParseUri(SourceVault.ID);
                string sourceSub = SourceVaultDict[CmdletModel.UriEnums.Subscriptions];

                // change subscription for HTTP requests
                string subscriptionContext = ServiceClientAdapter.BmsAdapter.Client.SubscriptionId;

                // Prepare Data Move
                ServiceClientAdapter.BmsAdapter.Client.SubscriptionId = sourceSub;
                PrepareDataMoveRequest prepareMoveRequest = new PrepareDataMoveRequest();  
                prepareMoveRequest.TargetResourceId = TargetVault.ID;
                prepareMoveRequest.TargetRegion = TargetVault.Location; 

                // currently only allowing vault level data move
                prepareMoveRequest.DataMoveLevel = "Vault";

                if (RetryOnlyFailed.IsPresent)
                {
                    prepareMoveRequest.IgnoreMoved = true;
                }
                else
                {
                    prepareMoveRequest.IgnoreMoved = false;
                }

                Logger.Instance.WriteDebug("Retry only with failed items : " + prepareMoveRequest.IgnoreMoved);
                Logger.Instance.WriteDebug("Location of Target vault: " + TargetVault.Location);
                                
                /* move Prepare move function to vault APIs */
                string correlationId = ServiceClientAdapter.PrepareDataMove(SourceVault.Name, SourceVault.ResourceGroupName, prepareMoveRequest);
                
                ServiceClientAdapter.BmsAdapter.Client.SubscriptionId = subscriptionContext; // set subscription to original
                WriteObject(correlationId);                    
            }, ShouldProcess(TargetVault.Name, VerbsCommon.Set));
        }
    }
}
