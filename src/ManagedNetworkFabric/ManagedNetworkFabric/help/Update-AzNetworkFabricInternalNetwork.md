---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/update-aznetworkfabricinternalnetwork
schema: 2.0.0
---

# Update-AzNetworkFabricInternalNetwork

## SYNOPSIS
Update a InternalNetworks.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkFabricInternalNetwork -L3IsolationDomainName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Annotation <String>]
 [-BgpConfigurationAllowAs <Int32>] [-BgpConfigurationAllowAsOverride <String>]
 [-BgpConfigurationAnnotation <String>] [-BgpConfigurationBfdConfigurationIntervalInMilliSecond <Int32>]
 [-BgpConfigurationBfdConfigurationMultiplier <Int32>] [-BgpConfigurationDefaultRouteOriginate <String>]
 [-BgpConfigurationIpv4ListenRangePrefix <String[]>]
 [-BgpConfigurationIpv4NeighborAddress <INeighborAddressPatch[]>]
 [-BgpConfigurationIpv6ListenRangePrefix <String[]>]
 [-BgpConfigurationIpv6NeighborAddress <INeighborAddressPatch[]>] [-BgpConfigurationPeerAsn <Int64>]
 [-BgpConfigurationV4OverV6BgpSession <String>] [-BgpConfigurationV6OverV4BgpSession <String>]
 [-BmpConfigurationNeighborIPExclusion <String[]>] [-BmpConfigurationState <String>]
 [-ConnectedIPv4Subnet <IConnectedSubnetPatch[]>] [-ConnectedIPv6Subnet <IConnectedSubnetPatch[]>]
 [-EgressAclId <String>] [-ExportRoutePolicy <IExportRoutePolicy>] [-ImportRoutePolicy <IImportRoutePolicy>]
 [-IngressAclId <String>] [-IsMonitoringEnabled <String>] [-Mtu <Int32>]
 [-NativeIpv4PrefixLimit <IPrefixLimitPatchProperties[]>]
 [-NativeIpv6PrefixLimit <IPrefixLimitPatchProperties[]>]
 [-StaticRouteConfigurationBfdConfigurationIntervalInMilliSecond <Int32>]
 [-StaticRouteConfigurationBfdConfigurationMultiplier <Int32>]
 [-StaticRouteConfigurationIpv4Route <IStaticRoutePatchProperties[]>]
 [-StaticRouteConfigurationIpv6Route <IStaticRoutePatchProperties[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzNetworkFabricInternalNetwork -L3IsolationDomainName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzNetworkFabricInternalNetwork -L3IsolationDomainName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityL3IsolationDomainExpanded
```
Update-AzNetworkFabricInternalNetwork -Name <String>
 -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity> [-Annotation <String>]
 [-BgpConfigurationAllowAs <Int32>] [-BgpConfigurationAllowAsOverride <String>]
 [-BgpConfigurationAnnotation <String>] [-BgpConfigurationBfdConfigurationIntervalInMilliSecond <Int32>]
 [-BgpConfigurationBfdConfigurationMultiplier <Int32>] [-BgpConfigurationDefaultRouteOriginate <String>]
 [-BgpConfigurationIpv4ListenRangePrefix <String[]>]
 [-BgpConfigurationIpv4NeighborAddress <INeighborAddressPatch[]>]
 [-BgpConfigurationIpv6ListenRangePrefix <String[]>]
 [-BgpConfigurationIpv6NeighborAddress <INeighborAddressPatch[]>] [-BgpConfigurationPeerAsn <Int64>]
 [-BgpConfigurationV4OverV6BgpSession <String>] [-BgpConfigurationV6OverV4BgpSession <String>]
 [-BmpConfigurationNeighborIPExclusion <String[]>] [-BmpConfigurationState <String>]
 [-ConnectedIPv4Subnet <IConnectedSubnetPatch[]>] [-ConnectedIPv6Subnet <IConnectedSubnetPatch[]>]
 [-EgressAclId <String>] [-ExportRoutePolicy <IExportRoutePolicy>] [-ImportRoutePolicy <IImportRoutePolicy>]
 [-IngressAclId <String>] [-IsMonitoringEnabled <String>] [-Mtu <Int32>]
 [-NativeIpv4PrefixLimit <IPrefixLimitPatchProperties[]>]
 [-NativeIpv6PrefixLimit <IPrefixLimitPatchProperties[]>]
 [-StaticRouteConfigurationBfdConfigurationIntervalInMilliSecond <Int32>]
 [-StaticRouteConfigurationBfdConfigurationMultiplier <Int32>]
 [-StaticRouteConfigurationIpv4Route <IStaticRoutePatchProperties[]>]
 [-StaticRouteConfigurationIpv6Route <IStaticRoutePatchProperties[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityL3IsolationDomain
```
Update-AzNetworkFabricInternalNetwork -Name <String>
 -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity> -Property <IInternalNetworkPatch>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkFabricInternalNetwork -InputObject <IManagedNetworkFabricIdentity> [-Annotation <String>]
 [-BgpConfigurationAllowAs <Int32>] [-BgpConfigurationAllowAsOverride <String>]
 [-BgpConfigurationAnnotation <String>] [-BgpConfigurationBfdConfigurationIntervalInMilliSecond <Int32>]
 [-BgpConfigurationBfdConfigurationMultiplier <Int32>] [-BgpConfigurationDefaultRouteOriginate <String>]
 [-BgpConfigurationIpv4ListenRangePrefix <String[]>]
 [-BgpConfigurationIpv4NeighborAddress <INeighborAddressPatch[]>]
 [-BgpConfigurationIpv6ListenRangePrefix <String[]>]
 [-BgpConfigurationIpv6NeighborAddress <INeighborAddressPatch[]>] [-BgpConfigurationPeerAsn <Int64>]
 [-BgpConfigurationV4OverV6BgpSession <String>] [-BgpConfigurationV6OverV4BgpSession <String>]
 [-BmpConfigurationNeighborIPExclusion <String[]>] [-BmpConfigurationState <String>]
 [-ConnectedIPv4Subnet <IConnectedSubnetPatch[]>] [-ConnectedIPv6Subnet <IConnectedSubnetPatch[]>]
 [-EgressAclId <String>] [-ExportRoutePolicy <IExportRoutePolicy>] [-ImportRoutePolicy <IImportRoutePolicy>]
 [-IngressAclId <String>] [-IsMonitoringEnabled <String>] [-Mtu <Int32>]
 [-NativeIpv4PrefixLimit <IPrefixLimitPatchProperties[]>]
 [-NativeIpv6PrefixLimit <IPrefixLimitPatchProperties[]>]
 [-StaticRouteConfigurationBfdConfigurationIntervalInMilliSecond <Int32>]
 [-StaticRouteConfigurationBfdConfigurationMultiplier <Int32>]
 [-StaticRouteConfigurationIpv4Route <IStaticRoutePatchProperties[]>]
 [-StaticRouteConfigurationIpv6Route <IStaticRoutePatchProperties[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a InternalNetworks.

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

### -BgpConfigurationAllowAs
Allows for routes to be received and processed even if the router detects its own ASN in the AS-Path.
0 is disable, Possible values are 1-10, default is 2.

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

### -BgpConfigurationAllowAsOverride
Enable Or Disable state.

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

### -BgpConfigurationAnnotation
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

### -BgpConfigurationBfdConfigurationIntervalInMilliSecond
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

### -BgpConfigurationBfdConfigurationMultiplier
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

### -BgpConfigurationDefaultRouteOriginate
Originate a defaultRoute.
Ex: "True" | "False".

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

### -BgpConfigurationIpv4ListenRangePrefix
List of BGP IPv4 Listen Range prefixes.

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

### -BgpConfigurationIpv4NeighborAddress
List with stringified IPv4 Neighbor Addresses.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INeighborAddressPatch[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpConfigurationIpv6ListenRangePrefix
List of BGP IPv6 Listen Ranges prefixes.

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

### -BgpConfigurationIpv6NeighborAddress
List with stringified IPv6 Neighbor Address.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INeighborAddressPatch[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpConfigurationPeerAsn
Peer ASN.
Example: 65047.

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

### -BgpConfigurationV4OverV6BgpSession
V4 over V6 bgp session.

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

### -BgpConfigurationV6OverV4BgpSession
v6 over v4 bgp session.

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

### -BmpConfigurationNeighborIPExclusion
BMP Collector Address.

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

### -BmpConfigurationState
BMP Monitoring configuration state.

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

### -ConnectedIPv4Subnet
List of Connected IPv4 Subnets.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IConnectedSubnetPatch[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectedIPv6Subnet
List of connected IPv6 Subnets.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IConnectedSubnetPatch[]
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

### -EgressAclId
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

### -ExportRoutePolicy
Export Route Policy either IPv4 or IPv6.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExportRoutePolicy
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportRoutePolicy
Import Route Policy either IPv4 or IPv6.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IImportRoutePolicy
Parameter Sets: UpdateExpanded, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressAclId
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

### -IsMonitoringEnabled
To check whether monitoring of internal network is enabled or not.

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

### -Mtu
Maximum transmission unit.
Default value is 1500.

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

### -Name
Name of the Internal Network.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityL3IsolationDomainExpanded, UpdateViaIdentityL3IsolationDomain
Aliases: InternalNetworkName

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

### -Property
The InternalNetwork patch resource definition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternalNetworkPatch
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternalNetworkPatch

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternalNetwork

## NOTES

## RELATED LINKS
