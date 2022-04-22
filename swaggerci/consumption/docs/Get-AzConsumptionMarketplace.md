---
external help file:
Module Name: Az.Consumption
online version: https://docs.microsoft.com/en-us/powershell/module/az.consumption/get-azconsumptionmarketplace
schema: 2.0.0
---

# Get-AzConsumptionMarketplace

## SYNOPSIS
Lists the marketplaces for a scope at the defined scope.
Marketplaces are available via this API only for May 1, 2014 or later.

## SYNTAX

```
Get-AzConsumptionMarketplace -Scope <String> [-Filter <String>] [-Skiptoken <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the marketplaces for a scope at the defined scope.
Marketplaces are available via this API only for May 1, 2014 or later.

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

### -Filter
May be used to filter marketplaces by properties/usageEnd (Utc time), properties/usageStart (Utc time), properties/resourceGroup, properties/instanceName or properties/instanceId.
The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'.
It does not currently support 'ne', 'or', or 'not'.

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

### -Scope
The scope associated with marketplace operations.
This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, '/providers/Microsoft.Billing/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope and '/providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope.
For subscription, billing account, department, enrollment account and ManagementGroup, you can also add billing period to the scope using '/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}'.
For e.g.
to specify billing period at department scope use '/providers/Microsoft.Billing/departments/{departmentId}/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}'

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

### -Skiptoken
Skiptoken is only used if a previous operation returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls.

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

### -Top
May be used to limit the number of results to the most recent N marketplaces.

```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20211001.IMarketplace

## NOTES

ALIASES

## RELATED LINKS

