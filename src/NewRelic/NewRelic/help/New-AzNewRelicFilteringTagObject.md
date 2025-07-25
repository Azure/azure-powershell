---
external help file: Az.NewRelic-help.xml
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/Az.NewRelic/new-aznewrelicfilteringtagobject
schema: 2.0.0
---

# New-AzNewRelicFilteringTagObject

## SYNOPSIS
Create an in-memory object for FilteringTag.

## SYNTAX

```
New-AzNewRelicFilteringTagObject [-Action <String>] [-Name <String>] [-Value <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for FilteringTag.

## EXAMPLES

### Example 1: Create Filtering Tag object
```powershell
New-AzNewRelicFilteringTagObject -Action Include -Name testLogRule1 -Value filteringTag1
```

```output
Action  Name         Value
------  ----         -----
Include testLogRule1 filteringTag1
```

This command creates a filtering tag object.

## PARAMETERS

### -Action
Valid actions for a filtering tag.
Exclusion takes priority over inclusion.

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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.FilteringTag

## NOTES

## RELATED LINKS
