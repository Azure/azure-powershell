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

using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    public class AzureHDInsightQuotaCapability
    {
        public AzureHDInsightQuotaCapability(QuotaCapability quotaCapability)
        {
            this.CoresUsed = quotaCapability?.CoresUsed;
            this.MaxCoresAllowed = quotaCapability?.MaxCoresAllowed;
            RegionalQuotas = new List<AzureHDInsightRegionalQuotaCapability>();

            int? count = quotaCapability?.RegionalQuotas?.Count;
            for (int i = 0; i < count; i++)
            {
                RegionalQuotas.Add(new AzureHDInsightRegionalQuotaCapability(quotaCapability.RegionalQuotas[i]));
            }
        }

        /// <summary>
        /// the cores that have been used.
        /// </summary>
        public long? CoresUsed { get; set; }

        /// <summary>
        /// The max value of cores that are allowed.
        /// </summary>
        public long? MaxCoresAllowed { get; set; }

        /// <summary>
        /// The list of regional quotas.
        /// </summary>
        public IList<AzureHDInsightRegionalQuotaCapability> RegionalQuotas { get; set; }
    }
}
