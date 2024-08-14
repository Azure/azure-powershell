### Example 1: List Skus For Capacity
```powershell
Get-AzFabricCapacitySku -ResourceGroupName "testrg" -CapacityName "azsdktest"
```

```output
{
  "value": [
    {
      "resourceType": "Microsoft.Fabric/capacities",
      "sku": {
        "name": "F16",
        "tier": "Fabric"
      }
    },
    {
      "resourceType": "Microsoft.Fabric/capacities",
      "sku": {
        "name": "F8",
        "tier": "Fabric"
      }
    },
    {
      "resourceType": "Microsoft.Fabric/capacities",
      "sku": {
        "name": "F64",
        "tier": "Fabric"
      }
    },
    {
      "resourceType": "Microsoft.Fabric/capacities",
      "sku": {
        "name": "F1024",
        "tier": "Fabric"
      }
    },
    {
      "resourceType": "Microsoft.Fabric/capacities",
      "sku": {
        "name": "F128",
        "tier": "Fabric"
      }
    },
    {
      "resourceType": "Microsoft.Fabric/capacities",
      "sku": {
        "name": "F2",
        "tier": "Fabric"
      }
    },
    {
      "resourceType": "Microsoft.Fabric/capacities",
      "sku": {
        "name": "F256",
        "tier": "Fabric"
      }
    },
    {
      "resourceType": "Microsoft.Fabric/capacities",
      "sku": {
        "name": "F32",
        "tier": "Fabric"
      }
    },
    {
      "resourceType": "Microsoft.Fabric/capacities",
      "sku": {
        "name": "F4",
        "tier": "Fabric"
      }
    },
    {
      "resourceType": "Microsoft.Fabric/capacities",
      "sku": {
        "name": "F512",
        "tier": "Fabric"
      }
    },
    {
      "resourceType": "Microsoft.Fabric/capacities",
      "sku": {
        "name": "F2048",
        "tier": "Fabric"
      }
    }
  ]
}
```

{{ Add description here }}

### Example 2: List Skus
```powershell
Get-AzFabricCapacitySku
```

```output
{
  "value": [
    {
      "name": "F8",
      "locations": [
        "West Europe"
      ],
      "resourceType": "Capacities"
    },
    {
      "name": "F64",
      "locations": [
        "West Europe"
      ],
      "resourceType": "Capacities"
    },
    {
      "name": "F128",
      "locations": [
        "West Europe"
      ],
      "resourceType": "Capacities"
    },
    {
      "name": "F512",
      "locations": [
        "West Europe"
      ],
      "resourceType": "Capacities"
    }
  ]
}
```

{{ Add description here }}

