### Example 1: Create NIC to migrate
```powershell
New-AzMigrateHCINicMappingObject -NicID a -TargetVirtualSwitchId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external"
```

```output
NicId                    : a
TargetNetworkId          : /subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external
TestNetworkId            : /subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external
SelectionTypeForFailover : SelectedByUser
```
Get NIC object to provide input for New-AzMigrateHCIServerReplication and Set-AzMigrateHCIServerReplication