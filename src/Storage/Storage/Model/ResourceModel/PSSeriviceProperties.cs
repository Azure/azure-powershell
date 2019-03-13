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
using XTable = Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

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
                this.StaticWebsite = PSStaticWebsiteProperties.ParsePSStaticWebsiteProperties(properties.StaticWebsite);
            }
        }  
        
        //
        // Summary:
        //     Initializes a new instance of the PSSeriviceProperties class from old XSCL service properties.
        public PSSeriviceProperties(XTable.ServiceProperties properties)
        {
            if (properties != null)
            {
                this.Logging = new LoggingProperties()
                {
                    Version = properties.Logging.Version,
                    RetentionDays = properties.Logging.RetentionDays,
                    LoggingOperations = (LoggingOperations)Enum.Parse(typeof(LoggingOperations), properties.Logging.LoggingOperations.ToString(), true),
                };
                this.HourMetrics = new MetricsProperties()
                {
                    Version = properties.HourMetrics.Version,
                    RetentionDays = properties.HourMetrics.RetentionDays,
                    MetricsLevel = (MetricsLevel)Enum.Parse(typeof(MetricsLevel), properties.HourMetrics.MetricsLevel.ToString(), true),
                };
                this.MinuteMetrics = new MetricsProperties()
                {
                    Version = properties.MinuteMetrics.Version,
                    RetentionDays = properties.MinuteMetrics.RetentionDays,
                    MetricsLevel = (MetricsLevel)Enum.Parse(typeof(MetricsLevel), properties.MinuteMetrics.MetricsLevel.ToString(), true),
                };
                this.DefaultServiceVersion = properties.DefaultServiceVersion;
                this.Cors = PSCorsRule.ParseCorsRules(properties.Cors);
            }
        }

        //
        // Summary:
        //     Gets or sets the logging properties.
        [Ps1Xml(Label = "Logging.Version", Target = ViewControl.List, ScriptBlock = "$_.Logging.Version", Position = 0)]
        [Ps1Xml(Label = "Logging.LoggingOperations", Target = ViewControl.List, ScriptBlock = "$_.Logging.LoggingOperations", Position = 1)]
        [Ps1Xml(Label = "Logging.RetentionDays", Target = ViewControl.List, ScriptBlock = "$_.Logging.RetentionDays", Position = 2)]
        public LoggingProperties Logging { get; set; }
        //
        // Summary:
        //     Gets or sets the hour metrics properties.
        [Ps1Xml(Label = "HourMetrics.Version", Target = ViewControl.List, ScriptBlock = "$_.HourMetrics.Version", Position = 3)]
        [Ps1Xml(Label = "HourMetrics.MetricsLevel", Target = ViewControl.List, ScriptBlock = "$_.HourMetrics.MetricsLevel", Position = 4)]
        [Ps1Xml(Label = "HourMetrics.RetentionDays", Target = ViewControl.List, ScriptBlock = "$_.HourMetrics.RetentionDays", Position = 5)]
        public MetricsProperties HourMetrics { get; set; }
        //
        // Summary:
        //     Gets or sets the Cross Origin Resource Sharing (CORS) properties.
        [Ps1Xml(Label = "Cors", Target = ViewControl.List, ScriptBlock = "$_.Cors", Position = 14)]
        public PSCorsRule[] Cors { get; set; }
        //
        // Summary:
        //     Gets or sets the minute metrics properties.
        [Ps1Xml(Label = "MinuteMetrics.Version", Target = ViewControl.List, ScriptBlock = "$_.MinuteMetrics.Version", Position = 6)]
        [Ps1Xml(Label = "MinuteMetrics.MetricsLevel", Target = ViewControl.List, ScriptBlock = "$_.MinuteMetrics.MetricsLevel", Position = 7)]
        [Ps1Xml(Label = "MinuteMetrics.RetentionDays", Target = ViewControl.List, ScriptBlock = "$_.MinuteMetrics.RetentionDays", Position = 8)]
        public MetricsProperties MinuteMetrics { get; set; }
        //
        // Summary:
        //     Gets or sets the default service version.
        [Ps1Xml(Label = "DefaultServiceVersion", Target = ViewControl.List, Position = 15)]
        public string DefaultServiceVersion { get; set; }
        //
        // Summary:
        //     Gets or sets the delete retention policy.
        [Ps1Xml(Label = "DeleteRetentionPolicy.Enabled", Target = ViewControl.List, ScriptBlock = "$_.DeleteRetentionPolicy.Enabled", Position = 9)]
        [Ps1Xml(Label = "DeleteRetentionPolicy.RetentionDays", Target = ViewControl.List, ScriptBlock = "$_.DeleteRetentionPolicy.RetentionDays", Position = 10)]
        public PSDeleteRetentionPolicy DeleteRetentionPolicy { get; set; }
        //
        // Summary:
        //     Gets or sets the service properties pertaining to StaticWebsites
        [Ps1Xml(Label = "StaticWebsite.Enabled", Target = ViewControl.List, ScriptBlock = "$_.StaticWebsite.Enabled", Position = 11)]
        [Ps1Xml(Label = "StaticWebsite.IndexDocument", Target = ViewControl.List, ScriptBlock = "$_.StaticWebsite.IndexDocument", Position = 12)]
        [Ps1Xml(Label = "StaticWebsite.ErrorDocument404Path", Target = ViewControl.List, ScriptBlock = "$_.StaticWebsite.ErrorDocument404Path", Position = 13)]
        public PSStaticWebsiteProperties StaticWebsite { get; set; }
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

    // Wrapper of StaticWebsiteProperties
    public class PSStaticWebsiteProperties
    {
        //
        // Summary:
        //     Parse DeleteRetentionPolicy object in SDK to wrapped  PSDeleteRetentionPolicy object
        public static PSStaticWebsiteProperties ParsePSStaticWebsiteProperties(StaticWebsiteProperties staticWebsiteProperties)
        {
            if (staticWebsiteProperties == null)
            {
                return null;
            }
            PSStaticWebsiteProperties psProperties = new PSStaticWebsiteProperties();
            psProperties.Enabled = staticWebsiteProperties.Enabled;
            psProperties.IndexDocument = staticWebsiteProperties.IndexDocument;
            psProperties.ErrorDocument404Path = staticWebsiteProperties.ErrorDocument404Path;
            return psProperties;
        }

        //
        // Summary:
        //     True if static websites should be enabled on the blob service for the corresponding
        //     Storage Account.
        public bool Enabled { get; set; }
        //
        // Summary:
        //     Gets or sets a string representing the name of the index document in each directory.
        public string IndexDocument { get; set; }
        //
        // Summary:
        //     Gets or sets a string representing the path to the error document that should
        //     be shown when a 404 is issued (meaning, when a browser requests a page that does
        //     not exist.)
        public string ErrorDocument404Path { get; set; }
    }
}
