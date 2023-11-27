### Example 1: Returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM
```powershell
PS C:\> Invoke-AzLogzHostMonitor -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04

ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

This command returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM.

### Example 2: Returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM by pipeline
```powershell
PS C:\> Get-AzLogzMonitor -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Invoke-AzLogzHostMonitor

ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

This command returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM by pipeline.

