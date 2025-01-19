### Example 1: Create a new Service or Create an exiting Service.
```powershell
New-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01 -Location eastus -SkuTier "Enterprise" -SkuName "E0"
```

```output
Fqdn                                             : azps-spring-01.azuremicroservices.io
Id                                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01
IngressConfigReadTimeoutInSecond                 :
Location                                         : eastus
MarketplaceResourcePlan                          : asa-ent-hr-mtr
MarketplaceResourceProduct                       : azure-spring-cloud-vmware-tanzu-2
MarketplaceResourcePublisher                     : vmware-inc
Name                                             : azps-spring-01
NetworkProfileAppNetworkResourceGroup            :
NetworkProfileAppSubnetId                        :
NetworkProfileOutboundType                       : loadBalancer
NetworkProfileRequiredTraffic                    :
NetworkProfileServiceCidr                        :
NetworkProfileServiceRuntimeNetworkResourceGroup :
NetworkProfileServiceRuntimeSubnetId             :
OutboundIPPublicIP                               : {20.253.92.83, 20.253.92.97}
PowerState                                       : Running
ProvisioningState                                : Succeeded
ResourceGroupName                                : azps_test_group_spring
ServiceId                                        : 0871555f28044a46bdc0f31682b862ef
SkuCapacity                                      :
SkuName                                          : E0
SkuTier                                          : Enterprise
SystemDataCreatedAt                              : 2024-04-24 上午 05:49:39
SystemDataCreatedBy                              : v-jinpel@microsoft.com
SystemDataCreatedByType                          : User
SystemDataLastModifiedAt                         : 2024-04-24 上午 05:49:39
SystemDataLastModifiedBy                         : v-jinpel@microsoft.com
SystemDataLastModifiedByType                     : User
Tag                                              : {
                                                   }
Type                                             : Microsoft.AppPlatform/Spring
Version                                          : 3
VnetAddonDataPlanePublicEndpoint                 :
VnetAddonLogStreamPublicEndpoint                 :
ZoneRedundant                                    : False
```

Create a new Service or Create an exiting Service.

### Example 2: Create a new Service or Create an exiting Service.
```powershell
New-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-02 -Location eastus
```

```output
Fqdn                                             : azps-spring-02.azuremicroservices.io
Id                                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02
IngressConfigReadTimeoutInSecond                 :
Location                                         : eastus
Name                                             : azps-spring-02
NetworkProfileAppNetworkResourceGroup            :
NetworkProfileAppSubnetId                        :
NetworkProfileOutboundType                       : loadBalancer
NetworkProfileRequiredTraffic                    :
NetworkProfileServiceCidr                        :
NetworkProfileServiceRuntimeNetworkResourceGroup :
NetworkProfileServiceRuntimeSubnetId             :
OutboundIPPublicIP                               : {20.237.102.222, 20.237.103.29}
PowerState                                       : Running
ProvisioningState                                : Succeeded
ResourceGroupName                                : azps_test_group_spring
ServiceId                                        : 59fd2d8c82144a129a682a631d39a4f8
SkuCapacity                                      :
SkuName                                          : S0
SkuTier                                          : Standard
SystemDataCreatedAt                              : 2023-12-13 上午 08:41:49
SystemDataCreatedBy                              : v-jinpel@microsoft.com
SystemDataCreatedByType                          : User
SystemDataLastModifiedAt                         : 2023-12-13 上午 08:41:49
SystemDataLastModifiedBy                         : v-jinpel@microsoft.com
SystemDataLastModifiedByType                     : User
Tag                                              : {
                                                   }
Type                                             : Microsoft.AppPlatform/Spring
Version                                          : 3
VnetAddonLogStreamPublicEndpoint                 :
ZoneRedundant                                    : False
```

Create a new Service or Create an exiting Service.