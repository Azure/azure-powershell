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

using Microsoft.Azure.Management.SiteRecovery.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Recovery Plans.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryRecoveryPlan", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRRecoveryPlan>))]
    public class GetAzureSiteRecoveryRecoveryPlan : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets name of the Recovery Plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets friendly name of the Recovery Plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets RP JSON FilePath.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Position = 1, Mandatory = false)]
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName, Position = 1, Mandatory = false)]
        public string Path { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
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
        /// Queries by Friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            RecoveryPlanListResponse recoveryPlanListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan();
            bool found = false;

            foreach (RecoveryPlan recoveryPlan in recoveryPlanListResponse.RecoveryPlans)
            {
                if (0 == string.Compare(this.FriendlyName, recoveryPlan.Properties.FriendlyName, StringComparison.OrdinalIgnoreCase))
                {
                    var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(recoveryPlan.Name).RecoveryPlan;
                    this.WriteRecoveryPlan(rp);
                    if (!string.IsNullOrEmpty(this.Path))
                    {
                        GetRecoveryPlanFile(rp);
                    }

                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.RecoveryPlanNotFound,
                    this.FriendlyName,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        /// Queries by Name.
        /// </summary>
        private void GetByName()
        {
            RecoveryPlanListResponse recoveryPlanListResponse =
                 RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan();
            bool found = false;

            foreach (RecoveryPlan recoveryPlan in recoveryPlanListResponse.RecoveryPlans)
            {
                if (0 == string.Compare(this.Name, recoveryPlan.Name, StringComparison.OrdinalIgnoreCase))
                {
                    var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(recoveryPlan.Name).RecoveryPlan;
                    this.WriteRecoveryPlan(rp);
                    if (!string.IsNullOrEmpty(this.Path))
                    {
                        GetRecoveryPlanFile(rp);
                    }

                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.RecoveryPlanNotFound,
                    this.Name,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        /// Queries all / by default.
        /// </summary>
        private void GetAll()
        {
            RecoveryPlanListResponse recoveryPlanListResponse =
                 RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan();

            this.WriteRecoveryPlans(recoveryPlanListResponse.RecoveryPlans);
        }

        private void GetRecoveryPlanFile(RecoveryPlan recoveryPlan)
        {
            recoveryPlan = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(recoveryPlan.Name).RecoveryPlan;

            if (string.IsNullOrEmpty(this.Path) || !Directory.Exists(System.IO.Path.GetDirectoryName(this.Path)))
            {
                throw new DirectoryNotFoundException(string.Format(Properties.Resources.DirectoryNotFound, System.IO.Path.GetDirectoryName(this.Path)));
            }

            string fullFileName = this.Path;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fullFileName, false))
            {
                string json = JsonConvert.SerializeObject(recoveryPlan, Formatting.Indented);
                file.WriteLine(json);
            }
        }

        /// <summary>
        /// Write Recovery Plans.
        /// </summary>
        /// <param name="recoveryPlanList">List of Recovery Plans</param>
        private void WriteRecoveryPlans(IList<RecoveryPlan> recoveryPlanList)
        {
            IList<ASRRecoveryPlan> asrRecoveryPlans = new List<ASRRecoveryPlan>();

            foreach (RecoveryPlan recoveryPlan in recoveryPlanList)
            {
                var replicationProtectedItemListResponse = RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItemInRP(recoveryPlan.Name);
                asrRecoveryPlans.Add(new ASRRecoveryPlan(recoveryPlan, replicationProtectedItemListResponse.ReplicationProtectedItems));
            }

            this.WriteObject(asrRecoveryPlans, true);
        }

        /// <summary>
        /// Write Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlan">Recovery Plan object</param>
        private void WriteRecoveryPlan(RecoveryPlan recoveryPlan)
        {
            var replicationProtectedItemListResponse = RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItemInRP(recoveryPlan.Name);
            this.WriteObject(new ASRRecoveryPlan(recoveryPlan, replicationProtectedItemListResponse.ReplicationProtectedItems));
        }
    }
}