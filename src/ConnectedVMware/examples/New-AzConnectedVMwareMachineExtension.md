### Example 1: Create VM Extension
```powershell
New-AzConnectedVMwareMachineExtension -Name "AzureMonitorLinuxAgent" -VirtualMachineName "test-vm" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d" -Location "eastus" -PropertiesType "AzureMonitorLinuxAgent" -Publisher "Microsoft.Azure.Monitor"
```

```output
Location Name                   ResourceGroupName
-------- ----                   -----------------
eastus   AzureMonitorLinuxAgent azcli-test-rg
```

This command create the Extension name `AzureMonitorLinuxAgent` in the VM named `test-vm` in a resource group named `azcli-test-rg`.