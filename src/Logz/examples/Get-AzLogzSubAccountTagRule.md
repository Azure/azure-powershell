### Example 1: Get the default tag rule set for a given logz sub account resource
```powershell
<<<<<<< HEAD
Get-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01
```

```output
=======
PS C:\> Get-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command gets the default tag rule set for a given logz sub account resource.

### Example 2: Get the default tag rule set for a given logz sub account resourceby pipeline
```powershell
<<<<<<< HEAD
New-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01 | Get-AzLogzSubAccountTagRule
```

```output
=======
PS C:\> New-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01 | Get-AzLogzSubAccountTagRule

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command gets the default tag rule set for a given logz sub account resource by pipeline.

