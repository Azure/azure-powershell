---
external help file:
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/new-azsentinelmetadata
schema: 2.0.0
---

# New-AzSentinelMetadata

## SYNOPSIS
Create a Metadata.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSentinelMetadata -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-AuthorEmail <String>] [-AuthorLink <String>] [-AuthorName <String>]
 [-CategoryDomain <String[]>] [-CategoryVertical <String[]>] [-ContentId <String>]
 [-DependencyContentId <String>] [-DependencyCriterion <IMetadataDependencies[]>] [-DependencyKind <Kind>]
 [-DependencyName <String>] [-DependencyOperator <Operator>] [-DependencyVersion <String>]
 [-FirstPublishDate <DateTime>] [-Kind <Kind>] [-LastPublishDate <DateTime>] [-ParentId <String>]
 [-Provider <String[]>] [-SourceId <String>] [-SourceKind <SourceKind>] [-SourceName <String>]
 [-SupportEmail <String>] [-SupportLink <String>] [-SupportName <String>] [-SupportTier <SupportTier>]
 [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzSentinelMetadata -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -Metadata <IMetadataModel> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Metadata.

## EXAMPLES

### Example 1: Create a Metadata
```powershell
PS C:\> $name = "myMetadataName"
PS C:\> New-AzSentinelMetadata -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Name $Name -AuthorEmail "myauthoremail@email.com" -AuthorName "My Author" -CategoryDomain @('Security','Identity') -ContentId $Name -DependencyContentId "workbookId" -DependencyKind "Workbook" -DependencyName "workbookName" -DependencyVersion "1.0.0" -FirstPublishDate (get-date -Format "yyyy-MM-dd") -Kind Solution -ParentId $name -Provider "Community" -SourceId $name -SourceKind "Solution" -SourceName "SourceName" -Version "1.0.0"

{{ Add output here }}
```

This command creates a metadata.

## PARAMETERS

### -AuthorEmail
Email of author contact

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorLink
Link for author/vendor page

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorName
Name of the author.
Company or person.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CategoryDomain
domain for the solution content item

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CategoryVertical
Industry verticals for the solution content item

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentId
Static ID for the content.
Used to identify dependencies and content from solutions or community.
Hard-coded/static for out of the box content and solutions.
Dynamic for user-created.
This is the resource name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DependencyContentId
Id of the content item we depend on

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DependencyCriterion
This is the list of dependencies we must fulfill, according to the AND/OR operator
To construct, see NOTES section for DEPENDENCYCRITERION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IMetadataDependencies[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DependencyKind
Type of the content item we depend on

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.Kind
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DependencyName
Name of the content item

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DependencyOperator
Operator used for list of dependencies in criteria array.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.Operator
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DependencyVersion
Version of the the content item we depend on.
Can be blank, * or missing to indicate any version fulfills the dependency.
If version does not match our defined numeric format then an exact match is required.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirstPublishDate
first publish date solution content item

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
The kind of content the metadata is for.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.Kind
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastPublishDate
last publish date for the solution content item

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
Metadata resource definition.
To construct, see NOTES section for METADATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IMetadataModel
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The Metadata name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: MetadataName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentId
Full parent resource ID of the content item the metadata is for.
This is the full resource ID including the scope (subscription and resource group)

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Provider
Providers for the solution content item

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceId
ID of the content source.
The solution ID, workspace ID, etc

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceKind
Source type of the content

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.SourceKind
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceName
Name of the content source.
The repo name, solution name, LA workspace name etc.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportEmail
Email of support contact

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportLink
Link for support help, like to support page to open a ticket etc.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportName
Name of the support contact.
Company or person.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportTier
Type of support for content item

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.SupportTier
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Version of the content.
Default and recommended format is numeric (e.g.
1, 1.0, 1.0.0, 1.0.0.0), following ARM template best practices.
Can also be any string, but then we cannot guarantee any version checks

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IMetadataModel

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IMetadataModel

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DEPENDENCYCRITERION <IMetadataDependencies[]>: This is the list of dependencies we must fulfill, according to the AND/OR operator
  - `[ContentId <String>]`: Id of the content item we depend on
  - `[Criterion <IMetadataDependencies[]>]`: This is the list of dependencies we must fulfill, according to the AND/OR operator
  - `[Kind <Kind?>]`: Type of the content item we depend on
  - `[Name <String>]`: Name of the content item
  - `[Operator <Operator?>]`: Operator used for list of dependencies in criteria array.
  - `[Version <String>]`: Version of the the content item we depend on.  Can be blank, * or missing to indicate any version fulfills the dependency.  If version does not match our defined numeric format then an exact match is required.

METADATA <IMetadataModel>: Metadata resource definition.
  - `[Etag <String>]`: Etag of the azure resource
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[AuthorEmail <String>]`: Email of author contact
  - `[AuthorLink <String>]`: Link for author/vendor page
  - `[AuthorName <String>]`: Name of the author. Company or person.
  - `[CategoryDomain <String[]>]`: domain for the solution content item
  - `[CategoryVertical <String[]>]`: Industry verticals for the solution content item
  - `[ContentId <String>]`: Static ID for the content.  Used to identify dependencies and content from solutions or community.  Hard-coded/static for out of the box content and solutions. Dynamic for user-created.  This is the resource name
  - `[DependencyContentId <String>]`: Id of the content item we depend on
  - `[DependencyCriterion <IMetadataDependencies[]>]`: This is the list of dependencies we must fulfill, according to the AND/OR operator
    - `[ContentId <String>]`: Id of the content item we depend on
    - `[Criterion <IMetadataDependencies[]>]`: This is the list of dependencies we must fulfill, according to the AND/OR operator
    - `[Kind <Kind?>]`: Type of the content item we depend on
    - `[Name <String>]`: Name of the content item
    - `[Operator <Operator?>]`: Operator used for list of dependencies in criteria array.
    - `[Version <String>]`: Version of the the content item we depend on.  Can be blank, * or missing to indicate any version fulfills the dependency.  If version does not match our defined numeric format then an exact match is required.
  - `[DependencyKind <Kind?>]`: Type of the content item we depend on
  - `[DependencyName <String>]`: Name of the content item
  - `[DependencyOperator <Operator?>]`: Operator used for list of dependencies in criteria array.
  - `[DependencyVersion <String>]`: Version of the the content item we depend on.  Can be blank, * or missing to indicate any version fulfills the dependency.  If version does not match our defined numeric format then an exact match is required.
  - `[FirstPublishDate <DateTime?>]`: first publish date solution content item
  - `[Kind <Kind?>]`: The kind of content the metadata is for.
  - `[LastPublishDate <DateTime?>]`: last publish date for the solution content item
  - `[ParentId <String>]`: Full parent resource ID of the content item the metadata is for.  This is the full resource ID including the scope (subscription and resource group)
  - `[Provider <String[]>]`: Providers for the solution content item
  - `[SourceId <String>]`: ID of the content source.  The solution ID, workspace ID, etc
  - `[SourceKind <SourceKind?>]`: Source type of the content
  - `[SourceName <String>]`: Name of the content source.  The repo name, solution name, LA workspace name etc.
  - `[SupportEmail <String>]`: Email of support contact
  - `[SupportLink <String>]`: Link for support help, like to support page to open a ticket etc.
  - `[SupportName <String>]`: Name of the support contact. Company or person.
  - `[SupportTier <SupportTier?>]`: Type of support for content item
  - `[Version <String>]`: Version of the content.  Default and recommended format is numeric (e.g. 1, 1.0, 1.0.0, 1.0.0.0), following ARM template best practices.  Can also be any string, but then we cannot guarantee any version checks

## RELATED LINKS

