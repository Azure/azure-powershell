### Example 1: Returns the payload of the logz sub account that needs to be passed in the request body for installing Logz.io agent on a VM
```powershell
Invoke-AzLogzHostSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01
```

```output
ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

This command returns the payload of the logz sub account that needs to be passed in the request body for installing Logz.io agent on a VM.

### Example 2: Returns the payload of the logz sub account that needs to be passed in the request body for installing Logz.io agent on a VM by pipeline
```powershell
Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 | Invoke-AzLogzHostSubAccount
```

```output
ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

This command returns the payload of the logz sub account that needs to be passed in the request body for installing Logz.io agent on a VM by pipeline.

