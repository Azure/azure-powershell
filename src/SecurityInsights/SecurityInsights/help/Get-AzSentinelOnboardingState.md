---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelonboardingstate
schema: 2.0.0
---

# Get-AzSentinelOnboardingState

## SYNOPSIS
Get Sentinel onboarding state

## SYNTAX

### List (Default)
```
Get-AzSentinelOnboardingState -ResourceGroupName <String> [-SubscriptionId <String[]>] -WorkspaceName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzSentinelOnboardingState -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSentinelOnboardingState -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get Sentinel onboarding state

## EXAMPLES

### Example 1: List all Onboarding States
```powershell
Get-AzSentinelOnboardingState -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```

```output
Id   : /subscriptions/314b1a41-c53c-4092-8d4a-2810f6a44a0c/resourceGroups/myRG/providers/Microsoft.OperationalInsights/workspaces/cybersecurity/providers/Microsoft.SecurityInsights/onboardingStates/default
Name : default
```

This command lists all Onboarding States under a Microsoft Sentinel workspace.

### Example 2: Get an Onboarding State
```powershell
Get-AzSentinelOnboardingState -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Name "default"
```

```output
Id   : /subscriptions/314b1a41-c53c-4092-8d4a-2810f6a44a0c/resourceGroups/myRG/providers/Microsoft.OperationalInsights/workspaces/cybersecurity/providers/Microsoft.SecurityInsights/onboardingStates/default
Name : default
```

This command gets an Onboarding State.

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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The Sentinel onboarding state name.
Supports - default

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SentinelOnboardingStateName

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ISentinelOnboardingState

## NOTES

## RELATED LINKS
