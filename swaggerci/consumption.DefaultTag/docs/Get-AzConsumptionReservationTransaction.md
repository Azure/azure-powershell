---
external help file:
Module Name: Az.Consumption
online version: https://learn.microsoft.com/powershell/module/az.consumption/get-azconsumptionreservationtransaction
schema: 2.0.0
---

# Get-AzConsumptionReservationTransaction

## SYNOPSIS
List of transactions for reserved instances on billing account scope.
Note: The refund transactions are posted along with its purchase transaction (i.e.
in the purchase billing month).
For example, The refund is requested in May 2021.
This refund transaction will have event date as May 2021 but the billing month as April 2020 when the reservation purchase was made.
Note: ARM has a payload size limit of 12MB, so currently callers get 400 when the response size exceeds the ARM limit.
In such cases, API call should be made with smaller date ranges.

## SYNTAX

### List (Default)
```
Get-AzConsumptionReservationTransaction -BillingAccountId <String> [-Filter <String>]
 [-PreviewMarkupPercentage <Decimal>] [-UseMarkupIfPartner] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzConsumptionReservationTransaction -BillingAccountId <String> -BillingProfileId <String>
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List of transactions for reserved instances on billing account scope.
Note: The refund transactions are posted along with its purchase transaction (i.e.
in the purchase billing month).
For example, The refund is requested in May 2021.
This refund transaction will have event date as May 2021 but the billing month as April 2020 when the reservation purchase was made.
Note: ARM has a payload size limit of 12MB, so currently callers get 400 when the response size exceeds the ARM limit.
In such cases, API call should be made with smaller date ranges.

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

### -BillingAccountId
BillingAccount ID

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

### -BillingProfileId
Azure Billing Profile ID.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
Filter reservation transactions by date range.
The properties/EventDate for start date and end date.
The filter supports 'le' and 'ge'.
Note: API returns data for the entire start date's and end date's billing month.
For example, filter properties/eventDate+ge+2020-01-01+AND+properties/eventDate+le+2020-12-29 will include data for the entire December 2020 month (i.e.
will contain records for dates December 30 and 31)

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

### -PreviewMarkupPercentage
Preview markup percentage to be applied.

```yaml
Type: System.Decimal
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseMarkupIfPartner
Applies mark up to the transactions if the caller is a partner.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20230301.IModernReservationTransaction

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20230301.IReservationTransaction

## NOTES

ALIASES

## RELATED LINKS

