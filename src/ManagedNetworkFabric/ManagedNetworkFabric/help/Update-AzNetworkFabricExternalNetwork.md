---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/update-aznetworkfabricexternalnetwork
schema: 2.0.0
---

# Update-AzNetworkFabricExternalNetwork

## SYNOPSIS
API to update certain properties of the ExternalNetworks resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkFabricExternalNetwork -L3IsolationDomainName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Annotation <String>]
 [-BmpConfigurationState <String>] [-ExportRoutePolicyExportIpv4RoutePolicyId <String>]
 [-ExportRoutePolicyExportIpv6RoutePolicyId <String>] [-ImportRoutePolicyImportIpv4RoutePolicyId <String>]
 [-ImportRoutePolicyImportIpv6RoutePolicyId <String>] [-NativeIpv4PrefixLimit <IPrefixLimitPatchProperties[]>]
 [-NativeIpv6PrefixLimit <IPrefixLimitPatchProperties[]>] [-NetworkToNetworkInterconnectId <String>]
 [-OptionAPropertiesBfdConfigurationIntervalInMilliSecond <Int32>]
 [-OptionAPropertiesBfdConfigurationMultiplier <Int32>] [-OptionAPropertyEgressAclId <String>]
 [-OptionAPropertyIngressAclId <String>] [-OptionAPropertyMtu <Int32>] [-OptionAPropertyPeerAsn <Int64>]
 [-OptionAPropertyPrimaryIpv4Prefix <String>] [-OptionAPropertyPrimaryIpv6Prefix <String>]
 [-OptionAPropertySecondaryIpv4Prefix <String>] [-OptionAPropertySecondaryIpv6Prefix <String>]
 [-OptionAPropertyV4OverV6BgpSession <String>] [-OptionAPropertyV6OverV4BgpSession <String>]
 [-OptionAPropertyVlanId <Int32>] [-OptionBPropertyExportRouteTarget <String[]>]
 [-OptionBPropertyImportRouteTarget <String[]>] [-PeeringOption <String>]
 [-RouteTargetExportIpv4RouteTarget <String[]>] [-RouteTargetExportIpv6RouteTarget <String[]>]
 [-RouteTargetImportIpv4RouteTarget <String[]>] [-RouteTargetImportIpv6RouteTarget <String[]>]
 [-StaticRouteConfigurationBfdConfigurationIntervalInMilliSecond <Int32>]
 [-StaticRouteConfigurationBfdConfigurationMultiplier <Int32>]
 [-StaticRouteConfigurationIpv4Route <IStaticRoutePatchProperties[]>]
 [-StaticRouteConfigurationIpv6Route <IStaticRoutePatchProperties[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzNetworkFabricExternalNetwork -L3IsolationDomainName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzNetworkFabricExternalNetwork -L3IsolationDomainName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityL3IsolationDomainExpanded
```
Update-AzNetworkFabricExternalNetwork -Name <String>
 -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity> [-Annotation <String>]
 [-BmpConfigurationState <String>] [-ExportRoutePolicyExportIpv4RoutePolicyId <String>]
 [-ExportRoutePolicyExportIpv6RoutePolicyId <String>] [-ImportRoutePolicyImportIpv4RoutePolicyId <String>]
 [-ImportRoutePolicyImportIpv6RoutePolicyId <String>] [-NativeIpv4PrefixLimit <IPrefixLimitPatchProperties[]>]
 [-NativeIpv6PrefixLimit <IPrefixLimitPatchProperties[]>] [-NetworkToNetworkInterconnectId <String>]
 [-OptionAPropertiesBfdConfigurationIntervalInMilliSecond <Int32>]
 [-OptionAPropertiesBfdConfigurationMultiplier <Int32>] [-OptionAPropertyEgressAclId <String>]
 [-OptionAPropertyIngressAclId <String>] [-OptionAPropertyMtu <Int32>] [-OptionAPropertyPeerAsn <Int64>]
 [-OptionAPropertyPrimaryIpv4Prefix <String>] [-OptionAPropertyPrimaryIpv6Prefix <String>]
 [-OptionAPropertySecondaryIpv4Prefix <String>] [-OptionAPropertySecondaryIpv6Prefix <String>]
 [-OptionAPropertyV4OverV6BgpSession <String>] [-OptionAPropertyV6OverV4BgpSession <String>]
 [-OptionAPropertyVlanId <Int32>] [-OptionBPropertyExportRouteTarget <String[]>]
 [-OptionBPropertyImportRouteTarget <String[]>] [-PeeringOption <String>]
 [-RouteTargetExportIpv4RouteTarget <String[]>] [-RouteTargetExportIpv6RouteTarget <String[]>]
 [-RouteTargetImportIpv4RouteTarget <String[]>] [-RouteTargetImportIpv6RouteTarget <String[]>]
 [-StaticRouteConfigurationBfdConfigurationIntervalInMilliSecond <Int32>]
 [-StaticRouteConfigurationBfdConfigurationMultiplier <Int32>]
 [-StaticRouteConfigurationIpv4Route <IStaticRoutePatchProperties[]>]
 [-StaticRouteConfigurationIpv6Route <IStaticRoutePatchProperties[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityL3IsolationDomain
```
Update-AzNetworkFabricExternalNetwork -Name <String>
 -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity> -Property <IExternalNetworkPatch>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkFabricExternalNetwork -InputObject <IManagedNetworkFabricIdentity> [-Annotation <String>]
 [-BmpConfigurationState <String>] [-ExportRoutePolicyExportIpv4RoutePolicyId <String>]
 [-ExportRoutePolicyExportIpv6RoutePolicyId <String>] [-ImportRoutePolicyImportIpv4RoutePolicyId <String>]
 [-ImportRoutePolicyImportIpv6RoutePolicyId <String>] [-NativeIpv4PrefixLimit <IPrefixLimitPatchProperties[]>]
 [-NativeIpv6PrefixLimit <IPrefixLimitPatchProperties[]>] [-NetworkToNetworkInterconnectId <String>]
 [-OptionAPropertiesBfdConfigurationIntervalInMilliSecond <Int32>]
 [-OptionAPropertiesBfdConfigurationMultiplier <Int32>] [-OptionAPropertyEgressAclId <String>]
 [-OptionAPropertyIngressAclId <String>] [-OptionAPropertyMtu <Int32>] [-OptionAPropertyPeerAsn <Int64>]
 [-OptionAPropertyPrimaryIpv4Prefix <String>] [-OptionAPropertyPrimaryIpv6Prefix <String>]
 [-OptionAPropertySecondaryIpv4Prefix <String>] [-OptionAPropertySecondaryIpv6Prefix <String>]
 [-OptionAPropertyV4OverV6BgpSession <String>] [-OptionAPropertyV6OverV4BgpSession <String>]
 [-OptionAPropertyVlanId <Int32>] [-OptionBPropertyExportRouteTarget <String[]>]
 [-OptionBPropertyImportRouteTarget <String[]>] [-PeeringOption <String>]
 [-RouteTargetExportIpv4RouteTarget <String[]>] [-RouteTargetExportIpv6RouteTarget <String[]>]
 [-RouteTargetImportIpv4RouteTarget <String[]>] [-RouteTargetImportIpv6RouteTarget <String[]>]
 [-StaticRouteConfigurationBfdConfigurationIntervalInMilliSecond <Int32>]
 [-StaticRouteConfigurationBfdConfigurationMultiplier <Int32>]
 [-StaticRouteConfigurationIpv4Route <IStaticRoutePatchProperties[]>]
 [-StaticRouteConfigurationIpv6Route <IStaticRoutePatchProperties[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
API to update certain properties of the ExternalNetworks resource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Annotation
Switch configuration description.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
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

### -BmpConfigurationState
BMP Configuration State.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
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

### -ExportRoutePolicyExportIpv4RoutePolicyId
ARM resource ID of RoutePolicy.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportRoutePolicyExportIpv6RoutePolicyId
ARM resource ID of RoutePolicy.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportRoutePolicyImportIpv4RoutePolicyId
ARM resource ID of RoutePolicy.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportRoutePolicyImportIpv6RoutePolicyId
ARM resource ID of RoutePolicy.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -L3IsolationDomainInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityL3IsolationDomain
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -L3IsolationDomainName
Name of the L3 Isolation Domain.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the External Network.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityL3IsolationDomain
Aliases: ExternalNetworkName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NativeIpv4PrefixLimit
Prefix limits

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IPrefixLimitPatchProperties[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NativeIpv6PrefixLimit
Prefix limits

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IPrefixLimitPatchProperties[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkToNetworkInterconnectId
ARM Resource ID of the networkToNetworkInterconnectId of the ExternalNetwork resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertiesBfdConfigurationIntervalInMilliSecond
Interval in milliseconds.
Example: 300.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertiesBfdConfigurationMultiplier
Multiplier for the Bfd Configuration.
Example: 5.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyEgressAclId
Egress Acl.
ARM resource ID of Access Control Lists.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyIngressAclId
Ingress Acl.
ARM resource ID of Access Control Lists.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyMtu
MTU to use for option A peering.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyPeerAsn
Peer ASN number.Example : 28

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyPrimaryIpv4Prefix
IPv4 Address Prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyPrimaryIpv6Prefix
IPv6 Address Prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertySecondaryIpv4Prefix
Secondary IPv4 Address Prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertySecondaryIpv6Prefix
Secondary IPv6 Address Prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyV4OverV6BgpSession
V4OverV6 BGP Session state

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyV6OverV4BgpSession
V6OverV4 BGP Session state

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyVlanId
Vlan identifier.
Example : 501

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionBPropertyExportRouteTarget
RouteTargets to be applied.
This is used for the backward compatibility.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionBPropertyImportRouteTarget
RouteTargets to be applied.
This is used for the backward compatibility.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringOption
Peering option list.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
The ExternalNetwork patch resource definition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExternalNetworkPatch
Parameter Sets: UpdateViaIdentityL3IsolationDomain
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteTargetExportIpv4RouteTarget
Route Targets to be applied for outgoing routes into CE.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteTargetExportIpv6RouteTarget
Route Targets to be applied for outgoing routes from CE.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteTargetImportIpv4RouteTarget
Route Targets to be applied for incoming routes into CE.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteTargetImportIpv6RouteTarget
Route Targets to be applied for incoming routes from CE.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticRouteConfigurationBfdConfigurationIntervalInMilliSecond
Interval in milliseconds.
Example: 300.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticRouteConfigurationBfdConfigurationMultiplier
Multiplier for the Bfd Configuration.
Example: 5.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticRouteConfigurationIpv4Route
List of IPv4 Routes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IStaticRoutePatchProperties[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticRouteConfigurationIpv6Route
List of IPv6 Routes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IStaticRoutePatchProperties[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExternalNetworkPatch

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExternalNetwork

## NOTES

## RELATED LINKS
