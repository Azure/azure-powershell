---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.storage/new-azstorageblobrangetorestore
schema: 2.0.0
---

# New-AzStorageBlobRangeToRestore

## SYNOPSIS
Creates a Blob Range object to restores a Storage account.

## SYNTAX

```
New-AzStorageBlobRangeToRestore [-StartRange <String>] [-EndRange <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzStorageBlobRangeToRestore** cmdlet creates a Blob range object, which can be used in Restore-AzStorageBlobRange.

## EXAMPLES

### Example 1: Creates a blob range to restore
```powershell
PS C:\> $range = New-AzStorageBlobRangeToRestore -StartRange container1/blob1 -EndRange container2/blob2
```

This command creates a blob range to restore, which starts at container1/blob1 (include), and ends at container2/blob2 (exclude).

### Example 2: Creates a blob range which will restore from first blob in alphabetical order, to a specific blob (exclude)
```powershell
PS C:\> $range = New-AzStorageBlobRangeToRestore -StartRange "" -EndRange container2/blob2
```

This command creates a blob range which will restore from first blob of alphabetical order, to a specific blob container2/blob2 (exclude)

### Example 3: Creates a blob range which will restore from a specific blob (include), to the last blob in alphabetical order
```powershell
PS C:\> $range = New-AzStorageBlobRangeToRestore -StartRange container1/blob1 -EndRange ""
```

This command creates a blob range which will restore from a specific blob container1/blob1 (include), to the last blob in alphabetical order.

### Example 4: Creates a blob range which will restore all blobs
```powershell
PS C:\> $range = New-AzStorageBlobRangeToRestore -StartRange "" -EndRange ""
```

This command creates a blob range which will restore all blobs.

## PARAMETERS

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

### -EndRange
Specify the blob restore End range.
End range will be excluded in restore blobs.
Set it as empty strng to restore to the end.

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

### -StartRange
Specify the blob restore start range.
Start range will be included in restore blobs.
Set it as empty string to restore from begining.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSBlobRestoreRange

## NOTES

## RELATED LINKS
