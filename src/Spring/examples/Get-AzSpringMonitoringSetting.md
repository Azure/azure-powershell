### Example 1: Get the Monitoring Setting and its properties
```powershell
Get-AzSpringMonitoringSetting -ResourceGroupName Spring-gp-junxi -Name Spring-service
```

```output
Name    ResourceGroupName ProvisioningState TraceEnabled
----    ----------------- ----------------- ------------
default azurespringrg     Succeeded         True
```

Get the Monitoring Setting and its properties.

### Example 2: Get the Monitoring Setting and its properties by pipeline
```powershell
 Update-AzSpringMonitoringSetting -AppInsightsInstrumentationKey "InstrumentationKey=xxxxxxxxxxxxxxxxxxx;IngestionEndpoint=https://xxxxxx.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/" | Get-AzSpringMonitoringSetting
```

```output
Name    ResourceGroupName ProvisioningState TraceEnabled
----    ----------------- ----------------- ------------
default azurespringrg     Succeeded         True
```

Get the Monitoring Setting and its properties by pipeline.

