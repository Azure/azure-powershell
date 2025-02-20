### Example 1: Create NIC to migrate
```powershell
New-AzMigrateLocalNicMappingObject -NicID a -TargetVirtualSwitchId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external"
```

```output
NicId                    : a
TargetNetworkId          : /subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external
TestNetworkId            : /subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external
SelectionTypeForFailover : SelectedByUser
```
Get NIC object to provide input for New-AzMigrateLocalServerReplication and Set-AzMigrateLocalServerReplication