---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringappdeployment
schema: 2.0.0
---

# Get-AzSpringAppDeployment

## SYNOPSIS
Get a Deployment and its properties.

## SYNTAX

### List1 (Default)
```
Get-AzSpringAppDeployment -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-Expand <String>] [-Version <List<String>>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringAppDeployment -AppName <String> -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringAppDeployment -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityApp
```
Get-AzSpringAppDeployment -AppInputObject <ISpringAppsIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringAppDeployment -AppName <String> -Name <String> -SpringInputObject <ISpringAppsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzSpringAppDeployment -AppName <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-Version <List<String>>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a Deployment and its properties.

## EXAMPLES

### Example 1: Get a Deployment and its properties.
```powershell
Get-AzSpringAppDeployment -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02
```

```output
Name   ResourceGroupName      ProvisioningState Active
----   -----------------      ----------------- ------
green1 azps_test_group_spring Succeeded         False
green  azps_test_group_spring Succeeded         True
```

Get a Deployment and its properties.

### Example 2: Get a Deployment and its properties.
```powershell
Get-AzSpringAppDeployment -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02 -AppName tools
```

```output
Name   ResourceGroupName      ProvisioningState Active
----   -----------------      ----------------- ------
green1 azps_test_group_spring Succeeded         False
green  azps_test_group_spring Succeeded         True
```

Get a Deployment and its properties.

### Example 3: Get a Deployment and its properties.
```powershell
Get-AzSpringAppDeployment -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02 -AppName tools -Name green
```

```output
Active                       : True
DeploymentSetting            : {
                                 "resourceRequests": {
                                   "cpu": "1",
                                   "memory": "1Gi"
                                 },
                                 "livenessProbe": {
                                   "probeAction": {
                                     "type": "TCPSocketAction"
                                   },
                                   "disableProbe": false,
                                   "initialDelaySeconds": 300,
                                   "periodSeconds": 10,
                                   "timeoutSeconds": 3,
                                   "failureThreshold": 3,
                                   "successThreshold": 1
                                 },
                                 "readinessProbe": {
                                   "probeAction": {
                                     "type": "TCPSocketAction"
                                   },
                                   "disableProbe": false,
                                   "initialDelaySeconds": 0,
                                   "periodSeconds": 5,
                                   "timeoutSeconds": 3,
                                   "failureThreshold": 3,
                                   "successThreshold": 1
                                 },
                                 "startupProbe": {
                                   "disableProbe": false
                                 },
                                 "terminationGracePeriodSeconds": 90
                               }
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/apps/tools/deployments/green
Instance                     : {{
                                 "name": "tools-green-5-6c5d99c955-sqwqj",
                                 "status": "Running",
                                 "discoveryStatus": "UP",
                                 "startTime": "2024-05-27T03:50:58Z"
                               }}
Name                         : green
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SkuCapacity                  : 1
SkuName                      : S0
SkuTier                      : Standard
Source                       : {
                                 "type": "Jar",
                                 "relativePath": "resources/f9d35d43770d39092a663e665e82ae1d84a9e0da3d0d10c407acada6a40cd281-2024052703-cca56cd9-5602-4ec6-bb23-64df5cdd7e94",
                                 "runtimeVersion": "Java_8"
                               }
Status                       : Running
SystemDataCreatedAt          : 2024-05-27 上午 03:48:15
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-27 上午 03:51:29
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apps/deployments
```

Get a Deployment and its properties.

## PARAMETERS

### -AppInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentityApp
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AppName
The name of the App resource.

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

### -Expand
The expand expression to apply on the operation.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

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
The name of the Deployment resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityApp, GetViaIdentitySpring
Aliases: DeploymentName

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
Parameter Sets: Get, List, List1
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
Parameter Sets: Get, List, List1
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
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Version of the deployments to be listed

```yaml
Type: System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: List, List1
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IDeploymentResource

## NOTES

## RELATED LINKS

