---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringconfigurationservice
schema: 2.0.0
---

# Get-AzSpringConfigurationService

## SYNOPSIS
Get the Application Configuration Service and its properties.

## SYNTAX

### Get (Default)
```
Get-AzSpringConfigurationService -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringConfigurationService -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringConfigurationService -SpringInputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzSpringConfigurationService -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the Application Configuration Service and its properties.

## EXAMPLES

### Example 1: Get the Application Configuration Service and its properties.
```powershell
Get-AzSpringConfigurationService -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
GitPropertyRepository        : {{
                                 "name": "ghatest",
                                 "patterns": [ "app/dev" ],
                                 "uri": "https://github.com/lijinpei2008/ghatest",
                                 "label": "master"
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/configurationServices/default
Instance                     : {{
                                 "name": "application-configuration-service-674f48b866-clsh5",
                                 "status": "Running"
                               }, {
                                 "name": "application-configuration-service-674f48b866-g8tgc",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestInstanceCount : 2
ResourceRequestMemory        : 1Gi
SystemDataCreatedAt          : 2023-12-19 上午 09:37:05
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 09:39:12
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/configurationServices
```

Get the Application Configuration Service and its properties.

### Example 2: Get the Application Configuration Service and its properties.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringConfigurationService -SpringInputObject $serviceObj
```

```output
GitPropertyRepository        : {{
                                 "name": "ghatest",
                                 "patterns": [ "app/dev" ],
                                 "uri": "https://github.com/lijinpei2008/ghatest",
                                 "label": "master"
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/configurationServices/default
Instance                     : {{
                                 "name": "application-configuration-service-674f48b866-clsh5",
                                 "status": "Running"
                               }, {
                                 "name": "application-configuration-service-674f48b866-g8tgc",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestInstanceCount : 2
ResourceRequestMemory        : 1Gi
SystemDataCreatedAt          : 2023-12-19 上午 09:37:05
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 09:39:12
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/configurationServices
```

Get the Application Configuration Service and its properties.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IConfigurationServiceResource

## NOTES

## RELATED LINKS

