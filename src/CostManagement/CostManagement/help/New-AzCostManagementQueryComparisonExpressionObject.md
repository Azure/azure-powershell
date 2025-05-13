---
external help file: Az.CostManagement-help.xml
Module Name: Az.CostManagement
online version: https://learn.microsoft.com/powershell/module/Az.CostManagement/new-azcostmanagementquerycomparisonexpressionobject
schema: 2.0.0
---

# New-AzCostManagementQueryComparisonExpressionObject

## SYNOPSIS
Create an in-memory object for QueryComparisonExpression.

## SYNTAX

```
New-AzCostManagementQueryComparisonExpressionObject -Name <String> -Value <String[]>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for QueryComparisonExpression.

## EXAMPLES

### Example 1: Create a comparison expression object of query for cost management export
```powershell
New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Value @('East US', 'West Europe')
```

```output
Name             Operator Value
----             -------- -----
ResourceLocation In       {East US, West Europe}
```

This command creates a comparison expression object of query for cost management export.

## PARAMETERS

### -Name
The name of the column to use in comparison.

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

### -Value
Array of values to use for comparison.

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.QueryComparisonExpression

## NOTES

## RELATED LINKS
