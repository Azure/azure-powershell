---
external help file:
Module Name: Az.DnsResolver
online version: https://docs.microsoft.com/powershell/module/az.dnsresolver/update-azdnsforwardingrulesetforwardingrule
schema: 2.0.0
---

# Update-AzDnsForwardingRulesetForwardingRule

## SYNOPSIS
Updates a forwarding rule in a DNS forwarding ruleset.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDnsForwardingRulesetForwardingRule -DnsForwardingRulesetName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>]
 [-ForwardingRuleState <ForwardingRuleState>] [-Metadata <Hashtable>] [-TargetDnsServer <ITargetDnsServer[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDnsForwardingRulesetForwardingRule -InputObject <IDnsResolverIdentity> [-IfMatch <String>]
 [-ForwardingRuleState <ForwardingRuleState>] [-Metadata <Hashtable>] [-TargetDnsServer <ITargetDnsServer[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a forwarding rule in a DNS forwarding ruleset.

## EXAMPLES

### Example 1: Update forwarding rule by name (adding metadata)
```powershell
Update-AzDnsForwardingRulesetForwardingRule -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleForwardingRule -ResourceGroupName sampleRG -Metadata @{"key0" = "value0"}
```

```output
Location Name                 Type                                    Etag
-------- ----                 ----                                    ----
westus2  forwardingRule Microsoft.Network/dnsForwardingRulesets/forwardingRule "04005592-0000-0800-0000-60e7ec170000"
```

This command updates forwarding rule by name (adding metadata)

### Example 2: Updates a forwarding rule by identity
```powershell
$inputObject = Get-AzDnsForwardingRulesetForwardingRule -ResourceGroupName powershell-test-rg -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleForwardingRule
Update-AzDnsForwardingRulesetForwardingRule -InputObject $inputObject  -Metadata @{"value0" = "value1"}
```

```output
Location Name                 Type                                             Etag
-------- ----                 ----                                             ----
westus2  forwardingRule Microsoft.Network/dnsForwardingRulesets/forwardingRule "04005592-0000-0800-0000-60e7ec170000"
```

This command updates forwarding rule via identity (adding metadata)

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

### -DnsForwardingRulesetName
The name of the DNS forwarding ruleset.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForwardingRuleState
The state of forwarding rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ForwardingRuleState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
ETag of the resource.
Omit this value to always overwrite the current resource.
Specify the last-seen ETag value to prevent accidentally overwriting any concurrent changes.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Metadata
Metadata attached to the forwarding rule.

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

### -Name
The name of the forwarding rule.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ForwardingRuleName

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
Parameter Sets: UpdateExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDnsServer
DNS servers to forward the DNS query to.
To construct, see NOTES section for TARGETDNSSERVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.ITargetDnsServer[]
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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IForwardingRule

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

TARGETDNSSERVER <ITargetDnsServer[]>: DNS servers to forward the DNS query to.
  - `[IPAddress <String>]`: DNS server IP address.
  - `[Port <Int32?>]`: DNS server port.

## RELATED LINKS

