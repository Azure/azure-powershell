### Example 1: List App and its properties.
```powershell
Get-AzSpringApp -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Location Name    ProvisioningState ResourceGroupName
-------- ----    ----------------- -----------------
eastus   tools01 Succeeded         azps_test_group_spring
eastus   tools   Succeeded         azps_test_group_spring
```

List App and its properties.

### Example 2: Get an App and its properties.
```powershell
Get-AzSpringApp -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name tools
```

```output
AddonConfig                       : {
                                      "applicationConfigurationService": {
                                      },
                                      "serviceRegistry": {
                                      }
                                    }
ClientAuthCertificate             :
CustomPersistentDisk              :
EnableEndToEndTl                  : False
Fqdn                              : azps-spring-01.azuremicroservices.io
HttpsOnly                         : False
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apps/tools
IdentityPrincipalId               :
IdentityTenantId                  :
IdentityType                      :
IdentityUserAssignedIdentity      : {
                                    }
IngressSettingBackendProtocol     : Default
IngressSettingReadTimeoutInSecond : 300
IngressSettingSendTimeoutInSecond : 60
IngressSettingSessionAffinity     : None
IngressSettingSessionCookieMaxAge : 0
LoadedCertificate                 :
Location                          : eastus
Name                              : tools
PersistentDiskMountPath           : /mypersistentdisk
PersistentDiskSizeInGb            : 0
PersistentDiskUsedInGb            :
ProvisioningState                 : Succeeded
Public                            : False
ResourceGroupName                 : azps_test_group_spring
SystemDataCreatedAt               : 2023-12-13 上午 09:12:11
SystemDataCreatedBy               : v-jinpel@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 2023-12-13 上午 09:12:11
SystemDataLastModifiedBy          : v-jinpel@microsoft.com
SystemDataLastModifiedByType      : User
TemporaryDiskMountPath            : /mytemporarydisk
TemporaryDiskSizeInGb             : 2
Type                              : Microsoft.AppPlatform/Spring/apps
Url                               :
VnetAddonPublicEndpoint           :
VnetAddonPublicEndpointUrl        :
```

Get an App and its properties.

### Example 3: Get an App and its properties.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringApp -SpringInputObject $serviceObj -Name tools
```

```output
AddonConfig                       : {
                                      "applicationConfigurationService": {
                                      },
                                      "serviceRegistry": {
                                      }
                                    }
ClientAuthCertificate             :
CustomPersistentDisk              :
EnableEndToEndTl                  : False
Fqdn                              : azps-spring-01.azuremicroservices.io
HttpsOnly                         : False
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apps/tools
IdentityPrincipalId               :
IdentityTenantId                  :
IdentityType                      :
IdentityUserAssignedIdentity      : {
                                    }
IngressSettingBackendProtocol     : Default
IngressSettingReadTimeoutInSecond : 300
IngressSettingSendTimeoutInSecond : 60
IngressSettingSessionAffinity     : None
IngressSettingSessionCookieMaxAge : 0
LoadedCertificate                 :
Location                          : eastus
Name                              : tools
PersistentDiskMountPath           : /mypersistentdisk
PersistentDiskSizeInGb            : 0
PersistentDiskUsedInGb            :
ProvisioningState                 : Succeeded
Public                            : False
ResourceGroupName                 : azps_test_group_spring
SystemDataCreatedAt               : 2023-12-13 上午 09:12:11
SystemDataCreatedBy               : v-jinpel@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 2023-12-13 上午 09:12:11
SystemDataLastModifiedBy          : v-jinpel@microsoft.com
SystemDataLastModifiedByType      : User
TemporaryDiskMountPath            : /mytemporarydisk
TemporaryDiskSizeInGb             : 2
Type                              : Microsoft.AppPlatform/Spring/apps
Url                               :
VnetAddonPublicEndpoint           :
VnetAddonPublicEndpointUrl        :
```

Get an App and its properties.