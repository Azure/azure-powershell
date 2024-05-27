### Example 1: Create the default Spring Cloud Gateway or Create the existing Spring Cloud Gateway.
```powershell
New-AzSpringCloudGateway -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default -Public:$true -ResourceRequestsCpu 1 -ResourceRequestsMemory 2Gi -SkuName "E0" -SkuCapacity 2 -SkuTier "Enterprise"
```

```output
ApiMetadataPropertyDescription           :
ApiMetadataPropertyDocumentation         :
ApiMetadataPropertyServerUrl             :
ApiMetadataPropertyTitle                 :
ApiMetadataPropertyVersion               :
Apm                                      :
ClientAuthCertificate                    :
ClientAuthCertificateVerification        : Disabled
CorPropertyAllowCredentials              :
CorPropertyAllowedHeader                 :
CorPropertyAllowedMethod                 :
CorPropertyAllowedOrigin                 :
CorPropertyAllowedOriginPattern          :
CorPropertyExposedHeader                 :
CorPropertyMaxAge                        :
EnvironmentVariableProperty              : {
                                           }
EnvironmentVariableSecret                : {
                                           }
HttpsOnly                                : False
Id                                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default
Instance                                 : {{
                                             "name": "asc-scg-default-0",
                                             "status": "Running"
                                           }, {
                                             "name": "asc-scg-default-1",
                                             "status": "Running"
                                           }}
Name                                     : default
OperatorPropertiesResourceRequestsCpu    : 1
OperatorPropertiesResourceRequestsMemory : 2Gi
OperatorPropertyInstance                 : {{
                                             "name": "scg-operator-6b755d7686-h8hkw",
                                             "status": "Running"
                                           }}
ProvisioningState                        : Succeeded
Public                                   : True
ResourceGroupName                        : azps_test_group_spring
ResourceRequestInstanceCount             : 1
ResourceRequestsCpu                      : 1
ResourceRequestsMemory                   : 2Gi
SkuCapacity                              : 2
SkuName                                  : E0
SkuTier                                  : Enterprise
SsoPropertyClientId                      :
SsoPropertyClientSecret                  :
SsoPropertyIssuerUri                     :
SsoPropertyScope                         :
SystemDataCreatedAt                      : 2024-04-25 上午 06:47:20
SystemDataCreatedBy                      : v-jinpel@microsoft.com
SystemDataCreatedByType                  : User
SystemDataLastModifiedAt                 : 2024-04-25 上午 06:47:20
SystemDataLastModifiedBy                 : v-jinpel@microsoft.com
SystemDataLastModifiedByType             : User
Type                                     : Microsoft.AppPlatform/Spring/gateways
Url                                      : azps-spring-01-gateway-17d75.svc.azuremicroservices.io
```

Create the default Spring Cloud Gateway or update the existing Spring Cloud Gateway.