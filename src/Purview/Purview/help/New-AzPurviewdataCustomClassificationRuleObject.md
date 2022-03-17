---
external help file:
Module Name: Az.Purview
online version: https://docs.microsoft.com/powershell/module/az.Purviewdata/new-AzPurviewdataCustomClassificationRuleObject
schema: 2.0.0
---

# New-AzPurviewdataCustomClassificationRuleObject

## SYNOPSIS
Create an in-memory object for CustomClassificationRule.

## SYNTAX

```
New-AzPurviewdataCustomClassificationRuleObject -Kind <ClassificationRuleType> [-ClassificationName <String>]
 [-ColumnPattern <IClassificationRulePattern[]>] [-DataPattern <IClassificationRulePattern[]>]
 [-Description <String>] [-MinimumPercentageMatch <Double>] [-RuleStatus <ClassificationRuleStatus>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CustomClassificationRule.

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

### -ClassificationName


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

### -ColumnPattern


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20211001Preview.IClassificationRulePattern[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataPattern


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20211001Preview.IClassificationRulePattern[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description


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

### -Kind


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ClassificationRuleType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinimumPercentageMatch


```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleStatus


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ClassificationRuleStatus
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

### Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20211001Preview.CustomClassificationRule

## NOTES

ALIASES

## RELATED LINKS

