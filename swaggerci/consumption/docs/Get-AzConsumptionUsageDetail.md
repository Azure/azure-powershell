---
external help file:
Module Name: Az.Consumption
online version: https://docs.microsoft.com/en-us/powershell/module/az.consumption/get-azconsumptionusagedetail
schema: 2.0.0
---

# Get-AzConsumptionUsageDetail

## SYNOPSIS
Lists the usage details for the defined scope.
Usage details are available via this API only for May 1, 2014 or later.

## SYNTAX

```
Get-AzConsumptionUsageDetail -Scope <String> [-Expand <String>] [-Filter <String>] [-Metric <Metrictype>]
 [-Skiptoken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Lists the usage details for the defined scope.
Usage details are available via this API only for May 1, 2014 or later.

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

### -Expand
May be used to expand the properties/additionalInfo or properties/meterDetails within a list of usage details.
By default, these fields are not included when listing usage details.

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

### -Filter
May be used to filter usageDetails by properties/resourceGroup, properties/resourceName, properties/resourceId, properties/chargeType, properties/reservationId, properties/publisherType or tags.
The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'.
It does not currently support 'ne', 'or', or 'not'.
Tag filter is a key value pair string where key and value is separated by a colon (:).
PublisherType Filter accepts two values azure and marketplace and it is currently supported for Web Direct Offer Type

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

### -Metric
Allows to select different type of cost/usage records.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Consumption.Support.Metrictype
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope associated with usage details operations.
This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, '/providers/Microsoft.Billing/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope and '/providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope.
For subscription, billing account, department, enrollment account and management group, you can also add billing period to the scope using '/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}'.
For e.g.
to specify billing period at department scope use '/providers/Microsoft.Billing/departments/{departmentId}/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}'.
Also, Modern Commerce Account scopes are '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for billingAccount scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.

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
May be used to limit the number of results to the most recent N usageDetails.

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

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20211001.IUsageDetail

## NOTES

ALIASES

## RELATED LINKS

