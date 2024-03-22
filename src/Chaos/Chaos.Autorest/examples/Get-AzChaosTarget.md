### Example 1: Get a Target resource that extends a tracked regional resource.
```powershell
Get-AzChaosTarget -ParentProviderNamespace Microsoft.Compute -ParentResourceName exampleVM -ParentResourceType virtualMachines -ResourceGroupName azps_test_group_chaos
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_chaos/providers/microsoft.compute/virtualmachines/exampleVM/providers/Microsoft.Chaos/targets/
                               microsoft-virtualmachine
Location                     : eastus
Name                         : microsoft-virtualmachine
Property                     : {
                               }
ResourceGroupName            : azps_test_group_chaos
SystemDataCreatedAt          : 2024-03-18 10:28:42 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-18 10:28:42 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Chaos/targets
```

Get a Target resource that extends a tracked regional resource.

### Example 2: Get a Target resource that extends a tracked regional resource.
```powershell
Get-AzChaosTarget -ParentProviderNamespace Microsoft.Compute -ParentResourceName exampleVM -ParentResourceType virtualMachines -ResourceGroupName azps_test_group_chaos -Name microsoft-virtualmachine
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_chaos/providers/microsoft.compute/virtualmachines/exampleVM/providers/Microsoft.Chaos/targets/
                               microsoft-virtualmachine
Location                     : eastus
Name                         : microsoft-virtualmachine
Property                     : {
                               }
ResourceGroupName            : azps_test_group_chaos
SystemDataCreatedAt          : 2024-03-18 10:28:42 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-18 10:28:42 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Chaos/targets
```

Get a Target resource that extends a tracked regional resource.