---
external help file:
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/get-azbillinginvoice
schema: 2.0.0
---

# Get-AzBillingInvoice

## SYNOPSIS
Get the invoice by name.

## SYNTAX

### List2 (Default)
```
Get-AzBillingInvoice -SubscriptionId <String[]> [-Expand <String>] [-Filter <String>] [-Skiptoken <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzBillingInvoice -BillingAccountName <String> -BillingProfileName <String> -PeriodEndDate <String>
 -PeriodStartDate <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzBillingInvoice -BillingAccountName <String> -PeriodEndDate <String> -PeriodStartDate <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzBillingInvoice -BillingAccountName <String> -BillingProfileName <String> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzBillingInvoice -Name <String> -SubscriptionId <String[]> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzBillingInvoice -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzBillingInvoice -InputObject <IBillingIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the invoice by name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -BillingAccountName
billing Account Id.

```yaml
Type: System.String
Parameter Sets: List1, List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BillingProfileName
Billing Profile Id.

```yaml
Type: System.String
Parameter Sets: List1, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Expand
May be used to expand the downloadUrl property within a list of invoices.
This enables download links to be generated for multiple invoices at once.
By default, downloadURLs are not included when listing invoices.

```yaml
Type: System.String
Parameter Sets: List2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Filter
May be used to filter invoices by invoicePeriodEndDate.
The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'.
It does not currently support 'ne', 'or', or 'not'.

```yaml
Type: System.String
Parameter Sets: List2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity
Parameter Sets: GetViaIdentity1, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of an invoice resource.

```yaml
Type: System.String
Parameter Sets: Get, Get1
Aliases: InvoiceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PeriodEndDate
Invoice period end date.

```yaml
Type: System.String
Parameter Sets: List1, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PeriodStartDate
Invoice period start date.

```yaml
Type: System.String
Parameter Sets: List1, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Skiptoken
Skiptoken is only used if a previous operation returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls.

```yaml
Type: System.String
Parameter Sets: List2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String[]
Parameter Sets: List2, Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Top
May be used to limit the number of results to the most recent N invoices.

```yaml
Type: System.Int32
Parameter Sets: List2
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.IBillingIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IInvoiceSummary

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20180301Preview.IInvoice

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20181101Preview.IInvoiceListResult

## ALIASES

## RELATED LINKS

