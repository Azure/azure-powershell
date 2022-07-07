---
external help file:
Module Name: Az.DnsResolver
online version: https://docs.microsoft.com/powershell/module/az.dnsresolver/get-azdnsforwardingruleset
schema: 2.0.0
---

# Get-AzDnsForwardingRuleset

## SYNOPSIS
Gets a DNS forwarding ruleset properties.

## SYNTAX

### List1 (Default)
```
Get-AzDnsForwardingRuleset [-SubscriptionId <String[]>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDnsForwardingRuleset -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDnsForwardingRuleset -InputObject <IDnsResolverIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzDnsForwardingRuleset -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzDnsForwardingRuleset -ResourceGroupName <String> -VirtualNetworkName <String>
 [-SubscriptionId <String[]>] [-Top <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a DNS forwarding ruleset properties.

## EXAMPLES

### Example 1: List all DNS forwarding rulesets in a subscription
```powershell
Get-AzDnsForwardingRuleset -SubscriptionId 0e5a46b1-de0b-4ec3-a5d7-dda908b4e076
```

```output
Location Name                                                            Type                                    Etag
-------- ----                                                            ----                                    ----
westus2  dnsForwardingRuleset                                            Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
westus2  pw-dnsForwardingRuleset                                         Microsoft.Network/dnsForwardingRulesets "08009ec9-0000-0800-0000-60e383b70000"
westus2  pw-dnsForwardingRuleset1                                        Microsoft.Network/dnsForwardingRulesets "08007ccc-0000-0800-0000-60e3846a0000"
eastus2  dnsforwardingruleset-test-eastus2-main-syn-outbound-primary-0   Microsoft.Network/dnsForwardingRulesets "4f006bb2-0000-0200-0000-60e7ef240000"
eastus2  dnsforwardingruleset-test-eastus2-main-syn-outbound-secondary-0 Microsoft.Network/dnsForwardingRulesets "4f006db2-0000-0200-0000-60e7ef240000"
```

This command gets all DNS forwarding ruleset under the subscription.

### Example 2: Get single DNS forwarding ruleset by name
```powershell
Get-AzDnsForwardingRuleset -Name dnsForwardingRuleset -ResourceGroupName sampleRG
```

```output
Location Name                 Type                                    Etag
-------- ----                 ----                                    ----
westus2  dnsForwardingRuleset Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
```

This command gets single DNS forwarding ruleset by name.

### Example 3: List all DNS forwarding ruleset under the resouce group
```powershell
Get-AzDnsForwardingRuleset -ResourceGroupName sampleRG
```

```output
Location Name                     Type                                    Etag
-------- ----                     ----                                    ----
westus2  dnsForwardingRuleset     Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
westus2  pw-dnsForwardingRuleset  Microsoft.Network/dnsForwardingRulesets "08009ec9-0000-0800-0000-60e383b70000"
westus2  pw-dnsForwardingRuleset1 Microsoft.Network/dnsForwardingRulesets "08007ccc-0000-0800-0000-60e3846a0000"
```

This command gets all DNS forwarding ruleset under the resouce group.

### Example 4: List all DNS forwarding ruleset under the virtual network
```powershell
Get-AzDnsForwardingRuleset -ResourceGroupName sampleRG -VirtualNetworkName virtualnetwork-test
```

```output
Location Name                     Type                                    Etag
-------- ----                     ----                                    ----
westus2  dnsForwardingRuleset     Microsoft.Network/dnsForwardingRulesets "04005592-0000-0800-0000-60e7ec170000"
```

This command gets all DNS forwarding ruleset under the virtual network.

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
The name of the DNS forwarding ruleset.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DnsForwardingRulesetName

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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsForwardingRuleset

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IVirtualNetworkDnsForwardingRuleset

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

