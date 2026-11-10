### Example 1: Change the class of a storage
```powershell
Update-AzCommvaultStorage -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name storage-hot -StorageClassType COLD
```

Changes the class of the storage to cold.

