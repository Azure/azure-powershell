---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelbookmark
schema: 2.0.0
---

# Get-AzSentinelBookmark

## SYNOPSIS
Gets a bookmark.

## SYNTAX

### List (Default)
```
Get-AzSentinelBookmark -ResourceGroupName <String> [-SubscriptionId <String[]>] -WorkspaceName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSentinelBookmark -Id <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSentinelBookmark -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a bookmark.

## EXAMPLES

### Example 1: List all Bookmarks
```powershell
Get-AzSentinelBookmark -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```

```output
DisplayName    	: SecurityAlert - 28b401e1e0c9
CreatedByEmail	: john@contoso.com
CreatedByName  	: John Contoso
Label          	: {}
Note           	: This needs further investigation
Name           	: 515fc035-2ed8-4fa1-ad7d-28b401e1e0c9
```

This command lists all Bookmarks under a Microsoft Sentinel workspace.

### Example 2: Get a Bookmark
```powershell
Get-AzSentinelBookmark -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "515fc035-2ed8-4fa1-ad7d-28b401e1e0c9"
```

```output
DisplayName    	: SecurityAlert - 28b401e1e0c9
CreatedByEmail	: john@contoso.com
CreatedByName  	: John Contoso
Label          	: {}
Note           	: This needs further investigation
Name           	: 515fc035-2ed8-4fa1-ad7d-28b401e1e0c9
```

This command gets a Bookmark.

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
Bookmark ID

```yaml
Type: System.String
Parameter Sets: Get
Aliases: BookmarkId

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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IBookmark

## NOTES

## RELATED LINKS
