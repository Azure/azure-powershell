---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/new-azspringappdeployment
schema: 2.0.0
---

# New-AzSpringAppDeployment

## SYNOPSIS
Create a new Deployment or Create an exiting Deployment.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSpringAppDeployment -AppName <String> -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String>] [-Active] [-DeploymentSetting <IDeploymentSettings>] [-SkuCapacity <Int32>]
 [-SkuName <String>] [-SkuTier <String>] [-Source <IUserSourceInfo>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityAppExpanded
```
New-AzSpringAppDeployment -AppInputObject <ISpringAppsIdentity> -Name <String> [-Active]
 [-DeploymentSetting <IDeploymentSettings>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-Source <IUserSourceInfo>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzSpringAppDeployment -InputObject <ISpringAppsIdentity> [-Active]
 [-DeploymentSetting <IDeploymentSettings>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-Source <IUserSourceInfo>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentitySpringExpanded
```
New-AzSpringAppDeployment -AppName <String> -Name <String> -SpringInputObject <ISpringAppsIdentity> [-Active]
 [-DeploymentSetting <IDeploymentSettings>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-Source <IUserSourceInfo>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzSpringAppDeployment -AppName <String> -Name <String> -ResourceGroupName <String> -ServiceName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzSpringAppDeployment -AppName <String> -Name <String> -ResourceGroupName <String> -ServiceName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new Deployment or Create an exiting Deployment.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
$settingObj = New-AzSpringAppDeploymentSettingObject -ResourceRequestCpu "1000m" -ResourceRequestMemory "3Gi" -TerminationGracePeriodSecond 30 -LivenessProbeDisableProbe:$false -LivenessProbeInitialDelaySecond 30 -LivenessProbePeriodSecond 10 -LivenessProbeFailureThreshold 3 -LivenessProbeActionType HTTPGetAction -ReadinessProbeDisableProbe:$false -ReadinessProbeInitialDelaySecond 30 -ReadinessProbePeriodSecond 10 -ReadinessProbeFailureThreshold 3 -ReadinessProbeActionType HTTPGetAction 
$source = New-AzSpringAppDeploymentSourceUploadedObject -ArtifactSelector sub-module-1 -RuntimeVersion 1.0 -RelativePath "resources/a172cedcae47474b615c54d510a5d84a8dea3032e958587430b413538be3f333-2019082605-e3095339-1723-44b7-8b5e-31b1003978bc" -Version 1.0
New-AzSpringAppDeployment -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -AppName tools -Name azps-appdeployment -Source $source -DeploymentSetting $settingObj -SkuName "S0" -SkuTier "Standard" -SkuCapacity 1
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
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

## PARAMETERS

### -Active
Indicates whether the Deployment is active

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityAppExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
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
Parameter Sets: CreateViaIdentityAppExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
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

### -Name
The name of the Deployment resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAppExpanded, CreateViaIdentitySpringExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### -SkuCapacity
Current capacity of the target resource

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityAppExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
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
Parameter Sets: CreateViaIdentitySpringExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IDeploymentResource

## NOTES

## RELATED LINKS

