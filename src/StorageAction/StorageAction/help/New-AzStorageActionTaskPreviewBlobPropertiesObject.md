---
external help file: Az.StorageAction-help.xml
Module Name: Az.StorageAction
online version: https://learn.microsoft.com/powershell/module/Az.StorageAction/new-azstorageactiontaskpreviewblobpropertiesobject
schema: 2.0.0
---

# New-AzStorageActionTaskPreviewBlobPropertiesObject

## SYNOPSIS
Create an in-memory object for StorageTaskPreviewBlobProperties.

## SYNTAX

```
New-AzStorageActionTaskPreviewBlobPropertiesObject [-Metadata <IStorageTaskPreviewKeyValueProperties[]>]
 [-Name <String>] [-Property <IStorageTaskPreviewKeyValueProperties[]>]
 [-Tag <IStorageTaskPreviewKeyValueProperties[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageTaskPreviewBlobProperties.

## EXAMPLES

### Example 1: Create blob property object
```powershell
$creationTime = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Creation-Time" -Value "Wed, 07 Jun 2023 05:23:29 GMT"
$metadata = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "mKey1" -Value "mValue1"
$tags = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "tKey1" -Value "tValue1"
New-AzStorageActionTaskPreviewBlobPropertiesObject -Name 'folder1/file1.txt' -Metadata $metadata -Property $creationTime -Tag $tags
```

```output
MatchedBlock : 
Metadata     : {{
                 "key": "mKey1",
                 "value": "mValue1"
               }}
Name         : folder1/file1.txt
Property     : {{
                 "key": "Creation-Time",
                 "value": "Wed, 07 Jun 2023 05:23:29 GMT"
               }}
Tag          : {{
                 "key": "tKey1",
                 "value": "tValue1"
               }}
```

This command create a blob property object.

## PARAMETERS

### -Metadata
metadata key value pairs to be tested for a match against the provided condition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskPreviewKeyValueProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of test blob.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
properties key value pairs to be tested for a match against the provided condition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskPreviewKeyValueProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
tags key value pairs to be tested for a match against the provided condition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskPreviewKeyValueProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.StorageTaskPreviewBlobProperties

## NOTES

## RELATED LINKS
