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

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class PSTroubleshootResult : PSTopLevelResource
    {
        public string Code { get; set; }

        public DateTime? EndTime { get; set; }

        public List<PSTroubleshootDetails> Results { get; set; }

        public DateTime? StartTime { get; set; }

        [JsonIgnore]
        public string ResultsText
        {
            get { return JsonConvert.SerializeObject(Results, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeResults()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
