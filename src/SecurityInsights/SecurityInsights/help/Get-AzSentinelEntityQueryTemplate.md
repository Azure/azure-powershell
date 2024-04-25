---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelentityquerytemplate
schema: 2.0.0
---

# Get-AzSentinelEntityQueryTemplate

## SYNOPSIS
Gets an entity query.

## SYNTAX

### List (Default)
```
Get-AzSentinelEntityQueryTemplate -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-Kind <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSentinelEntityQueryTemplate -Id <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IEntityQueryTemplate

## NOTES

## RELATED LINKS
