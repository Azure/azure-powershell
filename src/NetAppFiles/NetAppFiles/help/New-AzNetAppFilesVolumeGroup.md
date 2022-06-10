---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://docs.microsoft.com/powershell/module/az.netappfiles/new-aznetappfilesvolumegroup
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
 -ApplicationIdentifier <String> -ProximityPlacementGroup <String> -NodeMemory <Int32>
 [-CapacityOverhead <Int32>] [-StartingHostId <Int32>] [-HostCount <Int32>] [-SystemRole <String>]
 [-Prefix <String>] [-Vnet <String>] [-SubnetId <String>] [-DataSize <Int64>] [-DataPerformance <Int32>]
 [-LogSize <Int64>] [-LogPerformance <Int32>] [-SharedSize <Int64>] [-SharedPerformance <Int32>]
 [-DataBackupSize <Int64>] [-DataBackupPerformance <Int32>] [-LogBackupSize <Int64>]
 [-LogBackupPerformance <Int32>] [-HannaSystemReplication] [-DisasterRecoveryDestination]
 [-BackupProtocolType <String[]>] [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>]
 [-GlobalPlacementRule <System.Collections.Generic.IList`1[Microsoft.Azure.Management.NetApp.Models.PlacementKeyValuePairs]>]
 [-Tag <Hashtable>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
New-AzNetAppFilesVolumeGroup -PoolName <String> [-Name <String>] [-GroupDescription <String>]
 [-ApplicationType <String>] -ApplicationIdentifier <String> -ProximityPlacementGroup <String>
 -NodeMemory <Int32> [-CapacityOverhead <Int32>] [-StartingHostId <Int32>] [-HostCount <Int32>]
 [-SystemRole <String>] [-Prefix <String>] [-Vnet <String>] [-SubnetId <String>] [-DataSize <Int64>]
 [-DataPerformance <Int32>] [-LogSize <Int64>] [-LogPerformance <Int32>] [-SharedSize <Int64>]
 [-SharedPerformance <Int32>] [-DataBackupSize <Int64>] [-DataBackupPerformance <Int32>]
 [-LogBackupSize <Int64>] [-LogBackupPerformance <Int32>] [-HannaSystemReplication]
 [-DisasterRecoveryDestination] [-BackupProtocolType <String[]>]
 [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>]
 [-GlobalPlacementRule <System.Collections.Generic.IList`1[Microsoft.Azure.Management.NetApp.Models.PlacementKeyValuePairs]>]
 [-Tag <Hashtable>] -AccountObject <PSNetAppFilesAccount> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetAppFilesVolumeGroup** cmdlet creates an ANF VolumeGroup.

## EXAMPLES

### Example 1
```powershell
New-AzNetAppFilesVolumeGroup -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfVolumeGroupName" -Location "westus2"  -GroupDescription "MyAnfVolumeGroup Description" -ApplicationIdentifier "SH1" -ProximityPlacementGroup "MyPPGResourceId" -Vnet "MyAnfVnet" -SystemRole "PRIMARY" -NodeMemory 100
```

This command creates the new "PRIMARY" ANF VolumeGroup "MyAnfVolumeGroup" within the Account "MyAnfAccount" using the proximityPlacementGroup "MyPPGResourceId", the vnet "MyAnfVnet", and NodeMemory of 100

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

### -DataBackupPerformance
Specify throughput in MiB/s.
If ommited DataBackupPerformance will be autocalculated or specify an integer value representing throughput.

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

### -DataBackupSize
Specify capacity (in GiB).
If ommited DataSize will be autocalculated or specify an integer value representing size.

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
If ommited DataPerformance will be autocalculated or specify and integer value representing throughput.

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

### -DataSize
Specify capacity (in GiB).
If ommited DataSize will be autocalculated or specify an integer value representing size.

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
HANA System Replication (HSR): Replication between the same SID instance on hosts in the same region, or differerent regions.
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
If ommited LogBackupPerformance will be autocalculated or specify an integer value representing throughput.

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

### -LogBackupSize
Specify capacity (in GiB).
If ommited DataSize will be autocalculated or specify an integer value representing size.

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

### -LogPerformance
Specify throughput in MiB/s.
If ommited LogPerformance will be autocalculated or specify and integer value representing throughput.

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

### -LogSize
Specify capacity (in GiB).
If ommited LogSize will be autocalculated or specify an integer value representing size.

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

Required: True
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
If ommited SharedPerformance will be autocalculated or specify and integer value representing throughput.

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

### -SharedSize
Specify capacity (in GiB).
If ommited SharedSize will be autocalculated or specify an integer value representing size.

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