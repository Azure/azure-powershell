---
external help file: Microsoft.Azure.Commands.Consumption.dll-Help.xml
Module Name: AzureRM.Consumption
online version:
schema: 2.0.0
---

# Get-AzureRmConsumptionBudget

## SYNOPSIS
Get a list of budgets in either a subscription or a resource group.

## SYNTAX

```
Get-AzureRmConsumptionBudget [-DefaultProfile <IAzureContextContainer>] [-ResourceGroupName <String>]
 [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmConsumptionBudget cmdlet gets a list of budgets in either a subscription or a resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmConsumptionBudget
```

This command gets a list of budgets in the subscription.

### Example 2
```powershell
PS C:\> Get-AzureRmConsumptionBudget -ResourceGroupName RGBudgets
```

This command gets a list of budgets in the resource group `RGBudgets`.

### Example 3
```powershell
PS C:\> Get-AzureRmConsumptionBudget -Name PSBudget
```

This command gets a list of budgets including a single budget with the budget name `PSBudget`.

### Example 4
```powershell
PS C:\> Get-AzureRmConsumptionBudget -ResourceGroupName RGBudgets -Name PSBudgetRG
```

This command gets a list of budgets including a single budget with the budget name `PSBudgetRG` in the resource group `RGBudgets`.

## PARAMETERS

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

### -Name
Name of a budget.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None


## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Consumption.Models.PSBudget, Microsoft.Azure.Commands.Consumption, Version=0.3.3.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS
