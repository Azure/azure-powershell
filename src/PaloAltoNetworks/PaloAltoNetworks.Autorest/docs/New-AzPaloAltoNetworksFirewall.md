---
external help file:
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/new-azpaloaltonetworksfirewall
schema: 2.0.0
---

# New-AzPaloAltoNetworksFirewall

## SYNOPSIS
Create a FirewallResource

## SYNTAX

```
New-AzPaloAltoNetworksFirewall -Name <String> -ResourceGroupName <String> -Location <String>
 -MarketplaceDetailOfferId <String> -MarketplaceDetailPublisherId <String> -NetworkProfile <INetworkProfile>
 -PlanDataBillingCycle <String> -PlanDataPlanId <String> [-SubscriptionId <String>]
 [-AssociatedRulestackId <String>] [-AssociatedRulestackLocation <String>]
 [-AssociatedRulestackResourceId <String>] [-DnsSettingDnsServer <IIPAddress[]>]
 [-DnsSettingEnabledDnsType <String>] [-DnsSettingEnableDnsProxy <String>] [-EnableSystemAssignedIdentity]
 [-FrontEndSetting <IFrontendSetting[]>] [-IsPanoramaManaged <String>]
 [-MarketplaceDetailMarketplaceSubscriptionStatus <String>] [-PanEtag <String>]
 [-PanoramaConfigString <String>] [-PlanDataUsageType <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a FirewallResource

## EXAMPLES

### Example 1: Create a FirewallResource.
```powershell
$publicIP = New-AzPaloAltoNetworksIPAddressObject -ResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/publicIPAddresses/azps-network-publicipaddresses"

$networkProfile = New-AzPaloAltoNetworksProfileObject -EnableEgressNat DISABLED -PublicIP $publicIP -NetworkType VNET -VnetConfigurationIPOfTrustSubnetForUdrAddress 10.1.1.0/24 -VnetConfigurationTrustSubnetResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network/subnets/subnet1" -VnetConfigurationUnTrustSubnetResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network/subnets/subnet2" -VnetResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network"

New-AzPaloAltoNetworksFirewall -Name azps-firewall -ResourceGroupName azps_test_group_pan -Location eastus -MarketplaceDetailOfferId "pan_swfw_cloud_ngfw" -MarketplaceDetailPublisherId "paloaltonetworks" -NetworkProfile $networkProfile -PlanDataBillingCycle "MONTHLY" -PlanDataPlanId "cloud-ngfw-payg-test" -AssociatedRulestackResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/PaloAltoNetworks.Cloudngfw/localRulestacks/azps-panlr" -DnsSettingDnsServer $publicIP -DnsSettingEnableDnsProxy DISABLED -DnsSettingEnabledDnsType CUSTOM -AssociatedRulestackLocation eastus
```

```output
Location           Name           MarketplaceDetailPublisherId ProvisioningState ResourceGroupName
--------           ----           ---------------------------- ----------------- -----------------
australiasoutheast azps-firewall  paloaltonetworks             Succeeded         azps_test_group_pan
```

Create a FirewallResource.

## PARAMETERS

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

### -EnableSystemAssignedIdentity
Decides if enable a system assigned identity for the resource.

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

Required: True
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Firewall resource name

```yaml
Type: System.String
Parameter Sets: (All)
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

Required: True
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

Required: True
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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IFirewallResource

## NOTES

## RELATED LINKS

