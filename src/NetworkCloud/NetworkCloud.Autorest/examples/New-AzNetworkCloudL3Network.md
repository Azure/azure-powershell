### Example 1: Create Layer 3 (L3) network
```powershell
New-AzNetworkCloudL3Network -ResourceGroupName resourceGroupName -Name l3NetworkName -Location eastus -ExtendedLocationName  "subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ExtendedLocation/customLocations/clusterExtendedLocationName" -ExtendedLocationType "CustomLocation" -Vlan 1001 -L3IsolationDomainId "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/l3IsolationDomainName" -Ipv4ConnectedPrefix  "10.1.100.0/24" -Ipv6ConnectedPrefix  "fd01:1::0/64" -SubscriptionId subscriptionId
```

```output
Location Name            SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType AzureAsyncOperation ResourceGroupName
-------- ----            ------------------- -------------------     ----------------------- ------------------------ ------------------------             ---------------------------- ------------------- -----------------
eastus   l3NetworkName   05/09/2023 16:46:38 user1                   User                    05/09/2023 16:55:26      user1                                User                                             resourceGroupName
```

This command creates a new layer 3 (L3) network.
