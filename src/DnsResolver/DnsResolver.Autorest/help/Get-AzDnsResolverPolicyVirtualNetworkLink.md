---
external help file:
Module Name: Az.DnsResolver
online version: https://learn.microsoft.com/powershell/module/az.dnsresolver/get-azdnsresolverpolicyvirtualnetworklink
schema: 2.0.0
---

# Get-AzDnsResolverPolicyVirtualNetworkLink

## SYNOPSIS
Gets properties of a DNS resolver policy virtual network link.

## SYNTAX

### List (Default)
```
Get-AzDnsResolverPolicyVirtualNetworkLink -DnsResolverPolicyName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDnsResolverPolicyVirtualNetworkLink -DnsResolverPolicyName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDnsResolverPolicyVirtualNetworkLink -InputObject <IDnsResolverIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a DNS resolver policy virtual network link.

## EXAMPLES

### Example 1: List all DNS Resolver Policy Links under the dns resolver policy 
```powershell
Get-AzDnsResolverPolicyVirtualNetworkLink -ResourceGroupName exampleResourceGroup -DnsResolverPolicyName exampleDnsResolverPolicy
```

```output
Location Name                                  Type                                     Etag
-------- ----                                  ----                                     ----
westus2  dnsresolverpolicylinktestresolver2422 Microsoft.Network/dnsResolverPolicyLinks "8b002671-0000-0800-0000-60386dc10000"
westus2  dnsresolverpolicylinktestresolver2654 Microsoft.Network/dnsResolverPolicyLinks "8b000f71-0000-0800-0000-60386cc40000"
westus2  dnsresolverpolicylinktestresolver8416 Microsoft.Network/dnsResolverPolicyLinks "94008a5e-0000-0800-0000-603972f20000"
westus2  dnsresolverpolicylinktestresolver5036 Microsoft.Network/dnsResolverPolicyLinks "8b002f71-0000-0800-0000-60386df80000"
westus2  dnsresolverpolicylinktestresolver3718 Microsoft.Network/dnsResolverPolicyLinks "00009b95-0000-0800-0000-603e8b210000"
westus2  dnsresolverpolicylinktestresolver2758 Microsoft.Network/dnsResolverPolicyLinks "8b00da70-0000-0800-0000-60386b4f0000"
westus2  dnsresolverpolicylinktestresolver7108 Microsoft.Network/dnsResolverPolicyLinks "00008e95-0000-0800-0000-603e8aee0000"
westus2  dnsresolverpolicylinktestresolver7639 Microsoft.Network/dnsResolverPolicyLinks "8b00b670-0000-0800-0000-60386b010000"
westus2  dnsresolverpolicylinktestresolver5912 Microsoft.Network/dnsResolverPolicyLinks "8a00557f-0000-0800-0000-603853bc0000"
westus2  dnsresolverpolicylinktestguli01       Microsoft.Network/dnsResolverPolicyLinks "48009f1b-0000-0800-0000-60302ec40000"
westus2  dnsresolverpolicylinktestresolver9892 Microsoft.Network/dnsResolverPolicyLinks "47008640-0000-0800-0000-60300f220000"
```

This command gets all DNS Resolver Policy Links under the dns resolver policy.

### Example 2: Get single DNS Resolver Policy Link by name
```powershell
Get-AzDnsResolverPolicyVirtualNetworkLink -ResourceGroupName powershell-test-rg -DnsResolverPolicyName $resolverPolicyName -Name psdnsresolverpolicylinkname33nmy1fz
```

```output
Location Name                                Type                                     Etag
-------- ----                                ----                                     ----
westus2  psdnsresolverpolicylinkname33nmy1fz Microsoft.Network/dnsResolverPolicyLinks "0000c2d4-0000-0800-0000-604013880000"
```

This command gets a single DNS Resolver Policy Link by name.

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

### -DnsResolverPolicyName
The name of the DNS resolver policy.

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
The name of the DNS resolver policy virtual network link for the DNS resolver policy.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DnsResolverPolicyVirtualNetworkLinkName

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
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IDnsResolverPolicyVirtualNetworkLink

## NOTES

## RELATED LINKS

