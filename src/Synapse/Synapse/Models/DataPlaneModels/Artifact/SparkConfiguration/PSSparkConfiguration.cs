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

using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSparkConfiguration
    {
        public PSSparkConfiguration(SparkConfiguration sparkConfig)           
        {
            this.Description = sparkConfig?.Description;
            this.Configs = sparkConfig?.Configs;
            this.Annotations = sparkConfig?.Annotations;
            this.Notes = sparkConfig?.Notes;
            this.CreatedBy = sparkConfig?.CreatedBy;
            this.Created = sparkConfig?.Created;
            this.ConfigMergeRule = sparkConfig?.ConfigMergeRule;
        }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "configs")]
        public IDictionary<string, string> Configs { get; }

        [JsonProperty(PropertyName = "annotations")]
        public IList<string> Annotations { get; }

        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTimeOffset? Created { get; set; }

        [JsonProperty(PropertyName = "configMergeRule")]
        public IDictionary<string, string> ConfigMergeRule { get; }
    }
}
