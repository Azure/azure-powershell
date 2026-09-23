### Example 1: Update a dynatrace SingleSignOn resource
```powershell
Update-AzDynatraceMonitorSSOConfig -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 -AadDomain "mpliftrlogz20210811outlook.onmicrosoft.com"
```

```output
Name    ProvisioningState SingleSignOnState SingleSignOnUrl
----    ----------------- ----------------- ---------------
default Succeeded         Initial
```

This command update a dynatrace SingleSignOn resource.