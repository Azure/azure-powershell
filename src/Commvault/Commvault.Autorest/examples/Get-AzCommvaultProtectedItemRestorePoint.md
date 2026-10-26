### Example 1: Get the restore points of a protected item
```powershell
Get-AzCommvaultProtectedItemRestorePoint -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -ProtectedItemName vm-app01
```

Gets the restore points that are available for the protected item.

