### Example 1: List the cloud accounts in a subscription
```powershell
Get-AzCommvaultCloudAccount
```

Lists all cloud accounts in the current subscription.

### Example 2: List the cloud accounts in a resource group
```powershell
Get-AzCommvaultCloudAccount -ResourceGroupName rg-commvault
```

Lists the cloud accounts in the resource group.

### Example 3: Get a cloud account
```powershell
Get-AzCommvaultCloudAccount -ResourceGroupName rg-commvault -Name cca-contoso
```

Gets the cloud account named cca-contoso.

