# Upcoming breaking changes in Azure PowerShell

## Az.Accounts

### `Get-AzAccessToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The Token property of the output type will be changed from String to SecureString. Add the [-AsSecureString] switch to avoid the impact of this upcoming breaking change.
  - This change is expected to take effect from Az.Accounts version: 4.0.0 and Az version: 13.0.0

## Az.App

### `New-AzContainerApp`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'

### `New-AzContainerAppJob`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'

### `Update-AzContainerApp`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'

### `Update-AzContainerAppJob`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : IdentityUserAssignedIdentity will be renamed to UserAssignedIdentity. And its type will be simplified as string array. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'

## Az.DevCenter

### `Get-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'DevBox' to the new type :'DevBox'
  - The following properties in the output type are being deprecated : 'Detail' 'ProvisioningState' 'HardwareProfileSkuName'
  - The following properties are being added to the output type : 'Detail' 'ProvisioningState' 'HardwareProfileSkuName'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzDevCenterUserDevBoxOperation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'DevBoxOperation' to the new type :'DevBoxOperation'
  - The following properties in the output type are being deprecated : 'Detail' 'Status'
  - The following properties are being added to the output type : 'Detail' 'Status'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzDevCenterUserEnvironment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Environment' to the new type :'Environment'
  - The following properties in the output type are being deprecated : 'Detail' 'ProvisioningState'
  - The following properties are being added to the output type : 'Detail' 'ProvisioningState'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzDevCenterUserEnvironmentAction`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'EnvironmentAction' to the new type :'EnvironmentAction'
  - The following properties in the output type are being deprecated : 'NextScheduledTime'
  - The following properties are being added to the output type : 'NextScheduledTime'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzDevCenterUserEnvironmentLog`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'boolean' to the new type :'string'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-OutFile`
    - The parameter : 'OutFile' is changing.
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-PassThru`
    - The parameter : 'PassThru' is changing.
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'

### `Get-AzDevCenterUserEnvironmentOperation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'EnvironmentOperation' to the new type :'EnvironmentOperation'
  - The following properties in the output type are being deprecated : 'Detail' 'EnvironmentParameter' 'Status'
  - The following properties are being added to the output type : 'Detail' 'EnvironmentParameter' 'Status'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzDevCenterUserPool`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Pool' to the new type :'Pool'
  - The following properties in the output type are being deprecated : 'HardwareProfileSkuName'
  - The following properties are being added to the output type : 'HardwareProfileSkuName'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Invoke-AzDevCenterUserDelayDevBoxAction`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'DevBoxActionDelayResult' to the new type :'DevBoxActionDelayResult'
  - The following properties in the output type are being deprecated : 'Detail'
  - The following properties are being added to the output type : 'Detail'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Invoke-AzDevCenterUserDelayEnvironmentAction`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'EnvironmentAction' to the new type :'EnvironmentAction'
  - The following properties in the output type are being deprecated : 'NextScheduledTime'
  - The following properties are being added to the output type : 'NextScheduledTime'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'DevBox' to the new type :'DevBox'
  - The following properties in the output type are being deprecated : 'Detail' 'ProvisioningState' 'HardwareProfileSkuName'
  - The following properties are being added to the output type : 'Detail' 'ProvisioningState' 'HardwareProfileSkuName'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzDevCenterUserEnvironment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Environment' to the new type :'Environment'
  - The following properties in the output type are being deprecated : 'Detail' 'ProvisioningState'
  - The following properties are being added to the output type : 'Detail' 'ProvisioningState'
  - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
  - The change is expected to take effect from version : '2.0.0'

## Az.ElasticSan

### `New-AzElasticSanVolumeGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'

### `Update-AzElasticSanVolumeGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'

## Az.Monitor

### `New-AzDataCollectionEndpoint`
- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-UserAssignedIdentity`
    - The parameter : 'UserAssignedIdentity' is changing. The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : UserAssignedIdentity's type will be simplified as string array.
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
 
### `New-AzDataCollectionRule`
- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-UserAssignedIdentity`
    - The parameter : 'UserAssignedIdentity' is changing. The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : UserAssignedIdentity's type will be simplified as string array.
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'

