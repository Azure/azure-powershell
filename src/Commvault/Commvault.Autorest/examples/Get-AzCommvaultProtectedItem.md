### Example 1: List the protected items of a protection group
```powershell
Get-AzCommvaultProtectedItem -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms
```

Lists the protected items in the protection group.

### Example 2: Get a protected item
```powershell
Get-AzCommvaultProtectedItem -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -Name vm-app01
```

Gets the protected item named vm-app01.

