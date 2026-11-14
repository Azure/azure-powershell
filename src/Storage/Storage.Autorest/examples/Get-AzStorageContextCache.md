### Example 1: List context caches in a resource group
```powershell
Get-AzStorageContextCache -ResourceGroupName "myResourceGroup"
```

Lists context caches in the resource group. Omit ResourceGroupName to list caches in the current subscription, or specify Name to get one cache.
