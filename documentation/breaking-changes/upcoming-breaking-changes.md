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

