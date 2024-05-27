---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringapiportal
schema: 2.0.0
---

# Get-AzSpringApiPortal

## SYNOPSIS
Get the API portal and its properties.

## SYNTAX

### List (Default)
```
Get-AzSpringApiPortal -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringApiPortal -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringApiPortal -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringApiPortal -Name <String> -SpringInputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the API portal and its properties.

## EXAMPLES

### Example 1: Get the API portal and its properties.
```powershell
Get-AzSpringApiPortal -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
GatewayId                    : {/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default}
HttpsOnly                    : False
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apiPortals/default
Instance                     : {{
                                 "name": "asc-api-portal-default-5d6bdf7d6d-bpf4d",
                                 "status": "Running"
                               }, {
                                 "name": "asc-api-portal-default-5d6bdf7d6d-gfhh2",
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
SystemDataLastModifiedAt     : 2023-12-15 上午 02:47:55
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apiPortals
Url                          : azps-spring-01-apiportal-7fc53.svc.azuremicroservices.io
```

Get the API portal and its properties.

### Example 2: Get the API portal and its properties.
```powershell
Get-AzSpringApiPortal -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default
```

```output
GatewayId                    : {/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default}
HttpsOnly                    : False
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apiPortals/default
Instance                     : {{
                                 "name": "asc-api-portal-default-5d6bdf7d6d-bpf4d",
                                 "status": "Running"
                               }, {
                                 "name": "asc-api-portal-default-5d6bdf7d6d-gfhh2",
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
SystemDataLastModifiedAt     : 2023-12-15 上午 02:47:55
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apiPortals
Url                          : azps-spring-01-apiportal-7fc53.svc.azuremicroservices.io
```

Get the API portal and its properties.

### Example 3: Get the API portal and its properties.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringApiPortal -SpringInputObject $serviceObj -Name default
```

```output
GatewayId                    : {/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/gateways/default}
HttpsOnly                    : False
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/apiPortals/default
Instance                     : {{
                                 "name": "asc-api-portal-default-5d6bdf7d6d-bpf4d",
                                 "status": "Running"
                               }, {
                                 "name": "asc-api-portal-default-5d6bdf7d6d-gfhh2",
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
SystemDataLastModifiedAt     : 2023-12-15 上午 02:47:55
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apiPortals
Url                          : azps-spring-01-apiportal-7fc53.svc.azuremicroservices.io
```

Get the API portal and its properties.

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
The name of API portal.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySpring
Aliases: ApiPortalName

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IApiPortalResource

## NOTES

## RELATED LINKS

