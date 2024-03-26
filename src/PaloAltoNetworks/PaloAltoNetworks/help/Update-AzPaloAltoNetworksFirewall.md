---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/update-azpaloaltonetworksfirewall
schema: 2.0.0
---

# Update-AzPaloAltoNetworksFirewall

## SYNOPSIS
Update a FirewallResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPaloAltoNetworksFirewall -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AssociatedRulestackId <String>] [-AssociatedRulestackLocation <String>]
 [-AssociatedRulestackResourceId <String>] [-DnsSettingDnsServer <IIPAddress[]>]
 [-DnsSettingEnableDnsProxy <String>] [-DnsSettingEnabledDnsType <String>]
 [-FrontEndSetting <IFrontendSetting[]>] [-IdentityType <String>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-IsPanoramaManaged <String>] [-MarketplaceDetailMarketplaceSubscriptionStatus <String>]
 [-MarketplaceDetailOfferId <String>] [-MarketplaceDetailPublisherId <String>]
 [-NetworkProfile <INetworkProfile>] [-PanEtag <String>] [-PanoramaConfigString <String>]
 [-PlanDataBillingCycle <String>] [-PlanDataPlanId <String>] [-PlanDataUsageType <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPaloAltoNetworksFirewall -InputObject <IPaloAltoNetworksIdentity> [-AssociatedRulestackId <String>]
 [-AssociatedRulestackLocation <String>] [-AssociatedRulestackResourceId <String>]
 [-DnsSettingDnsServer <IIPAddress[]>] [-DnsSettingEnableDnsProxy <String>]
 [-DnsSettingEnabledDnsType <String>] [-FrontEndSetting <IFrontendSetting[]>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-IsPanoramaManaged <String>]
 [-MarketplaceDetailMarketplaceSubscriptionStatus <String>] [-MarketplaceDetailOfferId <String>]
 [-MarketplaceDetailPublisherId <String>] [-NetworkProfile <INetworkProfile>] [-PanEtag <String>]
 [-PanoramaConfigString <String>] [-PlanDataBillingCycle <String>] [-PlanDataPlanId <String>]
 [-PlanDataUsageType <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a FirewallResource

## EXAMPLES

### Example 1: Update a FirewallResource.
```powershell
Update-AzPaloAltoNetworksFirewall -Name azps-firewall -ResourceGroupName azps_test_group_pan -Tag @{"123"="abc"}
```

```output
Location           Name           MarketplaceDetailPublisherId ProvisioningState ResourceGroupName
--------           ----           ---------------------------- ----------------- -----------------
australiasoutheast azps-firewall  paloaltonetworks             Succeeded         azps_test_group_pan
```

Update a FirewallResource.

## PARAMETERS

### -AssociatedRulestackId
Associated rulestack Id

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

### -AssociatedRulestackLocation
Rulestack location

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

### -AssociatedRulestackResourceId
Resource Id

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

### -DnsSettingDnsServer
List of IPs associated with the Firewall

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IIPAddress[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DnsSettingEnabledDnsType
Enabled DNS proxy type, disabled by default

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

### -DnsSettingEnableDnsProxy
Enable DNS proxy, disabled by default

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

### -FrontEndSetting
Frontend settings for Firewall

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IFrontendSetting[]
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

### -IsPanoramaManaged
Panorama Managed: Default is False.
Default will be CloudSec managed

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

### -MarketplaceDetailMarketplaceSubscriptionStatus
Marketplace Subscription Status

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

### -MarketplaceDetailOfferId
Offer Id

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

### -MarketplaceDetailPublisherId
Publisher Id

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
Firewall resource name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: FirewallName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfile
Network settings

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.INetworkProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PanEtag
panEtag info

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

### -PanoramaConfigString
Base64 encoded string representing Panorama parameters to be used by Firewall to connect to Panorama.
This string is generated via azure plugin in Panorama

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

### -PlanDataBillingCycle
different billing cycles like MONTHLY/WEEKLY

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

### -PlanDataPlanId
plan id as published by Liftr.PAN

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

### -PlanDataUsageType
different usage type like PAYG/COMMITTED

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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IFirewallResource

## NOTES

## RELATED LINKS
