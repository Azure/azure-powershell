### Example 1
```powershell
Remove-AzAvailabilityGroupListener -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'SqlVmGroup01' -Name 'AgListener01'
```

### Example 2
```powershell
$msListner = Get-AzAvailabilityGroupListener -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'SqlVmGroup01' -Name 'AgListener01'
$msListner | Remove-AzAvailabilityGroupListener
```

