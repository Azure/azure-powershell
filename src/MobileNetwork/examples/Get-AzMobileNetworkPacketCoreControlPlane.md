### Example 1: List information about the specified packet core control plane by Sub.
```powershell
Get-AzMobileNetworkPacketCoreControlPlane
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pccp azps_test_group   Succeeded
```

List information about the specified packet core control plane by Sub.

### Example 2: Get information about the specified packet core control plane by ResourceGroup.
```powershell
Get-AzMobileNetworkPacketCoreControlPlane -ResourceGroupName azps_test_group
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pccp azps_test_group   Succeeded
```

Get information about the specified packet core control plane by ResourceGroup.

### Example 3: Get information about the specified packet core control plane by Name.
```powershell
Get-AzMobileNetworkPacketCoreControlPlane -ResourceGroupName azps_test_group -Name azps-mn-pccp
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pccp azps_test_group   Succeeded
```

Get information about the specified packet core control plane by Name.