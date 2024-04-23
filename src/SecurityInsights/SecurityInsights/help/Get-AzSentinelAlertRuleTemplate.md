---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelalertruletemplate
schema: 2.0.0
---

# Get-AzSentinelAlertRuleTemplate

## SYNOPSIS
Gets the alert rule template.

## SYNTAX

### List (Default)
```
Get-AzSentinelAlertRuleTemplate -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzSentinelAlertRuleTemplate -Id <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSentinelAlertRuleTemplate -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets the alert rule template.

## EXAMPLES

### Example 1: List all Alert Rule Templates
```powershell
Get-AzSentinelAlertRuleTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```

```output
DisplayName        : TI map IP entity to GitHub_CL
Description        : Identifies a match in GitHub_CL table from any IP IOC from TI
CreatedDateUtc     : 8/27/2019 12:00:00 AM
LastUpdatedDateUtc : 10/19/2021 12:00:00 AM
Kind               : Scheduled
Severity           : Medium
Name               : aac495a9-feb1-446d-b08e-a1164a539452

DisplayName        : Accessed files shared by temporary external user
Description        : This detection identifies an external user is added to a Team or Teams chat
                     and shares a files which is accessed by many users (>10) and the users is removed within short period of time. This might be
                     an indicator of suspicious activity.
CreatedDateUtc     : 8/18/2020 12:00:00 AM
LastUpdatedDateUtc : 1/3/2022 12:00:00 AM
Kind               : Scheduled
Severity           : Low
Name               : bff058b2-500e-4ae5-bb49-a5b1423cbd5b
```

This command lists all Alert Rule Templates under a Microsoft Sentinel workspace.

### Example 2: Get an Alert Rule Template
```powershell
Get-AzSentinelAlertRuleTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myRuaac495a9-feb1-446d-b08e-a1164a539452leTemplateId"
```

```output
DisplayName        : TI map IP entity to GitHub_CL
Description        : Identifies a match in GitHub_CL table from any IP IOC from TI
CreatedDateUtc     : 8/27/2019 12:00:00 AM
LastUpdatedDateUtc : 10/19/2021 12:00:00 AM
Kind               : Scheduled
Severity           : Medium
Name               : aac495a9-feb1-446d-b08e-a1164a539452
```

This command gets an Alert Rule Template.

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

### -Id
Alert rule template ID

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AlertRuleTemplateId, TemplateId

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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertRuleTemplate

## NOTES

## RELATED LINKS
