---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceDataFactoryObject
schema: 2.0.0
---

# New-AzMLWorkspaceDataFactoryObject

## SYNOPSIS
Create an in-memory object for DataFactory.

## SYNTAX

```
New-AzMLWorkspaceDataFactoryObject [-Description <String>] [-DisableLocalAuth <Boolean>]
 [-ResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DataFactory.

## EXAMPLES

### Example 1: Create an in-memory object for DataFactory
```powershell
New-AzMLWorkspaceDataFactoryObject
```

Create an in-memory object for DataFactory

## PARAMETERS

### -Description
The description of the Machine Learning compute.

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

### -DisableLocalAuth
Opt-out of local authentication and ensure customers can use only MSI and AAD exclusively for authentication.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ARM resource id of the underlying compute.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.DataFactory

## NOTES

ALIASES

## RELATED LINKS

