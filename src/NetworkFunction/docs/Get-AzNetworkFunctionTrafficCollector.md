---
external help file:
Module Name: Az.NetworkFunction
online version: https://docs.microsoft.com/en-us/powershell/module/az.networkfunction/get-aznetworkfunctiontrafficcollector
schema: 2.0.0
---

# Get-AzNetworkFunctionTrafficCollector

## SYNOPSIS
Gets the specified Azure Traffic Collector in a specified resource group

## SYNTAX

### List (Default)
```
Get-AzNetworkFunctionTrafficCollector [-ResourceGroupName <String>] [-SubscriptionId <String>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkFunctionTrafficCollector -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFunctionTrafficCollector -InputObject <ITrafficCollectorIdentity> [<CommonParameters>]
```

## DESCRIPTION
Gets the specified Azure Traffic Collector in a specified resource group

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
Parameter Sets: Get
Aliases: AzureRMContext, AzureCredential

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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20210501.ITrafficCollectorIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Azure Traffic Collector name

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20210501.ITrafficCollectorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkFunction.Models.Api20210501.IAzureTrafficCollector

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ITrafficCollectorIdentity>: Identity Parameter
  - `[AzureTrafficCollectorName <String>]`: Azure Traffic Collector name
  - `[CollectorPolicyName <String>]`: Collector Policy Name
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

## RELATED LINKS

