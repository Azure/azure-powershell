---
external help file:
Module Name: Az.CostManagement
online version: https://docs.microsoft.com/en-us/powershell/module/az.CostManagement/new-AzCostManagementQueryColumnObject
schema: 2.0.0
---

# New-AzCostManagementQueryColumnObject

## SYNOPSIS
Create a in-memory object for QueryColumn

## SYNTAX

```
New-AzCostManagementQueryColumnObject [-Name <String>] [-Type <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for QueryColumn

## EXAMPLES

### Example 1: Create a column object of query for cost management export
```powershell
PS C:\> New-AzCostManagementQueryColumnObject -Name 'SubscriptionGuid' -Type 'string'

Name             Type
----             ----
SubscriptionGuid string
```

This command creates a column object of query for cost management export.

## PARAMETERS

### -Name
The name of column.

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
The type of column.

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

### Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryColumn

## NOTES

ALIASES

## RELATED LINKS

