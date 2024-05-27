### Example 1: {{ Add title here }}
```powershell
Update-AzSpringApiPortal -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default -GatewayId $gatewayObj.Id -Public:$true -SkuName "E0" -SkuCapacity 2 -SkuTier "Enterprise"
```

```output
GatewayId                    : {}
HttpsOnly                    : False
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apiPortals/default
Instance                     : {{
                                 "name": "asc-api-portal-default-c9c6dc6cf-6tbln",
                                 "status": "Running"
                               }, {
                                 "name": "asc-api-portal-default-c9c6dc6cf-d6rpg",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
Public                       : True
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestMemory        : 1Gi
SkuCapacity                  : 2
SkuName                      : E0
SkuTier                      : Enterprise
SourceUrl                    :
SsoPropertyClientId          :
SsoPropertyClientSecret      :
SsoPropertyIssuerUri         :
SsoPropertyScope             :
SystemDataCreatedAt          : 2023-12-15 上午 02:47:55
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-01-04 上午 09:02:21
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apiPortals
Url                          : azps-spring-01-apiportal-7fc53.svc.azuremicroservices.io
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

