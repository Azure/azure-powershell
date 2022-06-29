---
external help file:
Module Name: Az.DnsResolver
online version: https://docs.microsoft.com/powershell/module/az.dnsresolver/get-azdnsresolver
schema: 2.0.0
---

# Get-AzDnsResolver

## SYNOPSIS
Gets properties of a DNS resolver.

## SYNTAX

### List1 (Default)
```
Get-AzDnsResolver [-SubscriptionId <String[]>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDnsResolver -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDnsResolver -InputObject <IDnsResolverIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDnsResolver -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzDnsResolver -ResourceGroupName <String> -VirtualNetworkName <String> [-SubscriptionId <String[]>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a DNS resolver.

## EXAMPLES

### Example 1: List all DNS Resolvers under the subscription 
```powershell
Get-AzDnsResolver -SubscriptionId 0e5a46b1-de0b-4ec3-a5d7-dda908b4e076
```

```output
Location Name                        Type                           Etag
-------- ----                        ----                           ----
westus2  dnsresolvertestresolver2422 Microsoft.Network/dnsResolvers "8b002671-0000-0800-0000-60386dc10000"
westus2  dnsresolvertestresolver2654 Microsoft.Network/dnsResolvers "8b000f71-0000-0800-0000-60386cc40000"
westus2  dnsresolvertestresolver8416 Microsoft.Network/dnsResolvers "94008a5e-0000-0800-0000-603972f20000"
westus2  dnsresolvertestresolver5036 Microsoft.Network/dnsResolvers "8b002f71-0000-0800-0000-60386df80000"
westus2  dnsresolvertestresolver3718 Microsoft.Network/dnsResolvers "00009b95-0000-0800-0000-603e8b210000"
westus2  dnsresolvertestresolver2758 Microsoft.Network/dnsResolvers "8b00da70-0000-0800-0000-60386b4f0000"
westus2  dnsresolvertestresolver7108 Microsoft.Network/dnsResolvers "00008e95-0000-0800-0000-603e8aee0000"
westus2  dnsresolvertestresolver7639 Microsoft.Network/dnsResolvers "8b00b670-0000-0800-0000-60386b010000"
westus2  dnsresolvertestresolver5912 Microsoft.Network/dnsResolvers "8a00557f-0000-0800-0000-603853bc0000"
westus2  dnsresolvertestguli01       Microsoft.Network/dnsResolvers "48009f1b-0000-0800-0000-60302ec40000"
westus2  dnsresolvertestresolver9892 Microsoft.Network/dnsResolvers "47008640-0000-0800-0000-60300f220000"
```

This command gets all DNS Resolvers under the subscription.

### Example 2: List all DNS Resolvers under the resource group 
```powershell
Get-AzDnsResolver -ResourceGroupName powershell-test-rg
```

```output
Location Name                      Type                           Etag
-------- ----                      ----                           ----
westus2  psdnsresolvername33nmy1fz Microsoft.Network/dnsResolvers "0000c2d4-0000-0800-0000-604013880000"
westus2  psdnsresolvername34dp19g6 Microsoft.Network/dnsResolvers "0000c9d4-0000-0800-0000-604013990000"
westus2  psdnsresolvername35m3jf0n Microsoft.Network/dnsResolvers "0000d0d4-0000-0800-0000-604013a80000"
```

This command gets all DNS Resolvers under the resource group.

### Example 3: Get single DNS Resolver by name 
```powershell
Get-AzDnsResolver -ResourceGroupName powershell-test-rg -Name  psdnsresolvername33nmy1fz
```

```output
Location Name                      Type                           Etag
-------- ----                      ----                           ----
westus2  psdnsresolvername33nmy1fz Microsoft.Network/dnsResolvers "0000c2d4-0000-0800-0000-604013880000"
```

This command gets  single DNS Resolver by name.

### Example 4: List all DNS Resolvers under the virtual network 
```powershell
Get-AzDnsResolver -ResourceGroupName powershell-test-rg -VirtualNetworkName virtualnetwork-test
```

```output
Location Name                      Type                           Etag
-------- ----                      ----                           ----
westus2  psdnsresolvername33nmy1fz Microsoft.Network/dnsResolvers "0000c2d4-0000-0800-0000-604013880000"
```

This command gets  single DNS Resolver by virtual network.

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
The name of the DNS resolver.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DnsResolverName

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
Parameter Sets: Get, List, List2
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
Parameter Sets: Get, List, List1, List2
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
Parameter Sets: List, List1, List2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkName
The name of the virtual network.

```yaml
Type: System.String
Parameter Sets: List2
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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolver

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.ISubResource

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

