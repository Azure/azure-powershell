---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/update-aznetworkcloudcluster
schema: 2.0.0
---

# Update-AzNetworkCloudCluster

## SYNOPSIS
Update a new cluster or update the properties of the cluster if it exists.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkCloudCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-AggregatorOrSingleRackDefinitionAvailabilityZone <String>]
 [-AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration <IBareMetalMachineConfigurationData[]>]
 [-AggregatorOrSingleRackDefinitionNetworkRackId <String>]
 [-AggregatorOrSingleRackDefinitionRackLocation <String>]
 [-AggregatorOrSingleRackDefinitionRackSerialNumber <String>]
 [-AggregatorOrSingleRackDefinitionRackSkuId <String>]
 [-AggregatorOrSingleRackDefinitionStorageApplianceConfiguration <IStorageApplianceConfigurationData[]>]
 [-AnalyticOutputSettingAnalyticsWorkspaceId <String>]
 [-AnalyticsOutputSettingsAssociatedIdentityType <String>]
 [-AnalyticsOutputSettingsAssociatedIdentityUserAssignedIdentityResourceId <String>]
 [-AssociatedIdentityType <String>] [-AssociatedIdentityUserAssignedIdentityResourceId <String>]
 [-ClusterLocation <String>] [-ClusterServicePrincipalApplicationId <String>]
 [-ClusterServicePrincipalId <String>] [-ClusterServicePrincipalPassword <SecureString>]
 [-ClusterServicePrincipalTenantId <String>] [-CommandOutputSettingContainerUrl <String>]
 [-ComputeDeploymentThresholdGrouping <String>] [-ComputeDeploymentThresholdType <String>]
 [-ComputeDeploymentThresholdValue <Int64>] [-ComputeRackDefinition <IRackDefinition[]>]
 [-EnableSystemAssignedIdentity <Boolean>] [-RuntimeProtectionConfigurationEnforcementLevel <String>]
 [-SecretArchiveKeyVaultId <String>] [-SecretArchiveSettingVaultUri <String>]
 [-SecretArchiveSettingsAssociatedIdentityType <String>]
 [-SecretArchiveSettingsAssociatedIdentityUserAssignedIdentityResourceId <String>]
 [-SecretArchiveUseKeyVault <String>] [-Tag <Hashtable>] [-UpdateStrategyMaxUnavailable <Int64>]
 [-UpdateStrategyThresholdType <String>] [-UpdateStrategyThresholdValue <Int64>] [-UpdateStrategyType <String>]
 [-UpdateStrategyWaitTimeMinute <Int64>] [-UserAssignedIdentity <String[]>]
 [-VulnerabilityScanningSettingContainerScan <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkCloudCluster -InputObject <INetworkCloudIdentity> [-IfMatch <String>] [-IfNoneMatch <String>]
 [-AggregatorOrSingleRackDefinitionAvailabilityZone <String>]
 [-AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration <IBareMetalMachineConfigurationData[]>]
 [-AggregatorOrSingleRackDefinitionNetworkRackId <String>]
 [-AggregatorOrSingleRackDefinitionRackLocation <String>]
 [-AggregatorOrSingleRackDefinitionRackSerialNumber <String>]
 [-AggregatorOrSingleRackDefinitionRackSkuId <String>]
 [-AggregatorOrSingleRackDefinitionStorageApplianceConfiguration <IStorageApplianceConfigurationData[]>]
 [-AnalyticOutputSettingAnalyticsWorkspaceId <String>]
 [-AnalyticsOutputSettingsAssociatedIdentityType <String>]
 [-AnalyticsOutputSettingsAssociatedIdentityUserAssignedIdentityResourceId <String>]
 [-AssociatedIdentityType <String>] [-AssociatedIdentityUserAssignedIdentityResourceId <String>]
 [-ClusterLocation <String>] [-ClusterServicePrincipalApplicationId <String>]
 [-ClusterServicePrincipalId <String>] [-ClusterServicePrincipalPassword <SecureString>]
 [-ClusterServicePrincipalTenantId <String>] [-CommandOutputSettingContainerUrl <String>]
 [-ComputeDeploymentThresholdGrouping <String>] [-ComputeDeploymentThresholdType <String>]
 [-ComputeDeploymentThresholdValue <Int64>] [-ComputeRackDefinition <IRackDefinition[]>]
 [-EnableSystemAssignedIdentity <Boolean>] [-RuntimeProtectionConfigurationEnforcementLevel <String>]
 [-SecretArchiveKeyVaultId <String>] [-SecretArchiveSettingVaultUri <String>]
 [-SecretArchiveSettingsAssociatedIdentityType <String>]
 [-SecretArchiveSettingsAssociatedIdentityUserAssignedIdentityResourceId <String>]
 [-SecretArchiveUseKeyVault <String>] [-Tag <Hashtable>] [-UpdateStrategyMaxUnavailable <Int64>]
 [-UpdateStrategyThresholdType <String>] [-UpdateStrategyThresholdValue <Int64>] [-UpdateStrategyType <String>]
 [-UpdateStrategyWaitTimeMinute <Int64>] [-UserAssignedIdentity <String[]>]
 [-VulnerabilityScanningSettingContainerScan <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a new cluster or update the properties of the cluster if it exists.

## EXAMPLES

### Example 1: Update cluster
```powershell
$storageapplianceconfigurationdata = @()
$baremetalmachineconfigurationdata = @()
$computerackdefinition = @(@{IRackDefinition = "The list of rack definitions for the compute racks in a multi-rack cluster, or an empty list in a single-rack cluster."})
$tagHash = @{
    tag = "tag"
    tagUpdate = "tagUpdate"
}
$securePassword = ConvertTo-SecureString "password" -asplaintext -force

Update-AzNetworkCloudCluster -ResourceGroupName resourceGroup -Name clusterName -SubscriptionId subscriptionId -AggregatorOrSingleRackDefinitionNetworkRackId rackId -AggregatorOrSingleRackDefinitionRackSerialNumber sr1234 -AggregatorOrSingleRackDefinitionRackSkuId rackSku -AggregatorOrSingleRackDefinitionAvailabilityZone availabilityzone -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration $baremetalmachineconfigurationdata -AggregatorOrSingleRackDefinitionRackLocation rackLocation -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration $storageapplianceconfigurationdata -ClusterServicePrincipalApplicationId clusterServicePrincipalAppId -ClusterServicePrincipalId ClusterServicePrincipalId -ClusterServicePrincipalPassword $securePassword -ClusterServicePrincipalTenantId tenantId -ComputeRackDefinition $computerackdefinition -Tag $tagHash
```

```output
Location Name             SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGro
                                                                                                                                                                                           upName
-------- ----             ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- -----------
eastus   clusterName        08/09/2023 18:33:54   user                          User             08/09/2023 19:45:35           user                                       User              RGName
```

Patch the properties of the provided cluster, or update the tags associated with the cluster.
Properties and tag updates can be done independently.

### Example 2: Update cluster with Identity
```powershell
$storageapplianceconfigurationdata = @()
$baremetalmachineconfigurationdata = @()
$computerackdefinition = @(@{IRackDefinition = "The list of rack definitions for the compute racks in a multi-rack cluster, or an empty list in a single-rack cluster."})
$tagHash = @{
    tag = "tag"
    tagUpdate = "tagUpdate"
}
$securePassword = ConvertTo-SecureString "password" -asplaintext -force
$userAssignedIdentityResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myManagedIdentity"


Update-AzNetworkCloudCluster -ResourceGroupName resourceGroup -Name clusterName -AggregatorOrSingleRackDefinitionNetworkRackId rackId -AggregatorOrSingleRackDefinitionRackSerialNumber sr1234 -AggregatorOrSingleRackDefinitionRackSkuId rackSku -UserAssignedIdentity $userAssignedIdentityResourceId -SubscriptionId subscriptionId -AggregatorOrSingleRackDefinitionAvailabilityZone availabilityZone -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration $baremetalmachineconfigurationdata -AggregatorOrSingleRackDefinitionRackLocation rackLocation -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration $storageapplianceconfigurationdata -AnalyticsOutputSettingsAssociatedIdentityType identityType -AnalyticsOutputSettingsAssociatedIdentityUserAssignedIdentityResourceId userAssignedIdentityResourceId -AnalyticOutputSettingAnalyticsWorkspaceId analyticsWorkspaceId -CommandOutputSettingContainerUrl containerUrl -AssociatedIdentityType commandOutputSettingsIdentityType -AssociatedIdentityUserAssignedIdentityResourceId commandOutputSettingsUserAssignedIdentityResourceId -ClusterServicePrincipalApplicationId clusterServicePrincipalAppId -ClusterServicePrincipalId ClusterServicePrincipalId -ClusterServicePrincipalPassword $securePassword -ClusterServicePrincipalTenantId tenantId -ComputeRackDefinition $computerackdefinition -SecretArchiveKeyVaultId keyVaultId -SecretArchiveSettingVaultUri keyVaultUri -SecretArchiveSettingsAssociatedIdentityType identityType -SecretArchiveSettingsAssociatedIdentityUserAssignedIdentityResourceId userAssignedIdentityResourceId -SecretArchiveUseKeyVault useKeyVault -UpdateStrategyThresholdType updateStrategyThresholdType -UpdateStrategyThresholdValue updateStrategyThresholdValue -UpdateStrategyType updateStrategyType -UpdateStrategyWaitTimeMinute updateStrategyWaitTimeMinutes -VulnerabilityScanningSettingContainerScan vulnerabilityScanningSettingContainerScan -ComputeDeploymentThresholdGrouping computeDeploymentThresholdGrouping -ComputeDeploymentThresholdType computeDeploymentThresholdType -ComputeDeploymentThresholdValue computeDeploymentThresholdValue -Tag $tagHash
```

```output
Location Name             SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGro
                                                                                                                                                                                           upName
-------- ----             ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- -----------
uksouth   clusterName        04/10/2025 18:14:18   user                          User             04/10/2025 18:35:38           user                                       User              RGName
```

This command updates the properties of the specified cluster or updates its tags, command output settings, analytics output settings, and archive output settings using the User Assigned Identity (UAI) associated with the cluster.
Property updates and tag updates can be performed independently.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IBareMetalMachineConfigurationData[]
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

Required: False
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

Required: False
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

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration
The list of storage appliance configuration data for this rack.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IStorageApplianceConfigurationData[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AnalyticOutputSettingAnalyticsWorkspaceId
The resource ID of the analytics workspace that is to be used by the specified identity.

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

### -AnalyticsOutputSettingsAssociatedIdentityType
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

### -AnalyticsOutputSettingsAssociatedIdentityUserAssignedIdentityResourceId
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
The type of associated identity for CommandOutputSettings.

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

### -AssociatedIdentityUserAssignedIdentityResourceId
The resource ID of the user assigned identity for CommandOutputSettings.

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
Type: System.String
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
Type: System.String
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
The list of rack definitions for the compute racks in a multi-rack cluster, or an empty list in a single-rack cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IRackDefinition[]
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
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The ETag of the transformation.
Omit this value to always overwrite the current resource.
Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.

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

### -IfNoneMatch
Set to '*' to allow a new record set to be created, but to prevent updating an existing resource.
Other values will result in error from server as they are not supported.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ClusterName

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
Parameter Sets: UpdateExpanded
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
Type: System.String
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

### -SecretArchiveSettingsAssociatedIdentityType
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

### -SecretArchiveSettingsAssociatedIdentityUserAssignedIdentityResourceId
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

### -SecretArchiveSettingVaultUri
The URI for the key vault used as the secret archive.

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
Type: System.String
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
Type: System.String
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
Type: System.String
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

### -VulnerabilityScanningSettingContainerScan
The mode selection for container vulnerability scanning.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.ICluster

## NOTES

## RELATED LINKS
