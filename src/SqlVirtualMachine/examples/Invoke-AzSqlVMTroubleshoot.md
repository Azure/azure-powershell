### Example 1
```powershell
Invoke-AzSqlVMTroubleshoot -ResourceGroupName 'ResourceGroup01' -SqlVirtualMachineName 'sqlvm1' -StartTimeUtc '2023-03-15T17:10:00Z' -EndTimeUtc '2023-03-16T08:30:10Z' -TroubleshootingScenario 'UnhealthyReplica'
```

```output
EndTimeUtc StartTimeUtc TroubleshootingScenario VirtualMachineResourceId
---------- ------------ ----------------------- ------------------------

```

### Example 2
```powershell
$sqlvm = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
$sqlvm | Invoke-AzSqlVMTroubleshoot -StartTimeUtc '2023-03-15T17:10:00Z' -EndTimeUtc '2023-03-16T08:30:10Z' -TroubleshootingScenario 'UnhealthyReplica'
```

```output
EndTimeUtc StartTimeUtc TroubleshootingScenario VirtualMachineResourceId
---------- ------------ ----------------------- ------------------------

```

