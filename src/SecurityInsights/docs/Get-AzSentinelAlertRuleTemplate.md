---
external help file:
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/get-azsentinelalertruletemplate
schema: 2.0.0
---

# Get-AzSentinelAlertRuleTemplate

## SYNOPSIS
Gets the alert rule template.

## SYNTAX

### List (Default)
```
Get-AzSentinelAlertRuleTemplate -ResourceGroupName <String> -WorkspaceName <String>
 [-OperationalInsightsResourceProvider <String>] [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSentinelAlertRuleTemplate -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-OperationalInsightsResourceProvider <String>] [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSentinelAlertRuleTemplate -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the alert rule template.

## EXAMPLES

### Example 1: List all Alert Rule Templates
```powershell
PS C:\> Get-AzSentinelAlertRuleTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

Id
--
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
```

This command lists all Alert Rule Templates under a Microsoft Sentinel workspace.

### Example 2: Get an Alert Rule Template
```powershell
PS C:\> Get-AzSentinelAlertRuleTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myRuleTemplateId"

Id
--
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
```

This command gets an Alert Rule Template.

### Example 3: Get an Alert Rule Template by object Id
```powershell
PS C:\> $template = Get-AzSentinelAlertRuleTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $template[0] | Get-AzSentinelAlertRuleTemplate

Id
--
/subscriptions/0000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroupName/providers/Microsoft.OperationalInsig…
```

This command gets an Alert Rule Template by object

## PARAMETERS

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

### -OperationalInsightsResourceProvider
The namespace of workspaces resource provider- Microsoft.OperationalInsights.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: "Microsoft.OperationalInsights"
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

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

### -WorkspaceName
The name of the workspace.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAlertRuleTemplate

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ISecurityInsightsIdentity>: Identity Parameter
  - `[ActionId <String>]`: Action ID
  - `[AlertRuleTemplateId <String>]`: Alert rule template ID
  - `[AutomationRuleId <String>]`: Automation rule ID
  - `[BookmarkId <String>]`: Bookmark ID
  - `[ConsentId <String>]`: consent ID
  - `[DataConnectorId <String>]`: Connector ID
  - `[EntityId <String>]`: entity ID
  - `[EntityQueryId <String>]`: entity query ID
  - `[EntityQueryTemplateId <String>]`: entity query template ID
  - `[Id <String>]`: Resource identity path
  - `[IncidentCommentId <String>]`: Incident comment ID
  - `[IncidentId <String>]`: Incident ID
  - `[MetadataName <String>]`: The Metadata name.
  - `[Name <String>]`: Threat intelligence indicator name field.
  - `[OperationalInsightsResourceProvider <String>]`: The namespace of workspaces resource provider- Microsoft.OperationalInsights.
  - `[RelationName <String>]`: Relation Name
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RuleId <String>]`: Alert rule ID
  - `[SentinelOnboardingStateName <String>]`: The Sentinel onboarding state name. Supports - default
  - `[SettingsName <String>]`: The setting name. Supports - Anomalies, EyesOn, EntityAnalytics, Ueba
  - `[SourceControlId <String>]`: Source control Id
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[WorkspaceName <String>]`: The name of the workspace.

## RELATED LINKS

