---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/Az.storage/new-azstorageblobqueryarrowfield
schema: 2.0.0
---

# New-AzStorageBlobQueryArrowField

## SYNOPSIS
Creates a blob query arrow field object, which can be used in New-AzStorageBlobQueryConfig.

## SYNTAX

```
New-AzStorageBlobQueryArrowField -Type <String> [-Name <String>] [-Precision <Int32>] [-Scale <Int32>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzStorageBlobQueryArrowField** cmdlet creates a blob query arrow field object, which can be used in New-AzStorageBlobQueryConfig.

## EXAMPLES

### Example 1: Create blob query arrow configures , and query a blob
```powershell
PS C:\> $inputconfig = New-AzStorageBlobQueryConfig -AsJson -RecordSeparator "`n" 

PS C:\> $field1 = New-AzStorageBlobQueryArrowField -Type Int64 -Name name1

PS C:\> $field2 = New-AzStorageBlobQueryArrowField -Type String 

PS C:\> $field3 = New-AzStorageBlobQueryArrowField -Type decimaL -Name name3 -Precision 2 -Scale 3

PS C:\> $outputconfig = New-AzStorageBlobQueryConfig -AsArrow -ArrowField $field1,$field2,$field3

PS C:\> $queryString = "SELECT * FROM BlobStorage WHERE Name = 'a'"

PS C:\> $result = Get-AzStorageBlobQueryResult -Container $containerName -Blob $blobName -QueryString $queryString -ResultFile "c:\resultfile.json" -InputTextConfiguration $inputconfig -OutputTextConfiguration $outputconfig -Context $ctx

PS C:\> $result

BytesScanned FailureCount BlobQueryError
------------ ------------ --------------
         449            0
```

This command first create input configuration object as csv, and output configuration object as arrow with 3 arrow fields, then use the 2 configurations to query blob.

## PARAMETERS

### -Name
The name of the field.
Optional.

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

### -Precision
The precision of the field.
Required if Type is Decimal.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scale
The scale  of the field.
Required if Type is Decimal.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of the field.
Required.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.PSBlobQueryArrowField

## NOTES

## RELATED LINKS
