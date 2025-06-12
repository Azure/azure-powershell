### Example 1: List DigitalTwinsInstances resource.
```powershell
Get-AzDigitalTwinsInstance
```

```output
Name                         Location ResourceGroupName
----                         -------- -----------------
azps-digitaltwins-instance   eastus   azps_test_group
azps-digitaltwins-instance-2 eastus   azps_test_group
```

List DigitalTwinsInstances resource.

### Example 2: Get DigitalTwinsInstances resource by ResourceGroup.
```powershell
Get-AzDigitalTwinsInstance -ResourceGroupName azps_test_group
```

```output
Name                         Location ResourceGroupName
----                         -------- -----------------
azps-digitaltwins-instance   eastus   azps_test_group
azps-digitaltwins-instance-2 eastus   azps_test_group
```

Get DigitalTwinsInstances resource by ResourceGroup.

### Example 3: Get DigitalTwinsInstances resource by Instance Name.
```powershell
Get-AzDigitalTwinsInstance -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance
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

Get DigitalTwinsInstances resource by Instance Name.