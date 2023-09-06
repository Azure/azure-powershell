---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzCdnResourceReferenceObject
schema: 2.0.0
---

# New-AzCdnResourceReferenceObject

## SYNOPSIS
Create an in-memory object for ResourceReference.

## SYNTAX

```
New-AzCdnResourceReferenceObject [-Id <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ResourceReference.

## EXAMPLES

### Example 1: Create an in-memory object for ResourceReference
```powershell
New-AzCdnResourceReferenceObject -Id Idtest
```

```output
Id
--
Idtest
```

Create an in-memory object for ResourceReference

## PARAMETERS

### -Id
Resource ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ResourceReference

## NOTES

ALIASES

## RELATED LINKS

