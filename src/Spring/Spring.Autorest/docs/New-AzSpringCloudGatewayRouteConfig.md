---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/new-azspringcloudgatewayrouteconfig
schema: 2.0.0
---

# New-AzSpringCloudGatewayRouteConfig

## SYNOPSIS
Create the default Spring Cloud Gateway route configs or Create the existing Spring Cloud Gateway route configs.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSpringCloudGatewayRouteConfig -GatewayName <String> -ResourceGroupName <String>
 -RouteConfigName <String> -ServiceName <String> [-SubscriptionId <String>] [-AppResourceId <String>]
 [-Filter <String[]>] [-OpenApiUri <String>] [-Predicate <String[]>] [-Protocol <String>]
 [-Route <IGatewayApiRoute[]>] [-SsoEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzSpringCloudGatewayRouteConfig -InputObject <ISpringAppsIdentity> [-AppResourceId <String>]
 [-Filter <String[]>] [-OpenApiUri <String>] [-Predicate <String[]>] [-Protocol <String>]
 [-Route <IGatewayApiRoute[]>] [-SsoEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityGatewayExpanded
```
New-AzSpringCloudGatewayRouteConfig -GatewayInputObject <ISpringAppsIdentity> -RouteConfigName <String>
 [-AppResourceId <String>] [-Filter <String[]>] [-OpenApiUri <String>] [-Predicate <String[]>]
 [-Protocol <String>] [-Route <IGatewayApiRoute[]>] [-SsoEnabled] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentitySpringExpanded
```
New-AzSpringCloudGatewayRouteConfig -GatewayName <String> -RouteConfigName <String>
 -SpringInputObject <ISpringAppsIdentity> [-AppResourceId <String>] [-Filter <String[]>]
 [-OpenApiUri <String>] [-Predicate <String[]>] [-Protocol <String>] [-Route <IGatewayApiRoute[]>]
 [-SsoEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzSpringCloudGatewayRouteConfig -GatewayName <String> -ResourceGroupName <String>
 -RouteConfigName <String> -ServiceName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzSpringCloudGatewayRouteConfig -GatewayName <String> -ResourceGroupName <String>
 -RouteConfigName <String> -ServiceName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create the default Spring Cloud Gateway route configs or Create the existing Spring Cloud Gateway route configs.

## EXAMPLES

### Example 1: Create the default Spring Cloud Gateway route configs or Create the existing Spring Cloud Gateway route configs.
```powershell
$appObj = Get-AzSpringApp -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name tools
$routeObj = New-AzSpringCloudGatewayApiRouteObject -Title "myApp route config" -SsoEnabled $true -Filter "StripPrefix=2","RateLimit=1,1s" -Predicate "Path=/api5/customer/**"
New-AzSpringCloudGatewayRouteConfig -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -GatewayName default -RouteConfigName azps-routeconfig -appResourceId $appObj.Id -OpenApiUri "https://raw.githubusercontent.com/OAI/OpenAPI-Specification/main/examples/v3.0/petstore.json" -Protocol HTTPS -Route $routeObj
```

```output
AppResourceId                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apps/tools
Filter                       :
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default/routeConfigs/azp
                               s-routeconfig
Name                         : azps-routeconfig
OpenApiUri                   : https://raw.githubusercontent.com/OAI/OpenAPI-Specification/main/examples/v3.0/petstore.json
Predicate                    :
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
SsoEnabled                   :
SystemDataCreatedAt          : 2024-04-26 上午 07:54:57
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-26 上午 07:54:57
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/gateways/routeConfigs
```

Create the default Spring Cloud Gateway route configs or Create the existing Spring Cloud Gateway route configs.

## PARAMETERS

### -AppResourceId
The resource Id of the Azure Spring Apps app, required unless route defines `uri`.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityGatewayExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Filter
To modify the request before sending it to the target endpoint, or the received response in app level.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityGatewayExpanded, CreateViaIdentitySpringExpanded
Aliases:

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
Parameter Sets: CreateViaIdentityGatewayExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OpenApiUri
The URI of OpenAPI specification.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityGatewayExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Predicate
A number of conditions to evaluate a route for each request in app level.
Each predicate may be evaluated against request headers and parameter values.
All of the predicates associated with a route must evaluate to true for the route to be matched to the request.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityGatewayExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
Protocol of routed Azure Spring Apps applications.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityGatewayExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Route
Array of API routes, each route contains properties such as `title`, `uri`, `ssoEnabled`, `predicates`, `filters`.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IGatewayApiRoute[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityGatewayExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteConfigName
The name of the Spring Cloud Gateway route config.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityGatewayExpanded, CreateViaIdentitySpringExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateViaIdentitySpringExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SsoEnabled
Enable Single Sign-On in app level.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityGatewayExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
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

