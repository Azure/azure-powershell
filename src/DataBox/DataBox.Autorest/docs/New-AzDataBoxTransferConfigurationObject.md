---
external help file:
Module Name: Az.DataBox
online version: https://learn.microsoft.com/powershell/module/Az.DataBox/new-azdataboxtransferconfigurationobject
schema: 2.0.0
---

# New-AzDataBoxTransferConfigurationObject

## SYNOPSIS
Create an in-memory object for TransferConfiguration.

## SYNTAX

```
New-AzDataBoxTransferConfigurationObject -Type <String>
 [-TransferAllDetail <ITransferConfigurationTransferAllDetails>]
 [-TransferFilterDetail <ITransferConfigurationTransferFilterDetails>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for TransferConfiguration.

## EXAMPLES

### Example 1: In-memory object for export job transfer configuration 
```powershell
New-AzDataBoxTransferConfigurationObject -Type "TransferAll" -TransferAllDetail @{"IncludeDataAccountType"="StorageAccount";"IncludeTransferAllBlob"= "True"; "IncludeTransferAllFile"="True"}
```

```output
TransferAllDetail    : {
                         "include": {
                           "dataAccountType": "StorageAccount",
                           "transferAllBlobs": true,
                           "transferAllFiles": true
                         }
                       }
TransferFilterDetail : {
                       }
Type                 : TransferAll
```

Create a in-memory object for export jobs TransferConfiguration

## PARAMETERS

### -TransferAllDetail
Map of filter type and the details to transfer all data.
This field is required only if the TransferConfigurationType is given as TransferAll.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.ITransferConfigurationTransferAllDetails
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TransferFilterDetail
Map of filter type and the details to filter.
This field is required only if the TransferConfigurationType is given as TransferUsingFilter.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.ITransferConfigurationTransferFilterDetails
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Type of the configuration for transfer.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.TransferConfiguration

## NOTES

## RELATED LINKS

