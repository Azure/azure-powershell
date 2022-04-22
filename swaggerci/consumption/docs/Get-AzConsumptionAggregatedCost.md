---
external help file:
Module Name: Az.Consumption
online version: https://docs.microsoft.com/en-us/powershell/module/az.consumption/get-azconsumptionaggregatedcost
schema: 2.0.0
---

# Get-AzConsumptionAggregatedCost

## SYNOPSIS
Provides the aggregate cost of a management group and all child management groups by current billing period.

## SYNTAX

### Get (Default)
```
Get-AzConsumptionAggregatedCost -ManagementGroupId <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get1
```
Get-AzConsumptionAggregatedCost -BillingPeriodName <String> -ManagementGroupId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConsumptionAggregatedCost -InputObject <IConsumptionIdentity> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzConsumptionAggregatedCost -InputObject <IConsumptionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Provides the aggregate cost of a management group and all child management groups by current billing period.

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

### -Filter
May be used to filter aggregated cost by properties/usageStart (Utc time), properties/usageEnd (Utc time).
The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'.
It does not currently support 'ne', 'or', or 'not'.
Tag filter is a key value pair string where key and value is separated by a colon (:).

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
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

### -ManagementGroupId
Azure Management Group ID.

```yaml
Type: System.String
Parameter Sets: Get, Get1
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

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.IConsumptionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20211001.IManagementGroupAggregatedCostResult

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

