### Example 1: Create prometheus forwarder data source object
```powershell
New-AzPrometheusForwarderDataSourceObject -LabelIncludeFilter @{"microsoft_metrics_include_label"="MonitoringData"} -Name "myPromDataSource1" -Stream "Microsoft-PrometheusMetrics"
```

```output
LabelIncludeFilter                                          Name              Stream
------------------                                          ----              ------
{…                                                          myPromDataSource1 {Microsoft-PrometheusMetrics}
```

This command creates a prometheus forwarder data source object.
