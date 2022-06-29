---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/update-azvirtualhubbgpconnection
schema: 2.0.0
---

# Update-AzVirtualHubBgpConnection

## SYNOPSIS
The Update-AzVirtualHubBgpConnection cmdlet updates an existing HubBgpConnection resource (Virtual WAN Hub BGP Connection).

## SYNTAX

### ByVirtualHubNameByHubVirtualNetworkConnectionObject (Default)
```
Update-AzVirtualHubBgpConnection -ResourceGroupName <String> -VirtualHubName <String> -Name <String>
 -PeerIp <String> -PeerAsn <UInt32> -VirtualHubVnetConnection <PSHubVirtualNetworkConnection> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubNameByHubVirtualNetworkConnectionResourceId
```
Update-AzVirtualHubBgpConnection -ResourceGroupName <String> -VirtualHubName <String> -Name <String>
 -PeerIp <String> -PeerAsn <UInt32> -VirtualHubVnetConnectionId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubObjectByHubVirtualNetworkConnectionObject
```
Update-AzVirtualHubBgpConnection -Name <String> -PeerIp <String> -PeerAsn <UInt32>
 -VirtualHubVnetConnection <PSHubVirtualNetworkConnection> -VirtualHub <PSVirtualHub> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubObjectByHubVirtualNetworkConnectionResourceId
```
Update-AzVirtualHubBgpConnection -Name <String> -PeerIp <String> -PeerAsn <UInt32>
 -VirtualHubVnetConnectionId <String> -VirtualHub <PSVirtualHub> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByHubBgpConnectionResourceIdByHubVirtualNetworkConnectionObject
```
Update-AzVirtualHubBgpConnection -PeerIp <String> -PeerAsn <UInt32>
 -VirtualHubVnetConnection <PSHubVirtualNetworkConnection> -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByHubBgpConnectionResourceIdByHubVirtualNetworkConnectionResourceId
```
Update-AzVirtualHubBgpConnection -PeerIp <String> -PeerAsn <UInt32> -VirtualHubVnetConnectionId <String>
 -ResourceId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByHubBgpConnectionObjectByHubVirtualNetworkConnectionObject
```
Update-AzVirtualHubBgpConnection [-PeerIp <String>] [-PeerAsn <UInt32>]
 -VirtualHubVnetConnection <PSHubVirtualNetworkConnection> -InputObject <PSBgpConnection> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByHubBgpConnectionObjectByHubVirtualNetworkConnectionResourceId
```
Update-AzVirtualHubBgpConnection [-PeerIp <String>] [-PeerAsn <UInt32>] -VirtualHubVnetConnectionId <String>
 -InputObject <PSBgpConnection> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByHubBgpConnectionObject
