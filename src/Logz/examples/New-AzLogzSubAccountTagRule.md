### Example 1: Create or update a tag rule set for a given sub account resource
```powershell
PS C:\> New-AzLogzSubAccountTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -SubAccountName logz-pwshsub01

Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command creates or update a tag rule set for a given sub account resource.

