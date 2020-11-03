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

using System.Collections.Generic;
using System.Linq;

using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    #region DCR - Data Collection Rule Resource

    /// <summary>
    /// Wraps around an Data Collection Rule.
    /// </summary>
    public class PSDataCollectionRuleResource : Resource
    {
        #region Properties
        /// <summary>
        /// Gets or sets description of the data collection rule.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the specification of data sources.
        /// This property is optional and can be omitted if the rule is meant
        /// to be used via direct calls to the provisioned endpoint.
        /// </summary>
        public PSDataCollectionRuleDataSources DataSources { get; set; }

        /// <summary>
        /// Gets or sets the specification of destinations.
        /// </summary>
        public PSDataCollectionRuleDestinations Destinations { get; set; }

        /// <summary>
        /// Gets or sets the specification of data flows.
        /// </summary>
        public IList<PSDataFlow> DataFlows { get; set; }

        /// <summary>
        /// Gets the resource provisioning state. Possible values include:
        /// 'Creating', 'Updating', 'Deleting', 'Succeeded', 'Failed'
        /// </summary>
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets resource entity tag (ETag).
        /// </summary>
        public string Etag { get; private set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the PSDataCollectionRuleResource class.
        /// </summary>
        public PSDataCollectionRuleResource()
        { }

        /// <summary>
        /// Initializes a new instance of the PSDataCollectionRuleResource class.
        /// </summary>
        /// <param name="dataCollectionRuleResource">The DataCollectionRuleResource to wrap.</param>
        public PSDataCollectionRuleResource(DataCollectionRuleResource dataCollectionRuleResource)
            : base(
                location: dataCollectionRuleResource.Location,
                id: dataCollectionRuleResource.Id,
                name: dataCollectionRuleResource.Name,
                type: dataCollectionRuleResource.Type,
                tags: dataCollectionRuleResource.Tags)
        {
            Description = dataCollectionRuleResource.Description;
            DataSources = dataCollectionRuleResource.DataSources == null ? new PSDataCollectionRuleDataSources() :
                                                                           new PSDataCollectionRuleDataSources(dataCollectionRuleResource.DataSources);
            Destinations = dataCollectionRuleResource.Destinations == null ? new PSDataCollectionRuleDestinations() :
                                                                             new PSDataCollectionRuleDestinations(dataCollectionRuleResource.Destinations);
            DataFlows = dataCollectionRuleResource.DataFlows?.Select(x => new PSDataFlow(x)).ToList();
            ProvisioningState = dataCollectionRuleResource.ProvisioningState;
            Etag = dataCollectionRuleResource.Etag;
        }

        internal DataCollectionRuleResource ConvertToApiObject() 
        {
            var dcrDefinitionObject = new DataCollectionRuleResource
            {
                DataSources = new DataCollectionRuleDataSources(),
                Destinations = new DataCollectionRuleDestinations(),
                DataFlows = new List<DataFlow>()
            };

            if (this.DataSources.PerformanceCounters != null && this.DataSources.PerformanceCounters.Count > 0)
            {
                dcrDefinitionObject.DataSources.PerformanceCounters = this.DataSources.PerformanceCounters.Select(x => new PerfCounterDataSource(
                    x.Streams, x.ScheduledTransferPeriod, x.SamplingFrequencyInSeconds, x.CounterSpecifiers, x.Name)).ToList();
            }

            if (this.DataSources.WindowsEventLogs != null && this.DataSources.WindowsEventLogs.Count > 0)
            {
                dcrDefinitionObject.DataSources.WindowsEventLogs = this.DataSources.WindowsEventLogs.Select(x => new WindowsEventLogDataSource(
                    x.Streams, x.ScheduledTransferPeriod, x.XPathQueries, x.Name)).ToList();
            }

            if (this.DataSources.Syslog != null && this.DataSources.Syslog.Count > 0)
            {
                dcrDefinitionObject.DataSources.Syslog = this.DataSources.Syslog.Select(x => new SyslogDataSource(
                    x.Streams, x.FacilityNames, x.Name, x.LogLevels)).ToList();
            }

            if (this.DataSources.Extensions != null && this.DataSources.Extensions.Count > 0)
            {
                dcrDefinitionObject.DataSources.Extensions = this.DataSources.Extensions.Select(x => new ExtensionDataSource(
                    x.Streams, x.ExtensionName, x.Name, x.ExtensionSettings)).ToList();
            }

            if (this.Destinations.LogAnalytics != null && this.Destinations.LogAnalytics.Count > 0)
            {
                dcrDefinitionObject.Destinations.LogAnalytics = this.Destinations.LogAnalytics.Select(x => new LogAnalyticsDestination(
                    x.WorkspaceResourceId, x.Name)).ToList();
            }

            if (this.Destinations.AzureMonitorMetrics != null)
            {
                dcrDefinitionObject.Destinations.AzureMonitorMetrics = new DestinationsSpecAzureMonitorMetrics(this.Destinations.AzureMonitorMetrics.Name);
            }

            if (this.DataFlows != null && this.DataFlows.Count > 0)
            {
                dcrDefinitionObject.DataFlows = this.DataFlows.Select(x => new DataFlow(
                    x.Streams, x.Destinations)).ToList();
            }

            dcrDefinitionObject.Location = this.Location;
            dcrDefinitionObject.Description = this.Description;
            dcrDefinitionObject.Tags = this.Tags;

            return dcrDefinitionObject;
        }
    }

    #endregion

    #region DCR's Data Flow
    /// <summary>
    /// Wraps the DataFlow class.
    /// </summary>
    public class PSDataFlow
    {
        /// <summary>
        /// Gets or sets list of streams for this data flow.
        /// </summary>
        public IList<string> Streams { get; set; }

        /// <summary>
        /// Gets or sets list of destinations for this data flow.
        /// </summary>
        public IList<string> Destinations { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSDataFlow class.
        /// </summary>
        public PSDataFlow()
        { }

        /// <summary>
        /// Initializes a new instance of the PSDataFlow class.
        /// </summary>
        /// <param name="dataFlow">The DataFlow to wrap.</param>
        public PSDataFlow(DataFlow dataFlow)
        {
            Streams = dataFlow.Streams?.Select(x => x).ToList();
            Destinations = dataFlow.Destinations?.Select(x => x).ToList();
        }
    }
    #endregion

    #region DCR's Destinations
    /// <summary>
    /// Wraps the DataCollectionRuleDestinations class.
    /// </summary>
    public class PSDataCollectionRuleDestinations : PSDestinationsSpec
    {
        /// <summary>
        /// Initializes a new instance of the PSDataCollectionRuleDestinations class.
        /// </summary>
        public PSDataCollectionRuleDestinations() : base()
        { }

        /// <summary>
        /// Initializes a new instance of the PSDataCollectionRuleDestinations class.
        /// </summary>
        /// <param name="dataCollectionRuleDestinations">The DataCollectionRuleDestinations to wrap.</param>
        public PSDataCollectionRuleDestinations(DataCollectionRuleDestinations dataCollectionRuleDestinations)
            : base(dataCollectionRuleDestinations)
        { }
    }

    /// <summary>
    /// Wraps the DestinationsSpec class.
    /// </summary>
    public class PSDestinationsSpec
    {
        /// <summary>
        /// Gets or sets list of Log Analytics destinations.
        /// </summary>
        public IList<PSLogAnalyticsDestination> LogAnalytics { get; set; }

        /// <summary>
        /// Gets or sets azure Monitor Metrics destination.
        /// </summary>
        public PSDestinationsSpecAzureMonitorMetrics AzureMonitorMetrics { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSDestinationsSpec class.
        /// </summary>
        public PSDestinationsSpec()
        { }

        /// <summary>
        /// Initializes a new instance of the PSDestinationsSpec class.
        /// </summary>
        /// <param name="destinationsSpec">The DestinationsSpec to wrap.</param>
        public PSDestinationsSpec(DestinationsSpec destinationsSpec)
        {
            LogAnalytics = destinationsSpec.LogAnalytics?.Select(x => new PSLogAnalyticsDestination(x)).ToList();
            AzureMonitorMetrics = destinationsSpec.AzureMonitorMetrics == null ? new PSDestinationsSpecAzureMonitorMetrics() :
                                                                                 new PSDestinationsSpecAzureMonitorMetrics(destinationsSpec.AzureMonitorMetrics);
        }
    }

    /// <summary>
    /// Wraps the DestinationsSpecAzureMonitorMetrics class.
    /// </summary>
    public class PSDestinationsSpecAzureMonitorMetrics : PSAzureMonitorMetricsDestination
    {
        /// <summary>
        /// Initializes a new instance of the PSDestinationsSpecAzureMonitorMetrics class.
        /// </summary>
        public PSDestinationsSpecAzureMonitorMetrics() : base()
        { }

        /// <summary>
        /// Initializes a new instance of the PSDestinationsSpecAzureMonitorMetrics class.
        /// </summary>
        /// <param name="destinationsSpecAzureMonitorMetrics">The DestinationsSpecAzureMonitorMetrics to wrap.</param>
        public PSDestinationsSpecAzureMonitorMetrics(DestinationsSpecAzureMonitorMetrics destinationsSpecAzureMonitorMetrics)
            : base(destinationsSpecAzureMonitorMetrics)
        { }
    }

    /// <summary>
    /// Wraps the AzureMonitorMetricsDestination class.
    /// </summary>
    public class PSAzureMonitorMetricsDestination
    {
        /// <summary>
        /// Gets or sets a friendly name for the destination.
        /// This name should be unique across all destinations (regardless of
        /// type) within the data collection rule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSAzureMonitorMetricsDestination class.
        /// </summary>
        public PSAzureMonitorMetricsDestination()
        { }

        /// <summary>
        /// Initializes a new instance of the PSAzureMonitorMetricsDestination class.
        /// </summary>
        /// <param name="azureMonitorMetricsDestination">The AzureMonitorMetricsDestination to wrap.</param>
        public PSAzureMonitorMetricsDestination(AzureMonitorMetricsDestination azureMonitorMetricsDestination)
        {
            Name = azureMonitorMetricsDestination.Name;
        }
    }

    /// <summary>
    /// Wraps the LogAnalyticsDestination class.
    /// </summary>
    public class PSLogAnalyticsDestination
    {
        /// <summary>
        /// Gets or sets the resource ID of the Log Analytics workspace.
        /// </summary>
        public string WorkspaceResourceId { get; set; }

        /// <summary>
        /// Gets or sets a friendly name for the destination.
        /// This name should be unique across all destinations (regardless of
        /// type) within the data collection rule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSLogAnalyticsDestination class.
        /// </summary>
        public PSLogAnalyticsDestination()
        { }

        /// <summary>
        /// Initializes a new instance of the PSLogAnalyticsDestination class.
        /// </summary>
        /// <param name="logAnalyticsDestination">The LogAnalyticsDestination to wrap.</param>
        public PSLogAnalyticsDestination(LogAnalyticsDestination logAnalyticsDestination)
        {
            WorkspaceResourceId = logAnalyticsDestination.WorkspaceResourceId;
            Name = logAnalyticsDestination.Name;
        }
    }
    #endregion

    #region DCR's Data Sources
    /// <summary>
    /// Wraps the DataCollectionRuleDataSources class.
    /// </summary>
    public class PSDataCollectionRuleDataSources : PSDataSourcesSpec
    {
        /// <summary>
        /// Initializes a new instance of the PSDataCollectionRuleDataSources class.
        /// </summary>
        public PSDataCollectionRuleDataSources()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the PSDataCollectionRuleDataSources class.
        /// </summary>
        /// <param name="dataCollectionRuleDataSources">The DataCollectionRuleDataSources to wrap.</param>
        public PSDataCollectionRuleDataSources(DataCollectionRuleDataSources dataCollectionRuleDataSources)
            : base(dataCollectionRuleDataSources)
        { }
    }

    /// <summary>
    /// Wraps the DataSourcesSpec class.
    /// </summary>
    public class PSDataSourcesSpec
    {
        /// <summary>
        /// Gets or sets the list of performance counter data source
        /// configurations.
        /// </summary>
        public IList<PSPerfCounterDataSource> PerformanceCounters { get; set; }

        /// <summary>
        /// Gets or sets the list of Windows Event Log data source
        /// configurations.
        /// </summary>
        public IList<PSWindowsEventLogDataSource> WindowsEventLogs { get; set; }

        /// <summary>
        /// Gets or sets the list of Syslog data source configurations.
        /// </summary>
        public IList<PSSyslogDataSource> Syslog { get; set; }

        /// <summary>
        /// Gets or sets the list of Azure VM extension data source
        /// configurations.
        /// </summary>
        public IList<PSExtensionDataSource> Extensions { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSDataSourcesSpec class.
        /// </summary>
        public PSDataSourcesSpec()
        { }

        /// <summary>
        /// Initializes a new instance of the PSDataSourcesSpec class.
        /// </summary>
        /// <param name="dataSourcesSpec">The DataSourcesSpec to wrap.</param>
        public PSDataSourcesSpec(DataSourcesSpec dataSourcesSpec)
        {
            PerformanceCounters = dataSourcesSpec.PerformanceCounters?.Select(x => new PSPerfCounterDataSource(x)).ToList();
            WindowsEventLogs = dataSourcesSpec.WindowsEventLogs?.Select(x => new PSWindowsEventLogDataSource(x)).ToList();
            Syslog = dataSourcesSpec.Syslog?.Select(x => new PSSyslogDataSource(x)).ToList();
            Extensions = dataSourcesSpec.Extensions?.Select(x => new PSExtensionDataSource(x)).ToList();
        }
    }

    /// <summary>
    /// Wraps the ExtensionDataSource class.
    /// </summary>
    public class PSExtensionDataSource
    {
        /// <summary>
        /// Gets or sets list of streams that this data source will be sent to.
        /// A stream indicates what schema will be used for this data and
        /// usually what table in Log Analytics the data will be sent to.
        /// </summary>
        public IList<string> Streams { get; set; }

        /// <summary>
        /// Gets or sets the name of the VM extension.
        /// </summary>
        public string ExtensionName { get; set; }

        /// <summary>
        /// Gets or sets the extension settings. The format is specific for
        /// particular extension.
        /// </summary>
        public object ExtensionSettings { get; set; }

        /// <summary>
        /// Gets or sets a friendly name for the data source.
        /// This name should be unique across all data sources (regardless of
        /// type) within the data collection rule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSExtensionDataSource class.
        /// </summary>
        public PSExtensionDataSource()
        { }

        /// <summary>
        /// Initializes a new instance of the PSExtensionDataSource class.
        /// </summary>
        /// <param name="extensionDataSource">The ExtensionDataSource to wrap.</param>
        public PSExtensionDataSource(ExtensionDataSource extensionDataSource)
        {
            Streams = extensionDataSource.Streams?.Select(x => x).ToList();
            ExtensionName = extensionDataSource.ExtensionName;
            ExtensionSettings = extensionDataSource.ExtensionSettings;
            Name = extensionDataSource.Name;
        }
    }

    /// <summary>
    /// Wraps the SyslogDataSource class.
    /// </summary>
    public class PSSyslogDataSource
    {
        /// <summary>
        /// Gets or sets list of streams that this data source will be sent to.
        /// A stream indicates what schema will be used for this data and
        /// usually what table in Log Analytics the data will be sent to.
        /// </summary>
        public IList<string> Streams { get; set; }

        /// <summary>
        /// Gets or sets the list of facility names.
        /// </summary>
        public IList<string> FacilityNames { get; set; }

        /// <summary>
        /// Gets or sets the log levels to collect.
        /// </summary>
        public IList<string> LogLevels { get; set; }

        /// <summary>
        /// Gets or sets a friendly name for the data source.
        /// This name should be unique across all data sources (regardless of
        /// type) within the data collection rule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSSyslogDataSource class.
        /// </summary>
        public PSSyslogDataSource()
        { }

        /// <summary>
        /// Initializes a new instance of the PSSyslogDataSource class.
        /// </summary>
        /// <param name="syslogDataSource">The SyslogDataSource to wrap.</param>
        public PSSyslogDataSource(SyslogDataSource syslogDataSource)
        {
            Streams = syslogDataSource.Streams?.Select(x => x).ToList();
            FacilityNames = syslogDataSource.FacilityNames?.Select(x => x).ToList();
            LogLevels = syslogDataSource.LogLevels?.Select(x => x).ToList();
            Name = syslogDataSource.Name;
        }
    }

    /// <summary>
    /// Wraps the WindowsEventLogDataSource class.
    /// </summary>
    public class PSWindowsEventLogDataSource
    {
        /// <summary>
        /// Gets or sets list of streams that this data source will be sent to.
        /// A stream indicates what schema will be used for this data and
        /// usually what table in Log Analytics the data will be sent to.
        /// </summary>
        public IList<string> Streams { get; set; }

        /// <summary>
        /// Gets or sets the interval between data uploads (scheduled
        /// transfers), rounded up to the nearest minute. Possible values
        /// include: 'PT1M', 'PT5M', 'PT15M', 'PT30M', 'PT60M'
        /// </summary>
        public string ScheduledTransferPeriod { get; set; }

        /// <summary>
        /// Gets or sets a list of Windows Event Log queries in XPATH format.
        /// </summary>
        public IList<string> XPathQueries { get; set; }

        /// <summary>
        /// Gets or sets a friendly name for the data source.
        /// This name should be unique across all data sources (regardless of
        /// type) within the data collection rule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSWindowsEventLogDataSource class.
        /// </summary>
        public PSWindowsEventLogDataSource()
        { }

        /// <summary>
        /// Initializes a new instance of the PSWindowsEventLogDataSource class.
        /// </summary>
        /// <param name="windowsEventLogDataSource">The WindowsEventLogDataSource to wrap.</param>
        public PSWindowsEventLogDataSource(WindowsEventLogDataSource windowsEventLogDataSource)
        {
            Streams = windowsEventLogDataSource.Streams?.Select(x => x).ToList();
            ScheduledTransferPeriod = windowsEventLogDataSource.ScheduledTransferPeriod;
            XPathQueries = windowsEventLogDataSource.XPathQueries?.Select(x => x).ToList();
            Name = windowsEventLogDataSource.Name;
        }
    }

    /// <summary>
    /// Wraps the PerfCounterDataSource class.
    /// </summary>
    public class PSPerfCounterDataSource
    {
        /// <summary>
        /// Gets or sets list of streams that this data source will be sent to.
        /// A stream indicates what schema will be used for this data and
        /// usually what table in Log Analytics the data will be sent to.
        /// </summary>
        public IList<string> Streams { get; set; }

        /// <summary>
        /// Gets or sets the interval between data uploads (scheduled
        /// transfers), rounded up to the nearest minute. Possible values
        /// include: 'PT1M', 'PT5M', 'PT15M', 'PT30M', 'PT60M'
        /// </summary>
        public string ScheduledTransferPeriod { get; set; }

        /// <summary>
        /// Gets or sets the number of seconds between consecutive counter
        /// measurements (samples).
        /// </summary>
        public int SamplingFrequencyInSeconds { get; set; }

        /// <summary>
        /// Gets or sets a list of specifier names of the performance counters
        /// you want to collect.
        /// Use a wildcard (*) to collect a counter for all instances.
        /// To get a list of performance counters on Windows, run the command
        /// 'typeperf'.
        /// </summary>
        public IList<string> CounterSpecifiers { get; set; }

        /// <summary>
        /// Gets or sets a friendly name for the data source.
        /// This name should be unique across all data sources (regardless of
        /// type) within the data collection rule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSExtensionDataSource class.
        /// </summary>
        public PSPerfCounterDataSource()
        { }

        /// <summary>
        /// Initializes a new instance of the PSExtensionDataSource class.
        /// </summary>
        /// <param name="perfCounterDataSource">The PerfCounterDataSource to wrap.</param>
        public PSPerfCounterDataSource(PerfCounterDataSource perfCounterDataSource)
        {
            Streams = perfCounterDataSource.Streams?.Select(x => x).ToList();
            ScheduledTransferPeriod = perfCounterDataSource.ScheduledTransferPeriod;
            SamplingFrequencyInSeconds = perfCounterDataSource.SamplingFrequencyInSeconds;
            CounterSpecifiers = perfCounterDataSource.CounterSpecifiers?.Select(x => x).ToList();
            Name = perfCounterDataSource.Name;
        }
    }
    #endregion

    #region (DCR's child resource) Data Collection Rule Associations

    /// <summary>
    /// Wraps around an Data Collection Rule Association.
    /// </summary>
    public class PSDataCollectionRuleAssociationProxyOnlyResource : ProxyOnlyResource
    {
        #region Properties
        /// <summary>
        /// Gets or sets description of the association.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the data collection rule that is to
        /// be associated.
        /// </summary>
        public string DataCollectionRuleId { get; set; }

        /// <summary>
        /// Gets the resource provisioning state. Possible values include:
        /// 'Creating', 'Updating', 'Deleting', 'Succeeded', 'Failed'
        /// </summary>
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets resource entity tag (ETag).
        /// </summary>
        public string Etag { get; private set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the PSDataCollectionRuleAssociationProxyOnlyResource class.
        /// </summary>
        public PSDataCollectionRuleAssociationProxyOnlyResource()
        { }

        /// <summary>
        /// Initializes a new instance of the PSDataCollectionRuleAssociationProxyOnlyResource class.
        /// </summary>
        /// <param name="dataCollectionRuleAssociationProxyOnlyResource">The DataCollectionRuleAssociationProxyOnlyResource to wrap.</param>
        public PSDataCollectionRuleAssociationProxyOnlyResource(DataCollectionRuleAssociationProxyOnlyResource dataCollectionRuleAssociationProxyOnlyResource)
            : base(
                id: dataCollectionRuleAssociationProxyOnlyResource.Id,
                name: dataCollectionRuleAssociationProxyOnlyResource.Name,
                type: dataCollectionRuleAssociationProxyOnlyResource.Type)
        {
            Description = dataCollectionRuleAssociationProxyOnlyResource.Description;
            ProvisioningState = dataCollectionRuleAssociationProxyOnlyResource.ProvisioningState;
            Etag = dataCollectionRuleAssociationProxyOnlyResource.Etag;
            DataCollectionRuleId = dataCollectionRuleAssociationProxyOnlyResource.DataCollectionRuleId;
        }
    }
    #endregion
}