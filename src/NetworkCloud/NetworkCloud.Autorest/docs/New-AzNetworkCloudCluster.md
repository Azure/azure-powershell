---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/new-aznetworkcloudcluster
schema: 2.0.0
---

# New-AzNetworkCloudCluster

## SYNOPSIS
Create a new cluster or update the properties of the cluster if it exists.

## SYNTAX

```
New-AzNetworkCloudCluster -Name <String> -ResourceGroupName <String>
 -AggregatorOrSingleRackDefinitionNetworkRackId <String>
 -AggregatorOrSingleRackDefinitionRackSerialNumber <String>
 -AggregatorOrSingleRackDefinitionRackSkuId <String> -ClusterType <ClusterType> -ClusterVersion <String>
 -ExtendedLocationName <String> -ExtendedLocationType <String> -Location <String> -NetworkFabricId <String>
 [-SubscriptionId <String>] [-AggregatorOrSingleRackDefinitionAvailabilityZone <String>]
 [-AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration <IBareMetalMachineConfigurationData[]>]
 [-AggregatorOrSingleRackDefinitionRackLocation <String>]
 [-AggregatorOrSingleRackDefinitionStorageApplianceConfiguration <IStorageApplianceConfigurationData[]>]
 [-AnalyticsWorkspaceId <String>] [-AssociatedIdentityType <ManagedServiceIdentitySelectorType>]
 [-AssociatedIdentityUserAssignedIdentityResourceId <String>] [-ClusterLocation <String>]
 [-ClusterServicePrincipalApplicationId <String>] [-ClusterServicePrincipalId <String>]
 [-ClusterServicePrincipalPassword <SecureString>] [-ClusterServicePrincipalTenantId <String>]
 [-CommandOutputSettingContainerUrl <String>]
 [-ComputeDeploymentThresholdGrouping <ValidationThresholdGrouping>]
 [-ComputeDeploymentThresholdType <ValidationThresholdType>] [-ComputeDeploymentThresholdValue <Int64>]
 [-ComputeRackDefinition <IRackDefinition[]>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-ManagedResourceGroupConfigurationLocation <String>]
 [-ManagedResourceGroupConfigurationName <String>]
 [-RuntimeProtectionConfigurationEnforcementLevel <RuntimeProtectionEnforcementLevel>]
 [-SecretArchiveKeyVaultId <String>] [-SecretArchiveUseKeyVault <ClusterSecretArchiveEnabled>]
 [-Tag <Hashtable>] [-UpdateStrategyMaxUnavailable <Int64>]
 [-UpdateStrategyThresholdType <ValidationThresholdType>] [-UpdateStrategyThresholdValue <Int64>]
 [-UpdateStrategyType <ClusterUpdateStrategyType>] [-UpdateStrategyWaitTimeMinute <Int64>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new cluster or update the properties of the cluster if it exists.

## EXAMPLES

### Example 1: Create cluster
```powershell
$storageapplianceconfigurationdata = @()
$baremetalmachineconfigurationdata = @()
$computerackdefinition = @(@{IRackDefinition = "The list of rack definitions for the compute racks in a multi-rackcluster, or an empty list in a single-rack cluster."})
$tagHash = @{
    tag = "tag"
}
$securePassword = ConvertTo-SecureString "password" -asplaintext -force

