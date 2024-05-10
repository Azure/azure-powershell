---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricexternalnetwork
schema: 2.0.0
---

# New-AzNetworkFabricExternalNetwork

## SYNOPSIS
Create ExternalNetwork PUT method.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkFabricExternalNetwork -L3IsolationDomainName <String> -Name <String> -ResourceGroupName <String>
 -PeeringOption <String> [-SubscriptionId <String>] [-Annotation <String>]
 [-ExportRoutePolicy <IExportRoutePolicy>] [-ExportRoutePolicyId <String>]
 [-ImportRoutePolicy <IImportRoutePolicy>] [-ImportRoutePolicyId <String>]
 [-OptionAPropertyBfdConfiguration <IBfdConfiguration>] [-OptionAPropertyEgressAclId <String>]
 [-OptionAPropertyIngressAclId <String>] [-OptionAPropertyMtu <Int32>] [-OptionAPropertyPeerAsn <Int64>]
 [-OptionAPropertyPrimaryIpv4Prefix <String>] [-OptionAPropertyPrimaryIpv6Prefix <String>]
 [-OptionAPropertySecondaryIpv4Prefix <String>] [-OptionAPropertySecondaryIpv6Prefix <String>]
 [-OptionAPropertyVlanId <Int32>] [-OptionBProperty <IL3OptionBProperties>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityL3IsolationDomain
```
New-AzNetworkFabricExternalNetwork -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity>
 -Name <String> -Body <IExternalNetwork> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityL3IsolationDomainExpanded
```
New-AzNetworkFabricExternalNetwork -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity>
 -Name <String> -PeeringOption <String> [-Annotation <String>] [-ExportRoutePolicy <IExportRoutePolicy>]
 [-ExportRoutePolicyId <String>] [-ImportRoutePolicy <IImportRoutePolicy>] [-ImportRoutePolicyId <String>]
 [-OptionAPropertyBfdConfiguration <IBfdConfiguration>] [-OptionAPropertyEgressAclId <String>]
 [-OptionAPropertyIngressAclId <String>] [-OptionAPropertyMtu <Int32>] [-OptionAPropertyPeerAsn <Int64>]
 [-OptionAPropertyPrimaryIpv4Prefix <String>] [-OptionAPropertyPrimaryIpv6Prefix <String>]
 [-OptionAPropertySecondaryIpv4Prefix <String>] [-OptionAPropertySecondaryIpv6Prefix <String>]
 [-OptionAPropertyVlanId <Int32>] [-OptionBProperty <IL3OptionBProperties>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabricExternalNetwork -L3IsolationDomainName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabricExternalNetwork -L3IsolationDomainName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create ExternalNetwork PUT method.

## EXAMPLES

### Example 1: Create the External Network Resource
```powershell
$exportRoutePolicy = @{
    ExportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ExportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
$importRoutePolicy = @{
    ImportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ImportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
$routeTarget = @{
    ExportIpv4RouteTarget = @("65046:10039")
    ExportIpv6RouteTarget = @("65046:10039")
    ImportIpv4RouteTarget = @("65046:10039")
    ImportIpv6RouteTarget = @("65046:10039")
}
$optionBProperty = @{
    RouteTarget = $routeTarget
}

$optionAPropertyBfdConfiguration = @{
    IntervalInMilliSecond = 300
    Multiplier = 3
}

New-AzNetworkFabricExternalNetwork -L3IsolationDomainName $l3domainName -Name $name -ResourceGroupName $resourceGroupName -PeeringOption "OptionB" -ExportRoutePolicy $exportRoutePolicy -ImportRoutePolicy $importRoutePolicy -OptionBProperty $optionBProperty
```

```output
AdministrativeState Annotation ConfigurationState ExportRoutePolicy
------------------- ---------- ------------------ -----------------
Enabled                                           
```

This command creates the External Network resource with Option B Properties.

### Example 2: Create the External Network Resource
```powershell
New-AzNetworkFabricExternalNetwork -L3IsolationDomainName $l3domainName -Name $name -ResourceGroupName $resourceGroupName -PeeringOption "OptionA" -ExportRoutePolicy $exportRoutePolicy -ImportRoutePolicy $importRoutePolicy -OptionAPropertyBfdConfiguration $optionAPropertyBfdConfiguration -OptionAPropertyEgressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/egressAclName" -OptionAPropertyIngressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/ingressAclName" -OptionAPropertyMtu 1500 -OptionAPropertyPeerAsn 65123 -OptionAPropertyPrimaryIpv4Prefix "172.31.0.0/30" -OptionAPropertySecondaryIpv4Prefix "172.31.0.0/30" -OptionAPropertyVlanId 501
```

```output
AdministrativeState Annotation ConfigurationState ExportRoutePolicy
------------------- ---------- ------------------ -----------------
Enabled                                           
```

This command creates the External Network resource with Option A Properties.

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

### -Body
Defines the External Network resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExternalNetwork
Parameter Sets: CreateViaIdentityL3IsolationDomain
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ExportRoutePolicy
Export Route Policy either IPv4 or IPv6.

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

### -ImportRoutePolicy
Import Route Policy either IPv4 or IPv6.

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

### -Name
Name of the External Network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ExternalNetworkName

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

### -OptionAPropertyBfdConfiguration
BFD configuration properties

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

### -OptionAPropertyEgressAclId
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

### -OptionAPropertyIngressAclId
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

### -OptionAPropertyMtu
MTU to use for option A peering.

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

### -OptionAPropertyPeerAsn
Peer ASN number.Example : 28

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionBProperty
option B properties object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IL3OptionBProperties
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExternalNetwork

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExternalNetwork

## NOTES

## RELATED LINKS

