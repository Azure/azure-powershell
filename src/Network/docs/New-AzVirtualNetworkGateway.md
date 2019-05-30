---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvirtualnetworkgateway
schema: 2.0.0
---

# New-AzVirtualNetworkGateway

## SYNOPSIS
Creates or updates a virtual network gateway in the specified resource group.

## SYNTAX

### Create (Default)
```
New-AzVirtualNetworkGateway -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <IVirtualNetworkGateway>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzVirtualNetworkGateway -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Active <Boolean>] [-BgpSettingAsn <Int64>] [-BgpSettingBgpPeeringAddress <String>]
 [-BgpSettingPeerWeight <Int32>] [-CustomRouteAddressPrefix <String[]>] [-EnableBgp <Boolean>] [-Etag <String>]
 [-GatewayDefaultSiteId <String>] [-GatewayType <VirtualNetworkGatewayType>]
 [-IPConfiguration <IVirtualNetworkGatewayIPConfiguration[]>] [-Id <String>] [-Location <String>]
 [-ResourceGuid <String>] [-SkuCapacity <Int32>] [-SkuName <VirtualNetworkGatewaySkuName>]
 [-SkuTier <VirtualNetworkGatewaySkuTier>] [-Tag <IResourceTags>]
 [-VpnClientAddressPoolAddressPrefix <String[]>] [-VpnClientConfigurationRadiusServerAddress <String>]
 [-VpnClientConfigurationRadiusServerSecret <String>]
 [-VpnClientConfigurationVpnClientIpsecPolicy <IIpsecPolicy[]>]
 [-VpnClientConfigurationVpnClientProtocol <VpnClientProtocol[]>]
 [-VpnClientConfigurationVpnClientRevokedCertificate <IVpnClientRevokedCertificate[]>]
 [-VpnClientConfigurationVpnClientRootCertificate <IVpnClientRootCertificate[]>] [-VpnType <VpnType>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzVirtualNetworkGateway -InputObject <INetworkIdentity> [-Active <Boolean>] [-BgpSettingAsn <Int64>]
 [-BgpSettingBgpPeeringAddress <String>] [-BgpSettingPeerWeight <Int32>] [-CustomRouteAddressPrefix <String[]>]
 [-EnableBgp <Boolean>] [-Etag <String>] [-GatewayDefaultSiteId <String>]
 [-GatewayType <VirtualNetworkGatewayType>] [-IPConfiguration <IVirtualNetworkGatewayIPConfiguration[]>]
 [-Id <String>] [-Location <String>] [-ResourceGuid <String>] [-SkuCapacity <Int32>]
 [-SkuName <VirtualNetworkGatewaySkuName>] [-SkuTier <VirtualNetworkGatewaySkuTier>] [-Tag <IResourceTags>]
 [-VpnClientAddressPoolAddressPrefix <String[]>] [-VpnClientConfigurationRadiusServerAddress <String>]
 [-VpnClientConfigurationRadiusServerSecret <String>]
 [-VpnClientConfigurationVpnClientIpsecPolicy <IIpsecPolicy[]>]
 [-VpnClientConfigurationVpnClientProtocol <VpnClientProtocol[]>]
 [-VpnClientConfigurationVpnClientRevokedCertificate <IVpnClientRevokedCertificate[]>]
 [-VpnClientConfigurationVpnClientRootCertificate <IVpnClientRootCertificate[]>] [-VpnType <VpnType>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzVirtualNetworkGateway -InputObject <INetworkIdentity> [-Parameter <IVirtualNetworkGateway>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a virtual network gateway in the specified resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Active
ActiveActive flag

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

### -CustomRouteAddressPrefix
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
Whether BGP is enabled for this virtual network gateway or not.

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

### -GatewayDefaultSiteId
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

### -GatewayType
The type of this virtual network gateway.
Possible values are: 'Vpn' and 'ExpressRoute'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayType
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

### -IPConfiguration
IP configurations for virtual network gateway.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfiguration[]
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
The name of the virtual network gateway.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: VirtualNetworkGatewayName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
A common class for general resource information

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The resource GUID property of the VirtualNetworkGateway resource.

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

### -SkuCapacity
The capacity.

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

### -SkuName
Gateway SKU name.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuName
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
Gateway SKU tier.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTier
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

### -VpnClientAddressPoolAddressPrefix
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

### -VpnClientConfigurationRadiusServerAddress
The radius server address property of the VirtualNetworkGateway resource for vpn client connection.

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

### -VpnClientConfigurationRadiusServerSecret
The radius secret property of the VirtualNetworkGateway resource for vpn client connection.

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

### -VpnClientConfigurationVpnClientIpsecPolicy
VpnClientIpsecPolicies for virtual network gateway P2S client.

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

### -VpnClientConfigurationVpnClientProtocol
VpnClientProtocols for Virtual network gateway.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnClientProtocol[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnClientConfigurationVpnClientRevokedCertificate
VpnClientRevokedCertificate for Virtual network gateway.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRevokedCertificate[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnClientConfigurationVpnClientRootCertificate
VpnClientRootCertificate for virtual network gateway.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientRootCertificate[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnType
The type of this virtual network gateway.
Possible values are: 'PolicyBased' and 'RouteBased'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnType
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvirtualnetworkgateway](https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvirtualnetworkgateway)

