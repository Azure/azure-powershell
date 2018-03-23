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
using System.IO;
using System.Management.Automation;
using Hyak.Common;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Gets a recovery plan or all the recovery plans in the Recovery Services vault
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        "AzureRmRecoveryServicesAsrRecoveryPlan",
        DefaultParameterSetName = ASRParameterSets.Default)]
    [Alias(
        "Get-ASRRP",
        "Get-ASRRecoveryPlan")]
    [OutputType(typeof(IEnumerable<ASRRecoveryPlan>))]
    public class GetAzureRmRecoveryServicesAsrRecoveryPlan : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the name of the recovery plan to get.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the friendly name of the recovery plan to get.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets the file path to which this cmdlet saves the recovery plan json definition.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByName,
            Position = 1,
            Mandatory = false)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByFriendlyName,
            Position = 1,
            Mandatory = false)]
        public string Path { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByFriendlyName:
                    this.GetByFriendlyName();
                    break;
                case ASRParameterSets.ByName:
                    this.GetByName();
                    break;
                case ASRParameterSets.Default:
                    this.GetAll();
                    break;
            }
        }

        /// <summary>
        ///     Queries all / by default.
        /// </summary>
        private void GetAll()
        {
            var recoveryPlanListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryRecoveryPlan();

            this.WriteRecoveryPlans(recoveryPlanListResponse);
        }

        /// <summary>
        ///     Queries by Friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            var recoveryPlanListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryRecoveryPlan();
            var found = false;

            foreach (var recoveryPlan in recoveryPlanListResponse)
            {
                if (0 ==
                    string.Compare(
                        this.FriendlyName,
                        recoveryPlan.Properties.FriendlyName,
                        StringComparison.OrdinalIgnoreCase))
                {
                    var rp = this.RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                        recoveryPlan.Name);
                    this.WriteRecoveryPlan(rp);
                    if (!string.IsNullOrEmpty(this.Path))
                    {
                        this.GetRecoveryPlanFile(rp);
                    }

                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.RecoveryPlanNotFound,
                        this.FriendlyName,
                        PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        ///     Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var recoveryPlanResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryRecoveryPlan(this.Name);

                if (recoveryPlanResponse != null)
                {
                    this.WriteRecoveryPlan(recoveryPlanResponse);

                    if (!string.IsNullOrEmpty(this.Path))
                    {
                        this.GetRecoveryPlanFile(recoveryPlanResponse);
                    }
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(
                        ex.Error.Code,
                        "NotFound",
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            Resources.RecoveryPlanNotFound,
                            this.Name,
                            PSRecoveryServicesClient.asrVaultCreds.ResourceName));
                }

                throw;
            }
        }

        private void GetRecoveryPlanFile(
            RecoveryPlan recoveryPlan)
        {
            recoveryPlan =
                this.RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(recoveryPlan.Name);

            if (string.IsNullOrEmpty(this.Path) ||
                !Directory.Exists(System.IO.Path.GetDirectoryName(this.Path)))
            {
                throw new DirectoryNotFoundException(
                    string.Format(
                        Resources.DirectoryNotFound,
                        System.IO.Path.GetDirectoryName(this.Path)));
            }

            var fullFileName = this.Path;
            using (var file = new StreamWriter(
                fullFileName,
                false))
            {
                var json = JsonConvert.SerializeObject(
                    recoveryPlan,
                    Formatting.Indented);
                file.WriteLine(json);
            }
        }

        /// <summary>
        ///     Write Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlan">Recovery Plan object</param>
        private void WriteRecoveryPlan(
            RecoveryPlan recoveryPlan)
        {
            var replicationProtectedItemListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryReplicationProtectedItemInRP(recoveryPlan.Name);
            this.WriteObject(
                new ASRRecoveryPlan(
                    recoveryPlan,
                    replicationProtectedItemListResponse));
        }

        /// <summary>
        ///     Write Recovery Plans.
        /// </summary>
        /// <param name="recoveryPlanList">List of Recovery Plans</param>
        private void WriteRecoveryPlans(
            IList<RecoveryPlan> recoveryPlanList)
        {
            IList<ASRRecoveryPlan> asrRecoveryPlans = new List<ASRRecoveryPlan>();

            foreach (var recoveryPlan in recoveryPlanList)
            {
                var replicationProtectedItemListResponse =
                    this.RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItemInRP(
                        recoveryPlan.Name);
                asrRecoveryPlans.Add(
                    new ASRRecoveryPlan(
                        recoveryPlan,
                        replicationProtectedItemListResponse));
            }

            this.WriteObject(
                asrRecoveryPlans,
                true);
        }
    }
}