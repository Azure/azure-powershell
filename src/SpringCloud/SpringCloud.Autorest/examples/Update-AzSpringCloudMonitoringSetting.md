### Example 1: Update the Monitoring Setting
```powershell
Update-AzSpringCloudMonitoringSetting -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service -AppInsightsInstrumentationKey "InstrumentationKey=xxxxxxxxxxxxxxxxxxx;IngestionEndpoint=https://xxxxxx.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/" -TraceEnabled
```

```output
Name    ResourceGroupName ProvisioningState TraceEnabled
----    ----------------- ----------------- ------------
default azurespringrg     Succeeded         True
```

Update the Monitoring Setting.

### Example 2: Update the Monitoring Setting by pipeline
```powershell
Get-AzSpringCloudMonitoringSetting -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service | Update-AzSpringCloudMonitoringSetting -AppInsightsInstrumentationKey "InstrumentationKey=xxxxxxxxxxxxxxxxxxx;IngestionEndpoint=https://xxxxxx.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/" -TraceEnabled
```

```output
Name    ResourceGroupName ProvisioningState TraceEnabled
----    ----------------- ----------------- ------------
default azurespringrg     Succeeded         True
```

Update the Monitoring Setting by pipeline.