New-AzNetworkCloudCluster -ResourceGroupName resourceGroup -Name clusterName -AggregatorOrSingleRackDefinitionNetworkRackId rackId -AggregatorOrSingleRackDefinitionRackSerialNumber sr1234 -AggregatorOrSingleRackDefinitionRackSkuId rackSku -ClusterType clustertype -ClusterVersion clusterversion -ExtendedLocationName CmExtendedLocation -ExtendedLocationType CustomLocation -Location location -NetworkFabricId networkFabricId -SubscriptionId subscriptionId -AggregatorOrSingleRackDefinitionAvailabilityZone avilabilityzone -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration $baremetalmachineconfigurationdata -AggregatorOrSingleRackDefinitionRackLocation rackLocation -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration $storageapplianceconfigurationdata -AnalyticsWorkspaceId anlyticsWorkSpaceId -ClusterServicePrincipalApplicationId clusterServicePrincipalAppId -ClusterServicePrincipalId ClusterServicePrincipalId -ClusterServicePrincipalPassword $securePassword -ClusterServicePrincipalTenantId tenantId -ComputeRackDefinition $computerackdefinition -Tag $tagHash
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType  SystemDataLastModifiedAt SystemDataLastModifiedBy         SystemDataLastModifiedByType ResourceGroupName
--------  ---------        -------------------   -------------------       -----------------------  ------------------------ ------------------------         ---------------------------- -----------
eastus    clusterName      08/09/2023 18:33:54   user                    User                       08/09/2023 19:45:35      user                             User                         RGName
```

This command creates a new cluster.

## PARAMETERS

### -AggregatorOrSingleRackDefinitionAvailabilityZone
The zone name used for this rack when created.
Availability zones are used for workload placement.

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

### -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration
The unordered list of bare metal machine configuration.
To construct, see NOTES section for AGGREGATORORSINGLERACKDEFINITIONBAREMETALMACHINECONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IBareMetalMachineConfigurationData[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AggregatorOrSingleRackDefinitionNetworkRackId
The resource ID of the network rack that matches this rack definition.

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

### -AggregatorOrSingleRackDefinitionRackLocation
The free-form description of the rack's location.

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

### -AggregatorOrSingleRackDefinitionRackSerialNumber
The unique identifier for the rack within Network Cloud cluster.
An alternate unique alphanumeric value other than a serial number may be provided if desired.

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

### -AggregatorOrSingleRackDefinitionRackSkuId
The resource ID of the sku for the rack being added.

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

### -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration
The list of storage appliance configuration data for this rack.
To construct, see NOTES section for AGGREGATORORSINGLERACKDEFINITIONSTORAGEAPPLIANCECONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IStorageApplianceConfigurationData[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AnalyticsWorkspaceId
The resource ID of the Log Analytics Workspace that will be used for storing relevant logs.

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

### -AssociatedIdentityType
The type of managed identity that is being selected.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.ManagedServiceIdentitySelectorType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssociatedIdentityUserAssignedIdentityResourceId
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

### -ClusterLocation
The customer-provided location information to identify where the cluster resides.

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

### -ClusterServicePrincipalApplicationId
The application ID, also known as client ID, of the service principal.

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

### -ClusterServicePrincipalId
The principal ID, also known as the object ID, of the service principal.

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

### -ClusterServicePrincipalPassword
The password of the service principal.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterServicePrincipalTenantId
The tenant ID, also known as the directory ID, of the tenant in which the service principal is created.

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

### -ClusterType
The type of rack configuration for the cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.ClusterType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterVersion
The current runtime version of the cluster.

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

### -CommandOutputSettingContainerUrl
The URL of the storage account container that is to be used by the specified identities.

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

### -ComputeDeploymentThresholdGrouping
Selection of how the type evaluation is applied to the cluster calculation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.ValidationThresholdGrouping
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeDeploymentThresholdType
Selection of how the threshold should be evaluated.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.ValidationThresholdType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeDeploymentThresholdValue
The numeric threshold value.

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

### -ComputeRackDefinition
The list of rack definitions for the compute racks in a multi-rackcluster, or an empty list in a single-rack cluster.
To construct, see NOTES section for COMPUTERACKDEFINITION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IRackDefinition[]
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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

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

### -ManagedResourceGroupConfigurationLocation
The location of the managed resource group.
If not specified, the location of the parent resource is chosen.

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

### -ManagedResourceGroupConfigurationName
The name for the managed resource group.
If not specified, the unique name is automatically generated.

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
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFabricId
The resource ID of the Network Fabric associated with the cluster.

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuntimeProtectionConfigurationEnforcementLevel
The mode of operation for runtime protection.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.RuntimeProtectionEnforcementLevel
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretArchiveKeyVaultId
The resource ID of the key vault to archive the secrets of the cluster.

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

### -SecretArchiveUseKeyVault
The indicator if the specified key vault should be used to archive the secrets of the cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.ClusterSecretArchiveEnabled
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

### -UpdateStrategyMaxUnavailable
The maximum number of worker nodes that can be offline within the increment of update, e.g., rack-by-rack.Limited by the maximum number of machines in the increment.
Defaults to the whole increment size.

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

### -UpdateStrategyThresholdType
Selection of how the threshold should be evaluated.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.ValidationThresholdType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateStrategyThresholdValue
The numeric threshold value.

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

### -UpdateStrategyType
The mode of operation for runtime protection.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.ClusterUpdateStrategyType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateStrategyWaitTimeMinute
The time to wait between the increments of update defined by the strategy.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ICluster

## NOTES

## RELATED LINKS

