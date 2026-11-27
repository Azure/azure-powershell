### Example 1: List the backup plans of a cloud account
```powershell
Get-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso
```

Lists the backup plans of the cloud account.

### Example 2: Get a backup plan
```powershell
Get-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name plan-daily
```

Gets the backup plan named plan-daily.

