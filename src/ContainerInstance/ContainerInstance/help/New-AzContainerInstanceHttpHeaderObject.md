---
external help file: Az.ContainerInstance-help.xml
Module Name: Az.ContainerInstance
online version: https://learn.microsoft.com/powershell/module/az.ContainerInstance/New-AzContainerInstanceHttpHeaderObject
schema: 2.0.0
---

# New-AzContainerInstanceHttpHeaderObject

## SYNOPSIS
Create a in-memory object for HttpHeader

## SYNTAX

```
New-AzContainerInstanceHttpHeaderObject -Name <String> [-Value <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for HttpHeader

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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
The header value..

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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.HttpHeader

## NOTES

## RELATED LINKS
