### Example 1: Create a Private Traffic Manager profile with weighted routing
```powershell
New-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -Location "global" -TrafficRoutingMethod "Weighted" -ProfileStatus "Enabled" -DnsConfigRecordType "CNAME" -DnsConfigTtl 60 -Tag @{environment="test"; team="networking"}
```

```output
Name              Location TrafficRoutingMethod ProfileStatus ProvisioningState
----              -------- -------------------- ------------- -----------------
weighted-profile  global   Weighted             Enabled       Succeeded
```

This command creates a new Private Traffic Manager profile with weighted traffic routing, CNAME DNS record type, and a TTL of 60 seconds.

### Example 2: Create a Private Traffic Manager profile with a topology map
```powershell
New-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName "priority-profile" -ResourceGroupName "demo-rg" -Location "global" -TrafficRoutingMethod "Priority" -ProfileStatus "Enabled" -CustomTopologyMap "Enable" -TopologyMapId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-ptm-demo/providers/Microsoft.Network/topologyMaps/ptm-topology-demo"
```

```output
Name              Location TrafficRoutingMethod ProfileStatus ProvisioningState
----              -------- -------------------- ------------- -----------------
priority-profile  global   Priority             Enabled       Succeeded
```

This command creates a Private Traffic Manager profile with priority-based routing and associates it with an existing topology map.

