### Example 1: Configures single-sign-on for this resource
```powershell
<<<<<<< HEAD
New-AzLogzMonitorSSOConfiguration -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04
```

```output
=======
PS C:\> New-AzLogzMonitorSSOConfiguration -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    ProvisioningState SingleSignOnState SingleSignOnUrl             ResourceGroupName
----    ----------------- ----------------- ---------------             -----------------
default Succeeded         Disable           https://app.logz.io/        logz-rg-test
```

This command configures single-sign-on for this resource.
