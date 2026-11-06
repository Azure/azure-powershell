### Example 1: List the protection groups of a cloud account
```powershell
Get-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso
```

Lists the protection groups of the cloud account.

### Example 2: Get a protection group
```powershell
Get-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name pg-prod-vms
```

Gets the protection group named pg-prod-vms.

