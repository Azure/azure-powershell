---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/new-azpeering
schema: 2.0.0
---

# New-AzPeering

## SYNOPSIS
Creates a new peering or updates an existing peering with the specified name under the given subscription and resource group.

## SYNTAX

```
New-AzPeering -Name <String> -ResourceGroupName <String> -Kind <Kind> -Location <String>
 [-SubscriptionId <String>] [-DirectConnection <IDirectConnection[]>] [-DirectPeerAsnId <String>]
 [-DirectPeeringType <DirectPeeringType>] [-ExchangeConnection <IExchangeConnection[]>]
 [-ExchangePeerAsnId <String>] [-PeeringLocation <String>] [-Sku <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new peering or updates an existing peering with the specified name under the given subscription and resource group.

## EXAMPLES

### Example 1: Create a new direct peering object
```powershell
$connection1 = New-AzPeeringDirectConnectionObject -BandwidthInMbps 10000 -BgpSessionMaxPrefixesAdvertisedV4 20000 ...
$directConnections = ,$connection1
New-AzPeering -Name TestPeeringPs -ResourceGroupName DemoRG -Kind Direct -Location "South Central US" -DirectConnection $directConnections -DirectPeeringType Cdn -DirectPeerAsnId $peerAsnId -PeeringLocation Dallas -Sku Premium_Direct_Unlimited
```

```output
Name        SkuName                  Kind   PeeringLocation ProvisioningState Location
----        -------                  ----   --------------- ----------------- --------
TestPeering Premium_Direct_Unlimited Direct Dallas          Succeeded         South Central US
```

Create a new direct peering object

## PARAMETERS

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

### -DirectConnection
The set of connections that constitute a direct peering.
To construct, see NOTES section for DIRECTCONNECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IDirectConnection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DirectPeerAsnId
The identifier of the referenced resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DirectPeeringType
The type of direct peering.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.DirectPeeringType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExchangeConnection
The set of connections that constitute an exchange peering.
To construct, see NOTES section for EXCHANGECONNECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IExchangeConnection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExchangePeerAsnId
The identifier of the referenced resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
The kind of the peering.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.Kind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the resource.

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

### -Name
The name of the peering.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PeeringName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringLocation
The location of the peering.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The name of the peering SKU.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SkuName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeering

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`DIRECTCONNECTION <IDirectConnection[]>`: The set of connections that constitute a direct peering.
  - `[BandwidthInMbps <Int32?>]`: The bandwidth of the connection.
  - `[BgpSessionMaxPrefixesAdvertisedV4 <Int32?>]`: The maximum number of prefixes advertised over the IPv4 session.
  - `[BgpSessionMaxPrefixesAdvertisedV6 <Int32?>]`: The maximum number of prefixes advertised over the IPv6 session.
  - `[BgpSessionMd5AuthenticationKey <String>]`: The MD5 authentication key of the session.
  - `[BgpSessionMicrosoftSessionIPv4Address <String>]`: The IPv4 session address on Microsoft's end.
  - `[BgpSessionMicrosoftSessionIPv6Address <String>]`: The IPv6 session address on Microsoft's end.
  - `[BgpSessionPeerSessionIPv4Address <String>]`: The IPv4 session address on peer's end.
  - `[BgpSessionPeerSessionIPv6Address <String>]`: The IPv6 session address on peer's end.
  - `[BgpSessionPrefixV4 <String>]`: The IPv4 prefix that contains both ends' IPv4 addresses.
  - `[BgpSessionPrefixV6 <String>]`: The IPv6 prefix that contains both ends' IPv6 addresses.
  - `[ConnectionIdentifier <String>]`: The unique identifier (GUID) for the connection.
  - `[PeeringDbFacilityId <Int32?>]`: The PeeringDB.com ID of the facility at which the connection has to be set up.
  - `[SessionAddressProvider <SessionAddressProvider?>]`: The field indicating if Microsoft provides session ip addresses.
  - `[UseForPeeringService <Boolean?>]`: The flag that indicates whether or not the connection is used for peering service.

`EXCHANGECONNECTION <IExchangeConnection[]>`: The set of connections that constitute an exchange peering.
  - `[BgpSessionMaxPrefixesAdvertisedV4 <Int32?>]`: The maximum number of prefixes advertised over the IPv4 session.
  - `[BgpSessionMaxPrefixesAdvertisedV6 <Int32?>]`: The maximum number of prefixes advertised over the IPv6 session.
  - `[BgpSessionMd5AuthenticationKey <String>]`: The MD5 authentication key of the session.
  - `[BgpSessionMicrosoftSessionIPv4Address <String>]`: The IPv4 session address on Microsoft's end.
  - `[BgpSessionMicrosoftSessionIPv6Address <String>]`: The IPv6 session address on Microsoft's end.
  - `[BgpSessionPeerSessionIPv4Address <String>]`: The IPv4 session address on peer's end.
  - `[BgpSessionPeerSessionIPv6Address <String>]`: The IPv6 session address on peer's end.
  - `[BgpSessionPrefixV4 <String>]`: The IPv4 prefix that contains both ends' IPv4 addresses.
  - `[BgpSessionPrefixV6 <String>]`: The IPv6 prefix that contains both ends' IPv6 addresses.
  - `[ConnectionIdentifier <String>]`: The unique identifier (GUID) for the connection.
  - `[PeeringDbFacilityId <Int32?>]`: The PeeringDB.com ID of the facility at which the connection has to be set up.

## RELATED LINKS

