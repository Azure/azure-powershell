---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricinternalnetwork
schema: 2.0.0
---

# New-AzNetworkFabricInternalNetwork

## SYNOPSIS
Creates InternalNetwork PUT method.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkFabricInternalNetwork -L3IsolationDomainName <String> -Name <String> -ResourceGroupName <String>
 -VlanId <Int32> [-SubscriptionId <String>] [-Annotation <String>]
 [-BgpConfiguration <IInternalNetworkPropertiesBgpConfiguration>] [-ConnectedIPv4Subnet <IConnectedSubnet[]>]
 [-ConnectedIPv6Subnet <IConnectedSubnet[]>] [-EgressAclId <String>] [-ExportRoutePolicy <IExportRoutePolicy>]
 [-ExportRoutePolicyId <String>] [-Extension <String>] [-ImportRoutePolicy <IImportRoutePolicy>]
 [-ImportRoutePolicyId <String>] [-IngressAclId <String>] [-IsMonitoringEnabled <String>] [-Mtu <Int32>]
 [-StaticRouteConfigurationBfdConfiguration <IBfdConfiguration>] [-StaticRouteConfigurationExtension <String>]
 [-StaticRouteConfigurationIpv4Route <IStaticRouteProperties[]>]
 [-StaticRouteConfigurationIpv6Route <IStaticRouteProperties[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityL3IsolationDomain
```
New-AzNetworkFabricInternalNetwork -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity>
 -Name <String> -Body <IInternalNetwork> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityL3IsolationDomainExpanded
```
New-AzNetworkFabricInternalNetwork -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity>
 -Name <String> -VlanId <Int32> [-Annotation <String>]
 [-BgpConfiguration <IInternalNetworkPropertiesBgpConfiguration>] [-ConnectedIPv4Subnet <IConnectedSubnet[]>]
 [-ConnectedIPv6Subnet <IConnectedSubnet[]>] [-EgressAclId <String>] [-ExportRoutePolicy <IExportRoutePolicy>]
 [-ExportRoutePolicyId <String>] [-Extension <String>] [-ImportRoutePolicy <IImportRoutePolicy>]
 [-ImportRoutePolicyId <String>] [-IngressAclId <String>] [-IsMonitoringEnabled <String>] [-Mtu <Int32>]
 [-StaticRouteConfigurationBfdConfiguration <IBfdConfiguration>] [-StaticRouteConfigurationExtension <String>]
 [-StaticRouteConfigurationIpv4Route <IStaticRouteProperties[]>]
 [-StaticRouteConfigurationIpv6Route <IStaticRouteProperties[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabricInternalNetwork -L3IsolationDomainName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabricInternalNetwork -L3IsolationDomainName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates InternalNetwork PUT method.

## EXAMPLES

### Example 1: Create the Internal Network Resource
```powershell
$bgpConfiguration = @{
    AllowAs = 2
    AllowAsOverride = "Enable"
    BfdConfiguration = @{
        IntervalInMilliSecond = 300
        Multiplier = 3
    }
    DefaultRouteOriginate = "True"
    Ipv4ListenRangePrefix = @("20.10.10.2/28")
    Ipv4NeighborAddress = @(@{
        Address = "20.10.10.2"
    })
    PeerAsn = 65047
}
$connectedIPv4Subnet = @(@{
    Prefix = "20.10.10.2/28"
})
$exportRoutePolicy = @{
    ExportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ExportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
$importRoutePolicy = @{
    ImportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ImportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
$staticRouteConfigurationBfdConfiguration = @{
    IntervalInMilliSecond = 300
    Multiplier = 3
}
$staticRouteConfigurationIpv4Route = @(@{
    NextHop = @("10.0.0.1")
    Prefix = "10.1.0.0/24"
})

New-AzNetworkFabricInternalNetwork -Name $name -L3IsolationDomainName $l3domainName -ResourceGroupName $resourceGroupName -VlanId "701" -BgpConfiguration $bgpConfiguration -ConnectedIPv4Subnet $connectedIPv4Subnet -EgressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/aclName" -ExportRoutePolicy $exportRoutePolicy -Extension "NoExtension" -ImportRoutePolicy $importRoutePolicy -IngressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/aclName" -IsMonitoringEnabled "True" -Mtu 1500 -StaticRouteConfigurationBfdConfiguration $staticRouteConfigurationBfdConfiguration -StaticRouteConfigurationExtension "NPB" -StaticRouteConfigurationIpv4Route $staticRouteConfigurationIpv4Route
```

```output
AdministrativeState Annotation BgpConfiguration
------------------- ---------- ----------------
Enabled                        
```

This command creates the Internal Network resource.

## PARAMETERS

### -Annotation
Switch configuration description.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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

### -BgpConfiguration
BGP configuration properties.
To construct, see NOTES section for BGPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternalNetworkPropertiesBgpConfiguration
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Defines the Internal Network resource.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternalNetwork
Parameter Sets: CreateViaIdentityL3IsolationDomain
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectedIPv4Subnet
List of Connected IPv4 Subnets.
To construct, see NOTES section for CONNECTEDIPV4SUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IConnectedSubnet[]
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectedIPv6Subnet
List of connected IPv6 Subnets.
To construct, see NOTES section for CONNECTEDIPV6SUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IConnectedSubnet[]
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportRoutePolicy
Export Route Policy either IPv4 or IPv6.
To construct, see NOTES section for EXPORTROUTEPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExportRoutePolicy
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportRoutePolicyId
ARM Resource ID of the RoutePolicy.
This is used for the backward compatibility.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Extension
Extension.
Example: NoExtension | NPB.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportRoutePolicy
Import Route Policy either IPv4 or IPv6.
To construct, see NOTES section for IMPORTROUTEPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IImportRoutePolicy
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportRoutePolicyId
ARM Resource ID of the RoutePolicy.
This is used for the backward compatibility.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsMonitoringEnabled
To check whether monitoring of internal network is enabled or not.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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

### -L3IsolationDomainInputObject
Identity Parameter
To construct, see NOTES section for L3ISOLATIONDOMAININPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: CreateViaIdentityL3IsolationDomain, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: (All)
Aliases: InternalNetworkName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticRouteConfigurationBfdConfiguration
BFD configuration properties
To construct, see NOTES section for STATICROUTECONFIGURATIONBFDCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IBfdConfiguration
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticRouteConfigurationExtension
Extension.
Example: NoExtension | NPB.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticRouteConfigurationIpv4Route
List of IPv4 Routes.
To construct, see NOTES section for STATICROUTECONFIGURATIONIPV4ROUTE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IStaticRouteProperties[]
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticRouteConfigurationIpv6Route
List of IPv6 Routes.
To construct, see NOTES section for STATICROUTECONFIGURATIONIPV6ROUTE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IStaticRouteProperties[]
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VlanId
Vlan identifier.
Example: 1001.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternalNetwork

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternalNetwork

## NOTES

## RELATED LINKS

