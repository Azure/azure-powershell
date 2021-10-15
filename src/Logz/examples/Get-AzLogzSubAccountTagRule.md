### Example 1: Get the default tag rule set for a given logz sub account resource
```powershell
PS C:\> Get-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01

Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command gets the default tag rule set for a given logz sub account resource.

### Example 2: Get the default tag rule set for a given logz sub account resourceby pipeline
```powershell
PS C:\> New-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01 | Get-AzLogzSubAccountTagRule

Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command gets the default tag rule set for a given logz sub account resource by pipeline.

