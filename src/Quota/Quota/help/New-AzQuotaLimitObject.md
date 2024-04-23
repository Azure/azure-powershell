---
external help file: Az.Quota-help.xml
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/Az.Quota/new-azquotalimitobject
schema: 2.0.0
---

# New-AzQuotaLimitObject

## SYNOPSIS
Create an in-memory object for LimitObject.

## SYNTAX

```
New-AzQuotaLimitObject -Value <Int32> [-LimitType <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LimitObject.

## EXAMPLES

### Example 1: Create an in-memory object for LimitValue
```powershell
New-AzQuotaLimitObject -Value 1003
```

```output
LimitObjectType LimitType Value
--------------- --------- -----
LimitValue                1003
```

This command create an in-memory object for LimitValue as value of the parameter Limit in the New/Update-AzQuota cmdlet.

## PARAMETERS

### -LimitType
The quota or usages limit types.

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
The quota/limit value.

```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.LimitObject

## NOTES

## RELATED LINKS
