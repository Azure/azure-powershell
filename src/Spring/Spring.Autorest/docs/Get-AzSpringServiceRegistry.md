---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringserviceregistry
schema: 2.0.0
---

# Get-AzSpringServiceRegistry

## SYNOPSIS
Get the Service Registry and its properties.

## SYNTAX

### Get (Default)
```
Get-AzSpringServiceRegistry -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringServiceRegistry -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringServiceRegistry -SpringInputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzSpringServiceRegistry -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the Service Registry and its properties.

## EXAMPLES

### Example 1: Get the Service Registry and its properties.
```powershell
Get-AzSpringServiceRegistry -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/serviceRegistries/default
Instance                     : {{
                                 "name": "eureka-azps-spring-01-default-727d1-0",
                                 "status": "Running"
                               }, {
                                 "name": "eureka-azps-spring-01-default-727d1-1",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestInstanceCount : 2
ResourceRequestMemory        : 1Gi
SystemDataCreatedAt          : 2023-12-19 上午 09:42:49
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 09:42:49
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/serviceRegistries
```

Get the Service Registry and its properties.

### Example 2: Get the Service Registry and its properties.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringServiceRegistry -SpringInputObject $serviceObj
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/serviceRegistries/default
Instance                     : {{
                                 "name": "eureka-azps-spring-01-default-727d1-0",
                                 "status": "Running"
                               }, {
                                 "name": "eureka-azps-spring-01-default-727d1-1",
                                 "status": "Running"
                               }}
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
ResourceRequestCpu           : 500m
ResourceRequestInstanceCount : 2
ResourceRequestMemory        : 1Gi
SystemDataCreatedAt          : 2023-12-19 上午 09:42:49
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 09:42:49
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/serviceRegistries
```

Get the Service Registry and its properties.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IServiceRegistryResource

## NOTES

## RELATED LINKS

