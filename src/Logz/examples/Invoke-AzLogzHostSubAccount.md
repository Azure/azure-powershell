### Example 1: Returns the payload of the logz sub account that needs to be passed in the request body for installing Logz.io agent on a VM
```powershell
<<<<<<< HEAD
Invoke-AzLogzHostSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01
```

```output
=======
PS C:\> Invoke-AzLogzHostSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

This command returns the payload of the logz sub account that needs to be passed in the request body for installing Logz.io agent on a VM.

### Example 2: Returns the payload of the logz sub account that needs to be passed in the request body for installing Logz.io agent on a VM by pipeline
```powershell
<<<<<<< HEAD
Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 | Invoke-AzLogzHostSubAccount
```

```output
=======
PS C:\> Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 | Invoke-AzLogzHostSubAccount

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

This command returns the payload of the logz sub account that needs to be passed in the request body for installing Logz.io agent on a VM by pipeline.

