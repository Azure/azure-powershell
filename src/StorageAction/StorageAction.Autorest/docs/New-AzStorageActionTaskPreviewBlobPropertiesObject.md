---
external help file:
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

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Metadata
metadata key value pairs to be tested for a match against the provided condition.
To construct, see NOTES section for METADATA properties and create a hash table.

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
property for the container name.

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
To construct, see NOTES section for PROPERTY properties and create a hash table.

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
To construct, see NOTES section for TAG properties and create a hash table.

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

