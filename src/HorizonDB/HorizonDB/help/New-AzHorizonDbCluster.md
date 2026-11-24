---
external help file: Az.HorizonDB-help.xml
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/new-azhorizondbcluster
schema: 2.0.0
---

# New-AzHorizonDbCluster

## SYNOPSIS
Create a new HorizonDB cluster or replaces an existing cluster.
PointInTimeRestore create the new Cluster resource and hydrates its service-owned database storage from an available source backup.
It does not clone source pools, Pool-scoped endpoints, firewall rules, parameter-group associations, or other child resources.
The new Cluster receives its service-generated Cluster-scoped Endpoint named cluster.
For restore, postgreSqlVersion must be omitted because the service obtains it from backup metadata.
During restore creation, the service ignores the requested backup.geoRedundancy value and configures the new cluster with the same geo-redundancy setting as the source cluster; this applies to both same-location and cross-location restores.
All remaining new-cluster configuration comes from the request or service defaults.
Same-location restore requires and honors pointInTimeUtc and allows creationSourceClusterLocation to be omitted.
Cross-location restore requires creationSourceClusterLocation to identify the source cluster's Azure location and requires pointInTimeUtc, but ignores the supplied timestamp and restores the latest available backup.
Cross-location responses omit pointInTimeUtc.

## SYNTAX

### CreateExpanded (Default)
```
New-AzHorizonDbCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 [-BackupGeoRedundancy <String>] [-BackupRetentionDay <Int32>] [-CreationMode <String>]
 [-CreationSourceClusterLocation <String>] [-CreationSourceClusterResourceId <String>]
 [-DataEncryptionPrimaryKeyUri <String>] [-DataEncryptionPrimaryUserAssignedIdentityId <String>]
 [-DataEncryptionType <String>] [-EnableSystemAssignedIdentity] [-NetworkPublicAccess <String>]
 [-PointInTimeUtc <DateTime>] [-PostgreSqlVersion <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzHorizonDbCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzHorizonDbCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a new HorizonDB cluster or replaces an existing cluster.
PointInTimeRestore create the new Cluster resource and hydrates its service-owned database storage from an available source backup.
It does not clone source pools, Pool-scoped endpoints, firewall rules, parameter-group associations, or other child resources.
The new Cluster receives its service-generated Cluster-scoped Endpoint named cluster.
For restore, postgreSqlVersion must be omitted because the service obtains it from backup metadata.
During restore creation, the service ignores the requested backup.geoRedundancy value and configures the new cluster with the same geo-redundancy setting as the source cluster; this applies to both same-location and cross-location restores.
All remaining new-cluster configuration comes from the request or service defaults.
Same-location restore requires and honors pointInTimeUtc and allows creationSourceClusterLocation to be omitted.
Cross-location restore requires creationSourceClusterLocation to identify the source cluster's Azure location and requires pointInTimeUtc, but ignores the supplied timestamp and restores the latest available backup.
Cross-location responses omit pointInTimeUtc.

## EXAMPLES

### Example 1: Create a cluster with geo-redundant backups and a managed identity
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$parameters = @{
    ResourceGroupName = 'example-resource-group'
    Name = 'example-cluster'
    Location = 'eastus2'
    PostgreSqlVersion = '17'
    NetworkPublicAccess = 'Enabled'
    BackupGeoRedundancy = 'Enabled'
    BackupRetentionDay = 14
    UserAssignedIdentity = @("/subscriptions/$subscriptionId/resourceGroups/identity-resource-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/fabric-writer")
    Tag = @{ environment = 'production' }
}
New-AzHorizonDbCluster @parameters | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : example-cluster
Location            : eastus2
PostgreSqlVersion   : 17
CreationMode        : Create
State               : Updating
ProvisioningState   : InProgress
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Create a cluster using service defaults
```powershell
New-AzHorizonDbCluster -ResourceGroupName 'example-resource-group' -Name 'minimum-defaults' -Location 'eastus2' -PostgreSqlVersion '18' -BackupGeoRedundancy 'Disabled' | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : minimum-defaults
Location            : eastus2
PostgreSqlVersion   : 18
CreationMode        : Create
State               : Updating
ProvisioningState   : InProgress
BackupGeoRedundancy : Disabled
BackupRetentionDay  : 7
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 3: Restore a cluster to a point in time in the same region
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$parameters = @{
    ResourceGroupName = 'example-resource-group'
    Name = 'restored-cluster'
    Location = 'eastus2'
    CreationMode = 'PointInTimeRestore'
    CreationSourceClusterResourceId = "/subscriptions/$subscriptionId/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/clusters/source-cluster"
    PointInTimeUtc = [datetime]'2026-07-27T12:00:00Z'
    NetworkPublicAccess = 'Disabled'
    BackupRetentionDay = 14
}
New-AzHorizonDbCluster @parameters | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : restored-cluster
Location            : eastus2
PostgreSqlVersion   : 17
CreationMode        : PointInTimeRestore
State               : Provisioning
ProvisioningState   : Provisioning
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 4: Restore a cluster to another region
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$parameters = @{
    ResourceGroupName = 'example-resource-group'
    Name = 'cross-region-restored-cluster'
    Location = 'westus2'
    CreationMode = 'PointInTimeRestore'
    CreationSourceClusterResourceId = "/subscriptions/$subscriptionId/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/clusters/source-cluster"
    CreationSourceClusterLocation = 'eastus2'
    PointInTimeUtc = [datetime]'2026-07-27T12:00:00Z'
    NetworkPublicAccess = 'Disabled'
    BackupRetentionDay = 14
}
New-AzHorizonDbCluster @parameters | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : cross-region-restored-cluster
Location            : westus2
PostgreSqlVersion   : 17
CreationMode        : PointInTimeRestore
State               : Provisioning
ProvisioningState   : Provisioning
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 5: Create a cluster with a customer-managed encryption key
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$identityId = "/subscriptions/$subscriptionId/resourceGroups/identity-resource-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/primary-encryption-identity"
$parameters = @{
    ResourceGroupName = 'example-resource-group'
    Name = 'example-cluster'
    Location = 'eastus2'
    PostgreSqlVersion = '17'
    BackupGeoRedundancy = 'Disabled'
    BackupRetentionDay = 14
    UserAssignedIdentity = @($identityId)
    DataEncryptionType = 'AzureKeyVault'
    DataEncryptionPrimaryKeyUri = 'https://primary-key-vault.vault.azure.net/keys/horizondb-primary-key'
    DataEncryptionPrimaryUserAssignedIdentityId = $identityId
}
New-AzHorizonDbCluster @parameters | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay, DataEncryptionType, DataEncryptionPrimaryKeyUri
```

```output
Name                        : example-cluster
Location                    : eastus2
PostgreSqlVersion           : 17
CreationMode                : Create
State                       : Updating
ProvisioningState           : InProgress
BackupGeoRedundancy         : Disabled
BackupRetentionDay          : 14
DataEncryptionType          : AzureKeyVault
DataEncryptionPrimaryKeyUri : https://primary-key-vault.vault.azure.net/keys/horizondb-primary-key
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

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

