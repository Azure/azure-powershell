### Example 1: Create or update a tag rule set for a given sub account resource
```powershell
<<<<<<< HEAD
New-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01
```

```output
=======
PS C:\> New-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command creates or update a tag rule set for a given sub account resource.

