### Example 1: List Service and its properties.
```powershell
Get-AzSpringService
```

```output
Location Name           ProvisioningState SkuName SkuTier    ResourceGroupName
-------- ----           ----------------- ------- -------    -----------------
eastus   azps-spring-01 Succeeded         E0      Enterprise azps_test_group_spring
eastus   azps-spring-02 Succeeded         S0      Standard   azps_test_group_spring
```

List Service and its properties.

### Example 2: List Service and its properties.
```powershell
Get-AzSpringService -ResourceGroupName azps_test_group_spring
```

```output
Location Name           ProvisioningState SkuName SkuTier    ResourceGroupName
-------- ----           ----------------- ------- -------    -----------------
eastus   azps-spring-01 Succeeded         E0      Enterprise azps_test_group_spring
eastus   azps-spring-02 Succeeded         S0      Standard   azps_test_group_spring
```

List Service and its properties.

### Example 3: Get a Service and its properties.
```powershell
Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
```

```output
Fqdn                                             : azps-spring-01.azuremicroservices.io
Id                                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01
IngressConfigReadTimeoutInSecond                 :
Location                                         : eastus
Name                                             : azps-spring-01
NetworkProfileAppNetworkResourceGroup            :
NetworkProfileAppSubnetId                        :
NetworkProfileOutboundType                       : loadBalancer
NetworkProfileRequiredTraffic                    :
NetworkProfileServiceCidr                        :
NetworkProfileServiceRuntimeNetworkResourceGroup :
NetworkProfileServiceRuntimeSubnetId             :
OutboundIPPublicIP                               : {4.255.75.210, 4.255.75.214}
PowerState                                       : Running
ProvisioningState                                : Succeeded
ResourceGroupName                                : azps_test_group_spring
ServiceId                                        : 0c6aeadde5dd43cfa31ee4e078381260
SkuCapacity                                      :
SkuName                                          : E0
SkuTier                                          : Enterprise
SystemDataCreatedAt                              : 2023-12-13 上午 08:24:54
SystemDataCreatedBy                              : v-jinpel@microsoft.com
SystemDataCreatedByType                          : User
SystemDataLastModifiedAt                         : 2023-12-13 上午 08:24:54
SystemDataLastModifiedBy                         : v-jinpel@microsoft.com
SystemDataLastModifiedByType                     : User
Tag                                              : {
                                                   }
Type                                             : Microsoft.AppPlatform/Spring
Version                                          : 3
VnetAddonLogStreamPublicEndpoint                 :
ZoneRedundant                                    : False
```

Get a Service and its properties.