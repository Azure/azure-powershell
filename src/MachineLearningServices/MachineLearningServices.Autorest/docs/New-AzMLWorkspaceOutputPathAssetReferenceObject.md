---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-AzMLWorkspaceOutputPathAssetReferenceObject
schema: 2.0.0
---

# New-AzMLWorkspaceOutputPathAssetReferenceObject

## SYNOPSIS
Create an in-memory object for OutputPathAssetReference.

## SYNTAX

```
New-AzMLWorkspaceOutputPathAssetReferenceObject -ReferenceType <ReferenceType> [-JobId <String>]
 [-Path <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for OutputPathAssetReference.

## EXAMPLES

### Example 1: Create an in-memory object for OutputPathAssetReference
```powershell
New-AzMLWorkspaceOutputPathAssetReferenceObject -JobId <String> -Path <String>
```

This command creates an in-memory object for OutputPathAssetReference.

## PARAMETERS

### -JobId
ARM resource ID of the job.

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

### -Path
The path of the file/directory in the job output.

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

### -ReferenceType
[Required] Specifies the type of asset reference.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ReferenceType
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.OutputPathAssetReference

## NOTES

## RELATED LINKS

