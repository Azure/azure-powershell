---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringcloudgatewayrouteconfig
schema: 2.0.0
---

# Get-AzSpringCloudGatewayRouteConfig

## SYNOPSIS
Get the Spring Cloud Gateway route configs.

## SYNTAX

### List (Default)
```
Get-AzSpringCloudGatewayRouteConfig -GatewayName <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringCloudGatewayRouteConfig -GatewayName <String> -ResourceGroupName <String>
 -RouteConfigName <String> -ServiceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringCloudGatewayRouteConfig -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityGateway
```
Get-AzSpringCloudGatewayRouteConfig -GatewayInputObject <ISpringAppsIdentity> -RouteConfigName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringCloudGatewayRouteConfig -GatewayName <String> -RouteConfigName <String>
 -SpringInputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the Spring Cloud Gateway route configs.

## EXAMPLES

### Example 1: Get the Spring Cloud Gateway route configs.
```powershell
Get-AzSpringCloudGatewayRouteConfig -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -GatewayName default
```

```output
AppResourceId                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apps/tools
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default/routeConfigs/azp
                               s-routeconfig
Name                         : azps-routeconfig
OpenApiUri                   : https://raw.githubusercontent.com/OAI/OpenAPI-Specification/main/examples/v3.0/petstore.json
Protocol                     : HTTPS
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
Route                        : {{
                                 "title": "myApp route config",
                                 "ssoEnabled": true,
                                 "tokenRelay": false,
                                 "predicates": [ "Path=/api5/customer/**" ],
                                 "filters": [ "StripPrefix=2", "RateLimit=1,1s" ]
                               }}
SystemDataCreatedAt          : 2023-12-15 上午 02:32:39
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-15 上午 02:32:39
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/gateways/routeConfigs
```

Get the Spring Cloud Gateway route configs.

### Example 2: Get the Spring Cloud Gateway route configs.
```powershell
Get-AzSpringCloudGatewayRouteConfig -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -GatewayName default -RouteConfigName azps-routeconfig
```

```output
AppResourceId                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apps/tools
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default/routeConfigs/azp
                               s-routeconfig
Name                         : azps-routeconfig
OpenApiUri                   : https://raw.githubusercontent.com/OAI/OpenAPI-Specification/main/examples/v3.0/petstore.json
Protocol                     : HTTPS
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
Route                        : {{
                                 "title": "myApp route config",
                                 "ssoEnabled": true,
                                 "tokenRelay": false,
                                 "predicates": [ "Path=/api5/customer/**" ],
                                 "filters": [ "StripPrefix=2", "RateLimit=1,1s" ]
                               }}
SystemDataCreatedAt          : 2023-12-15 上午 02:32:39
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-15 上午 02:32:39
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/gateways/routeConfigs
```

Get the Spring Cloud Gateway route configs.

### Example 3: Get the Spring Cloud Gateway route configs.
```powershell
$gatewayObj = Get-AzSpringCloudGateway -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default
Get-AzSpringCloudGatewayRouteConfig -GatewayInputObject $gatewayObj -RouteConfigName azps-routeconfig
```

```output
AppResourceId                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apps/tools
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default/routeConfigs/azp
                               s-routeconfig
Name                         : azps-routeconfig
OpenApiUri                   : https://raw.githubusercontent.com/OAI/OpenAPI-Specification/main/examples/v3.0/petstore.json
Protocol                     : HTTPS
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
Route                        : {{
                                 "title": "myApp route config",
                                 "ssoEnabled": true,
                                 "tokenRelay": false,
                                 "predicates": [ "Path=/api5/customer/**" ],
                                 "filters": [ "StripPrefix=2", "RateLimit=1,1s" ]
                               }}
SystemDataCreatedAt          : 2023-12-15 上午 02:32:39
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-15 上午 02:32:39
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/gateways/routeConfigs
```

Get the Spring Cloud Gateway route configs.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GatewayInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentityGateway
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -GatewayName
The name of Spring Cloud Gateway.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySpring, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteConfigName
The name of the Spring Cloud Gateway route config.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityGateway, GetViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpringInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IGatewayRouteConfigResource

## NOTES

## RELATED LINKS

