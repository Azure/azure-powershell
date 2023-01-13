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

using System.Collections;
using Microsoft.Azure.Commands.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    public class UpdatePSWorkspaceParameters : OperationalInsightsParametersBase
    {
        public PSWorkspaceSku Sku { get; set; }

        public Hashtable Tags { get; set; }

        public int? RetentionInDays { get; set; }

        public string PublicNetworkAccessForIngestion { get; set; }

        public string PublicNetworkAccessForQuery { get; set; }

        public int? DailyQuotaGb { get; set; }

        public bool? ForceCmkForQuery { get; set; }

        public PSWorkspaceFeatures WsFeatures { get; set; }

        public string DefaultDataCollectionRuleResourceId { get; set; }
    }
}
