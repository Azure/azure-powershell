### Example 1: Update a logz sub account resource
```powershell
<<<<<<< HEAD
Update-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 -Tag @{'key01'=1;'key02'=2;'key03'=3}
```

```output
=======
PS C:\> Update-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 -Tag @{'key01'=1;'key02'=2;'key03'=3}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name           MonitoringStatus Location ResourceGroupName
----           ---------------- -------- -----------------
logz-pwshsub01 Enabled          westus2  logz-rg-test
```

This command updates a logz sub account resource.

### Example 2: Update a logz sub account resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 | Update-AzLogzSubAccount -Tag @{'key01'=1;'key02'=2;'key03'=3}
```

```output
=======
PS C:\> Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 | Update-AzLogzSubAccount -Tag @{'key01'=1;'key02'=2;'key03'=3}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name           MonitoringStatus Location ResourceGroupName
----           ---------------- -------- -----------------
logz-pwshsub01 Enabled          westus2  logz-rg-test
```

This command updates a logz sub account resource by pipeline.

