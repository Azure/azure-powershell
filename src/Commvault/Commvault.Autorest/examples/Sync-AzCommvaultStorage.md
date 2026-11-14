### Example 1: Refresh a storage
```powershell
Sync-AzCommvaultStorage -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name storage-hot
```

Refreshes the storage so that its properties, such as the compliance lock status, match the current state on the partner side.

