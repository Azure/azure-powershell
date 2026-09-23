---
external help file:
Module Name: Az.StorageAction
online version: https://learn.microsoft.com/powershell/module/Az.StorageAction/new-azstorageactiontaskpreviewkeyvaluepropertiesobject
schema: 2.0.0
---

# New-AzStorageActionTaskPreviewKeyValuePropertiesObject

## SYNOPSIS
Create an in-memory object for StorageTaskPreviewKeyValueProperties.

## SYNTAX

```
New-AzStorageActionTaskPreviewKeyValuePropertiesObject [-Key <String>] [-Value <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageTaskPreviewKeyValueProperties.

## EXAMPLES

### Example 1: Create key and value property
```powershell
New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Creation-Time" -Value "Wed, 07 Jun 2023 05:23:29 GMT"
```

```output
Key           Value
---           -----
Creation-Time Wed, 07 Jun 2023 05:23:29 GMT
```

This command create a key-value property object.

## PARAMETERS

### -Key
Represents the key property of the pair.

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

### -Value
Represents the value property of the pair.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.StorageTaskPreviewKeyValueProperties

## NOTES

## RELATED LINKS

