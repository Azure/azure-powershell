---
external help file: Microsoft.Azure.Commands.Consumption.dll-Help.xml
Module Name: AzureRM.Consumption
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.consumption/set-azurermconsumptionbudget
schema: 2.0.0
---

# Set-AzureRmConsumptionBudget

## SYNOPSIS
Update a budget in either a subscription or a resource group.

## SYNTAX

```
Set-AzureRmConsumptionBudget [-DefaultProfile <IAzureContextContainer>] [-Amount <Decimal>]
 [-Category <String>] [-ContactEmail <String[]>] [-ContactGroup <String[]>] [-ContactRole <String[]>]
 [-EndDate <DateTime>] [-MeterFilter <String[]>] -Name <String> [-NotificationEnabled] [-NotificationDisabled]
 [-NotificationKey <String>] [-NotificationThreshold <Decimal>] [-ResourceFilter <String[]>]
 [-ResourceGroupFilter <String[]>] [-ResourceGroupName <String>] [-StartDate <DateTime>] [-TimeGrain <String>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Set-AzureRmConsumptionBudget cmdlet updates a budget in either a subscription or a resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-AzureRmConsumptionBudget -BudgetName PSBudget -Amount 75
```

This command updates a cost budget by a new amount with a budget name `PSBudget` in the subscription.

### Example 2
```powershell
PS C:\> Set-AzureRmConsumptionBudget -ResourceGroupName RGBudgets -BudgetName PSBudget -Amount 75
```

This command updates a cost budget by a new amount with a budget name `PSBudgetRG` in the resource group `RGBudgets`.

## PARAMETERS

### -Amount
Amount of a budget.

```yaml
Type: Decimal
Parameter Sets: (All)
Aliases:

Required: False
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

Required: False
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

### -ContactEmail
Email addresses to send the budget notification to when the threshold is exceeded.

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

### -ContactGroup
Action groups to send the budget notification to when the threshold is exceeded.

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

### -ContactRole
Contact roles to send the budget notification to when the threshold is exceeded.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:
Accepted values: Owner, Reader, Contributor

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

### -NotificationDisabled
The notification is disabled or not.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationEnabled
The notification is enabled or not.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationKey
Key of a notification associated with a budget, required to create a notification with notification enabled switch, notification threshold, contact emails, contact groups, or contact roles.

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

### -NotificationThreshold
Threshold value associated with a notification.
Notification is sent when the cost or usage exceeded the threshold.
It is always percent and has to be between 0 and 1000.

```yaml
Type: Decimal
Parameter Sets: (All)
Aliases:

Required: False
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

Required: False
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

Required: False
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
