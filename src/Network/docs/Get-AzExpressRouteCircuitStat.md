---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azexpressroutecircuitstat
schema: 2.0.0
---

# Get-AzExpressRouteCircuitStat

## SYNOPSIS
Gets all the stats from an express route circuit in a resource group.

## SYNTAX

### Get (Default)
```
Get-AzExpressRouteCircuitStat -CircuitName <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzExpressRouteCircuitStat -CircuitName <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzExpressRouteCircuitStat -InputObject <INetworkIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets all the stats from an express route circuit in a resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -CircuitName
The name of the express route circuit.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitStats
### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitStats
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/get-azexpressroutecircuitstat](https://docs.microsoft.com/en-us/powershell/module/az.network/get-azexpressroutecircuitstat)

