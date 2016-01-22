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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;
using Newtonsoft.Json;
using System.IO;

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
        public override void ExecuteCmdlet()
        {
            try
            {
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
            catch (Exception exception)
            {
                this.HandleException(exception);
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
                if (0 == string.Compare(this.FriendlyName, recoveryPlan.Properties.FriendlyName, true))
                {
                    if (!string.IsNullOrEmpty(this.Path))
                    {
                        GetRecoveryPlanFile(recoveryPlan);
                    }

                    this.WriteRecoveryPlan(recoveryPlan);
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
            this.WriteRecoveryPlan(RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(this.Name).RecoveryPlan);
            if (!string.IsNullOrEmpty(this.Path))
            {
                GetRecoveryPlanFile(RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(this.Name).RecoveryPlan);
            }

            //RecoveryPlanListResponse recoveryPlanListResponse =
            //     RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan();
            //bool found = false;

            //foreach (RecoveryPlan recoveryPlan in recoveryPlanListResponse.RecoveryPlans)
            //{
            //    if (0 == string.Compare(this.Name, recoveryPlan.Name, true))
            //    {
            //        if (!string.IsNullOrEmpty(this.Path))
            //        {
            //            GetRecoveryPlanFile(recoveryPlan);
            //        }

            //        this.WriteRecoveryPlan(recoveryPlan);
            //        found = true;
            //    }
            //}

            //if (!found)
            //{
            //    throw new InvalidOperationException(
            //        string.Format(
            //        Properties.Resources.RecoveryPlanNotFound,
            //        this.Name,
            //        PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            //}
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

            string filePath = string.IsNullOrEmpty(this.Path) ? Utilities.GetDefaultPath() : this.Path;
            if(!Directory.Exists(filePath))
            {
                throw new DirectoryNotFoundException(string.Format(Properties.Resources.DirectoryNotFound, filePath));
            }

            string fileName = string.Format("{0}_{1}.json", recoveryPlan.Name, DateTime.UtcNow.ToString("yyyy-MM-ddTHH-mm-ss"));
            string fullFileName = System.IO.Path.Combine(filePath, fileName);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fullFileName, false))
            {
                string json = JsonConvert.SerializeObject(recoveryPlan);
                file.WriteLine(json);
                //this.WriteObject(string.Format(Properties.Resources.RPJSONPath, recoveryPlan.Name, fullFileName));
            }
        }

        /// <summary>
        /// Write Recovery Plans.
        /// </summary>
        /// <param name="recoveryPlanList">List of Recovery Plans</param>
        private void WriteRecoveryPlans(IList<RecoveryPlan> recoveryPlanList)
        {
            this.WriteObject(recoveryPlanList.Select(rp => new ASRRecoveryPlan(rp)), true);
        }

        /// <summary>
        /// Write Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlan">Recovery Plan object</param>
        private void WriteRecoveryPlan(RecoveryPlan recoveryPlan)
        {
            this.WriteObject(new ASRRecoveryPlan(recoveryPlan));
        }
    }
}