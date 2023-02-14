### Example 1: Update a monitor resource
```powershell
<<<<<<< HEAD
Update-AzLogzMonitor -ResourceGroupName logz-rg-test -Name pwsh-logz04 -Tag @{'key01'=1;'key02'=2;'key03'=3}
```

```output
=======
PS C:\> Update-AzLogzMonitor -ResourceGroupName logz-rg-test -Name pwsh-logz04 -Tag @{'key01'=1;'key02'=2;'key03'=3}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name        MonitoringStatus Location ResourceGroupName
----        ---------------- -------- -----------------
pwsh-logz04 Enabled          westus2  logz-rg-test
```

This command updates a monitor resource.

### Example 2: Update a monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzLogzMonitor -ResourceGroupName logz-rg-test -Name pwsh-logz04 | Update-AzLogzMonitor -Tag @{'key01'=1;'key02'=2;'key03'=3}
```

```output
=======
PS C:\> Get-AzLogzMonitor -ResourceGroupName logz-rg-test -Name pwsh-logz04 | Update-AzLogzMonitor -Tag @{'key01'=1;'key02'=2;'key03'=3}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name        MonitoringStatus Location ResourceGroupName
----        ---------------- -------- -----------------
pwsh-logz04 Enabled          westus2  logz-rg-test
```

This command updates a monitor resource by pipeline.

