---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azeventcategory
schema: 2.0.0
---

# Get-AzEventCategory

## SYNOPSIS
Get the list of available event categories supported in the Activity Logs Service.
The current list includes the following: Administrative, Security, ServiceHealth, Alert, Recommendation, Policy.

## SYNTAX

```
Get-AzEventCategory [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the list of available event categories supported in the Activity Logs Service.
The current list includes the following: Administrative, Security, ServiceHealth, Alert, Recommendation, Policy.

## EXAMPLES

### Example 1: List event categories
```powershell
Get-AzEventCategory
```

```output
LocalizedValue  Value
--------------  -----
Administrative  Administrative
Security        Security
Service Health  ServiceHealth
Alert           Alert
Recommendation  Recommendation
Policy          Policy
Autoscale       Autoscale
Resource Health ResourceHealth
```

List event categories, these are also supported diagnostic setting categories for subscription

## PARAMETERS

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20150401.ILocalizableString

## NOTES

## RELATED LINKS

