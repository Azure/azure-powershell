### Example 1: List the capacity metrics rules for an account
```powershell
Get-AzStorageAdvancedPlatformMetricsRule -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount"
```

Lists the metrics rules for the storage account. An account without configured rules returns no results.

### Example 2: Get a metrics rule by resource identity
```powershell
$rules = Get-AzStorageAdvancedPlatformMetricsRule -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount"
Get-AzStorageAdvancedPlatformMetricsRule -InputObject @{ Id = $rules[0].Id }
```

Retrieves a specific existing rule using its resource identity. This example requires at least one configured rule.
