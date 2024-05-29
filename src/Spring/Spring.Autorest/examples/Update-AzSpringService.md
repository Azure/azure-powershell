### Example 1: Operation to Update an exiting Service.
```powershell
Update-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01 -Tag @{"abc"="123"}
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
OutboundIPPublicIP                               : {51.8.252.115, 51.8.252.177}
PowerState                                       : Running
ProvisioningState                                : Succeeded
ResourceGroupName                                : azps_test_group_spring
ServiceId                                        : a699f6701ad547338876ca019dc39898
SkuCapacity                                      :
SkuName                                          : E0
SkuTier                                          : Enterprise
SystemDataCreatedAt                              : 2024-05-24 上午 06:06:58
SystemDataCreatedBy                              : v-jinpel@microsoft.com
SystemDataCreatedByType                          : User
SystemDataLastModifiedAt                         : 2024-05-28 上午 09:50:25
SystemDataLastModifiedBy                         : v-jinpel@microsoft.com
SystemDataLastModifiedByType                     : User
Tag                                              : {
                                                     "abc": "123"
                                                   }
Type                                             : Microsoft.AppPlatform/Spring
Version                                          : 3
VnetAddonDataPlanePublicEndpoint                 :
VnetAddonLogStreamPublicEndpoint                 :
ZoneRedundant                                    : False
```

Operation to Update an exiting Service.