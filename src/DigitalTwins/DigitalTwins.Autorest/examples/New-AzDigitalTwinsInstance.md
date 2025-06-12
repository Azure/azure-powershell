### Example 1: Create the metadata of a DigitalTwinsInstance.
```powershell
New-AzDigitalTwinsInstance -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -Location eastus -EnableSystemAssignedIdentity:$true -PublicNetworkAccess 'Enabled'
```

```output
CreatedTime                  : 2025-06-06 09:44:17 AM
HostName                     : azps-digitaltwins-instance.api.eus.digitaltwins.azure.net
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.DigitalTwins/digitalTwinsInstances/azps-digitaltwins-instance
IdentityPrincipalId          : 6463ae74-a748-4f95-acf9-7d76e1d343b3
IdentityTenantId             : 213e87ed-8e08-4eb4-a63c-c073058f7b00
IdentityType                 : SystemAssigned
LastUpdatedTime              : 2025-06-06 09:45:03 AM
Location                     : eastus
Name                         : azps-digitaltwins-instance
PrivateEndpointConnection    : {}
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : azps_test_group
SystemDataCreatedAt          : 2025-06-06 09:44:15 AM
SystemDataCreatedBy          : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2025-06-06 09:44:15 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances
```

Create the metadata of a DigitalTwinsInstance.
The usual pattern to modify a property is to retrieve the DigitalTwinsInstance and security metadata, and then combine them with the modified values in a new body to create the DigitalTwinsInstance.