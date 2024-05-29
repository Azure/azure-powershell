---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringdevtoolportal
schema: 2.0.0
---

# Get-AzSpringDevToolPortal

## SYNOPSIS
Get the Application Live  and its properties.

## SYNTAX

### List (Default)
```
Get-AzSpringDevToolPortal -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringDevToolPortal -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringDevToolPortal -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringDevToolPortal -Name <String> -SpringInputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the Application Live  and its properties.

## EXAMPLES

### Example 1: Get the Application Live  and its properties.
```powershell
Get-AzSpringDevToolPortal -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
ApplicationAcceleratorRoute  : create
ApplicationAcceleratorState  : Enabled
ApplicationLiveViewRoute     : app-live-view
ApplicationLiveViewState     : Enabled
Component                    : {{
                                 "resourceRequests": {
                                   "cpu": "500m",
                                   "memory": "1Gi",
                                   "instanceCount": 2
                                 },
                                 "name": "server",
                                 "instances": [
                                   {
                                     "name": "server-d5bfc75b-9jv75",
                                     "status": "Running"
                                   },
                                   {
                                     "name": "server-d5bfc75b-wdvpk",
                                     "status": "Running"
                                   }
                                 ]
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/devToolPortals/default
Name                         : default
ProvisioningState            : Succeeded
Public                       : True
ResourceGroupName            : azps_test_group_spring
SsoPropertyClientId          :
SsoPropertyClientSecret      :
SsoPropertyMetadataUrl       :
SsoPropertyScope             :
SystemDataCreatedAt          : 2024-05-24 上午 06:17:55
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-24 上午 06:17:55
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/devToolPortals
Url                          : azps-spring-01-devtoolportal-a638a.svc.azuremicroservices.io
```

Get the Application Live  and its properties.

### Example 2: Get the Application Live  and its properties.
```powershell
Get-AzSpringDevToolPortal -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
ApplicationAcceleratorRoute  : create
ApplicationAcceleratorState  : Enabled
ApplicationLiveViewRoute     : app-live-view
ApplicationLiveViewState     : Enabled
Component                    : {{
                                 "resourceRequests": {
                                   "cpu": "500m",
                                   "memory": "1Gi",
                                   "instanceCount": 2
                                 },
                                 "name": "server",
                                 "instances": [
                                   {
                                     "name": "server-d5bfc75b-9jv75",
                                     "status": "Running"
                                   },
                                   {
                                     "name": "server-d5bfc75b-wdvpk",
                                     "status": "Running"
                                   }
                                 ]
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/devToolPortals/default
Name                         : default
ProvisioningState            : Succeeded
Public                       : True
ResourceGroupName            : azps_test_group_spring
SsoPropertyClientId          :
SsoPropertyClientSecret      :
SsoPropertyMetadataUrl       :
SsoPropertyScope             :
SystemDataCreatedAt          : 2024-05-24 上午 06:17:55
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-24 上午 06:17:55
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/devToolPortals
Url                          : azps-spring-01-devtoolportal-a638a.svc.azuremicroservices.io
```

Get the Application Live  and its properties.

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
The name of Dev Tool Portal.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySpring
Aliases: DevToolPortalName

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IDevToolPortalResource

## NOTES

## RELATED LINKS

