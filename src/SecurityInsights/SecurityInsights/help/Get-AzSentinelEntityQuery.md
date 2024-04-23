---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelentityquery
schema: 2.0.0
---

# Get-AzSentinelEntityQuery

## SYNOPSIS
Gets an entity query.

## SYNTAX

### List (Default)
```
Get-AzSentinelEntityQuery -ResourceGroupName <String> [-SubscriptionId <String[]>] -WorkspaceName <String>
 [-Kind <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzSentinelEntityQuery -Id <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSentinelEntityQuery -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets an entity query.

## EXAMPLES

### Example 1: List all Entity Queries
```powershell
Get-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```

```output
DisplayName     : Related entities
DataSource      : {SecurityAlert}
Name            : 98b974fd-cc64-48b8-9bd0-3a209f5b944b
InputEntityType : SecurityAlert

DisplayName     : Related alerts
DataSource      : {SecurityAlert}
Name            : 055a5692-555f-42bd-ac17-923a5a9994ed
InputEntityType : Host
```

This command lists all Entity Queries under a Microsoft Sentinel workspace.

### Example 2: Get an Entity Query
```powershell
Get-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myEntityQueryId"
```

```output
DisplayName     : Related entities
DataSource      : {SecurityAlert}
Name            : 98b974fd-cc64-48b8-9bd0-3a209f5b944b
InputEntityType : SecurityAlert
QueryTemplate   : let GetAlertRelatedEntities = (v_SecurityAlert_SystemAlertId:string){
                                              SecurityAlert
                                              | where SystemAlertId == v_SecurityAlert_SystemAlertId
                                              | project entities = todynamic(Entities)
                                              | mv-expand entities
                                              | project-rename entity=entities};
                                              GetAlertRelatedEntities('<systemAlertId>')
```

This command gets an Entity Query.

### Example 3: Get an Entity Query by object Id
```powershell
$EntityQueries = Get-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
 $EntityQueries[0] | Get-AzSentinelEntityQuery
```

```output
DisplayName     : Related entities
DataSource      : {SecurityAlert}
Name            : 98b974fd-cc64-48b8-9bd0-3a209f5b944b
InputEntityType : SecurityAlert
QueryTemplate   : let GetAlertRelatedEntities = (v_SecurityAlert_SystemAlertId:string){
                                              SecurityAlert
                                              | where SystemAlertId == v_SecurityAlert_SystemAlertId
                                              | project entities = todynamic(Entities)
                                              | mv-expand entities
                                              | project-rename entity=entities};
                                              GetAlertRelatedEntities('<systemAlertId>')
```

This command gets a Entity Query by object.

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
entity query ID

```yaml
Type: System.String
Parameter Sets: Get
Aliases: EntityQueryId

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
The entity query kind we want to fetch

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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IEntityQuery

## NOTES

## RELATED LINKS
