### Example 1: Update Extension of VM
```powershell
Update-AzConnectedVMwareMachineExtension -Name "AzureMonitorLinuxAgent" -VirtualMachineName "test-vm" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d" -Publisher "Microsoft.Azure.Monitor" -EnableAutomaticUpgrade
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   AzureMonitorLinuxAgent azcli-test-rg
```

This command enbale auto upgrade of Machine Extension `AzureMonitorLinuxAgent` of a VM named `test-vm` in a resource group named `azcli-test-rg`.