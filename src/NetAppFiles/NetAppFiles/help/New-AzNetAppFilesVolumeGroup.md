---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/new-aznetappfilesvolumegroup
schema: 2.0.0
---

# New-AzNetAppFilesVolumeGroup

## SYNOPSIS
Creates a new Azure NetApp Files (ANF) VolumeGroup along with requisite volumes.
Creating volume group will create all the volumes specified in request body implicitly. Once volumes are created using volume group, those will be treated as regular volumes thereafter.

## SYNTAX

### ByFieldsParameterSet (Default)
```
New-AzNetAppFilesVolumeGroup -ResourceGroupName <String> -Location <String> -AccountName <String>
 -PoolName <String> [-Name <String>] [-GroupDescription <String>] [-ApplicationType <String>]
 -ApplicationIdentifier <String> [-SystemId <String>] [-ProximityPlacementGroup <String>] -NodeMemory <Int32>
 [-CapacityOverhead <Int32>] [-StartingHostId <Int32>] [-HostCount <Int32>] [-SystemRole <String>]
 [-Prefix <String>] [-Vnet <String>] [-SubnetId <String>] [-DataSize <Int64>] [-DataPerformance <Int32>]
 [-LogSize <Int64>] [-LogPerformance <Int32>] [-SharedSize <Int64>] [-SharedPerformance <Int32>]
 [-DataBackupSize <Int64>] [-DataBackupPerformance <Int32>] [-LogBackupSize <Int64>]
 [-LogBackupPerformance <Int32>] [-HannaSystemReplication] [-DisasterRecoveryDestination]
 [-BackupProtocolType <String[]>] [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>]
 [-GlobalPlacementRule <System.Collections.Generic.IList`1[Microsoft.Azure.Management.NetApp.Models.PlacementKeyValuePairs]>]
 [-EncryptionKeySource <String>] [-KeyVaultPrivateEndpointResourceId <String>] [-NetworkFeature <String>]
 [-Zone <String[]>] [-Tag <Hashtable>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ORACLE
```
New-AzNetAppFilesVolumeGroup -PoolName <String> [-Name <String>] [-GroupDescription <String>]
 [-ApplicationType <String>] -ApplicationIdentifier <String> [-SystemId <String>]
 [-ProximityPlacementGroup <String>] -NodeMemory <Int32> [-CapacityOverhead <Int32>] [-StartingHostId <Int32>]
 [-HostCount <Int32>] [-SystemRole <String>] [-Prefix <String>] [-Vnet <String>] [-SubnetId <String>]
 [-DataSize <Int64>] [-DataReplicationSourceId <String>] [-DataReplicationSchedule <String>]
 [-DataPerformance <Int32>] [-LogSize <Int64>] [-LogPerformance <Int32>] [-LogReplicationSourceId <String>]
 [-LogReplicationSchedule <String>] [-SharedSize <Int64>] [-SharedPerformance <Int32>]
 [-SharedReplicationSourceId <String>] [-SharedReplicationSchedule <String>] [-DataBackupSize <Int64>]
 [-DataBackupPerformance <Int32>] [-DataBackupReplicationSourceId <String>]
 [-DataBackupReplicationSchedule <String>] [-LogBackupSize <Int64>] [-LogBackupPerformance <Int32>]
 [-LogBackupReplicationSourceId <String>] [-LogBackupReplicationSchedule <String>] [-HannaSystemReplication]
 [-DisasterRecoveryDestination] [-BackupProtocolType <String[]>]
 [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>]
 [-GlobalPlacementRule <System.Collections.Generic.IList`1[Microsoft.Azure.Management.NetApp.Models.PlacementKeyValuePairs]>]
 [-EncryptionKeySource <String>] [-KeyVaultPrivateEndpointResourceId <String>] [-NetworkFeature <String>]
 [-Zone <String[]>] [-OracleDatabaseSize <Int32>] [-NumberOfDataVolume <Int32>]
 [-AdditionalCapacityForSnapshots <Int32>] [-OracleDatabaseThroughput <Int32>] [-DataSize2 <Int64>]
 [-Data2Performance <Int32>] [-Data2ReplicationSourceId <String>] [-Data2ReplicationSchedule <String>]
 [-DataSize3 <Int64>] [-Data3Performance <Int32>] [-Data3ReplicationSourceId <String>]
 [-Data3ReplicationSchedule <String>] [-Data4Size <Int64>] [-Data4Performance <Int32>]
 [-Data4ReplicationSourceId <String>] [-Data4ReplicationSchedule <String>] [-Data5Size <Int64>]
 [-Data5Performance <Int32>] [-Data5ReplicationSourceId <String>] [-Data5ReplicationSchedule <String>]
 [-Data6Size <Int64>] [-Data6Performance <Int32>] [-Data6ReplicationSourceId <String>]
 [-Data6ReplicationSchedule <String>] [-Data7Size <Int64>] [-Data7Performance <Int32>]
 [-Data7ReplicationSourceId <String>] [-Data7ReplicationSchedule <String>] [-DataSize8 <Int64>]
 [-DataPerformance8 <Int32>] [-Data8ReplicationSourceId <String>] [-Data8ReplicationSchedule <String>]
 [-BinarySize <Int64>] [-BinaryPerformance <Int32>] [-BinaryReplicationSourceId <String>]
 [-BinaryReplicationSchedule <String>] [-BackupSize <Int64>] [-BackupPerformance <Int32>]
 [-BackupReplicationSourceId <String>] [-BackupReplicationSchedule <String>] [-LogMirrorSize <Int64>]
 [-LogMirrorPerformance <Int32>] [-LogMirrorReplicationSourceId <String>]
 [-LogMirrorReplicationSchedule <String>] [-Tag <Hashtable>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
New-AzNetAppFilesVolumeGroup -PoolName <String> [-Name <String>] [-GroupDescription <String>]
 [-ApplicationType <String>] -ApplicationIdentifier <String> [-SystemId <String>]
 [-ProximityPlacementGroup <String>] -NodeMemory <Int32> [-CapacityOverhead <Int32>] [-StartingHostId <Int32>]
 [-HostCount <Int32>] [-SystemRole <String>] [-Prefix <String>] [-Vnet <String>] [-SubnetId <String>]
 [-DataSize <Int64>] [-DataPerformance <Int32>] [-LogSize <Int64>] [-LogPerformance <Int32>]
 [-SharedSize <Int64>] [-SharedPerformance <Int32>] [-DataBackupSize <Int64>] [-DataBackupPerformance <Int32>]
 [-LogBackupSize <Int64>] [-LogBackupPerformance <Int32>] [-HannaSystemReplication]
 [-DisasterRecoveryDestination] [-BackupProtocolType <String[]>]
 [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>]
 [-GlobalPlacementRule <System.Collections.Generic.IList`1[Microsoft.Azure.Management.NetApp.Models.PlacementKeyValuePairs]>]
 [-EncryptionKeySource <String>] [-KeyVaultPrivateEndpointResourceId <String>] [-NetworkFeature <String>]
 [-Zone <String[]>] [-Tag <Hashtable>] -AccountObject <PSNetAppFilesAccount>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetAppFilesVolumeGroup** cmdlet creates an ANF VolumeGroup.

## EXAMPLES

### Example 1
```powershell
New-AzNetAppFilesVolumeGroup -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfVolumeGroupName" -Location "westus2"  -GroupDescription "MyAnfVolumeGroup Description" -ApplicationIdentifier "SH1" -ProximityPlacementGroup "MyPPGResourceId" -Vnet "MyAnfVnet" -SystemRole "PRIMARY" -NodeMemory 100
```

This command creates the new "PRIMARY" ANF VolumeGroup "MyAnfVolumeGroup" within the Account "MyAnfAccount" using the proximityPlacementGroup "MyPPGResourceId", the vnet "MyAnfVnet", and NodeMemory of 100

### Example 2
```powershell
New-AzNetAppFilesVolumeGroup -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfVolumeGroupName" -Location "westus2"  -GroupDescription "MyAnfVolumeGroup Description" -ApplicationIdentifier "OR1" -Zone 1 -Vnet "MyAnfVnet" -SystemRole "PRIMARY" -NodeMemory 100
```

This command creates the new "PRIMARY" ANF VolumeGroup "MyAnfVolumeGroup" within the Account "MyAnfAccount" using Zone 1, the vnet "MyAnfVnet", and NodeMemory of 100

## PARAMETERS

### -AccountName
The name of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccountObject
The account for the new pool object

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesAccount
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AdditionalCapacityForSnapshots
Additional capacity for snapshots (%). If you use snapshots for data protection, you need to plan for extra capacity. This field adds an additional size (%) for the data volume. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationIdentifier
Application specific identifier, default SAP System ID SH1

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

### -ApplicationType
Application Type, default SAP-HANA

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

### -BackupPerformance
Specify throughput in MiB/s. If omitted BackupPerformance will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupProtocolType
A hashtable array which represents the protocol types for Data Backup/Log Backup volumes default NFSv4.1, for other volume types nfsv4.1 will be used.

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

### -BackupReplicationSchedule
Replication schedule for Backup volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupReplicationSourceId
The resource id of the Backup source volume. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupSize
Specify capacity (in GiB). If omitted Size for BackupSize will be autocalculated or specify an integer value representing size.For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BinaryPerformance
Specify throughput in MiB/s. If omitted BinaryPerformance will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BinaryReplicationSchedule
Replication schedule for data3 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BinaryReplicationSourceId
The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BinarySize
Specify capacity (in GiB). If omitted Size for BinarySize will be autocalculated or specify an integer value representing size.For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CapacityOverhead
Capacity overhead %, Additional quota reserved for snapshots during best-practice sizing of data volume, default 50

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

### -Data2Performance
Specify throughput in MiB/s. If omitted DataPerformance for disk 2 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data2ReplicationSchedule
Replication schedule for data2 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data2ReplicationSourceId
The resource id of the source volume. Used to override DataSourceId. Used for Oracle DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data3Performance
Specify throughput in MiB/s. If omitted DataPerformance for disk 3 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data3ReplicationSchedule
Replication schedule for data3 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data3ReplicationSourceId
The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data4Performance
Specify throughput in MiB/s. If omitted DataPerformance for disk 4 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data4ReplicationSchedule
Replication schedule for data4 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data4ReplicationSourceId
The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data4Size
Specify capacity (in GiB). If omitted DataSize for disk 4 will be autocalculated or specify an integer value representing size. If NumberOfDataVolume is less than 4 this will be ignored. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data5Performance
Specify throughput in MiB/s. If omitted DataPerformance for disk 5 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data5ReplicationSchedule
Replication schedule for data5 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data5ReplicationSourceId
The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data5Size
Specify capacity (in GiB). If omitted DataSize for disk 5 will be autocalculated or specify an integer value representing size.If NumberOfDataVolume is less than 5 this will be ignored. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data6Performance
Specify throughput in MiB/s. If omitted DataPerformance for disk 6 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data6ReplicationSchedule
Replication schedule for data6 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data6ReplicationSourceId
The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data6Size
Specify capacity (in GiB). If omitted DataSize for disk 6 will be autocalculated or specify an integer value representing size. If NumberOfDataVolume is less than 6 this will be ignored. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data7Performance
Specify throughput in MiB/s. If omitted DataPerformance for disk 7 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data7ReplicationSchedule
Replication schedule for data7 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data7ReplicationSourceId
The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data7Size
Specify capacity (in GiB). If omitted DataSize for disk 7 will be autocalculated or specify an integer value representing size. If NumberOfDataVolume is less than 7 this will be ignored. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data8ReplicationSchedule
Replication schedule for data8 volume. Used to override DataReplicationSchedule. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Data8ReplicationSourceId
The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataBackupPerformance
Specify throughput in MiB/s.
If omitted DataBackupPerformance will be autocalculated or specify an integer value representing throughput.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataBackupReplicationSchedule
Replication schedule for DataBackup volume. Used for DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataBackupReplicationSourceId
The resource id of the DataBackup volume. Used for DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataBackupSize
Specify capacity (in GiB).
If omitted DataSize will be autocalculated or specify an integer value representing size.

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataPerformance
Specify throughput in MiB/s.
If omitted DataPerformance will be autocalculated or specify and integer value representing throughput.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataPerformance8
Specify throughput in MiB/s. If omitted DataPerformance for disk 8 will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataReplicationSchedule
Replication schedule for data2 volume. Used for Oracle DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataReplicationSourceId
The resource id of the source volume. Used for Oracle DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSize
Specify capacity (in GiB).
If omitted DataSize will be autocalculated or specify an integer value representing size.

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSize2
Specify capacity (in GiB). If omitted a DataSize size for disk 2 will be autocalculated or specify an integer value representing size.For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSize3
Specify capacity (in GiB). If omitted DataSize for disk 3 will be autocalculated or specify an integer value representing size. If NumberOfDataVolume is less than 3 this will be ignored. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSize8
Specify capacity (in GiB). If omitted DataSize for disk 8 will be autocalculated or specify an integer value representing size.If NumberOfDataVolume is less than 8 this will be ignored. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisasterRecoveryDestination
Create volume groups for DR, using ANF Cross Region Replication, scenario allows volumes to be replicated between different regions using SnapMirror

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

### -EncryptionKeySource
Source of key used to encrypt data in volume. Applicable if NetApp account has encryption.keySource = 'Microsoft.KeyVault'. Possible values are: 'Microsoft.NetApp, Microsoft.KeyVault'. To create a volume using customer-managed keys use 'Microsoft.KeyVault' note then you must set -NetworkFeature to Standard.

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

### -ExportPolicy
A hashtable array which represents the export policy, which should be common to all volumes.

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolumeExportPolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GlobalPlacementRule
Application specific placement rules for the volume group

```yaml
Type: System.Collections.Generic.IList`1[Microsoft.Azure.Management.NetApp.Models.PlacementKeyValuePairs]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupDescription
Group Description, example Primary for SH1-{HostId} (default)

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

### -HannaSystemReplication
HANA System Replication (HSR): Replication between the same SID instance on hosts in the same region, or different regions.
This could be Scale-Up or Scale-Out configurations.

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

### -HostCount
Number of SAP HANA hosts.
Total Number of SAP HANA hosts for single or multiplehost scenarios.
Defaults to 50 for single-host setups.
Currently at max 3 nodes can be configured.

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

### -KeyVaultPrivateEndpointResourceId
The resource ID of private endpoint for KeyVault. It must reside in the same VNET as the volume. Only applicable if encryptionKeySource = 'Microsoft.KeyVault'

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

### -Location
The location of the resource

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogBackupPerformance
Specify throughput in MiB/s.
If omitted LogBackupPerformance will be autocalculated or specify an integer value representing throughput.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogBackupReplicationSchedule
Replication schedule for LogBackup volume. Used for DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogBackupReplicationSourceId
The resource id of the LogBackup volume. Used for DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogBackupSize
Specify capacity (in GiB).
If omitted DataSize will be autocalculated or specify an integer value representing size.

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogMirrorPerformance
Specify throughput in MiB/s. If omitted LogMirrorPerformance will be autocalculated or specify and integer value representing throughput. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogMirrorReplicationSchedule
Replication schedule for data3 volume. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogMirrorReplicationSourceId
The resource id of the source volume. Used for Oracle DataProtection volumes (SystemRole = DR).

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogMirrorSize
Specify capacity (in GiB). If omitted Size for LogMirrorSize will be autocalculated or specify an integer value representing size.For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogPerformance
Specify throughput in MiB/s.
If omitted LogPerformance will be autocalculated or specify and integer value representing throughput.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogReplicationSchedule
Replication schedule for log volume. Used for DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogReplicationSourceId
The resource id of the log source volume. Used for DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogSize
Specify capacity (in GiB).
If omitted LogSize will be autocalculated or specify an integer value representing size.

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ANF VolumeGroup, example SAP-HANA-SH00001.
Defaults to SAP-HANA-{HostId}, where the {HostId} pattern in the name will be replaced by a 5 digit host ID that begins at 1 for the Single-host and counts up for the subsequent Multiple-host, host

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VolumeGroupName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFeature
Basic network, or Standard features available to the volume (Basic, Standard).

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

### -NetworkFeature
Basic network, or Standard features available to the volume (Basic, Standard).

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

### -NodeMemory
SAP node memory (GiB), Memory on SAP compute host

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NumberOfDataVolume
How many data volumes to create. Can have a minimum of 2 up to 8 data volumes. Defaults to 2. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OracleDatabaseSize
Total size of the Oracle Data Base (TiB). For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OracleDatabaseThroughput
Specify the total throughput required for your database. If you select more than one database volume, the throughput is distributed evenly among all volumes. You can change each individual volume, using the DataSize(no) DataPerformance(no) properties provided. For Oracle Application Volume Groups only

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolName
Default capacity pool for volumes, use a manual QoS type capacity pool

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

### -Prefix
All volume names will be prefixed with the given text.
The default values for prefix text depends on system role.
For PRIMARY it will be empty and HA it will be "HA - "

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

### -ProximityPlacementGroup
Default proximity placement group, for data, log, and if present the shared volume, in all volume groups.
Specifies that the data, log, and shared volumes are to be created close to the VMs

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

### -ResourceGroupName
The resource group of the ANF VolumeGroup

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedPerformance
Specify throughput in MiB/s.
If omitted SharedPerformance will be autocalculated or specify and integer value representing throughput.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedReplicationSchedule
Replication schedule for shared volume. Used for DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedReplicationSourceId
The resource id of the shared volume. Used for DataProtection volumes.

```yaml
Type: System.String
Parameter Sets: ORACLE
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedSize
Specify capacity (in GiB).
If omitted SharedSize will be autocalculated or specify an integer value representing size.

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartingHostId
Starting SAP HANA Host ID.
Host ID 1 indicates Master Host.
Shared, Data Backup and Log Backup volumes are only provisioned for Master Host i.e.
HostID == 1.1

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

### -SubnetId
Default delegated subnet, for all volume groups

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

### -SystemId
Unique Oracle system ID, default SAP System ID SH1 , default Oracle System Id (OID)ORA1

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

### -SystemRole
The role of the system, Primary SAP system, HANA System Replication(HSR) or DataRecovery destination for ANF Cross-region replication (CRR)

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

### -Tag
A hashtable which represents resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases: Tags

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vnet
Default virtual network, for all volume groups

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

### -Zone
A list of Availability Zones

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesAccount

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolumeGroupDetail

## NOTES

## RELATED LINKS

[Get-AzNetAppFilesVolumeGroup](./Get-AzNetAppFilesVolumeGroup.md)
[New-AzNetAppFilesVolumeGroup](./New-AzNetAppFilesVolumeGroup.md)
[Remove-AzNetAppFilesVolumeGroup](./Remove-AzNetAppFilesVolumeGroup.md)
[New-AzNetAppFilesVolume](./New-AzNetAppFilesVolume.md)
[Update-AzNetAppFilesVolume](./Update-AzNetAppFilesVolume.md)
[Remove-AzNetAppFilesVolume](./Remove-AzNetAppFilesVolume.md)
