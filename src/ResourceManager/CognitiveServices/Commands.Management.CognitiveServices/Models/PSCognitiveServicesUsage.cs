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

using Microsoft.Azure.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices.Models
{
    public class PSCognitiveServicesUsage
    {
        public PSCognitiveServicesUsage(Usage usage)
        {
            this.CurrentValue = usage.CurrentValue;
            this.Limit = usage.Limit;
            this.Name = usage.Name.Value;
            this.Status = usage.Status;
            this.Unit = usage.Unit;
            this.QuotaPeriod = usage.QuotaPeriod;
            this.NextResetTime = usage.NextResetTime;
        }

        public double? CurrentValue { get; }
        public string Name { get; }
        public double? Limit { get; }
        public string Status { get; }
        public string Unit { get; }
        public string QuotaPeriod { get; }
        public string NextResetTime { get; }
    }
}
