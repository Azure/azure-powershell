---
external help file:
Module Name: Az.PowerBiDedicated
online version: https://docs.microsoft.com/en-us/powershell/module/az.powerbidedicated/get-azpowerbidedicatedcapacitysku
schema: 2.0.0
---

# Get-AzPowerBiDedicatedCapacitySku

## SYNOPSIS
Lists eligible SKUs for PowerBI Dedicated resource provider.

## SYNTAX

### List (Default)
```
Get-AzPowerBiDedicatedCapacitySku [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzPowerBiDedicatedCapacitySku -DedicatedCapacityName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists eligible SKUs for PowerBI Dedicated resource provider.

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

### -DedicatedCapacityName
The name of the Dedicated capacity.
It must be at least 3 characters in length, and no more than 63.

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

### -ResourceGroupName
The name of the Azure Resource group of which a given PowerBIDedicated capacity is part.
This name must be at least 1 character in length, and no more than 90.

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

### -SubscriptionId
A unique identifier for a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Models.Api202101.ICapacitySku

### Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Models.Api202101.ISkuDetailsForExistingResource

## NOTES

ALIASES

## RELATED LINKS

