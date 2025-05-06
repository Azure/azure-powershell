---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/update-aznetappfilesvolume
schema: 2.0.0
---

# Update-AzNetAppFilesVolume

## SYNOPSIS
Updates an Azure NetApp Files (ANF) volume according to the optional modifiers provided.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Update-AzNetAppFilesVolume -ResourceGroupName <String> -Location <String> -AccountName <String>
 -PoolName <String> -Name <String> [-UsageThreshold <Int64>] [-ServiceLevel <String>]
 [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>] [-Backup <PSNetAppFilesVolumeBackupProperties>]
 [-ThroughputMibps <Double>] [-SnapshotPolicyId <String>] [-IsDefaultQuotaEnabled]
 [-DefaultUserQuotaInKiB <Int64>] [-DefaultGroupQuotaInKiB <Int64>] [-Tag <Hashtable>]
 [-UnixPermission <String>] [-CoolAccess] [-CoolnessPeriod <Int32>] [-CoolAccessRetrievalPolicy <String>]
 [-CoolAccessTieringPolicy <String>] [-SnapshotDirectoryVisible] [-SmbAccessBasedEnumeration <String>]
 [-ProtocolType <String[]>] [-SmbNonBrowsable <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Update-AzNetAppFilesVolume -Name <String> [-UsageThreshold <Int64>] [-ServiceLevel <String>]
 [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>] [-Backup <PSNetAppFilesVolumeBackupProperties>]
 [-ThroughputMibps <Double>] [-SnapshotPolicyId <String>] [-IsDefaultQuotaEnabled]
 [-DefaultUserQuotaInKiB <Int64>] [-DefaultGroupQuotaInKiB <Int64>] [-Tag <Hashtable>]
 [-UnixPermission <String>] [-CoolAccess] [-CoolnessPeriod <Int32>] [-CoolAccessRetrievalPolicy <String>]
 [-CoolAccessTieringPolicy <String>] [-SnapshotDirectoryVisible] [-SmbAccessBasedEnumeration <String>]
 [-ProtocolType <String[]>] [-SmbNonBrowsable <String>] -PoolObject <PSNetAppFilesPool>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Update-AzNetAppFilesVolume [-UsageThreshold <Int64>] [-ServiceLevel <String>]
 [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>] [-Backup <PSNetAppFilesVolumeBackupProperties>]
 [-ThroughputMibps <Double>] [-SnapshotPolicyId <String>] [-IsDefaultQuotaEnabled]
 [-DefaultUserQuotaInKiB <Int64>] [-DefaultGroupQuotaInKiB <Int64>] [-Tag <Hashtable>]
 [-UnixPermission <String>] [-CoolAccess] [-CoolnessPeriod <Int32>] [-CoolAccessRetrievalPolicy <String>]
 [-CoolAccessTieringPolicy <String>] [-SnapshotDirectoryVisible] [-SmbAccessBasedEnumeration <String>]
 [-ProtocolType <String[]>] [-SmbNonBrowsable <String>] -ResourceId <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzNetAppFilesVolume [-UsageThreshold <Int64>] [-ServiceLevel <String>]
 [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>] [-Backup <PSNetAppFilesVolumeBackupProperties>]
 [-ThroughputMibps <Double>] [-SnapshotPolicyId <String>] [-IsDefaultQuotaEnabled]
 [-DefaultUserQuotaInKiB <Int64>] [-DefaultGroupQuotaInKiB <Int64>] [-Tag <Hashtable>]
 [-UnixPermission <String>] [-CoolAccess] [-CoolnessPeriod <Int32>] [-CoolAccessRetrievalPolicy <String>]
 [-CoolAccessTieringPolicy <String>] [-SnapshotDirectoryVisible] [-SmbAccessBasedEnumeration <String>]
 [-ProtocolType <String[]>] [-SmbNonBrowsable <String>] -InputObject <PSNetAppFilesVolume>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzNetAppFilesVolume** cmdlet updates an ANF volume.

## EXAMPLES

### Example 1: Update an ANF volume
```powershell
Update-AzNetAppFilesVolume -ResourceGroupName "MyRG" -Location "westus2" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfVolume" -UsageThreshold Size
```

```output
Location          : westus2
Id                : /subscriptions/subsId/resourceGroups/MyRG/providers/Microsoft.NetApp/netAppAccounts/MyAnfAccount/capacityPools/MyAnfPool/volumes/MyAnfVolume
Name              : MyAnfAccount/MyAnfPool/MyAnfVolume
Type              : Microsoft.NetApp/netAppAccounts/capacityPools/volumes
Tags              :
FileSystemId      : 3e2773a7-2a72-d003-0637-1a8b1fa3eaaf
CreationToken     : MyAnfVolume
ServiceLevel      : Premium
UsageThreshold    : 2199023255552
ProvisioningState : Succeeded
SubnetId          : /subscriptions/subsId/resourceGroups/MyRG/providers/Microsoft.Network/virtualNetworks/MyRG-vnet/subnets/default
```

This command updates the ANF volume "MyAnfVolume" with the new UsageThreshold size.

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

### -Backup
A hashtable array which represents the backup object

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolumeBackupProperties
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoolAccess
Specifies whether Cool Access(tiering) is enabled for the volume (default false).

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

### -CoolAccessRetrievalPolicy
CoolAccessRetrievalPolicy determines the data retrieval behavior from the cool tier to standard storage based on the read pattern for cool access enabled volumes. The possible values for this field are: 
 Default - Data will be pulled from cool tier to standard storage on random reads. This policy is the default.
 OnRead - All client-driven data read is pulled from cool tier to standard storage on both sequential and random reads.
 Never - No client-driven data is pulled from cool tier to standard storage.

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

### -CoolAccessTieringPolicy
CoolAccessTieringPolicy determines which cold data blocks are moved to cool tier. The possible values for this field are: 
 Auto - Moves cold user data blocks in both the Snapshot copies and the active file system to the cool tier tier. This policy is the default.
 SnapshotOnly - Moves user data blocks of the Volume Snapshot copies that are not associated with the active file system to the cool tier.

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

### -CoolnessPeriod
Specifies the number of days after which data that is not accessed by clients will be tiered (minimum 7, maximum 63).

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

### -DefaultGroupQuotaInKiB
Default group quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies.

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

### -DefaultUserQuotaInKiB
Default user quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies.

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

### -ExportPolicy
A hashtable array which represents the export policy

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

### -InputObject
The volume object to update

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsDefaultQuotaEnabled
Specifies if default quota is enabled for the volume

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

### -Name
The name of the ANF volume

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet, ByParentObjectParameterSet
Aliases: VolumeName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolName
The name of the ANF pool

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

### -PoolObject
The pool object containing the volume to update

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesPool
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProtocolType
A hashtable array which represents the protocol types. You need to create Active Directory connections before creating an SMB/CIFS volume

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

### -ResourceGroupName
The resource group of the ANF account

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

### -ResourceId
The resource id of the ANF volume

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceLevel
The service level of the ANF volume

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

### -SmbAccessBasedEnumeration
Enables access based enumeration share property for SMB Shares. Only applicable for SMB/DualProtocol volume

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

### -SmbNonBrowsable
Enables non browsable property for SMB Shares. Only applicable for SMB/DualProtocol volume

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

### -SnapshotDirectoryVisible
If enabled (true) the volume will contain a read-only .snapshot directory which provides access to each of the volume's snapshots (default to true)

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

### -SnapshotPolicyId
Snapshot Policy ResourceId used to apply a snapshot policy to the volume

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

### -ThroughputMibps
Maximum throughput in Mibps that can be achieved by this volume

```yaml
Type: System.Nullable`1[System.Double]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnixPermission
UNIX permissions for NFS volume accepted in octal 4 digit format. First digit selects the set user ID(4), set group ID (2) and sticky (1) attributes. Second digit selects permission for the owner of the file: read (4), write (2) and execute (1). Third selects permissions for other users in the same group. the fourth for other users not in the group. 0755 - gives read/write/execute permissions to owner and read/execute to group and other users.

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

### -UsageThreshold
The maximum storage quota allowed for a file system in bytes

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

### System.String

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesPool

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume

## NOTES

## RELATED LINKS

[New-AzNetAppFilesVolume](./New-AzNetAppFilesVolume.md)
[Get-AzNetAppFilesVolume](./Get-AzNetAppFilesVolume.md)
[Remove-AzNetAppFilesVolume](./Remove-AzNetAppFilesVolume.md)
[Restore-AzNetAppFilesVolume](./Restore-AzNetAppFilesVolume.md)
[Set-AzNetAppFilesVolumePool](./Set-AzNetAppFilesVolumePool.md)
[Get-AzNetAppFilesVolumeBackupStatus](./Get-AzNetAppFilesVolumeBackupStatus.md)
[Get-AzNetAppFilesVolumeRestoreStatus](./Get-AzNetAppFilesVolumeRestoreStatus.md)
[Approve-AzNetAppFilesReplication](./Approve-AzNetAppFilesReplication.md)
[Initialize-AzNetAppFilesReplication](./Initialize-AzNetAppFilesReplication.md)
[Resume-AzNetAppFilesReplication](./Resume-AzNetAppFilesReplication.md)
[Remove-AzNetAppFilesReplication](./Remove-AzNetAppFilesReplication.md)
