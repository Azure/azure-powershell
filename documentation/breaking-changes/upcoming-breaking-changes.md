# Upcoming breaking changes in Azure PowerShell

## Az.Accounts

### `Get-AzAccessToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The Token property of the output type will be changed from String to SecureString. Add the [-AsSecureString] switch to avoid the impact of this upcoming breaking change.
  - This change is expected to take effect from Az.Accounts version: 4.0.0 and Az version: 13.0.0

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

