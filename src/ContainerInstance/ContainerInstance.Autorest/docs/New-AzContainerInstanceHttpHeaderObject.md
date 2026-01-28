---
external help file:
Module Name: Az.ContainerInstance
online version: https://learn.microsoft.com/powershell/module/Az.ContainerInstance/new-azcontainerinstancehttpheaderobject
schema: 2.0.0
---

# New-AzContainerInstanceHttpHeaderObject

## SYNOPSIS
Create an in-memory object for HttpHeader.

## SYNTAX

```
New-AzContainerInstanceHttpHeaderObject [-Name <String>] [-Value <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for HttpHeader.

## EXAMPLES

### Example 1: Create an HTTP Header object
```powershell
New-AzContainerInstanceHttpHeaderObject -name foo -value bar
```

```output
Name Value
---- -----
foo  bar
```

Create an HTTP Header object to be used in liveness or readiness probes.

## PARAMETERS

### -Name
The header name.

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
The header value.

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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.HttpHeader

## NOTES

## RELATED LINKS

