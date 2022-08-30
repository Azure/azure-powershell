---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azvirtualhubbgpconnection
schema: 2.0.0
---

# New-AzVirtualHubBgpConnection

## SYNOPSIS
The New-AzVirtualHubBgpConnection cmdlet creates a HubBgpConnection resource that peers the Azure Virtual WAN Hub Router with a BGP-enabled peer in a virtual network connected to the Virtual WAN Hub.

## SYNTAX

### ByVirtualHubNameByHubVirtualNetworkConnectionObject (Default)
```
New-AzVirtualHubBgpConnection -ResourceGroupName <String> -VirtualHubName <String> -PeerIp <String>
 -PeerAsn <UInt32> -Name <String> -VirtualHubVnetConnection <PSHubVirtualNetworkConnection> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubNameByHubVirtualNetworkConnectionResourceId
```
New-AzVirtualHubBgpConnection -ResourceGroupName <String> -VirtualHubName <String> -PeerIp <String>
 -PeerAsn <UInt32> -Name <String> -VirtualHubVnetConnectionId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubObjectByHubVirtualNetworkConnectionObject
```
New-AzVirtualHubBgpConnection -PeerIp <String> -PeerAsn <UInt32> -Name <String>
 -VirtualHubVnetConnection <PSHubVirtualNetworkConnection> -VirtualHub <PSVirtualHub> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubResourceIdByHubVirtualNetworkConnectionObject
```
New-AzVirtualHubBgpConnection -PeerIp <String> -PeerAsn <UInt32> -Name <String>
 -VirtualHubVnetConnection <PSHubVirtualNetworkConnection> -VirtualHubId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubObjectByHubVirtualNetworkConnectionResourceId
```
New-AzVirtualHubBgpConnection -PeerIp <String> -PeerAsn <UInt32> -Name <String>
 -VirtualHubVnetConnectionId <String> -VirtualHub <PSVirtualHub> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubResourceIdByHubVirtualNetworkConnectionResourceId
```
New-AzVirtualHubBgpConnection -PeerIp <String> -PeerAsn <UInt32> -Name <String>
 -VirtualHubVnetConnectionId <String> -VirtualHubId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVirtualHubBgpConnection cmdlet creates a HubBgpConnection resource that peers Azure Virtual WAN Hub Router with a BGP-enabled peer in virtual network connected to the Virtual WAN Hub.

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
```

```output
Name                        : testBgpConnection
Id                          : /subscriptions/{subscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/testHub/bgpConnections/testBgpConnection
HubVirtualNetworkConnection : /subscriptions/{subscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/testHub/hubVirtualNetworkConnections/testVnetConnection
PeerAsn                     : 20000
PeerIp                      : 192.168.1.5
```

The above will create a resource group, Virtual WAN, Virtual Network, Virtual WAN Hub in West US and connect the Virtual Network to the Virtual WAN Hub in that resource group in Azure. A Virtual WAN Hub BGP Connection will be created thereafter which will peer the Virtual WAN Hub with the network appliance deployed in the Virtual Network.

### Example 2
```powershell
$hubVnetConnection = Get-AzVirtualHubVnetConnection -ResourceGroupName "testRG" -VirtualHubName "testHub" -Name "testVnetConnection"
Get-AzVirtualHub -ResourceGroupName "testRG" -Name "testHub" | New-AzVirtualHubBgpConnection -PeerIp 192.168.1.5 -PeerAsn 20000 -Name "testBgpConnection" -VirtualHubVnetConnection $hubVnetConnection
```

```output
Name                        : testBgpConnection
Id                          : /subscriptions/{subscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/testHub/bgpConnections/testBgpConnection
HubVirtualNetworkConnection : /subscriptions/{subscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/testHub/hubVirtualNetworkConnections/testVnetConnection
PeerAsn                     : 20000
PeerIp                      : 192.168.1.5
```

The above will create a Virtual WAN Hub BGP Connection for existing Virtual WAN Hub and Virtual WAN Hub Vnet Connection using powershell piping on the output from Get-AzVirtualHub.

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

### -Name
The resource name.

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

### -PeerAsn
The peer ASN.

```yaml
Type: System.UInt32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeerIp
The peer IP.

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

### -VirtualHubId
The virtual hub resource id.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubResourceIdByHubVirtualNetworkConnectionObject, ByVirtualHubResourceIdByHubVirtualNetworkConnectionResourceId
Aliases: ParentResourceId, ParentVirtualHubId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHubName
The virtual hub name.

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

### -VirtualHubVnetConnection
The VirtualHubVnetConnection resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection
Parameter Sets: ByVirtualHubNameByHubVirtualNetworkConnectionObject, ByVirtualHubObjectByHubVirtualNetworkConnectionObject, ByVirtualHubResourceIdByHubVirtualNetworkConnectionObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHubVnetConnectionId
The VirtualHubVnetConnection resource id.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubNameByHubVirtualNetworkConnectionResourceId, ByVirtualHubObjectByHubVirtualNetworkConnectionResourceId, ByVirtualHubResourceIdByHubVirtualNetworkConnectionResourceId
Aliases:

Required: True
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

### Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSBgpConnection

## NOTES

## RELATED LINKS

[Get-AzVirtualHubBgpConnection](./Get-AzVirtualHubBgpConnection.md)

[Remove-AzVirtualHubBgpConnection](./Remove-AzVirtualHubBgpConnection.md)

[Update-AzVirtualHubBgpConnection](./Update-AzVirtualHubBgpConnection.md)
