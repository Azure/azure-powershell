### Example 1: Create a new App or update an exiting App.
```powershell
New-AzSpringApp -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name tools -Location eastus -TemporaryDiskMountPath "/mytemporarydisk" -TemporaryDiskSizeInGb 2 -PersistentDiskSizeInGb 0 -PersistentDiskMountPath "/mypersistentdisk"
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

Create a new App or update an exiting App.

### Example 2: Create a new App or update an exiting App.
```powershell
New-AzSpringApp -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02 -Name tools-02
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
Fqdn                              : azps-spring-02.azuremicroservices.io
HttpsOnly                         : False
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/apps/tools-02
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
Name                              : tools-02
PersistentDiskMountPath           : /persistent
PersistentDiskSizeInGb            : 0
PersistentDiskUsedInGb            :
ProvisioningState                 : Succeeded
Public                            : False
ResourceGroupName                 : azps_test_group_spring
SystemDataCreatedAt               : 2023-12-13 上午 09:27:47
SystemDataCreatedBy               : v-jinpel@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 2023-12-13 上午 09:27:47
SystemDataLastModifiedBy          : v-jinpel@microsoft.com
SystemDataLastModifiedByType      : User
TemporaryDiskMountPath            : /tmp
TemporaryDiskSizeInGb             : 5
Type                              : Microsoft.AppPlatform/Spring/apps
Url                               :
VnetAddonPublicEndpoint           :
VnetAddonPublicEndpointUrl        :
```

Create a new App or update an exiting App.