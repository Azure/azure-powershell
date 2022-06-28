---
external help file:
Module Name: Az.DnsResolver
online version: https://docs.microsoft.com/powershell/module/az.dnsresolver/get-azdnsresolveroutboundendpoint
schema: 2.0.0
---

# Get-AzDnsResolverOutboundEndpoint

## SYNOPSIS
Gets properties of an outbound endpoint for a DNS resolver.

## SYNTAX

### List (Default)
```
Get-AzDnsResolverOutboundEndpoint -DnsResolverName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDnsResolverOutboundEndpoint -DnsResolverName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDnsResolverOutboundEndpoint -InputObject <IDnsResolverIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets properties of an outbound endpoint for a DNS resolver.

## EXAMPLES

### Example 1: List all outbound endpoints under the DNS resolver in a resouce group 
```powershell
Get-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -ResourceGroupName sampleResouceGroup
```

```output
Name         Type                                             Etag
----         ----                                             ----
sampleOutbound Microsoft.Network/dnsResolvers/outboundEndpoints "0a001a28-0000-0800-0000-60e3846a0000"
sampleOutbound2 Microsoft.Network/dnsResolvers/outboundEndpoints "0a001a27-0000-0800-0000-60e3846a0000"
```
This command gets all outbound endpoints under the DNS resolver in a resouce group.

### Example 2: Get single outbound endpoint by name 
```powershell
Get-AzDnsResolverOutboundEndpoint -DnsResolverName sampleResolver -Name sampleOutbound -ResourceGroupName sampleResouceGroup
```

```output
Name         Type                                             Etag
----         ----                                             ----
sampleOutbound Microsoft.Network/dnsResolvers/outboundEndpoints "0a001a28-0000-0800-0000-60e3846a0000"
```

This command gets an outbound endpoint under the DNS resolver in a resouce group.

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

### -DnsResolverName
The name of the DNS resolver.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the outbound endpoint for the DNS resolver.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: OutboundEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The maximum number of results to return.
If not specified, returns up to 100 results.

```yaml
Type: System.Int32
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IOutboundEndpoint

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IDnsResolverIdentity>`: Identity Parameter
  - `[DnsForwardingRulesetName <String>]`: The name of the DNS forwarding ruleset.
  - `[DnsResolverName <String>]`: The name of the DNS resolver.
  - `[ForwardingRuleName <String>]`: The name of the forwarding rule.
  - `[Id <String>]`: Resource identity path
  - `[InboundEndpointName <String>]`: The name of the inbound endpoint for the DNS resolver.
  - `[OutboundEndpointName <String>]`: The name of the outbound endpoint for the DNS resolver.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VirtualNetworkLinkName <String>]`: The name of the virtual network link.
  - `[VirtualNetworkName <String>]`: The name of the virtual network.

## RELATED LINKS

