### Example 1: Create a dynatrace SingleSignOn resource
```powershell
New-AzDynatraceMonitorSSOConfig -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 -AadDomain "mpliftrlogz20210811outlook.onmicrosoft.com"
```

```output
Name    ProvisioningState SingleSignOnState SingleSignOnUrl
----    ----------------- ----------------- ---------------
default Succeeded         Initial
```

This command create a dynatrace SingleSignOn resource.