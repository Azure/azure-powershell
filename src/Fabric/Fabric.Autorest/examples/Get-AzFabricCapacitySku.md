### Example 1: List Skus For Capacity
```powershell
Get-AzFabricCapacitySku -ResourceGroupName "testrg" -CapacityName "azsdktest" | fl
```

```output
ResourceType : Microsoft.Fabric/capacities
SkuName      : F16
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F8
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F64
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F1024
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F128
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F2
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F256
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F32
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F4
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F512
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F2048
SkuTier      : Fabric
```

### Example 2: List Skus
```powershell
Get-AzFabricCapacitySku | fl
```

```output
Name  ResourceType
----  ------------
Location     : {West US}
Name         : F2
ResourceType : Capacities

Location     : {West US}
Name         : F4
ResourceType : Capacities

Location     : {West US}
Name         : F8
ResourceType : Capacities

Location     : {West US}
Name         : F16
ResourceType : Capacities

Location     : {West US}
Name         : F32
ResourceType : Capacities

Location     : {West US}
Name         : F64
ResourceType : Capacities

Location     : {West US}
Name         : F128
ResourceType : Capacities

Location     : {West US}
Name         : F256
ResourceType : Capacities

Location     : {West US}
Name         : F512
ResourceType : Capacities

Location     : {West US}
Name         : F1024
ResourceType : Capacities

Location     : {West US}
Name         : F2048
ResourceType : Capacities

Location     : {West India}
Name         : F2
ResourceType : Capacities

Location     : {West India}
Name         : F4
ResourceType : Capacities

...
```

