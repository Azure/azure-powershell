---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagerconnectivitycapabilities
schema: 2.0.0
---

# New-AzNetworkManagerConnectivityCapabilities

## SYNOPSIS
Creates a connectivity group item.

## SYNTAX

```
New-AzNetworkManagerConnectivityCapabilities -ConnectedGroupPrivateEndpointScale <String> -ConnectedGroupAddressOverlap <String> -PeeringEnforcement <String>
```

## DESCRIPTION
The **New-AzNetworkManagerConnectivityCapabilities** cmdlet creates an object for configuring connectivity capabilities.
## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerConnectivityCapabilities -ConnectedGroupPrivateEndpointScale "HighScale" -ConnectedGroupAddressOverlap "Disallowed" -PeeringEnforcement "Enforced"
```

Creates a connectivity capabilities object.

### Example 2
```powershell
New-AzNetworkManagerConnectivityCapabilities -ConnectedGroupPrivateEndpointScale "Standard" -ConnectedGroupAddressOverlap "Allowed" -PeeringEnforcement "Unenforced"
```

Creates a connectivity capabilities object.

## PARAMETERS

### -ConnectedGroupPrivateEndpointScale
Group Connectivity.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Standard, HighScale

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ConnectedGroupAddressOverlap
Network Group Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Allowed, Disallowed

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeeringEnforcement
Network Group Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Enforced, Unenforced

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.String

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityCapabilities

## NOTES

## RELATED LINKS

[New-AzNetworkManagerConnectivityConfiguration](./New-AzNetworkManagerConnectivityConfiguration.md)
[Set-AzNetworkManagerConnectivityConfiguration](./Set-AzNetworkManagerConnectivityConfiguration.md)
