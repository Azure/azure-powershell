### Example 1: Create Layer 2 (L2) network
```powershell
New-AzNetworkCloudL2Network -Name l2Network -ResourceGroupName resourceGroupName -ExtendedLocationName "/subscriptions/subscriptionId/resourcegroups/resourceGroupName/providers/microsoft.extendedlocation/customlocations/customLocationsName" -ExtendedLocationType "CustomLocation" -L2IsolationDomainId  "/subscriptions/fabricsubs/resourceGroups/resourceGroupName/providers/Microsoft.NetworkFabric/L2IsolationDomains/L2IsolationDomainsName" -Location  eastus -HybridAksPluginType  "DPDK" -InterfaceName "eth0" -Tag @{tags = "tag1" } -SubscriptionId subscriptionId
```

```output
Location Name       SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType Type                              AzureAsyncOperation
-------- ----       ------------------- -------------------      ----------------------- ------------------------ ------------------------  ---------------------------- ----                              -------------------
eastus   l2Network 05/25/2023 05:36:37  user1                    User                    05/25/2023 05:36:48      app1                      Application                  microsoft.networkcloud/l2networks
```

This command creates a new layer 2 (L2) network.
