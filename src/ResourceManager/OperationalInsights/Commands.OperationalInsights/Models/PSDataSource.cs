﻿using System;
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
        public const string IISLog = "IISLog";
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
                throw new ArgumentNullException("storageInsight");
            }

            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.Name = dataSource.Name;
            this.ResourceId = dataSource.Id;
            this.Kind = dataSource.Kind;
            switch(this.Kind){
                case PSDataSourceKinds.AzureAuditLog:
                    this.Properties = JsonConvert.DeserializeObject<PSAzureAuditLogDataSourceProperties>(dataSource.Properties);
                    break;
                case PSDataSourceKinds.WindowsEvent:
                    this.Properties = JsonConvert.DeserializeObject<PSWindowsEventDataSourceProperties>(dataSource.Properties);
                    break;
                case PSDataSourceKinds.WindowsPerformanceCounter:
                    this.Properties = JsonConvert.DeserializeObject<PSWindowsPerformanceCounterDataSourceProperties>(dataSource.Properties);
                    break;
                case PSDataSourceKinds.LinuxSyslog:
                    this.Properties = JsonConvert.DeserializeObject<PSLinuxSyslogDataSourceProperties>(dataSource.Properties);
                    break;
                case PSDataSourceKinds.LinuxSyslogCollection:
                    this.Properties = JsonConvert.DeserializeObject<PSLinuxSyslogCollectionDataSourceProperties>(dataSource.Properties);
                    break;
                case PSDataSourceKinds.LinuxPerformanceObject:
                    this.Properties = JsonConvert.DeserializeObject<PSLinuxPerformanceObjectDataSourceProperties>(dataSource.Properties);
                    break;
                case PSDataSourceKinds.LinuxPerformanceCollection:
                    this.Properties = JsonConvert.DeserializeObject<PSLinuxPerformanceCollectionDataSourceProperties>(dataSource.Properties);
                    break;
                case PSDataSourceKinds.CustomLog:
                    this.Properties = JsonConvert.DeserializeObject<PSCustomLogDataSourceProperties>(dataSource.Properties);
                    break;
            }

        }
    }
}
