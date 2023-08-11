---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/update-azsentinelsecuritymlanalyticssetting
schema: 2.0.0
---

# Update-AzSentinelSecurityMlAnalyticsSetting

## SYNOPSIS
Create the Security ML Analytics Settings.

## SYNTAX

### UpdateViaIdentity (Default)
```
Update-AzSentinelSecurityMlAnalyticsSetting -InputObject <ISecurityInsightsIdentity>
 -SecurityMlAnalyticsSetting <ISecurityMlAnalyticsSetting> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Update-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName <String> -SettingsResourceName <String>
 -WorkspaceName <String> -SecurityMlAnalyticsSetting <ISecurityMlAnalyticsSetting> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityWorkspace
```
Update-AzSentinelSecurityMlAnalyticsSetting -SettingsResourceName <String>
 -WorkspaceInputObject <ISecurityInsightsIdentity> -SecurityMlAnalyticsSetting <ISecurityMlAnalyticsSetting>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create the Security ML Analytics Settings.

## EXAMPLES

### Example 1: Update specific SecurityMlAnalyticsSetting with specified resource group and workspace
```powershell
$setting = New-AzSentinelAnomalySecurityMlAnalyticsSettingsObject -AnomalyVersion 1.0.5 -Enabled $false -DisplayName "Login from unusual region" -Frequency (New-TimeSpan -Hours 2) -SettingsStatus Production -IsDefaultSetting $true -SettingsDefinitionId "f209187f-1d17-4431-94af-c141bf5f23db"
Update-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-w4" -SettingsResourceName f209187f-1d17-4431-94af-c141bf5f23db -SecurityMlAnalyticsSetting $setting
```

```output
AnomalySettingsVersion       : 0
AnomalyVersion               : 1.0.5
CustomizableObservation      : {
                               }
Description                  : 
DisplayName                  : Login from unusual region
Enabled                      : False
Etag                         : "0a003319-0000-0300-0000-64d4c4510000"
Frequency                    : 02:00:00
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-w4/provi 
                               ders/Microsoft.SecurityInsights/securityMLAnalyticsSettings/f209187f-1d17-4431-94af-c141bf5f23db
IsDefaultSetting             : True
Kind                         : Anomaly
LastModifiedUtc              : 8/10/2023 11:04:47 AM
Name                         : f209187f-1d17-4431-94af-c141bf5f23db
RequiredDataConnector        : {}
SettingsDefinitionId         : f209187f-1d17-4431-94af-c141bf5f23db
SettingsStatus               : Production
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tactic                       : {}
Technique                    : {}
Type                         : Microsoft.SecurityInsights/securityMLAnalyticsSettings
```

This command updates specific SecurityMlAnalyticsSetting with specified resource group and workspace

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityMlAnalyticsSetting
Security ML Analytics Setting
To construct, see NOTES section for SECURITYMLANALYTICSSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityMlAnalyticsSetting
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SettingsResourceName
Security ML Analytics Settings resource name

```yaml
Type: System.String
Parameter Sets: Update, UpdateViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Update
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter
To construct, see NOTES section for WORKSPACEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: UpdateViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: Update
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityMlAnalyticsSetting

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityMlAnalyticsSetting

## NOTES

## RELATED LINKS

