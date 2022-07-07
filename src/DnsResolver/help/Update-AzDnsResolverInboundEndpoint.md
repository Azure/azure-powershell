---
external help file:
Module Name: Az.DnsResolver
online version: https://docs.microsoft.com/powershell/module/az.dnsresolver/update-azdnsresolverinboundendpoint
schema: 2.0.0
---

# Update-AzDnsResolverInboundEndpoint

## SYNOPSIS
Updates an inbound endpoint for a DNS resolver.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDnsResolverInboundEndpoint -DnsResolverName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDnsResolverInboundEndpoint -InputObject <IDnsResolverIdentity> [-IfMatch <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an inbound endpoint for a DNS resolver.

## EXAMPLES

### Example 1: Update Inbound Endpoint by name (adding tag)
```powershell
Update-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg -Tag @{"value0" = "value1"}
```

```output
Name                  Type                                            Etag
----                  ----                                            ----
sampleInboundEndpoint Microsoft.Network/dnsResolvers/inboundEndpoints "0c000868-0000-0800-0000-604112230000"
```

This command updates Inbound Endpoint by name (adding tag)

### Example 2: Update Inbound Endpoint via identity (adding tag)
```powershell
$inputobject = Get-AzDnsResolverInboundEndpoint -DnsResolverName pstestdnsresolvername -Name sampleInboundEndpoint -ResourceGroupName powershell-test-rg
Update-AzDnsResolverInboundEndpoint -InputObject $inputobject -Tag @{"value0" = "value1"}
```

```output
Name                  Type                                            Etag
----                  ----                                            ----
sampleInboundEndpoint Microsoft.Network/dnsResolvers/inboundEndpoints "0c00e768-0000-0800-0000-604112af0000"
```

This command updates Inbound Endpoint via identity (adding tag)

## PARAMETERS

### -AsJob
Run the command as a job

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
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

### -Name
The name of the inbound endpoint for the DNS resolver.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: InboundEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -Tag
Tags for inbound endpoint.

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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IInboundEndpoint

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

