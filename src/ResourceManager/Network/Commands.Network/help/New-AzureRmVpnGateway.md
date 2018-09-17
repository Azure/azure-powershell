---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/new-azurermvpngateway
schema: 2.0.0
---

# New-AzureRmVpnGateway

## SYNOPSIS
Creates a Scalable VPN Gateway.

## SYNTAX

### ByVirtualHubName (Default)
```
New-AzureRmVpnGateway -Name <String> -ResourceGroupName <String> -VpnGatewayScaleUnit <UInt32>
 -VirtualHubName <String> [-BgpPeerWeight <UInt32>]
 [-VpnConnection <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVpnConnection]>]
 [-Tag <Hashtable>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVirtualHubObject
```
New-AzureRmVpnGateway -Name <String> -ResourceGroupName <String> -VpnGatewayScaleUnit <UInt32>
 -VirtualHub <PSVirtualHub> [-BgpPeerWeight <UInt32>]
 [-VpnConnection <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVpnConnection]>]
 [-Tag <Hashtable>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVirtualHubResourceId
```
New-AzureRmVpnGateway -Name <String> -ResourceGroupName <String> -VpnGatewayScaleUnit <UInt32>
 -VirtualHubId <String> [-BgpPeerWeight <UInt32>]
 [-VpnConnection <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVpnConnection]>]
 [-Tag <Hashtable>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
New-AzureRmVpnGateway creates a scalable VPN Gateway. This is software defined connectivity for site to site connections inside the VirtualHub. 

This gateway resizes and scales based on the scale unit specified in this or the Set-AzureRmVpnGateway cmdlet. 

A connection is set up from a branch/Site known as VPNSite to the scalable gateway. Each connection comprises of 2 Active-Active tunnels.

The VpnGateway will be in the same location as the referenced VirtualHub.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmResourceGroup -Location "West US" -Name "testRG"
PS C:\> $virtualWan = New-AzureRmVirtualWan -ResourceGroupName testRG -Name myVirtualWAN -Location "West US"
PS C:\> $virtualHub = New-AzureRmVirtualHub -VirtualWan $virtualWan -ResourceGroupName "testRG" -Name "westushub" -AddressPrefix "10.0.0.1/24"
PS C:\> New-AzureRmVpnGateway -ResourceGroupName "testRG" -Name "testvpngw" -VirtualHubId $virtualHub.Id -BGPPeeringWeight 10 -VpnGatewayScaleUnit 2
```

The above will create a resource group, Virtual WAN, Virtual Network, Virtual Hub in West US in "testRG" resource group in Azure. 
A VPN gateway will be created thereafter in the Virtual Hub with 2 scale units.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpPeerWeight
The BgpPeering weight for this VpnGateway.

```yaml
Type: UInt32
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName, VpnGatewayName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
A hashtable which represents resource tags.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHub
The VirtualHub this VpnGateway needs to be associated with.

```yaml
Type: PSVirtualHub
Parameter Sets: ByVirtualHubObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHubId
The Id of the VirtualHub this VpnGateway needs to be associated with.

```yaml
Type: String
Parameter Sets: ByVirtualHubResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHubName
The Id of the VirtualHub this VpnGateway needs to be associated with.

```yaml
Type: String
Parameter Sets: ByVirtualHubName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnConnection
The list of VpnConnections that this VpnGateway needs to have.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVpnConnection]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnGatewayScaleUnit
The scale unit for this VpnGateway.

```yaml
Type: UInt32
Parameter Sets: (All)
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
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVpnGateway

## NOTES

## RELATED LINKS
