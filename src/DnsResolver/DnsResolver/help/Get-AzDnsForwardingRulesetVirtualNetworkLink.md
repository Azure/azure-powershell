---
external help file: Az.DnsResolver-help.xml
Module Name: Az.DnsResolver
online version: https://learn.microsoft.com/powershell/module/az.dnsresolver/get-azdnsforwardingrulesetvirtualnetworklink
schema: 2.0.0
---

# Get-AzDnsForwardingRulesetVirtualNetworkLink

## SYNOPSIS
Gets properties of a virtual network link to a DNS forwarding ruleset.

## SYNTAX

### List (Default)
```
Get-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDnsForwardingRulesetVirtualNetworkLink -InputObject <IDnsResolverIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a virtual network link to a DNS forwarding ruleset.

## EXAMPLES

### Example 1: List virtual network links under a DNS forwarding ruleset
```powershell
Get-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName pstestdnsresolvername -ResourceGroupName powershell-test-rg
```

```output
Name                   Type                                            Etag
----                   ----                                            ----
samplevnetLink1  Microsoft.Network/dnsForwardingRuleset/virtualNetworkLinks "0b008451-0000-0800-0000-60402b960000"
samplevnetLink2  Microsoft.Network/dnsForwardingRuleset/virtualNetworkLinks "0b0071aa-0000-0800-0000-60406a2d0000"
```

This command gets all virtual network link by name

### Example 2: Get single virtual network link by name
```powershell
Get-AzDnsForwardingRulesetVirtualNetworkLink -DnsForwardingRulesetName pstestdnsresolvername -Name samplevnetLink1 -ResourceGroupName powershell-test-rg
```

```output
Name                  Type                                            Etag
----                  ----                                            ----
samplevnetLink1 Microsoft.Network/dnsForwardingRuleset/virtualNetworkLinks "0b008451-0000-0800-0000-60402b960000"
```

This command gets single virtual network link by name

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
Parameter Sets: List, Get
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
The name of the virtual network link.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: VirtualNetworkLinkName

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IVirtualNetworkLink

## NOTES

## RELATED LINKS
