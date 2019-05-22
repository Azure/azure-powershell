---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvirtualnetworkgatewayconnection
schema: 2.0.0
---

# New-AzVirtualNetworkGatewayConnection

## SYNOPSIS
Creates or updates a virtual network gateway connection in the specified resource group.

## SYNTAX

### Create (Default)
```
New-AzVirtualNetworkGatewayConnection -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <IVirtualNetworkGatewayConnection>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzVirtualNetworkGatewayConnection -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-AuthorizationKey <String>] [-BgpSettingAsn <Int64>] [-BgpSettingBgpPeeringAddress <String>]
 [-BgpSettingPeerWeight <Int32>] [-ConnectionProtocol <VirtualNetworkGatewayConnectionProtocol>]
 [-ConnectionStatu <VirtualNetworkGatewayConnectionStatus>]
 -ConnectionType <VirtualNetworkGatewayConnectionType> [-EnableBgp <Boolean>] [-Etag <String>]
 [-ExpressRouteGatewayBypass <Boolean>] [-GatewayIPAddress <String>] [-Id <String>]
 [-IpsecPolicy <IIpsecPolicy[]>] [-LocalNetworkAddressSpaceAddressPrefix <String[]>]
 [-LocalNetworkGateway2Etag <String>] [-LocalNetworkGateway2Id <String>]
 [-LocalNetworkGateway2Location <String>] [-LocalNetworkGateway2PropertiesResourceGuid <String>]
 [-LocalNetworkGateway2Tags <IResourceTags>] [-Location <String>] [-PeerId <String>] [-ResourceGuid <String>]
 [-RoutingWeight <Int32>] [-SharedKey <String>] [-Tag <IResourceTags>]
 [-UsePolicyBasedTrafficSelector <Boolean>] -VirtualNetworkGateway1 <IVirtualNetworkGateway>
 [-VirtualNetworkGateway2 <IVirtualNetworkGateway>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzVirtualNetworkGatewayConnection -InputObject <INetworkIdentity> [-AuthorizationKey <String>]
 [-BgpSettingAsn <Int64>] [-BgpSettingBgpPeeringAddress <String>] [-BgpSettingPeerWeight <Int32>]
 [-ConnectionProtocol <VirtualNetworkGatewayConnectionProtocol>]
 [-ConnectionStatu <VirtualNetworkGatewayConnectionStatus>]
 -ConnectionType <VirtualNetworkGatewayConnectionType> [-EnableBgp <Boolean>] [-Etag <String>]
 [-ExpressRouteGatewayBypass <Boolean>] [-GatewayIPAddress <String>] [-Id <String>]
 [-IpsecPolicy <IIpsecPolicy[]>] [-LocalNetworkAddressSpaceAddressPrefix <String[]>]
 [-LocalNetworkGateway2Etag <String>] [-LocalNetworkGateway2Id <String>]
 [-LocalNetworkGateway2Location <String>] [-LocalNetworkGateway2PropertiesResourceGuid <String>]
 [-LocalNetworkGateway2Tags <IResourceTags>] [-Location <String>] [-PeerId <String>] [-ResourceGuid <String>]
 [-RoutingWeight <Int32>] [-SharedKey <String>] [-Tag <IResourceTags>]
 [-UsePolicyBasedTrafficSelector <Boolean>] -VirtualNetworkGateway1 <IVirtualNetworkGateway>
 [-VirtualNetworkGateway2 <IVirtualNetworkGateway>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzVirtualNetworkGatewayConnection -InputObject <INetworkIdentity>
 [-Parameter <IVirtualNetworkGatewayConnection>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a virtual network gateway connection in the specified resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorizationKey
The authorizationKey.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpSettingAsn
The BGP speaker's ASN.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpSettingBgpPeeringAddress
The BGP peering address and BGP identifier of this BGP speaker.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpSettingPeerWeight
The weight added to routes learned from this BGP speaker.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionProtocol
Connection protocol used for this connection

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionStatu
Virtual Network Gateway connection status.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionType
Gateway connection type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -EnableBgp
EnableBgp flag

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Etag
Gets a unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteGatewayBypass
Bypass ExpressRoute Gateway for data forwarding

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -GatewayIPAddress
IP address of local network gateway.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

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
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IpsecPolicy
The IPSec Policies to be considered by this connection.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalNetworkAddressSpaceAddressPrefix
A list of address blocks reserved for this virtual network in CIDR notation.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalNetworkGateway2Etag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalNetworkGateway2Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalNetworkGateway2Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalNetworkGateway2PropertiesResourceGuid
The resource GUID property of the LocalNetworkGateway resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalNetworkGateway2Tags
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the virtual network gateway connection.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: VirtualNetworkGatewayConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
A common class for general resource information

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnection
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PeerId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGuid
The resource GUID property of the VirtualNetworkGatewayConnection resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingWeight
The routing weight.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedKey
The IPSec shared key.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsePolicyBasedTrafficSelector
Enable policy-based traffic selectors.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkGateway1
The reference to virtual network gateway resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkGateway2
The reference to virtual network gateway resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnection
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvirtualnetworkgatewayconnection](https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvirtualnetworkgatewayconnection)

