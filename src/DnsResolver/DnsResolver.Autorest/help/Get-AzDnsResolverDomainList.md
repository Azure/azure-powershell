---
external help file:
Module Name: Az.DnsResolver
online version: https://learn.microsoft.com/powershell/module/az.dnsresolver/get-azdnsresolverdomainlist
schema: 2.0.0
---

# Get-AzDnsResolverDomainList

## SYNOPSIS
Gets properties of a DNS resolver domain list.

## SYNTAX

### List1 (Default)
```
Get-AzDnsResolverDomainList [-SubscriptionId <String[]>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDnsResolverDomainList -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDnsResolverDomainList -InputObject <IDnsResolverIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzDnsResolverDomainList -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a DNS resolver domain list.

## EXAMPLES

### Example 1: List all DNS Resolver Domain Lists under the subscription 
```powershell
Get-AzDnsResolverDomainList -SubscriptionId 0e5a46b1-de0b-4ec3-a5d7-dda908b4e076
```

```output
Location Name                                  Type                                     Etag
-------- ----                                  ----                                     ----
westus2  dnsresolverdomainlisttestresolver2422 Microsoft.Network/dnsResolverDomainLists "8b002671-0000-0800-0000-60386dc10000"
westus2  dnsresolverdomainlisttestresolver2654 Microsoft.Network/dnsResolverDomainLists "8b000f71-0000-0800-0000-60386cc40000"
westus2  dnsresolverdomainlisttestresolver8416 Microsoft.Network/dnsResolverDomainLists "94008a5e-0000-0800-0000-603972f20000"
westus2  dnsresolverdomainlisttestresolver5036 Microsoft.Network/dnsResolverDomainLists "8b002f71-0000-0800-0000-60386df80000"
westus2  dnsresolverdomainlisttestresolver3718 Microsoft.Network/dnsResolverDomainLists "00009b95-0000-0800-0000-603e8b210000"
westus2  dnsresolverdomainlisttestresolver2758 Microsoft.Network/dnsResolverDomainLists "8b00da70-0000-0800-0000-60386b4f0000"
westus2  dnsresolverdomainlisttestresolver7108 Microsoft.Network/dnsResolverDomainLists "00008e95-0000-0800-0000-603e8aee0000"
westus2  dnsresolverdomainlisttestresolver7639 Microsoft.Network/dnsResolverDomainLists "8b00b670-0000-0800-0000-60386b010000"
westus2  dnsresolverdomainlisttestresolver5912 Microsoft.Network/dnsResolverDomainLists "8a00557f-0000-0800-0000-603853bc0000"
westus2  dnsresolverdomainlisttestguli01       Microsoft.Network/dnsResolverDomainLists "48009f1b-0000-0800-0000-60302ec40000"
westus2  dnsresolverdomainlisttestresolver9892 Microsoft.Network/dnsResolverDomainLists "47008640-0000-0800-0000-60300f220000"
```

This command gets all DNS Resolver Domain Lists under the subscription.

### Example 2: List all DNS Resolver Domain Lists under the resource group 
```powershell
Get-AzDnsResolverDomainList -ResourceGroupName powershell-test-rg
```

```output
Location Name                            Type                                  Etag
-------- ----                            ----                                  ----
westus2  psdnsresolverdomainlistname33nmy1fz Microsoft.Network/dnsResolverDomainLists "0000c2d4-0000-0800-0000-604013880000"
westus2  psdnsresolverdomainlistname34dp19g6 Microsoft.Network/dnsResolverDomainLists "0000c9d4-0000-0800-0000-604013990000"
westus2  psdnsresolverdomainlistname35m3jf0n Microsoft.Network/dnsResolverDomainLists "0000d0d4-0000-0800-0000-604013a80000"
```

This command gets all DNS Resolver Domain Lists under the resource group.

### Example 3: Get single DNS Resolver by name 
```powershell
Get-AzDnsResolverDomainList -ResourceGroupName powershell-test-rg -Name psdnsresolverdomainlistname33nmy1fz
```

```output
Location Name                                Type                                     Etag
-------- ----                                ----                                     ----
westus2  psdnsresolverdomainlistname33nmy1fz Microsoft.Network/dnsResolverDomainLists "0000c2d4-0000-0800-0000-604013880000"
```

This command gets a single DNS Resolver Domain List by name.

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
The name of the DNS resolver domain list.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DnsResolverDomainListName

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
Parameter Sets: Get, List, List1
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IDnsResolverDomainList

## NOTES

## RELATED LINKS

