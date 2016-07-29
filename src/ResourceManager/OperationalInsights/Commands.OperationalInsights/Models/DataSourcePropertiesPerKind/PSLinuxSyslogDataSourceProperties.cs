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

    public class PSLinuxSyslogDataSourceProperties : PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.LinuxSyslog; } }

        [JsonProperty(PropertyName= "syslogName")]
        public string SyslogName { get; set; }

        [JsonProperty(PropertyName = "syslogSeverities")]
        public List<SyslogSeverityIdentifier> SyslogSeverities { get; set; }
    }

    /// <summary>
    /// Subscribe to a Syslog Severity
    /// </summary>
    public class SyslogSeverityIdentifier
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Severity type.
        /// </summary>
        [JsonProperty(PropertyName = "severity")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SyslogSeverities Severity { get; set; }

        #endregion
    }

    /// <summary>
    /// The linux syslog Severities.
    /// </summary>
    public enum SyslogSeverities
    {
        emerg,
        alert,
        crit,
        err,
        warning,
        notice,
        info,
        debug
    }

}
