---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/update-aznetworkfabric
schema: 2.0.0
---

# Update-AzNetworkFabric

## SYNOPSIS
Update Network Fabric resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkFabric -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Annotation <String>] [-AuthorizedTransceiverKey <String>] [-AuthorizedTransceiverVendor <String>]
 [-ControlPlaneAcl <String[]>] [-EnableSystemAssignedIdentity <Boolean?>] [-FabricAsn <Int64>]
 [-FabricVersion <String>] [-FeatureFlag <IFeatureFlagProperties[]>] [-HardwareAlertThreshold <Int32>]
 [-Ipv4Prefix <String>] [-Ipv6Prefix <String>]
 [-ManagementNetworkConfiguration <IManagementNetworkConfigurationProperties>]
 [-QoConfigurationQosConfigurationState <String>] [-RackCount <Int32>] [-ServerCountPerRack <Int32>]
 [-StorageAccountConfigurationStorageAccountId <String>] [-StorageAccountIdentityType <String>]
 [-StorageAccountIdentityUserAssignedIdentityResourceId <String>] [-StorageArrayCount <Int32>]
 [-Tag <Hashtable>] [-TerminalServerConfiguration <ITerminalServerConfiguration>]
 [-TrustedIPPrefix <String[]>] [-UniqueRdConfigurationNniDerivedUniqueRdConfigurationState <String>]
 [-UniqueRdConfigurationUniqueRdConfigurationState <String>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkFabric -InputObject <IManagedNetworkFabricIdentity> [-Annotation <String>]
 [-AuthorizedTransceiverKey <String>] [-AuthorizedTransceiverVendor <String>] [-ControlPlaneAcl <String[]>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-FabricAsn <Int64>] [-FabricVersion <String>]
 [-FeatureFlag <IFeatureFlagProperties[]>] [-HardwareAlertThreshold <Int32>] [-Ipv4Prefix <String>]
 [-Ipv6Prefix <String>] [-ManagementNetworkConfiguration <IManagementNetworkConfigurationProperties>]
 [-QoConfigurationQosConfigurationState <String>] [-RackCount <Int32>] [-ServerCountPerRack <Int32>]
 [-StorageAccountConfigurationStorageAccountId <String>] [-StorageAccountIdentityType <String>]
 [-StorageAccountIdentityUserAssignedIdentityResourceId <String>] [-StorageArrayCount <Int32>]
 [-Tag <Hashtable>] [-TerminalServerConfiguration <ITerminalServerConfiguration>]
 [-TrustedIPPrefix <String[]>] [-UniqueRdConfigurationNniDerivedUniqueRdConfigurationState <String>]
 [-UniqueRdConfigurationUniqueRdConfigurationState <String>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update Network Fabric resource.

## EXAMPLES

### Example 1: Update the Network Fabric
```powershell
Update-AzNetworkFabric -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation ConfigurationState FabricAsn FabricVersion Id
---------- ------------------ --------- ------------- --
           Succeeded          65048     1.0           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkFabrics/example-fabric
```

This command updates the properties of the given Network Fabric.

## PARAMETERS

### -Annotation
Switch configuration description.

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

### -AuthorizedTransceiverKey
Key that must be configured on the fabric.

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

### -AuthorizedTransceiverVendor
Vendor of the transceiver.

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

### -ControlPlaneAcl
Control Plane Access Control List ARM resource IDs.

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricAsn
ASN of CE devices for CE/PE connectivity.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricVersion
The version of Network Fabric.

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

### -FeatureFlag
NetworkFabric feature flag configuration information

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IFeatureFlagProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HardwareAlertThreshold
Hardware alert threshold percentage.
Possible values are from 20 to 100.

```yaml
Type: System.Int32
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Ipv4Prefix
IPv4Prefix for Management Network.
Example: 10.1.0.0/19.

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

### -Ipv6Prefix
IPv6Prefix for Management Network.
Example: 3FFE:FFFF:0:CD40::/59

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

### -ManagementNetworkConfiguration
Configuration to be used to setup the management network.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagementNetworkConfigurationProperties
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Network Fabric.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: NetworkFabricName

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

### -QoConfigurationQosConfigurationState
QoS configuration state.
Default is Disabled.

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

### -RackCount
Number of compute racks associated to Network Fabric.

```yaml
Type: System.Int32
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

### -ServerCountPerRack
Number of servers.Possible values are from 1-16.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountConfigurationStorageAccountId
Network Fabric storage account resource identifier.

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

### -StorageAccountIdentityType
The type of managed identity that is being selected.

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

### -StorageAccountIdentityUserAssignedIdentityResourceId
The user assigned managed identity resource ID to use.
Mutually exclusive with a system assigned identity type.

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

### -StorageArrayCount
Number of Storage arrays associated with the Network Fabric.

```yaml
Type: System.Int32
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
The value must be an UUID.

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

### -TerminalServerConfiguration
Network and credentials configuration currently applied to terminal server.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.ITerminalServerConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrustedIPPrefix
Trusted IP Prefixes ARM resource IDs.

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

### -UniqueRdConfigurationNniDerivedUniqueRdConfigurationState
NNI derived unique Route Distinguisher state.
Default is Disabled.

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

### -UniqueRdConfigurationUniqueRdConfigurationState
Unique Route Distinguisher configuration state.
Default is Enabled.

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkFabric

## NOTES

## RELATED LINKS

