### Example 1: Create platform telemetry data source object
```powershell
New-AzPlatformTelemetryDataSourceObject -Stream "Microsoft.Insights/autoscalesettings:Logs-AutoscaleEvaluations","Microsoft.Insights/autoscalesettings:Logs-AutoscaleScaleActions" -Name "myAutoScalePlatformTelemetryLogs"
```

```output
Name                             Stream
----                             ------
myAutoScalePlatformTelemetryLogs {Microsoft.Insights/autoscalesettings:Logs-AutoscaleEvaluations, Microsoft.Insights/autoscalesettings:Logs-AutoscaleScaleActions}
```

This command creates a platform telemetry data source object with XPathQuery.

