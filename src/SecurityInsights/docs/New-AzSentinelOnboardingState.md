---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/new-azsentinelonboardingstate
schema: 2.0.0
---

# New-AzSentinelOnboardingState

## SYNOPSIS
Create Sentinel onboarding state

## SYNTAX

### CreateExpanded (Default)
```
New-AzSentinelOnboardingState -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-CustomerManagedKey] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzSentinelOnboardingState -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -SentinelOnboardingStateParameter <ISentinelOnboardingState> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzSentinelOnboardingState -InputObject <ISecurityInsightsIdentity>
 -SentinelOnboardingStateParameter <ISentinelOnboardingState> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzSentinelOnboardingState -InputObject <ISecurityInsightsIdentity> [-CustomerManagedKey]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityWorkspace
```
New-AzSentinelOnboardingState -Name <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 -SentinelOnboardingStateParameter <ISentinelOnboardingState> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityWorkspaceExpanded
```
New-AzSentinelOnboardingState -Name <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-CustomerManagedKey] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create Sentinel onboarding state

## EXAMPLES

### Example 1: Add Sentinel onboarding state
```powershell
New-AzSentinelOnboardingState -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Name "default"
```

```output
CustomerManagedKey           : 
Etag                         : 
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/onboardingStates/default
Name                         : default
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 8/3/2023 3:49:07 AM
SystemDataCreatedBy          : v-jiaji@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/3/2023 3:49:07 AM
SystemDataLastModifiedBy     : v-jiaji@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.SecurityInsights/onboardingStates
```

This command configures the onboarding state of Sentinel

## PARAMETERS

### -CustomerManagedKey
Flag that indicates the status of the CMK setting

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityWorkspaceExpanded
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded, CreateViaIdentityWorkspace, CreateViaIdentityWorkspaceExpanded
Aliases: SentinelOnboardingStateName

Required: True
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SentinelOnboardingStateParameter
Sentinel onboarding state
To construct, see NOTES section for SENTINELONBOARDINGSTATEPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISentinelOnboardingState
Parameter Sets: Create, CreateViaIdentity, CreateViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: CreateViaIdentityWorkspace, CreateViaIdentityWorkspaceExpanded
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
Parameter Sets: Create, CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISentinelOnboardingState

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISentinelOnboardingState

## NOTES

## RELATED LINKS

