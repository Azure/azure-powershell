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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the ServiceDiagnosticSettings
    /// </summary>
    public class PSLogProfile
    {
        /// <summary>
        /// Gets or sets the id of the log profile.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the log profile.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the storage account.
        /// </summary>
        public string StorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the service bus rule
        /// </summary>
        public string ServiceBusRuleId { get; set; }

        /// <summary>
        /// Gets or sets the locations
        /// </summary>
        public IList<string> Locations { get; set; }

        /// <summary>
        /// Gets or sets the categories
        /// </summary>
        public IList<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the retention policy for this log
        /// </summary>
        public RetentionPolicy RetentionPolicy { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSLogProfile"/> class.
        /// </summary>
        public PSLogProfile(string id, string name, LogProfile logProfile)
        {
            this.Id = id;

            this.Name = name;

            this.Categories = logProfile.Categories.Select(x => x).ToList();
            this.Locations = logProfile.Locations.Select(x => x).ToList();
            this.RetentionPolicy = new RetentionPolicy()
            {
                Days = logProfile.RetentionPolicy.Days,
                Enabled = logProfile.RetentionPolicy.Enabled
            };
            this.ServiceBusRuleId = logProfile.ServiceBusRuleId;
            this.StorageAccountId = logProfile.StorageAccountId;
        }
    }
}
