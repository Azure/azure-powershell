---
external help file: Az.DnsResolver-help.xml
Module Name: Az.DnsResolver
online version: https://learn.microsoft.com/powershell/module/az.dnsresolver/invoke-azdnsresolverbulkdnsresolverdomainlist
schema: 2.0.0
---

# Invoke-AzDnsResolverBulkDnsResolverDomainList

## SYNOPSIS
Uploads or downloads the list of domains for a DNS Resolver Domain List from a storage link.

## SYNTAX

### BulkExpanded (Default)
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -DnsResolverDomainListName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -Action <String> -StorageUrl <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### BulkViaJsonString
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -DnsResolverDomainListName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### BulkViaJsonFilePath
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -DnsResolverDomainListName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Bulk
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -DnsResolverDomainListName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -Parameter <IDnsResolverDomainListBulk>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### BulkViaIdentityExpanded
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -InputObject <IDnsResolverIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] -Action <String> -StorageUrl <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BulkViaIdentity
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -InputObject <IDnsResolverIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] -Parameter <IDnsResolverDomainListBulk> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Uploads or downloads the list of domains for a DNS Resolver Domain List from a storage link.

## EXAMPLES

### EXAMPLE 1
```
{{ Add code here }}
```

### EXAMPLE 2
```
{{ Add code here }}
```

## PARAMETERS

### -Action
The action to take in the request, Upload or Download.

```yaml
Type: String
Parameter Sets: BulkExpanded, BulkViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DnsResolverDomainListName
The name of the DNS resolver domain list.

```yaml
Type: String
Parameter Sets: BulkExpanded, BulkViaJsonString, BulkViaJsonFilePath, Bulk
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
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfNoneMatch
Set to '*' to allow a new resource to be created, but to prevent updating an existing resource.
Other values will be ignored.

```yaml
Type: String
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

```yaml
Type: IDnsResolverIdentity
Parameter Sets: BulkViaIdentityExpanded, BulkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Bulk operation

```yaml
Type: String
Parameter Sets: BulkViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Bulk operation

```yaml
Type: String
Parameter Sets: BulkViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Describes a DNS resolver domain list for bulk UPLOAD or DOWNLOAD operations.

```yaml
Type: IDnsResolverDomainListBulk
Parameter Sets: Bulk, BulkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: BulkExpanded, BulkViaJsonString, BulkViaJsonFilePath, Bulk
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageUrl
The storage account blob file URL to be used in the bulk upload or download request of DNS resolver domain list.

```yaml
Type: String
Parameter Sets: BulkExpanded, BulkViaIdentityExpanded
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
Type: String
Parameter Sets: BulkExpanded, BulkViaJsonString, BulkViaJsonFilePath, Bulk
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
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverDomainListBulk
### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverDomainList
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IDnsResolverIdentity\>: Identity Parameter
  \[DnsForwardingRulesetName \<String\>\]: The name of the DNS forwarding ruleset.
  \[DnsResolverDomainListName \<String\>\]: The name of the DNS resolver domain list.
  \[DnsResolverName \<String\>\]: The name of the DNS resolver.
  \[DnsResolverPolicyName \<String\>\]: The name of the DNS resolver policy.
  \[DnsResolverPolicyVirtualNetworkLinkName \<String\>\]: The name of the DNS resolver policy virtual network link for the DNS resolver policy.
  \[DnsSecurityRuleName \<String\>\]: The name of the DNS security rule.
  \[ForwardingRuleName \<String\>\]: The name of the forwarding rule.
  \[Id \<String\>\]: Resource identity path
  \[InboundEndpointName \<String\>\]: The name of the inbound endpoint for the DNS resolver.
  \[OutboundEndpointName \<String\>\]: The name of the outbound endpoint for the DNS resolver.
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
The value must be an UUID.
  \[VirtualNetworkLinkName \<String\>\]: The name of the virtual network link.
  \[VirtualNetworkName \<String\>\]: The name of the VirtualNetwork

PARAMETER \<IDnsResolverDomainListBulk\>: Describes a DNS resolver domain list for bulk UPLOAD or DOWNLOAD operations.
  Action \<String\>: The action to take in the request, Upload or Download.
  StorageUrl \<String\>: The storage account blob file URL to be used in the bulk upload or download request of DNS resolver domain list.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.dnsresolver/invoke-azdnsresolverbulkdnsresolverdomainlist](https://learn.microsoft.com/powershell/module/az.dnsresolver/invoke-azdnsresolverbulkdnsresolverdomainlist)
