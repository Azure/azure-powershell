---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azvirtualnetworkgatewayvpnclientconnectionhealth
schema: 2.0.0
---

# Get-AzVirtualNetworkGatewayVpnclientConnectionHealth

## SYNOPSIS
Get the list of vpn client connection health of an Azure virtual network gateway for per vpn client connection

## SYNTAX

```
Get-AzVirtualNetworkGatewayVpnclientConnectionHealth -VirtualNetworkGatewayName <String> -ResourceGroupName <String> -InputObject <PSVirtualNetworkGateway> -ResourceId <ResourceId>
 [-AsJob] [<CommonParameters>]
```

## DESCRIPTION
List  all connected vpn client connection health. This includes:
vpnConnectionId
vpnConnectionDuration
vpnConnectionTime
publicIpAddress
privateIpAddress
vpnUserName
maxBandwidth
egressPacketsTransferred
egressBytesTransferred
ingressPacketsTransferred
ingressBytesTransferred
maxPacketsPerSecond

## EXAMPLES

### Example 1
```
PS C:\> Get-AzVirtualNetworkGatewayVpnclientConnectionHealth -ResourceGroupName resourceGroup -VirtualNetworkGatewayName gatewayName

	vpnConnectionId: IKEv2_1e1cfe59-5c7c-4315-a876-b11fbfdfeed4,
	vpnConnectionDuration: 900,
	vpnConnectionTime: 2019-05-02T22:26:22,
	publicIpAddress: 167.220.2.232:45522,
	privateIpAddress: 192.168.210.2,
	vpnUserName: gwp2sclientcert,
	maxBandwidth: 240000000,
	egressPacketsTransferred: 557,
	egressBytesTransferred: 33420,
	ingressPacketsTransferred: 557,
	ingressBytesTransferred: 33420,
	maxPacketsPerSecond: 4
```

For the Azure virtual network gateway named gatewayname in resource group resourceGroup, retrieves the currently connected vpn client connection by using IkeV2. 

## PARAMETERS

### -ResourceGroupName
Virtual network gateway resource group's name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkGatewayName
Virtual network gateway name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```
### -ResourceId
Virtual network gateway resource Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceId

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
Virtual network gateway object

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGateway
Parameter Sets: (All)
Aliases: VirtualNetworkGateway

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSGatewayRoute

## NOTES

## RELATED LINKS
