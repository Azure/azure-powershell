---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelbookmarkrelation
schema: 2.0.0
---

# Get-AzSentinelBookmarkRelation

## SYNOPSIS
Gets a bookmark relation.

## SYNTAX

### List (Default)
```
Get-AzSentinelBookmarkRelation -BookmarkId <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-Orderby <String>] [-SkipToken <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSentinelBookmarkRelation -BookmarkId <String> -RelationName <String> -ResourceGroupName <String>
 -WorkspaceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSentinelBookmarkRelation -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a bookmark relation.

## EXAMPLES

### Example 1: List all Bookmark Relations for a given Bookmark 
```powershell
 Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId"
```

```output
Name                : 83846045-d8dc-4d6b-abbe-7588219c474e
RelatedResourceName : 7cc984fe-61a2-43c2-a1a4-3583c8a89da2
RelatedResourceType : Microsoft.SecurityInsights/Incidents
```

This command lists all Bookmark Relations for a given Bookmark.

### Example 2: Get a Bookmark Relation
```powershell
 Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId"
```

```output
Name                : 83846045-d8dc-4d6b-abbe-7588219c474e
RelatedResourceName : 7cc984fe-61a2-43c2-a1a4-3583c8a89da2
RelatedResourceType : Microsoft.SecurityInsights/Incidents
```

This command gets a Bookmark Relation.

### Example 3: Get a Bookmark Relation by object Id
```powershell
 $Bookmarkrelations = Get-AzSentinelBookmarkRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -BookmarkId "myBookmarkId"
 $Bookmarkrelations[0] | Get-AzSentinelBookmarkRelation
```

```output
Name                : 83846045-d8dc-4d6b-abbe-7588219c474e
RelatedResourceName : 7cc984fe-61a2-43c2-a1a4-3583c8a89da2
RelatedResourceType : Microsoft.SecurityInsights/Incidents
```

This command gets a Bookmark by object

## PARAMETERS

### -BookmarkId
Bookmark ID

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

### -Filter
Filters the results, based on a Boolean condition.
Optional.

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

### -Orderby
Sorts the results.
Optional.

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

### -RelationName
Relation Name

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
Skiptoken is only used if a previous operation returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls.
Optional.

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

### -Top
Returns only the first n results.
Optional.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelation

## NOTES

## RELATED LINKS

