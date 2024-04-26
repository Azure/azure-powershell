### Example 1: Delete a tag rule set for a given logz sub account resource
```powershell
Remove-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01
```

This command deletes a tag rule set for a given logz sub account resource.

### Example 2: Delete a tag rule set for a given logz sub account resource by pipeline
```powershell
Get-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01 | Remove-AzLogzSubAccountTagRule
```

This command deletes a tag rule set for a given logz sub account resource by pipeline.

