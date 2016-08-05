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

using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{

    public class PSLinuxSyslogCollectionDataSourceProperties : PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.LinuxSyslogCollection; } }

        /// <summary>
        /// Whether to collect syslog from Linux computers.
        /// </summary>
        [JsonProperty(PropertyName= "state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CollectionState State { get; set; }
    }

    /// <summary>
    /// The linux syslog collection state.
    /// </summary>
    public enum CollectionState
    {
        /// <summary>
        /// The enabled.
        /// </summary>
        Enabled,

        /// <summary>
        /// The disabled.
        /// </summary>
        Disabled,
    }

}
