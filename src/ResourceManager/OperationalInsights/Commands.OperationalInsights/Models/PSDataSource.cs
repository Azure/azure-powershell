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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public abstract class PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public abstract string Kind { get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class PSDataSourceKinds {
        public const string AzureAuditLog = "AzureAuditLog";
        public const string AzureActivityLog = "AzureActivityLog";
        public const string IISLogs = "IISLogs";
        public const string WindowsEvent = "WindowsEvent";
        public const string WindowsPerformanceCounter = "WindowsPerformanceCounter";
        public const string LinuxSyslogCollection = "LinuxSyslogCollection";
        public const string LinuxSyslog = "LinuxSyslog";
        public const string CustomLog = "CustomLog";
        public const string CustomLogCollection = "CustomLogCollection";
        public const string LinuxPerformanceCollection = "LinuxPerformanceCollection";
        public const string LinuxPerformanceObject = "LinuxPerformanceObject";
    }

    public class PSDataSource
    {
        public string Name { get; set; }

        public string ResourceId { get; set; }

        public string ResourceGroupName { get; set; }

        public string WorkspaceName { get; set; }

        public string Kind { get; set; }

        public PSDataSourcePropertiesBase Properties { get; set; }

        public PSDataSource()
        {
        }

        public PSDataSource(DataSource dataSource, string resourceGroupName, string workspaceName)
        {
            if (dataSource == null)
            {
                throw new ArgumentNullException("dataSource");
            }

            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.Name = dataSource.Name;
            this.ResourceId = dataSource.Id;
            this.Kind = dataSource.Kind;
            switch(this.Kind){
                case PSDataSourceKinds.AzureActivityLog:
                    this.Properties = ((JToken)dataSource.Properties).ToObject<PSAzureActivityLogDataSourceProperties>();
                    break;
                case PSDataSourceKinds.WindowsEvent:
                    this.Properties = ((JToken)dataSource.Properties).ToObject<PSWindowsEventDataSourceProperties>();
                    break;
                case PSDataSourceKinds.WindowsPerformanceCounter:
                    this.Properties = ((JToken)dataSource.Properties).ToObject<PSWindowsPerformanceCounterDataSourceProperties>();
                    break;
                case PSDataSourceKinds.LinuxSyslog:
                    this.Properties = ((JToken)dataSource.Properties).ToObject<PSLinuxSyslogDataSourceProperties>();
                    break;
                case PSDataSourceKinds.LinuxSyslogCollection:
                    this.Properties = ((JToken)dataSource.Properties).ToObject<PSLinuxSyslogCollectionDataSourceProperties>();
                    break;
                case PSDataSourceKinds.LinuxPerformanceObject:
                    this.Properties = ((JToken)dataSource.Properties).ToObject<PSLinuxPerformanceObjectDataSourceProperties>();
                    break;
                case PSDataSourceKinds.LinuxPerformanceCollection:
                    this.Properties = ((JToken)dataSource.Properties).ToObject<PSLinuxPerformanceCollectionDataSourceProperties>();
                    break;
                case PSDataSourceKinds.CustomLog:
                    this.Properties = ((JToken)dataSource.Properties).ToObject<PSCustomLogDataSourceProperties>();
                    break;
                case PSDataSourceKinds.CustomLogCollection:
                    this.Properties = ((JToken)dataSource.Properties).ToObject<PSCustomLogCollectionDataSourceProperties>();
                    break;
                case PSDataSourceKinds.IISLogs:
                    this.Properties = ((JToken)dataSource.Properties).ToObject<PSIISLogsDataSourceProperties>();
                    break;
            }

        }
    }
}