### `Update-AzDataCollectionEndpoint`
- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-UserAssignedIdentity`
    - The parameter : 'UserAssignedIdentity' is changing. The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : UserAssignedIdentity's type will be simplified as string array.
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'

### `Update-AzDataCollectionRule`
- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-UserAssignedIdentity`
    - The parameter : 'UserAssignedIdentity' is changing. The type of the parameter is changing from 'Hashtable' to 'string[]'.
    - Change description : UserAssignedIdentity's type will be simplified as string array.
    - This change will take effect on '11/19/2024'- The change is expected to take effect from Az version : '13.0.0'
    - The change is expected to take effect from version : '2.0.0'

## Az.NetAppFiles

### `Get-AzNetAppFilesBackup`

- Parameter breaking-change will happen to all parameter sets
  - `-AccountBackupName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-PoolName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeObject`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12

### `New-AzNetAppFilesBackup`

- Parameter breaking-change will happen to all parameter sets
  - `-Location`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-PoolName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeObject`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12

### `Remove-AzNetAppFilesBackup`

- Parameter breaking-change will happen to all parameter sets
  - `-AccountBackupName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-PoolName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeObject`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12

### `Restore-AzNetAppFilesBackupFile`

- Parameter breaking-change will happen to all parameter sets
  - `-PoolName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeObject`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12

### `Update-AzNetAppFilesBackup`

- Parameter breaking-change will happen to all parameter sets
  - `-PoolName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeName`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12
  - `-VolumeObject`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.NetAppFiles version: 0.16 and Az version: 12

## Az.Sql

### `Get-AzSqlInstanceLink`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel' is changing
  - The following properties in the output type are being deprecated : 'TargetDatabase' 'PrimaryAvailabilityGroupName' 'SecondaryAvailabilityGroupName' 'SourceEndpoint' 'SourceReplicaId' 'TargetReplicaId' 'LinkState' 'LastHardenedLsn'
  - The following properties are being added to the output type : 'Databases' 'DistributedAvailabilityGroupName ' 'InstanceAvailabilityGroupName' 'PartnerAvailabilityGroupName' 'InstanceLinkRole' 'PartnerLinkRole' 'FailoverMode' 'SeedingMode' 'PartnerEndpoint'
  - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0

### `New-AzSqlInstanceLink`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel' is changing
  - The following properties in the output type are being deprecated : 'TargetDatabase' 'PrimaryAvailabilityGroupName' 'SecondaryAvailabilityGroupName' 'SourceEndpoint' 'SourceReplicaId' 'TargetReplicaId' 'LinkState' 'LastHardenedLsn'
  - The following properties are being added to the output type : 'Databases' 'DistributedAvailabilityGroupName ' 'InstanceAvailabilityGroupName' 'PartnerAvailabilityGroupName' 'InstanceLinkRole' 'PartnerLinkRole' 'FailoverMode' 'SeedingMode' 'PartnerEndpoint'
  - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-PrimaryAvailabilityGroupName`
    - The parameter : 'PrimaryAvailabilityGroupName' is being replaced by parameter : 'PartnerAvailabilityGroupName'.
    - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0
  - `-SecondaryAvailabilityGroupName`
    - The parameter : 'SecondaryAvailabilityGroupName' is being replaced by parameter : 'InstanceAvailabilityGroupName'.
    - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0
  - `-SourceEndpoint`
    - The parameter : 'SourceEndpoint' is being replaced by parameter : 'PartnerEndpoint'.
    - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0
  - `-TargetDatabase`
    - The parameter 'TargetDatabase' is being replaced by parameter 'Databases'. The type of new parameter is changing from 'String' to 'List<String>'
    - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0

### `Remove-AzSqlInstanceLink`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel' is changing
  - The following properties in the output type are being deprecated : 'TargetDatabase' 'PrimaryAvailabilityGroupName' 'SecondaryAvailabilityGroupName' 'SourceEndpoint' 'SourceReplicaId' 'TargetReplicaId' 'LinkState' 'LastHardenedLsn'
  - The following properties are being added to the output type : 'Databases' 'DistributedAvailabilityGroupName ' 'InstanceAvailabilityGroupName' 'PartnerAvailabilityGroupName' 'InstanceLinkRole' 'PartnerLinkRole' 'FailoverMode' 'SeedingMode' 'PartnerEndpoint'
  - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0

