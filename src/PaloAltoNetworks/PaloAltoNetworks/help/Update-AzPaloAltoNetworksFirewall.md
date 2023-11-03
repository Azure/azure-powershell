---
external help file:
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
 [-DnsSettingEnabledDnsType <EnabledDnsType>] [-DnsSettingEnableDnsProxy <DnsProxy>]
 [-FrontEndSetting <IFrontendSetting[]>] [-IdentityType <ManagedIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-IsPanoramaManaged <BooleanEnum>]
 [-MarketplaceDetailMarketplaceSubscriptionStatus <MarketplaceSubscriptionStatus>]
 [-MarketplaceDetailOfferId <String>] [-MarketplaceDetailPublisherId <String>]
 [-NetworkProfile <INetworkProfile>] [-PanEtag <String>] [-PanoramaConfigString <String>]
 [-PlanDataBillingCycle <BillingCycle>] [-PlanDataPlanId <String>] [-PlanDataUsageType <UsageType>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPaloAltoNetworksFirewall -InputObject <IPaloAltoNetworksIdentity> [-AssociatedRulestackId <String>]
 [-AssociatedRulestackLocation <String>] [-AssociatedRulestackResourceId <String>]
 [-DnsSettingDnsServer <IIPAddress[]>] [-DnsSettingEnabledDnsType <EnabledDnsType>]
 [-DnsSettingEnableDnsProxy <DnsProxy>] [-FrontEndSetting <IFrontendSetting[]>]
 [-IdentityType <ManagedIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-IsPanoramaManaged <BooleanEnum>]
 [-MarketplaceDetailMarketplaceSubscriptionStatus <MarketplaceSubscriptionStatus>]
 [-MarketplaceDetailOfferId <String>] [-MarketplaceDetailPublisherId <String>]
 [-NetworkProfile <INetworkProfile>] [-PanEtag <String>] [-PanoramaConfigString <String>]
 [-PlanDataBillingCycle <BillingCycle>] [-PlanDataPlanId <String>] [-PlanDataUsageType <UsageType>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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
To construct, see NOTES section for DNSSETTINGDNSSERVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.Api20220829.IIPAddress[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Support.EnabledDnsType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Support.DnsProxy
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
To construct, see NOTES section for FRONTENDSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.Api20220829.IFrontendSetting[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Support.ManagedIdentityType
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Support.BooleanEnum
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
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Support.MarketplaceSubscriptionStatus
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
To construct, see NOTES section for NETWORKPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.Api20220829.INetworkProfile
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
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Support.BillingCycle
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
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Support.UsageType
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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.Api20220829.IFirewallResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`DNSSETTINGDNSSERVER <IIPAddress[]>`: List of IPs associated with the Firewall
  - `[Address <String>]`: Address value
  - `[ResourceId <String>]`: Resource Id

`FRONTENDSETTING <IFrontendSetting[]>`: Frontend settings for Firewall
  - `BackendConfigurationPort <String>`: port ID
  - `FrontendConfigurationPort <String>`: port ID
  - `Name <String>`: Settings name
  - `Protocol <ProtocolType>`: Protocol Type
  - `[Address <String>]`: Address value
  - `[BackendConfigurationAddress1 <String>]`: Address value
  - `[BackendConfigurationAddressResourceId <String>]`: Resource Id
  - `[FrontendConfigurationAddressResourceId <String>]`: Resource Id

`INPUTOBJECT <IPaloAltoNetworksIdentity>`: Identity Parameter
  - `[FirewallName <String>]`: Firewall resource name
  - `[GlobalRulestackName <String>]`: GlobalRulestack resource name
  - `[Id <String>]`: Resource identity path
  - `[LocalRulestackName <String>]`: LocalRulestack resource name
  - `[Name <String>]`: certificate name
  - `[Priority <String>]`: Post Rule priority
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

`NETWORKPROFILE <INetworkProfile>`: Network settings
  - `EnableEgressNat <EgressNat>`: Enable egress NAT, enabled by default
  - `NetworkType <NetworkType>`: vnet or vwan, cannot be updated
  - `PublicIP <IIPAddress[]>`: List of IPs associated with the Firewall
  - `[EgressNatIP <IIPAddress[]>]`: Egress nat IP to use
    - `[Address <String>]`: Address value
    - `[ResourceId <String>]`: Resource Id
  - `[VHubAddressSpace <String>]`: Address Space
  - `[VHubResourceId <String>]`: Resource Id
  - `[VnetAddressSpace <String>]`: Address Space
  - `[VnetConfigurationIPOfTrustSubnetForUdrAddress <String>]`: Address value
  - `[VnetConfigurationIPOfTrustSubnetForUdrResourceId <String>]`: Resource Id
  - `[VnetConfigurationTrustSubnetAddressSpace <String>]`: Address Space
  - `[VnetConfigurationTrustSubnetResourceId <String>]`: Resource Id
  - `[VnetConfigurationUnTrustSubnetAddressSpace <String>]`: Address Space
  - `[VnetConfigurationUnTrustSubnetResourceId <String>]`: Resource Id
  - `[VnetResourceId <String>]`: Resource Id
  - `[VwanConfigurationIPOfTrustSubnetForUdrAddress <String>]`: Address value
  - `[VwanConfigurationIPOfTrustSubnetForUdrResourceId <String>]`: Resource Id
  - `[VwanConfigurationNetworkVirtualApplianceId <String>]`: Network Virtual Appliance resource ID 
  - `[VwanConfigurationTrustSubnetAddressSpace <String>]`: Address Space
  - `[VwanConfigurationTrustSubnetResourceId <String>]`: Resource Id
  - `[VwanConfigurationUnTrustSubnetAddressSpace <String>]`: Address Space
  - `[VwanConfigurationUnTrustSubnetResourceId <String>]`: Resource Id

## RELATED LINKS

