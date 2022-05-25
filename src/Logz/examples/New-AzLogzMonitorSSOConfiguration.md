### Example 1: Configures single-sign-on for this resource
```powershell
New-AzLogzMonitorSSOConfiguration -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04
```

```output
Name    ProvisioningState SingleSignOnState SingleSignOnUrl             ResourceGroupName
----    ----------------- ----------------- ---------------             -----------------
default Succeeded         Disable           https://app.logz.io/        logz-rg-test
```

This command configures single-sign-on for this resource.
