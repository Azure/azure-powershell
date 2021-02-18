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

namespace Microsoft.Azure.Commands.Support.Models
{
    public class PSServiceLevelAgreement
    {
        /// <summary>
        /// Gets time in UTC (ISO 8601 format) when SLA started.
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets time in UTC (ISO 8601 format) when SLA expires.
        /// </summary>
        public DateTime? ExpirationTime { get; set; }

        /// <summary>
        /// Gets service Level Agreement in minutes
        /// </summary>
        public int? SlaMinutes { get; set; }
    }
}
