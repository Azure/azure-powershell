---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.dll-Help.xml
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/get-azsentinelbookmark
schema: 2.0.0
---

# Get-AzSentinelBookmark

## SYNOPSIS
Get a Bookmark.

## SYNTAX

### WorkspaceScope (Default)
```
Get-AzSentinelBookmark -ResourceGroupName <String> -WorkspaceName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### BookmarkId.
```
Get-AzSentinelBookmark -ResourceGroupName <String> -WorkspaceName <String> -BookmarkId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceId
```
Get-AzSentinelBookmark -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSentinelBookmark** cmdlet gets a Bookmark from the specified workspace.
If you specify the *BookmarkId* parameter, a single **Bookmark** object is returned.
If you do not specify the *BookmarkId* parameter, an array containing all of the Bookmarks in the specified workspace are returned.
You can use the **Bookmark** object to update the Bookmark, for example you can add Notes the **Bookmark**.

## EXAMPLES

### Example 1
```powershell
PS C:\> $Bookmarks = Get-AzSentinelBookmark -ResourceGroupName "MyResourceGroup" -WorkspaceName "MyWorkspaceName"
```

This example gets all of the **Bookmarks** in the specified workspace, and then stores it in the $Bookmarks variable.

### Example 2
```powershell
PS C:\> $Bookmark = Get-AzSentinelBookmark -ResourceGroupName "MyResourceGroup" -WorkspaceName "MyWorkspaceName" -BookmarkId "MyBookmarkId"
```

This example gets an **Bookmark** in the specified workspace, and then stores it in the $Bookmark variable.

## PARAMETERS

### -BookmarkId
Bookmark Id,

```yaml
Type: System.String
Parameter Sets: BookmarkId.
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: WorkspaceScope, BookmarkId.
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource Id.

```yaml
Type: System.String
Parameter Sets: ResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WorkspaceName
Workspace Name.

```yaml
Type: System.String
Parameter Sets: WorkspaceScope, BookmarkId.
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

### System.String
## OUTPUTS

### Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks.PSSentinelBookmark
## NOTES

## RELATED LINKS
