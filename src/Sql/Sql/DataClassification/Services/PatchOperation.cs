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

using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Services
{
    [JsonTransformation]
    public class PatchOperation
    {
        [JsonProperty(PropertyName = "properties.op")]
        public PatchOperationKind OperationKind { get; set; }

        [JsonProperty(PropertyName = "properties.schema")]
        public string Schema { get; set; }

        [JsonProperty(PropertyName = "properties.table")]
        public string Table { get; set; }

        [JsonProperty(PropertyName = "properties.column")]
        public string Column { get; set; }

        [JsonProperty(PropertyName = "properties.sensitivityLabel")]
        public SensitivityLabel SensitivityLabel { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PatchOperationKind
    {
        [EnumMember(Value = "set")]
        Set,

        [EnumMember(Value = "remove")]
        Remove,

        [EnumMember(Value = "enable")]
        Enable,

        [EnumMember(Value = "disable")]
        Disable
    }
}
