---
external help file:
Module Name: Az.Consumption
online version: https://docs.microsoft.com/en-us/powershell/module/az.consumption/get-azconsumptionpricesheet
schema: 2.0.0
---

# Get-AzConsumptionPriceSheet

## SYNOPSIS
Gets the price sheet for a subscription.
Price sheet is available via this API only for May 1, 2014 or later.

## SYNTAX

### Get (Default)
```
Get-AzConsumptionPriceSheet [-SubscriptionId <String[]>] [-Expand <String>] [-Skiptoken <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzConsumptionPriceSheet -BillingPeriodName <String> [-SubscriptionId <String[]>] [-Expand <String>]
 [-Skiptoken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConsumptionPriceSheet -InputObject <IConsumptionIdentity> [-Expand <String>] [-Skiptoken <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzConsumptionPriceSheet -InputObject <IConsumptionIdentity> [-Expand <String>] [-Skiptoken <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the price sheet for a subscription.
Price sheet is available via this API only for May 1, 2014 or later.

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

### -BillingPeriodName
Billing Period Name.

```yaml
Type: System.String
Parameter Sets: Get1
Aliases:

Required: True
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

### -Expand
May be used to expand the properties/meterDetails within a price sheet.
By default, these fields are not included when returning price sheet.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.IConsumptionIdentity
Parameter Sets: GetViaIdentity, GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, Get1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
May be used to limit the number of results to the top N results.

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

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.IConsumptionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20211001.IPriceSheetResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IConsumptionIdentity>: Identity Parameter
  - `[BillingAccountId <String>]`: BillingAccount ID
  - `[BillingPeriodName <String>]`: Billing Period Name.
  - `[BillingProfileId <String>]`: Azure Billing Profile ID.
  - `[BudgetName <String>]`: Budget Name.
  - `[CustomerId <String>]`: Customer ID
  - `[Id <String>]`: Resource identity path
  - `[ManagementGroupId <String>]`: Azure Management Group ID.
  - `[ReservationId <String>]`: Id of the reservation
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[Scope <String>]`: The scope associated with usage details operations. This includes '/subscriptions/{subscriptionId}/' for subscription scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for Billing Account scope, '/providers/Microsoft.Billing/departments/{departmentId}' for Department scope, '/providers/Microsoft.Billing/enrollmentAccounts/{enrollmentAccountId}' for EnrollmentAccount scope and '/providers/Microsoft.Management/managementGroups/{managementGroupId}' for Management Group scope. For subscription, billing account, department, enrollment account and management group, you can also add billing period to the scope using '/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}'. For e.g. to specify billing period at department scope use '/providers/Microsoft.Billing/departments/{departmentId}/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}'. Also, Modern Commerce Account scopes are '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}' for billingAccount scope, '/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}' for billingProfile scope, 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/invoiceSections/{invoiceSectionId}' for invoiceSection scope, and 'providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}' specific for partners.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

## RELATED LINKS

