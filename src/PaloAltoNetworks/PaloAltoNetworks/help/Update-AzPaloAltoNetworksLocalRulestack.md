---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/update-azpaloaltonetworkslocalrulestack
schema: 2.0.0
---

# Update-AzPaloAltoNetworksLocalRulestack

## SYNOPSIS
Update a LocalRulestackResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPaloAltoNetworksLocalRulestack -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AssociatedSubscription <String[]>] [-DefaultMode <String>] [-Description <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-MinAppIdVersion <String>] [-PanEtag <String>]
 [-PanLocation <String>] [-Scope <String>] [-SecurityServiceAntiSpywareProfile <String>]
 [-SecurityServiceAntiVirusProfile <String>] [-SecurityServiceDnsSubscription <String>]
 [-SecurityServiceFileBlockingProfile <String>] [-SecurityServiceOutboundTrustCertificate <String>]
 [-SecurityServiceOutboundUnTrustCertificate <String>] [-SecurityServiceUrlFilteringProfile <String>]
 [-SecurityServiceVulnerabilityProfile <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPaloAltoNetworksLocalRulestack -InputObject <IPaloAltoNetworksIdentity>
 [-AssociatedSubscription <String[]>] [-DefaultMode <String>] [-Description <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-MinAppIdVersion <String>] [-PanEtag <String>]
 [-PanLocation <String>] [-Scope <String>] [-SecurityServiceAntiSpywareProfile <String>]
 [-SecurityServiceAntiVirusProfile <String>] [-SecurityServiceDnsSubscription <String>]
 [-SecurityServiceFileBlockingProfile <String>] [-SecurityServiceOutboundTrustCertificate <String>]
 [-SecurityServiceOutboundUnTrustCertificate <String>] [-SecurityServiceUrlFilteringProfile <String>]
 [-SecurityServiceVulnerabilityProfile <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a LocalRulestackResource

## EXAMPLES

### Example 1: Update a LocalRulestackResource.
```powershell
Update-AzPaloAltoNetworksLocalRulestack -Name azps-panlr -ResourceGroupName azps_test_group_pan -Tag @{"abc"="123"}
```

```output
Name       Location ProvisioningState ResourceGroupName
----       -------- ----------------- -----------------
azps-panlr eastus   Succeeded         azps_test_group_pan
```

Update a LocalRulestackResource.

## PARAMETERS

### -AssociatedSubscription
subscription scope of global rulestack

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultMode
Mode for default rules creation

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

### -Description
rulestack description

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

### -IdentityType
The type of managed identity assigned to this resource.

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

### -IdentityUserAssignedIdentity
The identities assigned to this resource by the user.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MinAppIdVersion
minimum version

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

### -Name
LocalRulestack resource name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: LocalRulestackName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PanEtag
PanEtag info

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

### -PanLocation
Rulestack Location, Required for GlobalRulestacks, Not for LocalRulestacks

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Rulestack Type

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

### -SecurityServiceAntiSpywareProfile
Anti spyware Profile data

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

### -SecurityServiceAntiVirusProfile
anti virus profile data

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

### -SecurityServiceDnsSubscription
DNS Subscription profile data

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

### -SecurityServiceFileBlockingProfile
File blocking profile data

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

### -SecurityServiceOutboundTrustCertificate
Trusted Egress Decryption profile data

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

### -SecurityServiceOutboundUnTrustCertificate
Untrusted Egress Decryption profile data

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

### -SecurityServiceUrlFilteringProfile
URL filtering profile data

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

### -SecurityServiceVulnerabilityProfile
IPs Vulnerability Profile Data

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.ILocalRulestackResource

## NOTES

## RELATED LINKS
