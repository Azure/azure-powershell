### Example 1: Shut down the VM gracefully
```powershell
Stop-AzScVmmVM -MachineId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.HybridCompute/machines/test-vm"
```

This command will Shut down the VM gracefully and bring it to Stopped state.

### Example 2: Power off the VM
```powershell
Stop-AzScVmmVM -MachineId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.HybridCompute/machines/test-vm" -SkipShutdown "true"
```

This command will Skip shutdown and power-off the VM immediately.

