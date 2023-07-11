### Example 1: Update the Monitoring Setting
```powershell
Update-AzSpringMonitoringSetting -ResourceGroupName Spring-gp-junxi -Name Spring-service -AppInsightsInstrumentationKey "InstrumentationKey=xxxxxxxxxxxxxxxxxxx;IngestionEndpoint=https://xxxxxx.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/" -TraceEnabled
```

```output
Name    ResourceGroupName ProvisioningState TraceEnabled
----    ----------------- ----------------- ------------
default azurespringrg     Succeeded         True
```

Update the Monitoring Setting.

### Example 2: Update the Monitoring Setting by pipeline
```powershell
Get-AzSpringMonitoringSetting -ResourceGroupName Spring-gp-junxi -Name Spring-service | Update-AzSpringMonitoringSetting -AppInsightsInstrumentationKey "InstrumentationKey=xxxxxxxxxxxxxxxxxxx;IngestionEndpoint=https://xxxxxx.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/" -TraceEnabled
```

```output
Name    ResourceGroupName ProvisioningState TraceEnabled
----    ----------------- ----------------- ------------
default azurespringrg     Succeeded         True
```

Update the Monitoring Setting by pipeline.

