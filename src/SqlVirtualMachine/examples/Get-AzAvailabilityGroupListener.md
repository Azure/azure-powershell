### Example 1: Get all Availability Group Listeners of a SQL Virtual Machine Group
```powershell
Get-AzAvailabilityGroupListener -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'SqlVmGroup01'
```

```output
Name            ResourceGroupName
----            -----------------
AgListener01    ResourceGroup01
AgListener02    ResourceGroup01
```

### Example 2: Get one Availability Group Listener of a SQL Virtual Machine Group
```powershell
Get-AzAvailabilityGroupListener -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'SqlVmGroup01' -Name 'AgListener01'
```

```output
Name            ResourceGroupName
----            -----------------
AgListener01    ResourceGroup01
```

