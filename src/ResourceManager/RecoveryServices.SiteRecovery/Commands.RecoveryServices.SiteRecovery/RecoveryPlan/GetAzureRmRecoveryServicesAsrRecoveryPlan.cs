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
    ///     Retrieves Azure Site Recovery Recovery Plans.
    /// </summary>
    [Cmdlet(VerbsCommon.Get,
        "AzureRmRecoveryServicesAsrRecoveryPlan",
        DefaultParameterSetName = ASRParameterSets.Default)]
    [Alias("Get-ASRRP",
        "Get-ASRRecoveryPlan")]
    [OutputType(typeof(IEnumerable<ASRRecoveryPlan>))]
    public class GetAzureRmRecoveryServicesAsrRecoveryPlan : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets name of the Recovery Plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets friendly name of the Recovery Plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets RP JSON FilePath.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName,
            Position = 1,
            Mandatory = false)]
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName,
            Position = 1,
            Mandatory = false)]
        public string Path { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            switch (ParameterSetName)
            {
                case ASRParameterSets.ByFriendlyName:
                    GetByFriendlyName();
                    break;
                case ASRParameterSets.ByName:
                    GetByName();
                    break;
                case ASRParameterSets.Default:
                    GetAll();
                    break;
            }
        }

        /// <summary>
        ///     Queries by Friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            var recoveryPlanListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan();
            var found = false;

            foreach (var recoveryPlan in recoveryPlanListResponse)
            {
                if (0 ==
                    string.Compare(FriendlyName,
                        recoveryPlan.Properties.FriendlyName,
                        StringComparison.OrdinalIgnoreCase))
                {
                    var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(recoveryPlan
                        .Name);
                    WriteRecoveryPlan(rp);
                    if (!string.IsNullOrEmpty(Path))
                    {
                        GetRecoveryPlanFile(rp);
                    }

                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(string.Format(Resources.RecoveryPlanNotFound,
                    FriendlyName,
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
                var recoveryPlanResponse =
                    RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(Name);

                if (recoveryPlanResponse != null)
                {
                    WriteRecoveryPlan(recoveryPlanResponse);

                    if (!string.IsNullOrEmpty(Path))
                    {
                        GetRecoveryPlanFile(recoveryPlanResponse);
                    }
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code,
                        "NotFound",
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    throw new InvalidOperationException(string.Format(
                        Resources.RecoveryPlanNotFound,
                        Name,
                        PSRecoveryServicesClient.asrVaultCreds.ResourceName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Queries all / by default.
        /// </summary>
        private void GetAll()
        {
            var recoveryPlanListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan();

            WriteRecoveryPlans(recoveryPlanListResponse);
        }

        private void GetRecoveryPlanFile(RecoveryPlan recoveryPlan)
        {
            recoveryPlan =
                RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(recoveryPlan.Name);

            if (string.IsNullOrEmpty(Path) ||
                !Directory.Exists(System.IO.Path.GetDirectoryName(Path)))
            {
                throw new DirectoryNotFoundException(string.Format(Resources.DirectoryNotFound,
                    System.IO.Path.GetDirectoryName(Path)));
            }

            var fullFileName = Path;
            using (var file = new StreamWriter(fullFileName,
                false))
            {
                var json = JsonConvert.SerializeObject(recoveryPlan,
                    Formatting.Indented);
                file.WriteLine(json);
            }
        }

        /// <summary>
        ///     Write Recovery Plans.
        /// </summary>
        /// <param name="recoveryPlanList">List of Recovery Plans</param>
        private void WriteRecoveryPlans(IList<RecoveryPlan> recoveryPlanList)
        {
            IList<ASRRecoveryPlan> asrRecoveryPlans = new List<ASRRecoveryPlan>();

            foreach (var recoveryPlan in recoveryPlanList)
            {
                var replicationProtectedItemListResponse =
                    RecoveryServicesClient
                        .GetAzureSiteRecoveryReplicationProtectedItemInRP(recoveryPlan.Name);
                asrRecoveryPlans.Add(new ASRRecoveryPlan(recoveryPlan,
                    replicationProtectedItemListResponse));
            }

            WriteObject(asrRecoveryPlans,
                true);
        }

        /// <summary>
        ///     Write Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlan">Recovery Plan object</param>
        private void WriteRecoveryPlan(RecoveryPlan recoveryPlan)
        {
            var replicationProtectedItemListResponse = RecoveryServicesClient
                .GetAzureSiteRecoveryReplicationProtectedItemInRP(recoveryPlan.Name);
            WriteObject(new ASRRecoveryPlan(recoveryPlan,
                replicationProtectedItemListResponse));
        }
    }
}