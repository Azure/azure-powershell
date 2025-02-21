---
external help file:
Module Name: Az.DnsResolver
online version: https://learn.microsoft.com/powershell/module/az.dnsresolver/get-azdnsresolverpolicydnssecurityrule
schema: 2.0.0
---

# Get-AzDnsResolverPolicyDnsSecurityRule

## SYNOPSIS
Gets properties of a DNS security rule for a DNS resolver policy.

## SYNTAX

### List (Default)
```
Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDnsResolverPolicyDnsSecurityRule -InputObject <IDnsResolverIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a DNS security rule for a DNS resolver policy.

## EXAMPLES

### Example 1: List all DNS Security Rule under the dns resolver policy 
```powershell
Get-AzDnsResolverPolicyDnsSecurityRule  -ResourceGroupName exampleResourceGroup -DnsResolverPolicyName exampleDnsResolverPolicy
```

```output
Location Name                            Type                               Etag
-------- ----                            ----                               ----
westus2  dnssecurityruletestresolver2422 Microsoft.Network/dnsSecurityRules "8b002671-0000-0800-0000-60386dc10000"
westus2  dnssecurityruletestresolver2654 Microsoft.Network/dnsSecurityRules "8b000f71-0000-0800-0000-60386cc40000"
westus2  dnssecurityruletestresolver8416 Microsoft.Network/dnsSecurityRules "94008a5e-0000-0800-0000-603972f20000"
westus2  dnssecurityruletestresolver5036 Microsoft.Network/dnsSecurityRules "8b002f71-0000-0800-0000-60386df80000"
westus2  dnssecurityruletestresolver3718 Microsoft.Network/dnsSecurityRules "00009b95-0000-0800-0000-603e8b210000"
westus2  dnssecurityruletestresolver2758 Microsoft.Network/dnsSecurityRules "8b00da70-0000-0800-0000-60386b4f0000"
westus2  dnssecurityruletestresolver7108 Microsoft.Network/dnsSecurityRules "00008e95-0000-0800-0000-603e8aee0000"
westus2  dnssecurityruletestresolver7639 Microsoft.Network/dnsSecurityRules "8b00b670-0000-0800-0000-60386b010000"
westus2  dnssecurityruletestresolver5912 Microsoft.Network/dnsSecurityRules "8a00557f-0000-0800-0000-603853bc0000"
westus2  dnssecurityruletestguli01       Microsoft.Network/dnsSecurityRules "48009f1b-0000-0800-0000-60302ec40000"
westus2  dnssecurityruletestresolver9892 Microsoft.Network/dnsSecurityRules "47008640-0000-0800-0000-60300f220000"
```

This command gets all DNS Security Rule under the dns resolver policy.

### Example 2: Get single DNS Security Rule by name
```powershell
Get-AzDnsResolverPolicyDnsSecurityRule -ResourceGroupName powershell-test-rg -DnsResolverPolicyName $resolverPolicyName -Name psdnssecurityrulename33nmy1fz
```

```output
Location Name                                Type                                     Etag
-------- ----                                ----                                     ----
westus2  psdnssecurityrulename33nmy1fz       Microsoft.Network/dnsSecurityRules       "0000c2d4-0000-0800-0000-604013880000"
```

This command gets a single DNS Security Rule by name.

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
The name of the DNS security rule.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DnsSecurityRuleName

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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IDnsSecurityRule

## NOTES

## RELATED LINKS

