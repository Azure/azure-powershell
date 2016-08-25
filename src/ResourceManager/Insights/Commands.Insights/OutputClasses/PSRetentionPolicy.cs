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

using Microsoft.Azure.Management.Insights.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the ServiceDiagnosticSettings
    /// </summary>
    public class PSRetentionPolicy
    {
        /// <summary>
        /// Gets or sets a value indicating whether the retention is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the retention in days.
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSRetentionPolicy class.
        /// </summary>
        public PSRetentionPolicy(RetentionPolicy retentionPolicy)
        {
            this.Enabled = retentionPolicy.Enabled;
            this.Days = retentionPolicy.Days;
        }
    }
}
