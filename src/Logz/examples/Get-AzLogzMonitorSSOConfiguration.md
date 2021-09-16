### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzLogzMonitorSSOConfiguration -ResourceGroupName LPTrials -MonitorName lpatlogz

Name    ProvisioningState SingleSignOnState SingleSignOnUrl                                ResourceGroupName
----    ----------------- ----------------- ---------------                                -----------------
default Succeeded         Existing          https://api-wa.logz.io/auth/azure/325420/login LPTrials
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> New-AzLogzMonitorSSOConfiguration -ResourceGroupName lucas-rg-test -MonitorName pwsh-logz04 | Get-AzLogzMonitorSSOConfiguration

Name    ProvisioningState SingleSignOnState SingleSignOnUrl             ResourceGroupName
----    ----------------- ----------------- ---------------             -----------------
default Succeeded         Disable           https://app.logz.io/        lucas-rg-test
```

{{ Add description here }}

