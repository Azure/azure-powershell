---
external help file:
Module Name: Az.CostManagement
online version: https://docs.microsoft.com/en-us/powershell/module/az.CostManagement/new-AzCostManagementQueryFilterObject
schema: 2.0.0
---

# New-AzCostManagementQueryFilterObject

## SYNOPSIS
Create a in-memory object for QueryFilter.
On a QueryFilter one and only one of and/or/not/dimension/tag can be set.

## SYNTAX

```
New-AzCostManagementQueryFilterObject [-And <IQueryFilter[]>] [-Dimension <IQueryComparisonExpression>]
 [-Not <IQueryFilter>] [-Or <IQueryFilter[]>] [-Tag <IQueryComparisonExpression>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for QueryFilter.
On a QueryFilter one and only one of and/or/not/dimension/tag can be set.

## EXAMPLES

### Example 1: Create a filter object of query for cost management export
```powershell
PS C:\> $orDimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Operator In -Value @('East US', 'West Europe')
PS C:\> $orTag = New-AzCostManagementQueryComparisonExpressionObject -Name 'Environment' -Operator In -Value @('UAT', 'Prod')
PS C:\> New-AzCostManagementQueryFilterObject -or @((New-AzCostManagementQueryFilterObject -Dimension $orDimension), (New-AzCostManagementQueryFilterObject -Tag $orTag))

And       :
Dimension : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20200601.QueryComparisonExpression
Not       : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20200601.QueryFilter
Or        : {Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20200601.QueryFilter, Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20200601.QueryFilter}
Tag       : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20200601.QueryComparisonExpression
```

this command creates a filter object of query for cost management export.

## PARAMETERS

### -And
The logical "AND" expression.
Must have at least 2 items.
To construct, see NOTES section for AND properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dimension
Has comparison expression for a dimension.
To construct, see NOTES section for DIMENSION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryComparisonExpression
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Not
The logical "NOT" expression.
To construct, see NOTES section for NOT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Or
The logical "OR" expression.
Must have at least 2 items.
To construct, see NOTES section for OR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryFilter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Has comparison expression for a tag.
To construct, see NOTES section for TAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryComparisonExpression
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

### Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryFilter

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


AND <IQueryFilter[]>: The logical "AND" expression. Must have at least 2 items.
  - `[And <IQueryFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
  - `[Dimension <IQueryComparisonExpression>]`: Has comparison expression for a dimension
    - `Name <String>`: The name of the column to use in comparison.
    - `Operator <OperatorType>`: The operator to use for comparison.
    - `Value <String[]>`: Array of values to use for comparison
  - `[Not <IQueryFilter>]`: The logical "NOT" expression.
  - `[Or <IQueryFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
  - `[Tag <IQueryComparisonExpression>]`: Has comparison expression for a tag

DIMENSION <IQueryComparisonExpression>: Has comparison expression for a dimension.
  - `Name <String>`: The name of the column to use in comparison.
  - `Operator <OperatorType>`: The operator to use for comparison.
  - `Value <String[]>`: Array of values to use for comparison

NOT <IQueryFilter>: The logical "NOT" expression.
  - `[And <IQueryFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
  - `[Dimension <IQueryComparisonExpression>]`: Has comparison expression for a dimension
    - `Name <String>`: The name of the column to use in comparison.
    - `Operator <OperatorType>`: The operator to use for comparison.
    - `Value <String[]>`: Array of values to use for comparison
  - `[Not <IQueryFilter>]`: The logical "NOT" expression.
  - `[Or <IQueryFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
  - `[Tag <IQueryComparisonExpression>]`: Has comparison expression for a tag

OR <IQueryFilter[]>: The logical "OR" expression. Must have at least 2 items.
  - `[And <IQueryFilter[]>]`: The logical "AND" expression. Must have at least 2 items.
  - `[Dimension <IQueryComparisonExpression>]`: Has comparison expression for a dimension
    - `Name <String>`: The name of the column to use in comparison.
    - `Operator <OperatorType>`: The operator to use for comparison.
    - `Value <String[]>`: Array of values to use for comparison
  - `[Not <IQueryFilter>]`: The logical "NOT" expression.
  - `[Or <IQueryFilter[]>]`: The logical "OR" expression. Must have at least 2 items.
  - `[Tag <IQueryComparisonExpression>]`: Has comparison expression for a tag

TAG <IQueryComparisonExpression>: Has comparison expression for a tag.
  - `Name <String>`: The name of the column to use in comparison.
  - `Operator <OperatorType>`: The operator to use for comparison.
  - `Value <String[]>`: Array of values to use for comparison

## RELATED LINKS

