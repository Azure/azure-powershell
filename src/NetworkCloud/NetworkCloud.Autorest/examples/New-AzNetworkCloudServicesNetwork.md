### Example 1: Create cloud services network
```powershell
$tags = @{
    Tag1 = 'tag1'
}
$endpointEgressList = @{}

New-AzNetworkCloudServicesNetwork -CloudServicesNetworkName cloudNetworkServicesName -ResourceGroupName resourceGroupName -ExtendedLocationName "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ExtendedLocation/customLocations/customLocationName" -ExtendedLocationType "CustomLocation" -Location eastus -AdditionalEgressEndpoint $endpointEgressList -EnableDefaultEgressEndpoint false -Tag $tags -SubscriptionId subscriptionId
```

```output
Location Name                     SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
-------- ----                     ------------------- -------------------    ----------------------- ------------------------ ------------------------
eastus   cloudNetworkServicesName 06/30/2023 13:32:28 User1                  User                    06/30/2023 13:32:39      resourceGroupName
```

This command creates a cloud services network.
