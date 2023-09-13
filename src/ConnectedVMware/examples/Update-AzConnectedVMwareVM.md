### Example 1: Update Virtual Machine Resource
```powershell
Update-AzConnectedVMwareVM -Name "test-vm" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d" 
-Tag @{"vm"="test"}
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vnet azcli-test-rg
```

This command update tag of a VM named `test-vm` in a resource group named `azcli-test-rg`.

### Example 2: Update Virtual Machine Resource Memory Size
```powershell
Update-AzConnectedVMwareVM -Name "test-vm" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d" 
-HardwareProfileMemorySizeMb 2048
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-vm azcli-test-rg
```

This command update Memory Size of a VM named `test-vm` in a resource group named `azcli-test-rg`.

### Example 2: Update Virtual Machine Resource Identity Type
```powershell
Update-AzConnectedVMwareVM -Name "test-vm" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d" -IdentityType "SystemAssigned"
```

```output
Kind   Location Name    ResourceGroupName
----   -------- ----    -----------------
VMware eastus   test-vm azcli-test-rg
```

This command update Identity Type of a VM named `test-vm` in a resource group named `azcli-test-rg`.