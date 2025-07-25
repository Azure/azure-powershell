### Example 1: Update metadata of DigitalTwinsInstance.
```powershell
Update-AzDigitalTwinsInstance -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -Tag @{"abc"="123"}
```

```output
CreatedTime                  : 2025-06-06 09:44:17 AM
HostName                     : azps-digitaltwins-instance.api.eus.digitaltwins.azure.net
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.DigitalTwins/digitalTwinsInstances/azps-digitaltwins-instance
IdentityPrincipalId          : 6463ae74-a748-4f95-acf9-7d76e1d343b3
IdentityTenantId             : 213e87ed-8e08-4eb4-a63c-c073058f7b00
IdentityType                 : SystemAssigned
LastUpdatedTime              : 2025-06-06 11:27:24 AM
Location                     : eastus
Name                         : azps-digitaltwins-instance
PrivateEndpointConnection    : {}
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : azps_test_group
SystemDataCreatedAt          : 2025-06-06 09:44:15 AM
SystemDataCreatedBy          : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2025-06-06 11:27:22 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "abc": "123"
                               }
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances
```

Update metadata of DigitalTwinsInstance.

### Example 2: Update the AzDigitalTwinsInstance by another AzDigitalTwinsInstance.
```powershell
Get-AzDigitalTwinsInstance -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance | Update-AzDigitalTwinsInstance -Tag @{"1234"="abcd"}
```

```output
CreatedTime                  : 2025-06-06 09:44:17 AM
HostName                     : azps-digitaltwins-instance.api.eus.digitaltwins.azure.net
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.DigitalTwins/digitalTwinsInstances/azps-digitaltwins-instance
IdentityPrincipalId          : 6463ae74-a748-4f95-acf9-7d76e1d343b3
IdentityTenantId             : 213e87ed-8e08-4eb4-a63c-c073058f7b00
IdentityType                 : SystemAssigned
LastUpdatedTime              : 2025-06-06 11:29:03 AM
Location                     : eastus
Name                         : azps-digitaltwins-instance
PrivateEndpointConnection    : {}
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : azps_test_group
SystemDataCreatedAt          : 2025-06-06 09:44:15 AM
SystemDataCreatedBy          : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2025-06-06 11:29:01 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "1234": "abcd"
                               }
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances
```

Update the AzDigitalTwinsInstance by another AzDigitalTwinsInstance.