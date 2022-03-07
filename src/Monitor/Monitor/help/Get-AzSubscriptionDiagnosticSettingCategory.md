---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Monitor.dll-Help.xml
Module Name: Az.Monitor
online version: https://docs.microsoft.com/powershell/module/az.monitor/get-azsubscriptiondiagnosticsettingcategory
schema: 2.0.0
---

# Get-AzSubscriptionDiagnosticSettingCategory

## SYNOPSIS
Get diagnostic setting categories for subscription.

## SYNTAX

```
Get-AzSubscriptionDiagnosticSettingCategory [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get diagnostic setting categories for subscription.

## EXAMPLES

### Example 1
```powershell
Get-AzSubscriptionDiagnosticSettingCategory
```

```output
Name            CategoryType
----            ------------
Administrative          Logs
Security                Logs
ServiceHealth           Logs
Alert                   Logs
Recommendation          Logs
Policy                  Logs
Autoscale               Logs
ResourceHealth          Logs
```

Get diagnostic setting categories.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSSubscriptionDiagnosticSettingCategory

## NOTES

## RELATED LINKS
