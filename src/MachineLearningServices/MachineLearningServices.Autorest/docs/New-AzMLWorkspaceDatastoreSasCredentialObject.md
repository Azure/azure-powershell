---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceDatastoreSasCredentialObject
schema: 2.0.0
---

# New-AzMLWorkspaceDatastoreSasCredentialObject

## SYNOPSIS
Create an in-memory object for SasDatastoreCredentials.

## SYNTAX

```
New-AzMLWorkspaceDatastoreSasCredentialObject -SasToken <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SasDatastoreCredentials.

## EXAMPLES

### Example 1: Create an in-memory object for SasDatastoreCredentials
```powershell
New-AzMLWorkspaceDatastoreSasCredentialObject
```

Create an in-memory object for SasDatastoreCredentials

## PARAMETERS

### -SasToken
[Required] Storage container secrets.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.SasDatastoreCredentials

## NOTES

ALIASES

## RELATED LINKS

