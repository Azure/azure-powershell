### Example 1: Gets the default Logz single sign-on resource for the given Monitor
```powershell
Get-AzLogzMonitorSSOConfiguration -ResourceGroupName LPTrials -MonitorName lpatlogz
```

```output
Name    ProvisioningState SingleSignOnState SingleSignOnUrl                                ResourceGroupName
----    ----------------- ----------------- ---------------                                -----------------
default Succeeded         Existing          https://api-wa.logz.io/auth/azure/325420/login LPTrials
```

This command gets the default Logz single sign-on resource for the given Monitor.

### Example 2: Gets the default Logz single sign-on resource for the given Monitor by pipeline
```powershell
New-AzLogzMonitorSSOConfiguration -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Get-AzLogzMonitorSSOConfiguration
```

```output
Name    ProvisioningState SingleSignOnState SingleSignOnUrl             ResourceGroupName
----    ----------------- ----------------- ---------------             -----------------
default Succeeded         Disable           https://app.logz.io/        logz-rg-test
```

This command gets the default Logz single sign-on resource for the given Monitor by pipeline.

