---
external help file:
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/get-azsentinelentityquerytemplate
schema: 2.0.0
---

# Get-AzSentinelEntityQueryTemplate

## SYNOPSIS
Gets an entity query.

## SYNTAX

### List (Default)
```
Get-AzSentinelEntityQueryTemplate -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-Kind <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSentinelEntityQueryTemplate -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSentinelEntityQueryTemplate -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an entity query.

## EXAMPLES

### Example 1: List all Entity Query Templates
```powershell
 Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```

```output
Title           : The user has created an account
Description     : This activity displays account creation events performed by the user
InputEntityType : Account
Kind            : Activity
Name            : d6d08c94-455f-4ea5-8f76-fc6c0c442cfa

Title           : The user has deleted an account
Description     : This activity displays account deletion events performed by the user
InputEntityType : Account
Kind            : Activity
Name            : e0459780-ac9d-4b72-8bd4-fecf6b46a0a1
```

This command lists all Entity Query Templates under a Microsoft Sentinel workspace.

### Example 2: Get an Entity Query Template
```powershell
 Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "d6d08c94-455f-4ea5-8f76-fc6c0c442cfa"
```

```output
Description     : This activity displays account creation events performed by the user
InputEntityType : Account
Kind            : Activity
Name            : d6d08c94-455f-4ea5-8f76-fc6c0c442cfa
```

This command gets an Entity Query Template.

### Example 3: Get an Entity Query Template by object Id
```powershell
 $EntityQueryTemplates = Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
 $EntityQueryTemplates[0] | Get-AzSentinelEntityQueryTemplate
```

```output
Description     : This activity displays account creation events performed by the user
InputEntityType : Account
Kind            : Activity
Name            : d6d08c94-455f-4ea5-8f76-fc6c0c442cfa
```

This command gets a Entity Query Template by object.

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
entity query template ID

```yaml
Type: System.String
Parameter Sets: Get
Aliases: EntityQueryTemplateId

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

### -Kind
The entity template query kind we want to fetch

```yaml
Type: System.String
Parameter Sets: List
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IEntityQueryTemplate

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ISecurityInsightsIdentity>`: Identity Parameter
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
  - `[RelationName <String>]`: Relation Name
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RuleId <String>]`: Alert rule ID
  - `[SentinelOnboardingStateName <String>]`: The Sentinel onboarding state name. Supports - default
  - `[SettingsName <String>]`: The setting name. Supports - Anomalies, EyesOn, EntityAnalytics, Ueba
  - `[SourceControlId <String>]`: Source control Id
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[WorkspaceName <String>]`: The name of the workspace.

## RELATED LINKS