### -BackupGeoRedundancy
The geo-redundancy state.
When creationMode is PointInTimeRestore, the service ignores the requested value during cluster creation and configures the new cluster with the same geo-redundancy setting as the source cluster, for both same-location and cross-location restores.
The response reports the inherited setting.
Geo-redundant backup is not supported when dataEncryption.type is AzureKeyVault.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupRetentionDay
The number of days that automatic backups are retained.
The service defaults to 7 days when this property is omitted.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreationMode
The mode used to create the cluster.
When this property is omitted while creating a new cluster, the service records Create.
PointInTimeRestore creates a new cluster from an available backup; pointInTimeUtc and creationSourceClusterResourceId are then required, postgreSqlVersion must be omitted because it is obtained from the backup metadata, and creationSourceClusterLocation is required when the source and target cluster locations differ.
During PointInTimeRestore creation, the service ignores the requested backup.geoRedundancy value and configures the new cluster with the same geo-redundancy setting as the source cluster.
This property is immutable and is returned as creation provenance.
On replacement, omission preserves the recorded value, resubmitting the same value is accepted, and changing it is rejected.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreationSourceClusterLocation
The Azure location of the source HorizonDB cluster used for point-in-time restore.
This property is optional when the source and target cluster locations are the same.
It is required when the source cluster location differs from the target cluster location and must identify the source cluster's location.
This property must be absent for creation modes other than PointInTimeRestore or when creationMode is omitted.
This immutable creation-provenance value does not change after creation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreationSourceClusterResourceId
The Azure resource ID of the source HorizonDB cluster used by the selected creation mode.
This property is required for PointInTimeRestore and other source-based creation modes, and must be absent when creationMode is Create or omitted.
A source cluster does not need to have a pool to be restored, provided an available backup exists.
This immutable creation-provenance value does not change after creation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEncryptionPrimaryKeyUri
The versionless Azure Key Vault key URI used to encrypt the cluster's primary storage.
Key version paths are not supported.
During initial cluster creation, this property can be provided together with primaryUserAssignedIdentityId.
For updates to an existing cluster through PUT or PATCH, this property and primaryUserAssignedIdentityId cannot both change in the same request; the first update must complete before submitting a separate update for the other property.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEncryptionPrimaryUserAssignedIdentityId
The Azure resource ID of the user-assigned managed identity used to access the primary encryption key.
The identity must also be assigned to the Cluster through its top-level identity property.
During initial cluster creation, this property can be provided together with primaryKeyUri.
For updates to an existing cluster through PUT or PATCH, this property and primaryKeyUri cannot both change in the same request; the first update must complete before submitting a separate update for the other property.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataEncryptionType
The type of data encryption used by the cluster.
When the data encryption configuration is supplied during initial cluster creation, this property is required.
For PUT updates of an existing cluster, this property may be omitted; if provided, it must match the existing encryption type.
This value is selected at cluster creation and cannot later be changed from SystemManaged to AzureKeyVault or from AzureKeyVault to SystemManaged.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
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

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the HorizonDB cluster.

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

### -NetworkPublicAccess
Specifies whether public access is enabled for the cluster.
The service defaults to Disabled when this property is omitted.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -PointInTimeUtc
The requested point in time, in UTC.
This property is required in every PointInTimeRestore request.
For a same-location restore, the service restores the latest backup available at or before this value.
For a cross-location restore, the service requires but ignores this value and restores the latest available backup; cross-location responses omit this property.
This property must be absent for other creation modes or when creationMode is omitted and can only be specified during resource creation.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PostgreSqlVersion
The PostgreSQL major version used by the HorizonDB cluster.
API version 2026-10-01-preview supports versions 17 and 18.
For ordinary cluster creation, the version is supplied in the request and is immutable after creation.
For point-in-time restore, the service obtains the version from the source backup metadata and the request must omit this property.
This API version does not support in-place PostgreSQL major-version upgrades.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.ICluster

## NOTES

## RELATED LINKS
