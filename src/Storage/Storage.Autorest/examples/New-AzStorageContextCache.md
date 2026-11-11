### Example 1: Create a regional context cache with a managed identity
```powershell
New-AzStorageContextCache -ResourceGroupName "myResourceGroup" -Name "mycontextcache" -Location "eastus" -AccountKind Regional -EnableSystemAssignedIdentity -Tag @{ purpose = "inference" }
```

Creates a regional context cache with a system-assigned managed identity. Use UserAssignedIdentity to provide user-assigned managed identity resource IDs.
