### Example 1: Get guest agent of a specific VM
```powershell
Get-AzConnectedVMwareGuestAgent -VirtualMachineName "test-vm" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Name    ResourceGroupName
----    -----------------
default azcli-test-rg
```

This command gets a guest agent of a Virtaul Machine named `test-vm` in a resource group named `azcli-test-rg`.