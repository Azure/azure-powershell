### Example 1: Returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM
```powershell
<<<<<<< HEAD
Invoke-AzLogzHostMonitor -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04
```

```output
=======
PS C:\> Invoke-AzLogzHostMonitor -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

This command returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM.

### Example 2: Returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM by pipeline
```powershell
<<<<<<< HEAD
Get-AzLogzMonitor -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Invoke-AzLogzHostMonitor
```

```output
=======
PS C:\> Get-AzLogzMonitor -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Invoke-AzLogzHostMonitor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

This command returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM by pipeline.

