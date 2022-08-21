### Example 1: Get a dynatrace SingleSignOn resource
```powershell
Get-AzDynatraceMonitorSSOConfig -ResourceGroupName dyobrg -MonitorName dyob-pwsh01
```

```output
Name    ResourceGroupName ProvisioningState SingleSignOnState SingleSignOnUrl
----    ----------------- ----------------- ----------------- ---------------
default dyobrg            Succeeded         Initial
```

This command gets a dynatrace SingleSignOn resource.

### Example 2: Get a dynatrace SingleSignOn resource by pipeline
```powershell
New-AzDynatraceMonitorSSOConfig -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 -AadDomain "mpliftrlogz20210811outlook.onmicrosoft.com" | Get-AzDynatraceMonitorSSOConfig
```

```output
Name    ResourceGroupName ProvisioningState SingleSignOnState SingleSignOnUrl
----    ----------------- ----------------- ----------------- ---------------
default dyobrg            Succeeded         Initial
```

This command gets a dynatrace SingleSignOn resource by pipeline.