```
Update-AzVirtualHubBgpConnection [-PeerIp <String>] [-PeerAsn <UInt32>]
 [-VirtualHubVnetConnection <PSHubVirtualNetworkConnection>] [-VirtualHubVnetConnectionId <String>]
 -InputObject <PSBgpConnection> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Update-AzVirtualHubBgpConnection cmdlet updates an existing HubBgpConnection resource (Virtual WAN Hub BGP Connection).

## EXAMPLES

### Example 1
```powershell
New-AzResourceGroup -Location "West US" -Name "testRG"
$frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "192.168.1.0/24"
$backendSubnet  = New-AzVirtualNetworkSubnetConfig -Name backendSubnet  -AddressPrefix "192.168.2.0/24"
$remoteVirtualNetwork = New-AzVirtualNetwork -Name "testVirtualNetwork" -ResourceGroupName "testRG" -Location "West US" -AddressPrefix "192.168.0.0/16" -Subnet $frontendSubnet,$backendSubnet
$virtualWan = New-AzVirtualWan -ResourceGroupName "testRG" -Name "testWan" -Location "West US"
New-AzVirtualHub -VirtualWan $virtualWan -ResourceGroupName "testRG" -Name "testHub" -AddressPrefix "10.0.1.0/24"
$hubVnetConnection = New-AzVirtualHubVnetConnection -ResourceGroupName "testRG" -VirtualHubName "testHub" -Name "testVnetConnection" -RemoteVirtualNetwork $remoteVirtualNetwork
New-AzVirtualHubBgpConnection -ResourceGroupName "testRG" -VirtualHubName "testHub" -PeerIp 192.168.1.5 -PeerAsn 20000 -Name "testBgpConnection" -VirtualHubVnetConnection $hubVnetConnection
Update-AzVirtualHubBgpConnection -ResourceGroupName "testRG" -VirtualHubName "testHub" -PeerIp 192.168.1.6 -PeerAsn 20000 -Name "testBgpConnection" -VirtualHubVnetConnection $hubVnetConnection
```

```output
Name                        : testBgpConnection
Id                          : /subscriptions/{subscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/testHub/bgpConnections/testBgpConnection
HubVirtualNetworkConnection : /subscriptions/{subscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/testHub/hubVirtualNetworkConnections/testVnetConnection
PeerAsn                     : 20000
PeerIp                      : 192.168.1.6
```

The above will create a resource group, Virtual WAN, Virtual Network, Virtual WAN Hub in West US and connect the Virtual Network to the Virtual WAN Hub in that resource group in Azure. A Virtual WAN Hub BGP Connection will be created thereafter which will peer the Virtual WAN Hub with the network appliance deployed in the Virtual Network. This Virtual WAN Hub BGP Connection is then updated to have a different Peer IP.

## PARAMETERS

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

### -InputObject
The virtual hub bgp connection resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSBgpConnection
Parameter Sets: ByHubBgpConnectionObjectByHubVirtualNetworkConnectionObject, ByHubBgpConnectionObjectByHubVirtualNetworkConnectionResourceId, ByHubBgpConnectionObject
Aliases: VirtualHubBgpConnection

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubNameByHubVirtualNetworkConnectionObject, ByVirtualHubNameByHubVirtualNetworkConnectionResourceId, ByVirtualHubObjectByHubVirtualNetworkConnectionObject, ByVirtualHubObjectByHubVirtualNetworkConnectionResourceId
Aliases: ResourceName, BgpConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeerAsn
The peer ASN.

```yaml
Type: System.UInt32
Parameter Sets: ByVirtualHubNameByHubVirtualNetworkConnectionObject, ByVirtualHubNameByHubVirtualNetworkConnectionResourceId, ByVirtualHubObjectByHubVirtualNetworkConnectionObject, ByVirtualHubObjectByHubVirtualNetworkConnectionResourceId, ByHubBgpConnectionResourceIdByHubVirtualNetworkConnectionObject, ByHubBgpConnectionResourceIdByHubVirtualNetworkConnectionResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.UInt32
Parameter Sets: ByHubBgpConnectionObjectByHubVirtualNetworkConnectionObject, ByHubBgpConnectionObjectByHubVirtualNetworkConnectionResourceId, ByHubBgpConnectionObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeerIp
The peer IP.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubNameByHubVirtualNetworkConnectionObject, ByVirtualHubNameByHubVirtualNetworkConnectionResourceId, ByVirtualHubObjectByHubVirtualNetworkConnectionObject, ByVirtualHubObjectByHubVirtualNetworkConnectionResourceId, ByHubBgpConnectionResourceIdByHubVirtualNetworkConnectionObject, ByHubBgpConnectionResourceIdByHubVirtualNetworkConnectionResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ByHubBgpConnectionObjectByHubVirtualNetworkConnectionObject, ByHubBgpConnectionObjectByHubVirtualNetworkConnectionResourceId, ByHubBgpConnectionObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubNameByHubVirtualNetworkConnectionObject, ByVirtualHubNameByHubVirtualNetworkConnectionResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: System.String
Parameter Sets: ByHubBgpConnectionResourceIdByHubVirtualNetworkConnectionObject, ByHubBgpConnectionResourceIdByHubVirtualNetworkConnectionResourceId
Aliases: BgpConnectionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHub
The virtual hub resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualHub
Parameter Sets: ByVirtualHubObjectByHubVirtualNetworkConnectionObject, ByVirtualHubObjectByHubVirtualNetworkConnectionResourceId
Aliases: ParentObject, ParentVirtualHub

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualHubName
The virtual hub name.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubNameByHubVirtualNetworkConnectionObject, ByVirtualHubNameByHubVirtualNetworkConnectionResourceId
Aliases: ParentResourceName, ParentVirtualHubName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHubVnetConnection
The VirtualHubVnetConnection resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection
Parameter Sets: ByVirtualHubNameByHubVirtualNetworkConnectionObject, ByVirtualHubObjectByHubVirtualNetworkConnectionObject, ByHubBgpConnectionResourceIdByHubVirtualNetworkConnectionObject, ByHubBgpConnectionObjectByHubVirtualNetworkConnectionObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection
Parameter Sets: ByHubBgpConnectionObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHubVnetConnectionId
The VirtualHubVnetConnection resource id.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubNameByHubVirtualNetworkConnectionResourceId, ByVirtualHubObjectByHubVirtualNetworkConnectionResourceId, ByHubBgpConnectionResourceIdByHubVirtualNetworkConnectionResourceId, ByHubBgpConnectionObjectByHubVirtualNetworkConnectionResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: ByHubBgpConnectionObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualHub

### Microsoft.Azure.Commands.Network.Models.PSBgpConnection

### Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSBgpConnection

## NOTES

## RELATED LINKS

[New-AzVirtualHubBgpConnection](./Update-AzVirtualHubBgpConnection.md)

[Get-AzVirtualHubBgpConnection](./Get-AzVirtualHubBgpConnection.md)

[Remove-AzVirtualHubBgpConnection](./Remove-AzVirtualHubBgpConnection.md)
