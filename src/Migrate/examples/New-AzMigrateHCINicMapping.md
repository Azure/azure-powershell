### Example 1: Create NIC to migrate
```powershell
New-AzMigrateHCINicMapping -NicID a -TargetNetworkId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/virtualnetworks/external"
```

```output
NicId                    : a
TargetNetworkId          : /subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/virtualnetworks/external
TestNetworkId            : /subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/virtualnetworks/external
SelectionTypeForFailover : SelectedByUser
```
Get NIC object to provide input for New-AzMigrateHCIServerReplication and Set-AzMigrateHCIServerReplication
