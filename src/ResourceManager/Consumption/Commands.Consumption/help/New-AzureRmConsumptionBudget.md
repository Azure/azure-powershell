---
external help file: Microsoft.Azure.Commands.Consumption.dll-Help.xml
Module Name: AzureRM.Consumption
online version:
schema: 2.0.0
---

# New-AzureRmConsumptionBudget

## SYNOPSIS
Create a budget in either a subscription or a resource group.

## SYNTAX

```
New-AzureRmConsumptionBudget [-DefaultProfile <IAzureContextContainer>] -Amount <Decimal> -Category <String>
 [-EndDate <DateTime>] [-MeterFilter <String[]>] -Name <String> [-ResourceFilter <String[]>]
 [-ResourceGroupFilter <String[]>] [-ResourceGroupName <String>] -StartDate <DateTime> -TimeGrain <String>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzureRmConsumptionBudget cmdlet creates a budget in either a subscription or a resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmConsumptionBudget -Amount 60 -BudgetName PSBudget -Category Cost -StartDate 2018-02-01 -EndDate 2018-11-01 -TimeGrain Monthly
```

This command creates a cost budget with a budget name `PSBudget` in the subscription.

### Example 2
```powershell
PS C:\> New-AzureRmConsumptionBudget -ResourceGroupName RGBudgets -Amount 60 -BudgetName PSBudgetRG -Category Cost -StartDate 2018-02-01 -EndDate 2018-11-01 -TimeGrain Monthly
```

This command creates a cost budget with a budget name `PSBudgetRG` in the resource group `RGBudgets`.

## PARAMETERS

### -Amount
Amount of a budget.

```yaml
Type: Decimal
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Category
Category of the budget can be cost or usage.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Cost, Usage

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndDate
End date (YYYY-MM-DD in UTC) of time period of a budget.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MeterFilter
Comma-separated list of meters to filter on.
Required if category is usage.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of a budget.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceFilter
Comma-separated list of resource instances to filter on.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupFilter
Comma-separated list of resource groups to filter on.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group of a budget.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartDate
Start date (YYYY-MM-DD in UTC) of time period of a budget.
Not prior to current month for monthly time grain.
Not prior to three months for quarterly time grain.
Not prior to twelve months for yearly time grain.
Future start date not more than three months.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeGrain
Time grain of the budget can be monthly, quarterly, or annually.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Monthly, Quarterly, Annually

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None


## OUTPUTS

### Microsoft.Azure.Commands.Consumption.Models.PSBudget


## NOTES

## RELATED LINKS
