### Example 1: Delete a tag rule set for a given logz sub account resource
```powershell
<<<<<<< HEAD
Remove-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01
=======
PS C:\> Remove-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a tag rule set for a given logz sub account resource.

### Example 2: Delete a tag rule set for a given logz sub account resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01 | Remove-AzLogzSubAccountTagRule
=======
PS C:\> Get-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01 | Remove-AzLogzSubAccountTagRule

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command deletes a tag rule set for a given logz sub account resource by pipeline.

