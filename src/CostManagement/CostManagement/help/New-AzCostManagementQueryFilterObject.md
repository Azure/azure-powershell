---
external help file: Az.CostManagement-help.xml
Module Name: Az.CostManagement
online version: https://learn.microsoft.com/powershell/module/Az.CostManagement/new-azcostmanagementqueryfilterobject
schema: 2.0.0
---

# New-AzCostManagementQueryFilterObject

## SYNOPSIS
Create an in-memory object for QueryFilter.

## SYNTAX

```
New-AzCostManagementQueryFilterObject [-And <IQueryFilter[]>] [-Dimensions <IQueryComparisonExpression>]
 [-Not <IQueryFilter>] [-Or <IQueryFilter[]>] [-Tag <IQueryComparisonExpression>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for QueryFilter.

## EXAMPLES

### Example 1: Create a filter object of query for cost management export
```powershell
$orDimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Value @('East US', 'West Europe')
$orTag = New-AzCostManagementQueryComparisonExpressionObject -Name 'Environment' -Value @('UAT', 'Prod')
New-AzCostManagementQueryFilterObject -or @((New-AzCostManagementQueryFilterObject -Dimensions $orDimension), (New-AzCostManagementQueryFilterObject -Tag $orTag))
```

```output
And       :
Dimension : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.QueryComparisonExpression
Not       : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.QueryFilter
Or        : {Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.QueryFilter, Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.QueryFilter}
Tag       : Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.QueryComparisonExpression
```

this command creates a filter object of query for cost management export.

## PARAMETERS

### -And
The logical "AND" expression.
Must have at least 2 items.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IQueryFilter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dimensions
Has comparison expression for a dimension.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IQueryComparisonExpression
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IQueryFilter
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IQueryFilter[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IQueryComparisonExpression
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

### Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.QueryFilter

## NOTES

## RELATED LINKS
