---
external help file:
Module Name: Az.Logz
online version: https://docs.microsoft.com/powershell/module/az.Logz/new-AzLogzFilteringTagObject
schema: 2.0.0
---

# New-AzLogzFilteringTagObject

## SYNOPSIS
Create a in-memory object for FilteringTag

## SYNTAX

```
New-AzLogzFilteringTagObject [-Action <TagAction>] [-Name <String>] [-Value <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for FilteringTag

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Action
Valid actions for a filtering tag.
Exclusion takes priority over inclusion.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Support.TagAction
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name (also known as the key) of the tag.

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
The value of the tag.

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

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.FilteringTag

## NOTES

ALIASES

## RELATED LINKS

