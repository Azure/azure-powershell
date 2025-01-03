---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/new-aznetworkcloudl3network
schema: 2.0.0
---

# New-AzNetworkCloudL3Network

## SYNOPSIS
Create a new layer 3 (L3) network or update the properties of the existing network.

## SYNTAX

```
New-AzNetworkCloudL3Network -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -ExtendedLocationName <String> -ExtendedLocationType <String> -L3IsolationDomainId <String> -Location <String>
 -Vlan <Int64> [-HybridAksIpamEnabled <HybridAksIpamEnabled>] [-HybridAksPluginType <HybridAksPluginType>]
 [-IPAllocationType <IPAllocationType>] [-InterfaceName <String>] [-Ipv4ConnectedPrefix <String>]
 [-Ipv6ConnectedPrefix <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a new layer 3 (L3) network or update the properties of the existing network.

## EXAMPLES

### Example 1: Create Layer 3 (L3) network
```powershell
New-AzNetworkCloudL3Network -ResourceGroupName resourceGroupName -Name l3NetworkName -Location eastus -ExtendedLocationName  "subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ExtendedLocation/customLocations/clusterExtendedLocationName" -ExtendedLocationType "CustomLocation" -Vlan 1001 -L3IsolationDomainId "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedNetworkFabric/l3IsolationDomains/l3IsolationDomainName" -Ipv4ConnectedPrefix  "10.1.100.0/24" -Ipv6ConnectedPrefix  "fd01:1::0/64" -SubscriptionId subscriptionId
```

```output
Location Name            SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType AzureAsyncOperation ResourceGroupName
-------- ----            ------------------- -------------------     ----------------------- ------------------------ ------------------------             ---------------------------- ------------------- -----------------
eastus   l3NetworkName   05/09/2023 16:46:38 user1                   User                    05/09/2023 16:55:26      user1                                User                                             resourceGroupName
```

This command creates a new layer 3 (L3) network.

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

### -ExtendedLocationName
The resource ID of the extended location on which the resource will be created.

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

### -ExtendedLocationType
The extended location type, for example, CustomLocation.

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

### -HybridAksIpamEnabled
Field Deprecated.
The field was previously optional, now it will have no defined behavior and will be ignored.
The indicator of whether or not to disable IPAM allocation on the network attachment definition injected into the Hybrid AKS Cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.HybridAksIpamEnabled
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HybridAksPluginType
Field Deprecated.
The field was previously optional, now it will have no defined behavior and will be ignored.
The network plugin type for Hybrid AKS.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.HybridAksPluginType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InterfaceName
The default interface name for this L3 network in the virtual machine.
This name can be overridden by the name supplied in the network attachment configuration of that virtual machine.

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

### -IPAllocationType
The type of the IP address allocation, defaulted to "DualStack".

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.IPAllocationType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv4ConnectedPrefix
The IPV4 prefix (CIDR) assigned to this L3 network.
Required when the IP allocation typeis IPV4 or DualStack.

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

### -Ipv6ConnectedPrefix
The IPV6 prefix (CIDR) assigned to this L3 network.
Required when the IP allocation typeis IPV6 or DualStack.

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

### -L3IsolationDomainId
The resource ID of the Network Fabric l3IsolationDomain.

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

### -Name
The name of the L3 network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: L3NetworkName

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
The value must be an UUID.

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

### -Vlan
The VLAN from the l3IsolationDomain that is used for this network.

```yaml
Type: System.Int64
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IL3Network

## NOTES

## RELATED LINKS
