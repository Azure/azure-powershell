---
external help file:
Module Name: Az.Consumption
online version: https://docs.microsoft.com/en-us/powershell/module/az.consumption/new-azconsumptionbudget
schema: 2.0.0
---

# New-AzConsumptionBudget

## SYNOPSIS
The operation to create or update a budget.
You can optionally provide an eTag if desired as a form of concurrency control.
To obtain the latest eTag for a given budget, perform a get operation prior to your put operation.

## SYNTAX

```
New-AzConsumptionBudget -Name <String> -Scope <String> [-Amount <Decimal>] [-DimensionName <String>]
 [-DimensionValue <String[]>] [-ETag <String>] [-FilterAnd <IBudgetFilterProperties[]>]
 [-Notification <Hashtable>] [-TagName <String>] [-TagValue <String[]>] [-TimeGrain <TimeGrainType>]
 [-TimePeriodEndDate <DateTime>] [-TimePeriodStartDate <DateTime>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a budget.
You can optionally provide an eTag if desired as a form of concurrency control.
To obtain the latest eTag for a given budget, perform a get operation prior to your put operation.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Amount
The total amount of cost to track with the budget

```yaml
Type: System.Decimal
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DimensionName
The name of the column to use in comparison.

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

### -DimensionValue
Array of values to use for comparison

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ETag
eTag of the resource.
To handle concurrent update scenario, this field will be used to determine whether the user is updating the latest version or not.

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

### -FilterAnd
The logical "AND" expression.
Must have at least 2 items.
To construct, see NOTES section for FILTERAND properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20211001.IBudgetFilterProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Budget Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: BudgetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Notification
Dictionary of notifications associated with the budget.
Budget can have up to five notifications.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope associated with budget operations.
This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for resourceGroup scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope, '/providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope.

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

### -TagName
The name of the column to use in comparison.

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

### -TagValue
Array of values to use for comparison

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeGrain
The time covered by a budget.
Tracking of the amount will be reset based on the time grain.
BillingMonth, BillingQuarter, and BillingAnnual are only supported by WD customers

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Consumption.Support.TimeGrainType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimePeriodEndDate
The end date for the budget.
If not provided, we default this to 10 years from the start date.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimePeriodStartDate
The start date for the budget.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20211001.IBudget

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FILTERAND <IBudgetFilterProperties[]>: The logical "AND" expression. Must have at least 2 items.
  - `[DimensionName <String>]`: The name of the column to use in comparison.
  - `[DimensionValue <String[]>]`: Array of values to use for comparison
  - `[TagName <String>]`: The name of the column to use in comparison.
  - `[TagValue <String[]>]`: Array of values to use for comparison

## RELATED LINKS