### `Update-AzSqlInstanceLink`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel' is changing
  - The following properties in the output type are being deprecated : 'TargetDatabase' 'PrimaryAvailabilityGroupName' 'SecondaryAvailabilityGroupName' 'SourceEndpoint' 'SourceReplicaId' 'TargetReplicaId' 'LinkState' 'LastHardenedLsn'
  - The following properties are being added to the output type : 'Databases' 'DistributedAvailabilityGroupName ' 'InstanceAvailabilityGroupName' 'PartnerAvailabilityGroupName' 'InstanceLinkRole' 'PartnerLinkRole' 'FailoverMode' 'SeedingMode' 'PartnerEndpoint'
  - This change is expected to take effect from Az.Sql version: 6.0.0 and Az version: 13.0.0

## Az.Storage

### `Close-AzStorageFileHandle`

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Get-AzStorageFile`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - The child property CloudFileDirectory from deprecated v11 SDK will be removed. Use child property ShareDirectoryClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Get-AzStorageFileContent`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed when -PassThru is specified. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Get-AzStorageFileCopyState`

- Parameter breaking-change will happen to all parameter sets
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Get-AzStorageFileHandle`

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Get-AzStorageShare`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileShare from deprecated v11 SDK will be removed. Use child property ShareClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `New-AzStorageDirectory`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileDirectory from deprecated v11 SDK will be removed. Use child property ShareDirectoryClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `New-AzStorageFileSASToken`

- Parameter breaking-change will happen to all parameter sets
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and a new mandatory parameter ShareFileClient will be added.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Protocol`
    - The type of parameter Protocol will be changed from SharedAccessProtocol to string.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `New-AzStorageShare`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileShare from deprecated v11 SDK will be removed. Use child property ShareClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `New-AzStorageShareSASToken`

- Parameter breaking-change will happen to all parameter sets
  - `-Protocol`
    - The type of parameter Protocol will be changed from SharedAccessProtocol to string.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Remove-AzStorageDirectory`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileDirectory from deprecated v11 SDK will be removed when -PassThru is specified. Use child property ShareDirectoryClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Remove-AzStorageFile`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed when -PassThru is specified. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Remove-AzStorageShare`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileShare from deprecated v11 SDK will be removed when -PassThru is specified. Use child property ShareClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Rename-AzStorageDirectory`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileDirectory from deprecated v11 SDK will be removed. Use child property ShareDirectoryClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Rename-AzStorageFile`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Set-AzStorageFileContent`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Directory`
    - The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Set-AzStorageShareQuota`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFileShare from deprecated v11 SDK will be removed. Use child property ShareClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Share`
    - The parameter Share (alias CloudFileShare) will be deprecated, and a new mandatory parameter ShareClient will be added.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Start-AzStorageFileCopy`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudFile from deprecated v11 SDK will be removed. Use child property ShareFileClient instead.
  - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Context`
    - The parameter Context will be required when the input source blob is based on OAuth credential.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-DestFile`
    - The parameter DestFile will be deprecated. To input a dest file instance, use DestShareFileClient instead.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-SrcBlob`
    - The type of parameter SrcBlob will be changed from CloudBlob to BlobBaseClient. The alias ICloudBlob will be deprecated.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-SrcContainer`
    - The type of parameter SrcContainer will be changed from CloudBlobContainer to BlobContainerClient.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-SrcFile`
    - The type of parameter SrcFile will be changed from CloudFile to ShareFileClient. The alias CloudFile will be deprecated.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0
  - `-SrcShare`
    - The type of parameter SrcShare will be changed from CloudFileShare to ShareClient. The alias CloudFileShare will be deprecated.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

### `Stop-AzStorageFileCopy`

- Parameter breaking-change will happen to all parameter sets
  - `-File`
    - The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.
    - This change is expected to take effect from Az.Storage version: 8.0.0 and Az version: 13.0.0

