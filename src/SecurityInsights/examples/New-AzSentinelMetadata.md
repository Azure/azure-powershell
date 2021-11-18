### Example 1: Create a Metadata
```powershell
PS C:\> $name = "myMetadataName"
PS C:\> New-AzSentinelMetadata -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Name $Name -AuthorEmail "myauthoremail@email.com" -AuthorName "My Author" -CategoryDomain @('Security','Identity') -ContentId $Name -DependencyContentId "workbookId" -DependencyKind "Workbook" -DependencyName "workbookName" -DependencyVersion "1.0.0" -FirstPublishDate (get-date -Format "yyyy-MM-dd") -Kind Solution -ParentId $name -Provider "Community" -SourceId $name -SourceKind "Solution" -SourceName "SourceName" -Version "1.0.0"

{{ Add output here }}
```

This command creates a metadata.
