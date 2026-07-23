### Example 1: Shut down the VM gracefully
```powershell
Stop-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01"
```

This command will Shut down the VM gracefully and bring it to Stopped state.

### Example 2: Power off the VM
```powershell
Stop-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -SkipShutdown
```

This command will Skip shutdown and power-off the VM immediately.

### Example 2: Power off the VM
```powershell
$SkipShutdownJson = '{
    "skipShutdown": "true"
}'
Stop-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -JsonString $SkipShutdownJson
```

This command will Skip shutdown and power-off the VM immediately.