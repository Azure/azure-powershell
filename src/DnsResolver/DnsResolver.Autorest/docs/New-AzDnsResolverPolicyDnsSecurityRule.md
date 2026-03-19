---
external help file:
Module Name: Az.DnsResolver
online version: https://learn.microsoft.com/powershell/module/az.dnsresolver/new-azdnsresolverpolicydnssecurityrule
schema: 2.0.0
---

# New-AzDnsResolverPolicyDnsSecurityRule

## SYNOPSIS
Creates or updates a DNS security rule for a DNS resolver policy.

## SYNTAX

```
New-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName <String> -Name <String>
 -ResourceGroupName <String> -DnsResolverDomainList <ISubResource[]> -Location <String> -Priority <Int32>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>]
 [-ActionBlockResponseCode <BlockResponseCode>] [-ActionType <ActionType>]
 [-DnsSecurityRuleState <DnsSecurityRuleState>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a DNS security rule for a DNS resolver policy.

## EXAMPLES

### Example 1: Create a DNS security rule 
```powershell
New-AzDnsResolverPolicyDnsSecurityRule -Name sampleSecurityRule -ResourceGroupName powershell-test-rg -DnsResolverPolicyName samplePolicyName -Location westus2 -DnsSecurityRuleState "Enabled" -ActionType "Block" -ActionBlockResponseCode "SERVFAIL" -Priority 100 -DnsResolverDomainList @{id = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg/providers/Microsoft.Network/dnsResolverDomainLists/exampleDomainListName";}

```

```output
Location Name                     Type                                     Etag
-------- ----                     ----                                     ----
westus2  sampleSecurityRule       Microsoft.Network/dnsSecurityRules       "000027d5-0000-0800-0000-6040150e0000"
```

This cmdlet creates a DNS security rule.

### Example 2: Create a DNS security rule with tag 
```powershell
New-AzDnsResolverPolicyDnsSecurityRule -Name sampleSecurityRule -ResourceGroupName powershell-test-rg -DnsResolverPolicyName samplePolicyName -Location westus2 -DnsSecurityRuleState "Enabled" -ActionType "Block" -ActionBlockResponseCode "SERVFAIL" -Priority 100 -DnsResolverDomainList @{id = "/subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg/providers/Microsoft.Network/dnsResolverDomainLists/exampleDomainListName";} -Tag @{"key0" = "value0"}
```

```output
Location Name                     Type                                     Etag
-------- ----                     ----                                     ----
westus2  sampleSecurityRule       Microsoft.Network/dnsSecurityRules       "00008cd5-0000-0800-0000-604016c90000"
```

This cmdlet creates a DNS security rule with tag.

## PARAMETERS

### -ActionBlockResponseCode
The response code for block actions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.BlockResponseCode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActionType
The type of action to take.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.ActionType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DnsResolverDomainList
DNS resolver policy domains lists that the DNS security rule applies to.
To construct, see NOTES section for DNSRESOLVERDOMAINLIST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.ISubResource[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DnsResolverPolicyName
The name of the DNS resolver policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DnsSecurityRuleState
The state of DNS security rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.DnsSecurityRuleState
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

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the DNS security rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DnsSecurityRuleName

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

### -Priority
The priority of the DNS security rule.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20230701Preview.IDnsSecurityRule

## NOTES

## RELATED LINKS

