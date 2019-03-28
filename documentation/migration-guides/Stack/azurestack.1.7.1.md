
This document serves as both a breaking change notification and migration guide for consumers of the AzureStack powershell version 1.7.1. This release supports Azurestack 1901 update or later

## Table of Contents
- [Breaking changes to Backup Admin cmdlets](#breaking-changes-to-backup-admin-cmdlets)
- [Breaking changes to Fabric Admin cmdlets](#breaking-changes-to-fabric-admin-cmdlets)

## Breaking changes to Backup Admin cmdlets
Backup uses cert-based encryption now. Support for symmetric keys is deprecated.
### Set-AzsBackupConfiguration 
The cmdlet now accepts parameter EncryptionCertPath instead of EncryptionKey

```powershell
# Old
Set-AzsBackupConfiguration -EncryptionKey $symmetricKey
# New
Set-AzsBackupConfiguration -EncryptionCertPath $pathToEncryptionCert
```

### Restore-AzsBackup 
The cmdlet now requires parameter DecryptionCertPath and DecryptionCertPassword

```powershell
# Old
Restore-AzsBackup -Name $backupResourceName
# New
Restore-AzsBackup -Name $backupResourceName -DecryptionCertPath $decryptionCertPath -DecryptionCertPassword $decryptionCertPassword
```

## Breaking changes to Fabric Admin cmdlets

### Get-AzsInfrastructureVolume
- The cmdlet Get-AzsInfrastructureVolume has been deprecated. This cmdlet has been replaced with Get-AzsVolume
```powershell
# Old
$storageSystem = Get-AzSStorageSystem -Location $ResourceLocation | Select-Object -First 1
$storageSystemName = ($storageSystem.Name -split '/')[-1]
$storagePool = Get-AzSStoragePool -Location $ResourceLocation -StorageSystem $storageSystemName
$storagePoolName = ($storagePool.Name -split '/')[-1]
Get-AzsInfrastructureVolume -Location $ResourceLocation -StorageSystem $storageSystemName -StoragePool $storagePoolName
# New
$scaleUnit = Get-AzsScaleUnit
$storageSubsystem = Get-AzsStorageSubSystem -ScaleUnit $scaleUnit[0].Name
Get-AzsVolume -ScaleUnit $scaleUnit[0].Name -StorageSubSystem $storageSubsystem.Name
```
	
### Get-AzsStorageSystem
- Get-AzsStorageSystem has been deprecated, This cmdlet has been replaced with Get-AzsStorageSubSystem

```powershell
# Old
$storageSystem = Get-AzSStorageSystem -Location $ResourceLocation 
# New
$scaleUnit = Get-AzsScaleUnit
$storageSubsystem = Get-AzsStorageSubSystem -ScaleUnit $scaleUnit[0].Name
```

### Get-AzsStoragePool
- Get-AzsStoragePool has been deprecated, Please use the TotalCapacityGB property of Get-AzsStorageSubSystem instead.