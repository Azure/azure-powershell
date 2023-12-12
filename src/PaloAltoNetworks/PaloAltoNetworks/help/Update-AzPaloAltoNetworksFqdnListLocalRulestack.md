---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/update-azpaloaltonetworksfqdnlistlocalrulestack
schema: 2.0.0
---

# Update-AzPaloAltoNetworksFqdnListLocalRulestack

## SYNOPSIS
Create a FqdnListLocalRulestackResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPaloAltoNetworksFqdnListLocalRulestack -LocalRulestackName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-AuditComment <String>] [-Description <String>]
 [-Etag <String>] [-FqdnList <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityLocalRulestackExpanded
```
Update-AzPaloAltoNetworksFqdnListLocalRulestack -Name <String>
 -LocalRulestackInputObject <IPaloAltoNetworksIdentity> [-AuditComment <String>] [-Description <String>]
 [-Etag <String>] [-FqdnList <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPaloAltoNetworksFqdnListLocalRulestack -InputObject <IPaloAltoNetworksIdentity>
 [-AuditComment <String>] [-Description <String>] [-Etag <String>] [-FqdnList <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a FqdnListLocalRulestackResource

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
comment for this object

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
fqdn object description

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

### -FqdnList
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

### -Name
fqdn list name

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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IFqdnListLocalRulestackResource
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

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.paloaltonetworks/update-azpaloaltonetworksfqdnlistlocalrulestack](https://learn.microsoft.com/powershell/module/az.paloaltonetworks/update-azpaloaltonetworksfqdnlistlocalrulestack)

