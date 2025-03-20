---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/update-azspringappdeployment
schema: 2.0.0
---

# Update-AzSpringAppDeployment

## SYNOPSIS
Operation to Update an exiting Deployment.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSpringAppDeployment -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String>] [-Active] [-DeploymentSetting <IDeploymentSettings>]
 [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>] [-Source <IUserSourceInfo>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityAppExpanded
```
Update-AzSpringAppDeployment -AppInputObject <ISpringAppsIdentity> -Name <String> [-Active]
 [-DeploymentSetting <IDeploymentSettings>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-Source <IUserSourceInfo>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSpringAppDeployment -InputObject <ISpringAppsIdentity> [-Active]
 [-DeploymentSetting <IDeploymentSettings>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-Source <IUserSourceInfo>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentitySpringExpanded
```
Update-AzSpringAppDeployment -AppName <String> -Name <String> -SpringInputObject <ISpringAppsIdentity>
 [-Active] [-DeploymentSetting <IDeploymentSettings>] [-SkuCapacity <Int32>] [-SkuName <String>]
 [-SkuTier <String>] [-Source <IUserSourceInfo>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzSpringAppDeployment -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzSpringAppDeployment -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Operation to Update an exiting Deployment.

## EXAMPLES

### Example 1: Operation to Update an exiting Deployment.
```powershell
Update-AzSpringAppDeployment -AppName tools -Name green -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02
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
                                 "name": "tools-green-5-6776b488f6-xllmz",
                                 "status": "Running",
                                 "discoveryStatus": "UP",
                                 "startTime": "2024-05-28T03:52:58Z"
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
SystemDataLastModifiedAt     : 2024-05-28 上午 03:52:53
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/apps/deployments
```

Operation to Update an exiting Deployment.

## PARAMETERS

### -Active
Indicates whether the Deployment is active

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: UpdateViaIdentityAppExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentitySpringExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
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

### -DeploymentSetting
Deployment settings of the Deployment

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IDeploymentSettings
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Deployment resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentitySpringExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: DeploymentName

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

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Current capacity of the target resource

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the Sku

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
Tier of the Sku

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Source
Uploaded source information of the deployment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IUserSourceInfo
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpringInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: UpdateViaIdentitySpringExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IDeploymentResource

## NOTES

## RELATED LINKS

