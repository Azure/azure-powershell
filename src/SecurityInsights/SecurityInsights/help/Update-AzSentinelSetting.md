---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/update-azsentinelsetting
schema: 2.0.0
---

# Update-AzSentinelSetting

## SYNOPSIS
Updates setting.

## SYNTAX

### UpdateExpandedAnomaliesEyesOnEntityAnalytics (Default)
```
Update-AzSentinelSetting -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String>]
 -SettingsName <String> -Enabled <Boolean> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpandedUeba
```
Update-AzSentinelSetting -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String>]
 -SettingsName <String> -DataSource <UebaDataSources[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpandedAnomaliesEyesOnEntityAnalytics
```
Update-AzSentinelSetting -InputObject <ISecurityInsightsIdentity> -Enabled <Boolean>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpandedUeba
```
Update-AzSentinelSetting -InputObject <ISecurityInsightsIdentity> -DataSource <UebaDataSources[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates setting.

## EXAMPLES

### Example 1: Update the Anomalies setting
```powershell
Update-AzSentinelSetting -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -SettingsName "Anomalies" -Enabled $true
```

This command updates the Anomalies setting, other settings are: EyesOn, EntityAnalytics and Ueba

## PARAMETERS

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

### -DataSource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.UebaDataSources[]
Parameter Sets: UpdateExpandedUeba, UpdateViaIdentityExpandedUeba
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Enabled
Anomalies

```yaml
Type: System.Boolean
Parameter Sets: UpdateExpandedAnomaliesEyesOnEntityAnalytics, UpdateViaIdentityExpandedAnomaliesEyesOnEntityAnalytics
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: UpdateViaIdentityExpandedAnomaliesEyesOnEntityAnalytics, UpdateViaIdentityExpandedUeba
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The Resource Group Name.

```yaml
Type: System.String
Parameter Sets: UpdateExpandedAnomaliesEyesOnEntityAnalytics, UpdateExpandedUeba
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SettingsName
The setting Name

```yaml
Type: System.String
Parameter Sets: UpdateExpandedAnomaliesEyesOnEntityAnalytics, UpdateExpandedUeba
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpandedAnomaliesEyesOnEntityAnalytics, UpdateExpandedUeba
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
[Alias('DataConnectionName')]
 The name of the workspace.

```yaml
Type: System.String
Parameter Sets: UpdateExpandedAnomaliesEyesOnEntityAnalytics, UpdateExpandedUeba
Aliases:

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.Settings

## NOTES

## RELATED LINKS
