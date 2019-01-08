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

namespace Microsoft.Azure.Commands.Advisor.Cmdlets.Models
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Advisor.Models;

    /// <summary>
    /// PS object for Advisor SDK SuppressionContract
    /// </summary>
    public class PsAzureAdvisorSuppressionContract
    {
        /// <summary>
        /// Initializes a new instance of the SuppressionContract class.
        /// </summary>
        /// <param name="suppressionId">The GUID of the suppression</param>
        /// <param name="ttl">The duration for which the suppression is valid.</param>
        public PsAzureAdvisorSuppressionContract(string suppressionId = null, string ttl = null)
        {
            this.SuppressionId = suppressionId;
            this.Ttl = ttl;
        }

        /// <summary>
        /// Gets or sets the GUID of the suppression.
        /// </summary>
        public string SuppressionId { get; set; }

        /// <summary>
        /// Gets or sets the duration for which the suppression is valid.
        /// </summary>
        public string Ttl { get; set; }

        /// <summary>
        /// Gets or sets the resource ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Parse the SuppressionContract into PsObject list
        /// </summary>
        /// <param name="suppressionContract">SuppressionContract to be converted</param>
        /// <returns>PsAzureAdvisorSuppressionContract generated</returns>
        internal static PsAzureAdvisorSuppressionContract FromSuppressionContract(SuppressionContract suppressionContract)
        {
            if (suppressionContract == null)
            {
                return null;
            }

            PsAzureAdvisorSuppressionContract psAzureAdvisorSuppressionContract = new PsAzureAdvisorSuppressionContract()
            {
                Id = suppressionContract.Id,
                Name = suppressionContract.Name,
                SuppressionId = suppressionContract.SuppressionId,
                Ttl = suppressionContract.Ttl,
                Type = suppressionContract.Type,
            };

            return psAzureAdvisorSuppressionContract;
        }

        /// <summary>
        /// Parse the list of SuppressionContract into PsObject list
        /// </summary>
        /// <param name="suppressionContract">List of SuppressionContract to be converted</param>
        /// <returns>List of PsAzureAdvisorSuppressionContract generated</returns>
        internal static List<PsAzureAdvisorSuppressionContract> FromSuppressionContractList(IEnumerable<SuppressionContract> suppressionContract)
        {
            List<PsAzureAdvisorSuppressionContract> psAzureAdvisorSuppressionContractList = new List<PsAzureAdvisorSuppressionContract>();

            foreach (SuppressionContract contract in suppressionContract)
            {
                psAzureAdvisorSuppressionContractList.Add(PsAzureAdvisorSuppressionContract.FromSuppressionContract(contract));
            }

            return psAzureAdvisorSuppressionContractList;
        }
    }
}
