---
external help file:
Module Name: Az.Cost
online version: https://docs.microsoft.com/en-us/powershell/module/az.cost/get-azcostalertexternal
schema: 2.0.0
---

# Get-AzCostAlertExternal

## SYNOPSIS
Lists the Alerts for external cloud provider type defined.

## SYNTAX

```
Get-AzCostAlertExternal -ExternalCloudProviderId <String>
 -ExternalCloudProviderType <ExternalCloudProviderType> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the Alerts for external cloud provider type defined.

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

### -ExternalCloudProviderId
This can be '{externalSubscriptionId}' for linked account or '{externalBillingAccountId}' for consolidated account used with dimension/query operations.

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

### -ExternalCloudProviderType
The external cloud provider type associated with dimension/query operations.
This includes 'externalSubscriptions' for linked account and 'externalBillingAccounts' for consolidated account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cost.Support.ExternalCloudProviderType
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Cost.Models.Api20211001.IAlertsResult

## NOTES

ALIASES

## RELATED LINKS

