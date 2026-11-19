### Example 1: Create or replace a context cache
```powershell
Set-AzStorageContextCache -ResourceGroupName "myResourceGroup" -Name "mycontextcache" -Location "eastus" -AccountKind Regional -EnableSystemAssignedIdentity $true -Description "Inference context cache"
```

Creates or replaces the context cache. Use Update-AzStorageContextCache for a partial update without respecifying creation properties.
