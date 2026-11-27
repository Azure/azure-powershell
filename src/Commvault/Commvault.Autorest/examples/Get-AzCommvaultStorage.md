### Example 1: List the storages of a cloud account
```powershell
Get-AzCommvaultStorage -ResourceGroupName rg-commvault -CloudAccountName cca-contoso
```

Lists the storages of the cloud account.

### Example 2: Get a storage
```powershell
Get-AzCommvaultStorage -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name storage-hot
```

Gets the storage named storage-hot.

