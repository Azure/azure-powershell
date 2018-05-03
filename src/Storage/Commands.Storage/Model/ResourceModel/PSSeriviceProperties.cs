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

using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel
{
    // Wrapper of ServiceProperties
    public class PSSeriviceProperties
    {
        //
        // Summary:
        //     Initializes a new instance of the PSSeriviceProperties class.
        public PSSeriviceProperties(ServiceProperties properties)
        {
            if (properties != null)
            {
                this.Logging = properties.Logging;
                this.HourMetrics = properties.HourMetrics;
                this.MinuteMetrics = properties.MinuteMetrics;
                this.DefaultServiceVersion = properties.DefaultServiceVersion;
                this.Cors = PSCorsRule.ParseCorsRules(properties.Cors);
                this.DeleteRetentionPolicy = PSDeleteRetentionPolicy.ParsePSDeleteRetentionPolicy(properties.DeleteRetentionPolicy);
            }
        }

        //
        // Summary:
        //     Gets or sets the logging properties.
        public LoggingProperties Logging { get; set; }
        //
        // Summary:
        //     Gets or sets the hour metrics properties.
        public MetricsProperties HourMetrics { get; set; }
        //
        // Summary:
        //     Gets or sets the Cross Origin Resource Sharing (CORS) properties.
        public PSCorsRule[] Cors { get; set; }
        //
        // Summary:
        //     Gets or sets the minute metrics properties.
        public MetricsProperties MinuteMetrics { get; set; }
        //
        // Summary:
        //     Gets or sets the default service version.
        public string DefaultServiceVersion { get; set; }
        //
        // Summary:
        //     Gets or sets the delete retention policy.
        public PSDeleteRetentionPolicy DeleteRetentionPolicy { get; set; }
    }

    // Wrapper of DeleteRetentionPolicy
    public class PSDeleteRetentionPolicy
    {
        //
        // Summary:
        //     Parse DeleteRetentionPolicy object in SDK to wrapped  PSDeleteRetentionPolicy object
        public static PSDeleteRetentionPolicy ParsePSDeleteRetentionPolicy(DeleteRetentionPolicy deleteRetentionPolicy)
        {
            if (deleteRetentionPolicy == null)
            {
                return null;
            }
            PSDeleteRetentionPolicy policy = new PSDeleteRetentionPolicy();
            policy.Enabled = deleteRetentionPolicy.Enabled;
            policy.RetentionDays = deleteRetentionPolicy.RetentionDays;
            return policy;
        }

        //
        // Summary:
        //     Gets or sets the Enabled flag of the DeleteRetentionPolicy.
        public bool Enabled { get; set; }
        //
        // Summary:
        //     Gets or Sets the number of days on the DeleteRetentionPolicy.
        public int? RetentionDays { get; set; }
    }
}
