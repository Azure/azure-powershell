---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-AzMLWorkspaceLiteralJobInputObject
schema: 2.0.0
---

# New-AzMLWorkspaceLiteralJobInputObject

## SYNOPSIS
Create an in-memory object for LiteralJobInput.

## SYNTAX

```
New-AzMLWorkspaceLiteralJobInputObject -Type <JobInputType> -Value <String> [-Description <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LiteralJobInput.

## EXAMPLES

### Example 1: Create an in-memory object for LiteralJobInput
```powershell
New-AzMLWorkspaceLiteralJobInputObject
```

Create an in-memory object for LiteralJobInput

## PARAMETERS

### -Description
Description for the input.

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

### -Type
[Required] Specifies the type of job.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.JobInputType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
[Required] Literal value for the input.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.LiteralJobInput

## NOTES

ALIASES

## RELATED LINKS

