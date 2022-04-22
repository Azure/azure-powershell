---
external help file:
Module Name: Az.Consumption
online version: https://docs.microsoft.com/en-us/powershell/module/az.consumption/get-azconsumptionreservationtransaction
schema: 2.0.0
---

# Get-AzConsumptionReservationTransaction

## SYNOPSIS
List of transactions for reserved instances on billing account scope

## SYNTAX

### List (Default)
```
Get-AzConsumptionReservationTransaction -BillingAccountId <String> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzConsumptionReservationTransaction -BillingAccountId <String> -BillingProfileId <String>
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List of transactions for reserved instances on billing account scope

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
Filter reservation transactions by date range.
The properties/EventDate for start date and end date.
The filter supports 'le' and 'ge'

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20211001.IModernReservationTransaction

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20211001.IReservationTransaction

## NOTES

ALIASES

## RELATED LINKS

