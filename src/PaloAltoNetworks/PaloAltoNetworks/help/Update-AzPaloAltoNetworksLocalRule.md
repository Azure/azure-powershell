---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/update-azpaloaltonetworkslocalrule
schema: 2.0.0
---

# Update-AzPaloAltoNetworksLocalRule

## SYNOPSIS
Create a LocalRulesResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPaloAltoNetworksLocalRule -LocalRulestackName <String> -Priority <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ActionType <String>] [-Application <String[]>] [-AuditComment <String>]
 [-CategoryFeed <String[]>] [-CategoryUrlCustom <String[]>] [-DecryptionRuleType <String>]
 [-Description <String>] [-DestinationCidr <String[]>] [-DestinationCountry <String[]>]
 [-DestinationFeed <String[]>] [-DestinationFqdnList <String[]>] [-DestinationPrefixList <String[]>]
 [-EnableLogging <String>] [-Etag <String>] [-InboundInspectionCertificate <String>]
 [-NegateDestination <String>] [-NegateSource <String>] [-Protocol <String>] [-ProtocolPortList <String[]>]
 [-RuleName <String>] [-RuleState <String>] [-SourceCidr <String[]>] [-SourceCountry <String[]>]
 [-SourceFeed <String[]>] [-SourcePrefixList <String[]>] [-Tag <ITagInfo[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityLocalRulestackExpanded
```
Update-AzPaloAltoNetworksLocalRule -Priority <String> -LocalRulestackInputObject <IPaloAltoNetworksIdentity>
 [-ActionType <String>] [-Application <String[]>] [-AuditComment <String>] [-CategoryFeed <String[]>]
 [-CategoryUrlCustom <String[]>] [-DecryptionRuleType <String>] [-Description <String>]
 [-DestinationCidr <String[]>] [-DestinationCountry <String[]>] [-DestinationFeed <String[]>]
 [-DestinationFqdnList <String[]>] [-DestinationPrefixList <String[]>] [-EnableLogging <String>]
 [-Etag <String>] [-InboundInspectionCertificate <String>] [-NegateDestination <String>]
 [-NegateSource <String>] [-Protocol <String>] [-ProtocolPortList <String[]>] [-RuleName <String>]
 [-RuleState <String>] [-SourceCidr <String[]>] [-SourceCountry <String[]>] [-SourceFeed <String[]>]
 [-SourcePrefixList <String[]>] [-Tag <ITagInfo[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPaloAltoNetworksLocalRule -InputObject <IPaloAltoNetworksIdentity> [-ActionType <String>]
 [-Application <String[]>] [-AuditComment <String>] [-CategoryFeed <String[]>] [-CategoryUrlCustom <String[]>]
 [-DecryptionRuleType <String>] [-Description <String>] [-DestinationCidr <String[]>]
 [-DestinationCountry <String[]>] [-DestinationFeed <String[]>] [-DestinationFqdnList <String[]>]
 [-DestinationPrefixList <String[]>] [-EnableLogging <String>] [-Etag <String>]
 [-InboundInspectionCertificate <String>] [-NegateDestination <String>] [-NegateSource <String>]
 [-Protocol <String>] [-ProtocolPortList <String[]>] [-RuleName <String>] [-RuleState <String>]
 [-SourceCidr <String[]>] [-SourceCountry <String[]>] [-SourceFeed <String[]>] [-SourcePrefixList <String[]>]
 [-Tag <ITagInfo[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a LocalRulesResource

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

### -ActionType
rule action

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

### -Application
array of rule applications

```yaml
Type: String[]
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuditComment
rule comment

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

### -CategoryFeed
feed list

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CategoryUrlCustom
custom URL

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DecryptionRuleType
enable or disable decryption

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

### -Description
rule description

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

### -DestinationCidr
special value 'any'

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationCountry
list of countries

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationFeed
list of feeds

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationFqdnList
fqdn list

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationPrefixList
prefix list

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableLogging
enable or disable logging

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

### -Etag
etag info

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

### -InboundInspectionCertificate
inbound Inspection Certificate

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: IPaloAltoNetworksIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocalRulestackInputObject
Identity Parameter
To construct, see NOTES section for LOCALRULESTACKINPUTOBJECT properties and create a hash table.

```yaml
Type: IPaloAltoNetworksIdentity
Parameter Sets: UpdateViaIdentityLocalRulestackExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocalRulestackName
LocalRulestack resource name

```yaml
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NegateDestination
cidr should not be 'any'

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

### -NegateSource
cidr should not be 'any'

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

### -Priority
Local Rule priority

```yaml
Type: String
Parameter Sets: UpdateExpanded, UpdateViaIdentityLocalRulestackExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
any, application-default, TCP:number, UDP:number

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

### -ProtocolPortList
prot port list

```yaml
Type: String[]
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
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleName
rule name

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

### -RuleState
state of this rule

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

### -SourceCidr
special value 'any'

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceCountry
list of countries

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceFeed
list of feeds

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourcePrefixList
prefix list

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
tag for rule
To construct, see NOTES section for TAG properties and create a hash table.

```yaml
Type: ITagInfo[]
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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.ILocalRulesResource
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IPaloAltoNetworksIdentity\>: Identity Parameter
  \[FirewallName \<String\>\]: Firewall resource name
  \[GlobalRulestackName \<String\>\]: GlobalRulestack resource name
  \[Id \<String\>\]: Resource identity path
  \[LocalRulestackName \<String\>\]: LocalRulestack resource name
  \[Name \<String\>\]: certificate name
  \[Priority \<String\>\]: Post Rule priority
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.

LOCALRULESTACKINPUTOBJECT \<IPaloAltoNetworksIdentity\>: Identity Parameter
  \[FirewallName \<String\>\]: Firewall resource name
  \[GlobalRulestackName \<String\>\]: GlobalRulestack resource name
  \[Id \<String\>\]: Resource identity path
  \[LocalRulestackName \<String\>\]: LocalRulestack resource name
  \[Name \<String\>\]: certificate name
  \[Priority \<String\>\]: Post Rule priority
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.

TAG \<ITagInfo\[\]\>: tag for rule
  Key \<String\>: tag name
  Value \<String\>: tag value

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.paloaltonetworks/update-azpaloaltonetworkslocalrule](https://learn.microsoft.com/powershell/module/az.paloaltonetworks/update-azpaloaltonetworkslocalrule)

