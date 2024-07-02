---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringcloudgateway
schema: 2.0.0
---

# Get-AzSpringCloudGateway

## SYNOPSIS
Get the Spring Cloud Gateway and its properties.

## SYNTAX

### List (Default)
```
Get-AzSpringCloudGateway -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringCloudGateway -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringCloudGateway -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringCloudGateway -Name <String> -SpringInputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the Spring Cloud Gateway and its properties.

## EXAMPLES

### Example 1: Get the Spring Cloud Gateway and its properties.
```powershell
Get-AzSpringCloudGateway -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
ApiMetadataPropertyDescription           :
ApiMetadataPropertyDocumentation         :
ApiMetadataPropertyServerUrl             :
ApiMetadataPropertyTitle                 :
ApiMetadataPropertyVersion               :
CorPropertyAllowCredentials              :
CorPropertyAllowedHeader                 :
CorPropertyAllowedMethod                 :
CorPropertyAllowedOrigin                 :
CorPropertyExposedHeader                 :
CorPropertyMaxAge                        :
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
                                             "name": "scg-operator-88b96b8dd-f9rhf",
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
SystemDataCreatedAt                      : 2023-12-15 上午 02:29:48
SystemDataCreatedBy                      : v-jinpel@microsoft.com
SystemDataCreatedByType                  : User
SystemDataLastModifiedAt                 : 2023-12-15 上午 02:29:48
SystemDataLastModifiedBy                 : v-jinpel@microsoft.com
SystemDataLastModifiedByType             : User
Type                                     : Microsoft.AppPlatform/Spring/gateways
Url                                      : azps-spring-01-gateway-17d75.svc.azuremicroservices.io
```

Get the Spring Cloud Gateway and its properties.

### Example 2: Get the Spring Cloud Gateway and its properties.
```powershell
Get-AzSpringCloudGateway -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default
```

```output
ApiMetadataPropertyDescription           :
ApiMetadataPropertyDocumentation         :
ApiMetadataPropertyServerUrl             :
ApiMetadataPropertyTitle                 :
ApiMetadataPropertyVersion               :
CorPropertyAllowCredentials              :
CorPropertyAllowedHeader                 :
CorPropertyAllowedMethod                 :
CorPropertyAllowedOrigin                 :
CorPropertyExposedHeader                 :
CorPropertyMaxAge                        :
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
                                             "name": "scg-operator-88b96b8dd-f9rhf",
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
SystemDataCreatedAt                      : 2023-12-15 上午 02:29:48
SystemDataCreatedBy                      : v-jinpel@microsoft.com
SystemDataCreatedByType                  : User
SystemDataLastModifiedAt                 : 2023-12-15 上午 02:29:48
SystemDataLastModifiedBy                 : v-jinpel@microsoft.com
SystemDataLastModifiedByType             : User
Type                                     : Microsoft.AppPlatform/Spring/gateways
Url                                      : azps-spring-01-gateway-17d75.svc.azuremicroservices.io
```

Get the Spring Cloud Gateway and its properties.

### Example 3: Get the Spring Cloud Gateway and its properties.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringCloudGateway -SpringInputObject $serviceObj -Name default
```

```output
ApiMetadataPropertyDescription           :
ApiMetadataPropertyDocumentation         :
ApiMetadataPropertyServerUrl             :
ApiMetadataPropertyTitle                 :
ApiMetadataPropertyVersion               :
CorPropertyAllowCredentials              :
CorPropertyAllowedHeader                 :
CorPropertyAllowedMethod                 :
CorPropertyAllowedOrigin                 :
CorPropertyExposedHeader                 :
CorPropertyMaxAge                        :
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
                                             "name": "scg-operator-88b96b8dd-f9rhf",
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
SystemDataCreatedAt                      : 2023-12-15 上午 02:29:48
SystemDataCreatedBy                      : v-jinpel@microsoft.com
SystemDataCreatedByType                  : User
SystemDataLastModifiedAt                 : 2023-12-15 上午 02:29:48
SystemDataLastModifiedBy                 : v-jinpel@microsoft.com
SystemDataLastModifiedByType             : User
Type                                     : Microsoft.AppPlatform/Spring/gateways
Url                                      : azps-spring-01-gateway-17d75.svc.azuremicroservices.io
```

Get the Spring Cloud Gateway and its properties.

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

### -Name
The name of Spring Cloud Gateway.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySpring
Aliases: GatewayName

Required: True
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IGatewayResource

## NOTES

## RELATED LINKS

