---
external help file: Az.DnsResolver-help.xml
Module Name: Az.DnsResolver
online version: https://learn.microsoft.com/powershell/module/az.dnsresolver/new-azdnsforwardingrulesetforwardingrule
schema: 2.0.0
---

# New-AzDnsForwardingRulesetForwardingRule

## SYNOPSIS
Create a forwarding rule in a DNS forwarding ruleset.

## SYNTAX

### CreateViaIdentityDnsForwardingRulesetExpanded (Default)
```
New-AzDnsForwardingRulesetForwardingRule -Name <String> -DnsForwardingRulesetInputObject <IDnsResolverIdentity>
 [-IfMatch <String>] [-IfNoneMatch <String>] -DomainName <String> -TargetDnsServer <ITargetDnsServer[]>
 [-ForwardingRuleState <String>] [-Metadata <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDnsForwardingRulesetForwardingRule -Name <String> -DnsForwardingRulesetName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDnsForwardingRulesetForwardingRule -Name <String> -DnsForwardingRulesetName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzDnsForwardingRulesetForwardingRule -Name <String> -DnsForwardingRulesetName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>]
 -DomainName <String> -TargetDnsServer <ITargetDnsServer[]> [-ForwardingRuleState <String>]
 [-Metadata <Hashtable>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a forwarding rule in a DNS forwarding ruleset.

## EXAMPLES

### Example 1: Create a forwarding rule.
```powershell
$targetIPConfig = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress 10.0.0.3 -PrivateIPAllocationMethod Dynamic -SubnetId /subscriptions/ea40042d-63d8-4d02-9261-fb31450e6c67/resourceGroups/sampleRG/providers/Microsoft.Network/virtualNetworks/vnet-hub/subnets/test-subnet
New-AzDnsForwardingRulesetForwardingRule -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleForwardingRule -ResourceGroupName sampleRG -TargetDnsServer $targetIPConfig
```

```output
Name                  Type                                            Etag
----                  ----                                            ----
sampleForwardingRule Microsoft.Network/dnsForwardingRuleset/forwardingRule "0b008451-0000-0800-0000-60402b960000"
```

This cmdlet creates a forwarding rule.

### Example 2: Create a forwarding rule with tag
```powershell
$targetIPConfig = New-AzDnsResolverIPConfigurationObject -PrivateIPAddress 10.0.0.3 -PrivateIPAllocationMethod Dynamic -SubnetId /subscriptions/ea40042d-63d8-4d02-9261-fb31450e6c67/resourceGroups/sampleRG/providers/Microsoft.Network/virtualNetworks/vnet-hub/subnets/test-subnet
New-AzDnsForwardingRulesetForwardingRule -DnsForwardingRulesetName dnsForwardingRuleset -Name sampleForwardingRule -ResourceGroupName sampleRG -TargetDnsServer $targetIPConfig -Metadata @{"key0" = "value0"}
```

```output
Name                  Type                                            Etag
----                  ----                                            ----
sampleForwardingRule Microsoft.Network/dnsForwardingRuleset/forwardingRule "0b008451-0000-0800-0000-60402b960000"
```

This cmdlet creates a forwarding rule with tag.

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

### -DnsForwardingRulesetInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity
Parameter Sets: CreateViaIdentityDnsForwardingRulesetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DnsForwardingRulesetName
The name of the DNS forwarding ruleset.

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString, CreateViaJsonFilePath, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainName
The domain name for the forwarding rule.

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityDnsForwardingRulesetExpanded, CreateExpanded
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
Type: System.String
Parameter Sets: CreateViaIdentityDnsForwardingRulesetExpanded, CreateExpanded
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

### -IfNoneMatch
Set to '*' to allow a new resource to be created, but to prevent updating an existing resource.
Other values will be ignored.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
Metadata attached to the forwarding rule.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateViaIdentityDnsForwardingRulesetExpanded, CreateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: CreateViaJsonString, CreateViaJsonFilePath, CreateExpanded
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
Type: System.String
Parameter Sets: CreateViaJsonString, CreateViaJsonFilePath, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDnsServer
DNS servers to forward the DNS query to.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.ITargetDnsServer[]
Parameter Sets: CreateViaIdentityDnsForwardingRulesetExpanded, CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IForwardingRule

## NOTES

## RELATED LINKS
