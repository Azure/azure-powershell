### Example 1: Set existing Deployment under the app as active
```powershell
Update-AzSpringAppActiveDeployment -Name tools -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02 -DeploymentName green
```

```output
AddonConfig                       : {
                                      "applicationConfigurationService": {
                                      },
                                      "configServer": {
                                      },
                                      "serviceRegistry": {
                                      }
                                    }
ClientAuthCertificate             :
CustomPersistentDisk              :
EnableEndToEndTl                  : False
Fqdn                              : azps-spring-02.azuremicroservices.io
HttpsOnly                         : False
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/apps/tools
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
SystemDataCreatedAt               : 2024-05-27 上午 03:29:23
SystemDataCreatedBy               : v-jinpel@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 2024-05-28 下午 12:12:05
SystemDataLastModifiedBy          : v-jinpel@microsoft.com
SystemDataLastModifiedByType      : User
TemporaryDiskMountPath            : /mytemporarydisk
TemporaryDiskSizeInGb             : 2
Type                              : Microsoft.AppPlatform/Spring/apps
Url                               :
VnetAddonPublicEndpoint           :
VnetAddonPublicEndpointUrl        :
```

Set existing Deployment under the app as active