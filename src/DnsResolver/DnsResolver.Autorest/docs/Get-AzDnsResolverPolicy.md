---
external help file:
Module Name: Az.DnsResolver
online version: https://learn.microsoft.com/powershell/module/az.dnsresolver/get-azdnsresolverpolicy
schema: 2.0.0
---

# Get-AzDnsResolverPolicy

## SYNOPSIS
Gets properties of a DNS resolver policy.

## SYNTAX

### List1 (Default)
```
Get-AzDnsResolverPolicy [-SubscriptionId <String[]>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDnsResolverPolicy -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDnsResolverPolicy -InputObject <IDnsResolverIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDnsResolverPolicy -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzDnsResolverPolicy -ResourceGroupName <String> -VirtualNetworkName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a DNS resolver policy.

## EXAMPLES

### Example 1: List all DNS Resolver Policies under the subscription 
```powershell
Get-AzDnsResolverPolicy -SubscriptionId 0e5a46b1-de0b-4ec3-a5d7-dda908b4e076
```

```output
Location Name                              Type                                  Etag
-------- ----                              ----                                  ----
westus2  dnsresolverpolicytestresolver2422 Microsoft.Network/dnsResolverPolicies "8b002671-0000-0800-0000-60386dc10000"
westus2  dnsresolverpolicytestresolver2654 Microsoft.Network/dnsResolverPolicies "8b000f71-0000-0800-0000-60386cc40000"
westus2  dnsresolverpolicytestresolver8416 Microsoft.Network/dnsResolverPolicies "94008a5e-0000-0800-0000-603972f20000"
westus2  dnsresolverpolicytestresolver5036 Microsoft.Network/dnsResolverPolicies "8b002f71-0000-0800-0000-60386df80000"
westus2  dnsresolverpolicytestresolver3718 Microsoft.Network/dnsResolverPolicies "00009b95-0000-0800-0000-603e8b210000"
westus2  dnsresolverpolicytestresolver2758 Microsoft.Network/dnsResolverPolicies "8b00da70-0000-0800-0000-60386b4f0000"
westus2  dnsresolverpolicytestresolver7108 Microsoft.Network/dnsResolverPolicies "00008e95-0000-0800-0000-603e8aee0000"
westus2  dnsresolverpolicytestresolver7639 Microsoft.Network/dnsResolverPolicies "8b00b670-0000-0800-0000-60386b010000"
westus2  dnsresolverpolicytestresolver5912 Microsoft.Network/dnsResolverPolicies "8a00557f-0000-0800-0000-603853bc0000"
westus2  dnsresolverpolicytestguli01       Microsoft.Network/dnsResolverPolicies "48009f1b-0000-0800-0000-60302ec40000"
westus2  dnsresolverpolicytestresolver9892 Microsoft.Network/dnsResolverPolicies "47008640-0000-0800-0000-60300f220000"
```

This command gets all DNS Resolver Policies under the subscription.

### Example 2: List all DNS Resolver Policies under the resource group 
```powershell
Get-AzDnsResolverPolicy -ResourceGroupName powershell-test-rg
```

```output
Location Name                      Type                                        Etag
-------- ----                      ----                                        ----
westus2  psdnsresolverpolicyname33nmy1fz Microsoft.Network/dnsResolverPolicies "0000c2d4-0000-0800-0000-604013880000"
westus2  psdnsresolverpolicyname34dp19g6 Microsoft.Network/dnsResolverPolicies "0000c9d4-0000-0800-0000-604013990000"
westus2  psdnsresolverpolicyname35m3jf0n Microsoft.Network/dnsResolverPolicies "0000d0d4-0000-0800-0000-604013a80000"
```

This command gets all DNS Resolver Policies under the resource group.

### Example 3: Get single DNS Resolver by name 
```powershell
Get-AzDnsResolverPolicy -ResourceGroupName powershell-test-rg -Name psdnsresolverpolicyname33nmy1fz
```

```output
Location Name                            Type                                  Etag
-------- ----                            ----                                  ----
westus2  psdnsresolverpolicyname33nmy1fz Microsoft.Network/dnsResolverPolicies "0000c2d4-0000-0800-0000-604013880000"
```

This command gets a single DNS Resolver Policy by name.

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
The name of the DNS resolver policy.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DnsResolverPolicyName

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
The value must be an UUID.

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
Parameter Sets: List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IDnsResolverPolicy

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.ISubResource

## NOTES

## RELATED LINKS

