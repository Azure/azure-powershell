---
external help file:
Module Name: Az.Consumption
online version: https://docs.microsoft.com/en-us/powershell/module/az.consumption/get-azconsumptionevent
schema: 2.0.0
---

# Get-AzConsumptionEvent

## SYNOPSIS
Lists the events that decrements Azure credits or Microsoft Azure consumption commitment for a billing account or a billing profile for a given start and end date.

## SYNTAX

### List1 (Default)
```
Get-AzConsumptionEvent -BillingAccountId <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzConsumptionEvent -BillingAccountId <String> -BillingProfileId <String> -EndDate <String>
 -StartDate <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the events that decrements Azure credits or Microsoft Azure consumption commitment for a billing account or a billing profile for a given start and end date.

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
Parameter Sets: List
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

### -EndDate
End date

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
May be used to filter the events by lotId, lotSource etc.
The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'.
It does not currently support 'ne', 'or', or 'not'.
Tag filter is a key value pair string where key and value is separated by a colon (:).

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartDate
Start date

```yaml
Type: System.String
Parameter Sets: List
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Consumption.Models.Api20211001.IEventSummary

## NOTES

ALIASES

## RELATED LINKS

