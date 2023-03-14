### Example 1: List Extensions of a VM
```powershell
Get-AzConnectedVMwareMachineExtension -VirtualMachineName "test-vm" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   AzureMonitorLinuxAgent azcli-test-rg
```

This command lists Machine Extensions of a VM named `test-vm` in a resource group named `azcli-test-rg`.

### Example 2: Get a specific Extension of a VM
```powershell
Get-AzConnectedVMwareMachineExtension -Name "AzureMonitorLinuxAgent" -VirtualMachineName "test-vm" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   AzureMonitorLinuxAgent azcli-test-rg
```

This command gets a Extensions named `AzureMonitorLinuxAgent` of a VM named `test-vm` in a resource group named `azcli-test-rg`.