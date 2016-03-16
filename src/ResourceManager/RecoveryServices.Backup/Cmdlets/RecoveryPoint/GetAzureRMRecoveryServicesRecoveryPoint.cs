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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRMRecoveryServicesRecoveryPoint"), OutputType(typeof(List<AzureRmRecoveryServicesRecoveryPointBase>))]
    class GetAzureRMRecoveryServicesRecoveryPoint : RecoveryServicesBackupCmdletBase
    {
        internal const string DateTimeFileterParameterSet = "DateTimeFilter";
        internal const string RecoveryPointIdParameterSet = "RecoveryPointId";

        [Parameter(Mandatory = true, ParameterSetName = DateTimeFileterParameterSet, HelpMessage = "", ValueFromPipeline = false)]        
        [ValidateNotNullOrEmpty]
        public DateTime StartDate { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DateTimeFileterParameterSet, HelpMessage = "", ValueFromPipeline = false)]        
        [ValidateNotNullOrEmpty]
        public DateTime EndDate { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DateTimeFileterParameterSet, HelpMessage = "", ValueFromPipeline = true)]
        [Parameter(Mandatory = true, ParameterSetName = RecoveryPointIdParameterSet, HelpMessage = "", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesItemBase Item { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RecoveryPointIdParameterSet, HelpMessage = "", ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public string RecoveryPointId { get; set; }

        public override void ExecuteCmdlet()
        {
            //Validate start time < end time
            base.ExecuteCmdlet();

            Dictionary<System.Enum, object> parameter = new Dictionary<System.Enum, object>();
            parameter.Add(GetRecoveryPointParams.Item, Item);

            if(this.ParameterSetName == DateTimeFileterParameterSet)
            {
                //User want list of RPs between given time range
                if (StartDate >= EndDate)
                {
                    throw new Exception("End date should be greated than start date"); //tbd: Correct nsg and exception type
                }

                parameter.Add(GetRecoveryPointParams.StartDate, StartDate);
                parameter.Add(GetRecoveryPointParams.EndDate, EndDate);
                PsBackupProviderManager providerManager = new PsBackupProviderManager(parameter, HydraAdapter);
                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(Item.ContainerType);
                psBackupProvider.ListRecoveryPoints();
            }
            else if (this.ParameterSetName == RecoveryPointIdParameterSet)
            {
                //User want details of a particular recovery point
                parameter.Add(GetRecoveryPointParams.RecoveryPointId, RecoveryPointId);
                PsBackupProviderManager providerManager = new PsBackupProviderManager(parameter, HydraAdapter);
                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(Item.ContainerType);
                psBackupProvider.GetRecoveryPointDetail();
            }
            else
            {

            }
        }
    }
}
