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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure Site Recovery Recovery Plan.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoveryRecoveryPlan", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRRecoveryPlan>))]
    public class GetAzureSiteRecoveryRecoveryPlan : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Recovery Plan ID.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ById, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets name of the Recovery Plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteWarningWithTimestamp(
                    string.Format(
                        Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name));

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByName:
                        this.GetByName();
                        break;
                    case ASRParameterSets.ById:
                        this.GetById();
                        break;
                    case ASRParameterSets.Default:
                        this.GetByDefault();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Queries by name.
        /// </summary>
        private void GetByName()
        {
            RecoveryPlanListResponse recoveryPlanListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan();

            bool found = false;
            foreach (RecoveryPlan recoveryPlan in recoveryPlanListResponse.RecoveryPlans)
            {
                if (0 == string.Compare(this.Name, recoveryPlan.Name, true))
                {
                    this.WriteRecoveryPlan(recoveryPlan);
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
        /// Queries by ID.
        /// </summary>
        private void GetById()
        {
            RecoveryPlanResponse recoveryPlanResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(this.Id);

            this.WriteRecoveryPlan(recoveryPlanResponse.RecoveryPlan);
        }

        /// <summary>
        /// Queries all / by default.
        /// </summary>
        private void GetByDefault()
        {
            RecoveryPlanListResponse recoveryPlanListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan();

            this.WriteRecoveryPlans(recoveryPlanListResponse.RecoveryPlans);
        }

        /// <summary>
        /// Writes Recovery Plans.
        /// </summary>
        /// <param name="recoveryPlans">List of Recovery Plans</param>
        private void WriteRecoveryPlans(IList<RecoveryPlan> recoveryPlans)
        {
            this.WriteObject(recoveryPlans.Select(rp => new ASRRecoveryPlan(rp)), true);
        }

        /// <summary>
        /// Writes Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlan">Recovery Plan</param>
        private void WriteRecoveryPlan(RecoveryPlan recoveryPlan)
        {
            this.WriteObject(new ASRRecoveryPlan(recoveryPlan));
        }
    }
}