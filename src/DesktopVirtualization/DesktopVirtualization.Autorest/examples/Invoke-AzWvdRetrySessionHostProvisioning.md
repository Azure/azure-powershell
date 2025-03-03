### Example 1: Retries sessionHostProvisioning
```powershell
Invoke-AzWvdRetrySessionHostProvisioning -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -SessionHostName "sessionHost1"
```

This command retries the provisioning on the given sessionHost.
