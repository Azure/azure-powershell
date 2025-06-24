### Example 1: Start a Virtual Machine
```powershell
Start-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01"

```

This command will power on the VM and bring it to Running state from Stopped state.

### Example 2: Start a Virtual Machine
```powershell
Start-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000"
```

This command will power on the VM and bring it to Running state from Stopped state.