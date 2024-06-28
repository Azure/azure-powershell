---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/new-azoracledatabasecloudvmcluster
schema: 2.0.0
---

# New-AzOracleDatabaseCloudVMCluster

## SYNOPSIS
Create a CloudVmCluster

## SYNTAX

### CreateExpanded (Default)
```
New-AzOracleDatabaseCloudVMCluster -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-BackupSubnetCidr <String>] [-CloudExadataInfrastructureId <String>]
 [-ClusterName <String>] [-CpuCoreCount <Int32>] [-DataCollectionOptionIsDiagnosticsEventsEnabled]
 [-DataCollectionOptionIsHealthMonitoringEnabled] [-DataCollectionOptionIsIncidentLogsEnabled]
 [-DataStoragePercentage <Int32>] [-DataStorageSizeInTb <Double>] [-DbNodeStorageSizeInGb <Int32>]
 [-DbServer <String[]>] [-DisplayName <String>] [-Domain <String>] [-GiVersion <String>] [-Hostname <String>]
 [-IsLocalBackupEnabled] [-IsSparseDiskgroupEnabled] [-LicenseModel <String>] [-MemorySizeInGb <Int32>]
 [-NsgCidr <INsgCidr[]>] [-OcpuCount <Single>] [-ScanListenerPortTcp <Int32>]
 [-ScanListenerPortTcpSsl <Int32>] [-SshPublicKey <String[]>] [-SubnetId <String>] [-SystemVersion <String>]
 [-Tag <Hashtable>] [-TimeZone <String>] [-VnetId <String>] [-ZoneId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzOracleDatabaseCloudVMCluster -Name <String> -ResourceGroupName <String> -Resource <ICloudVMCluster>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzOracleDatabaseCloudVMCluster -InputObject <IOracleDatabaseIdentity> -Resource <ICloudVMCluster>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzOracleDatabaseCloudVMCluster -InputObject <IOracleDatabaseIdentity> -Location <String>
 [-BackupSubnetCidr <String>] [-CloudExadataInfrastructureId <String>] [-ClusterName <String>]
 [-CpuCoreCount <Int32>] [-DataCollectionOptionIsDiagnosticsEventsEnabled]
 [-DataCollectionOptionIsHealthMonitoringEnabled] [-DataCollectionOptionIsIncidentLogsEnabled]
 [-DataStoragePercentage <Int32>] [-DataStorageSizeInTb <Double>] [-DbNodeStorageSizeInGb <Int32>]
 [-DbServer <String[]>] [-DisplayName <String>] [-Domain <String>] [-GiVersion <String>] [-Hostname <String>]
 [-IsLocalBackupEnabled] [-IsSparseDiskgroupEnabled] [-LicenseModel <String>] [-MemorySizeInGb <Int32>]
 [-NsgCidr <INsgCidr[]>] [-OcpuCount <Single>] [-ScanListenerPortTcp <Int32>]
 [-ScanListenerPortTcpSsl <Int32>] [-SshPublicKey <String[]>] [-SubnetId <String>] [-SystemVersion <String>]
 [-Tag <Hashtable>] [-TimeZone <String>] [-VnetId <String>] [-ZoneId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzOracleDatabaseCloudVMCluster -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzOracleDatabaseCloudVMCluster -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a CloudVmCluster

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

### -BackupSubnetCidr
Client OCI backup subnet CIDR, default is 192.168.252.0/22

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloudExadataInfrastructureId
Cloud Exadata Infrastructure ID

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The cluster name for cloud VM cluster.
The cluster name must begin with an alphabetic character, and may contain hyphens (-).
Underscores (_) are not permitted.
The cluster name can be no longer than 11 characters and is not case sensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CpuCoreCount
The number of CPU cores enabled on the cloud VM cluster.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataCollectionOptionIsDiagnosticsEventsEnabled
Indicates whether diagnostic collection is enabled for the VM cluster/Cloud VM cluster/VMBM DBCS.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataCollectionOptionIsHealthMonitoringEnabled
Indicates whether health monitoring is enabled for the VM cluster / Cloud VM cluster / VMBM DBCS.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataCollectionOptionIsIncidentLogsEnabled
Indicates whether incident logs and trace collection are enabled for the VM cluster / Cloud VM cluster / VMBM DBCS.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataStoragePercentage
The percentage assigned to DATA storage (user data and database files).
The remaining percentage is assigned to RECO storage (database redo logs, archive logs, and recovery manager backups).
Accepted values are 35, 40, 60 and 80.
The default is 80 percent assigned to DATA storage.
See [Storage Configuration](/Content/Database/Concepts/exaoverview.htm#Exadata) in the Exadata documentation for details on the impact of the configuration settings on storage.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataStorageSizeInTb
The data disk group size to be allocated in TBs.

```yaml
Type: System.Double
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DbNodeStorageSizeInGb
The local node storage to be allocated in GBs.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DbServer
The list of DB servers.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -DisplayName
Display Name

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Domain
The domain name for the cloud VM cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GiVersion
Oracle Grid Infrastructure (GI) software version

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Hostname
The hostname for the cloud VM cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsLocalBackupEnabled
If true, database backup on local Exadata storage is configured for the cloud VM cluster.
If false, database backup on local Exadata storage is not available in the cloud VM cluster.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsSparseDiskgroupEnabled
If true, sparse disk group is configured for the cloud VM cluster.
If false, sparse disk group is not created.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -LicenseModel
The Oracle license model that applies to the cloud VM cluster.
The default is LICENSE_INCLUDED.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MemorySizeInGb
The memory to be allocated in GBs.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
CloudVmCluster name

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: Cloudvmclustername

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

### -NsgCidr
CIDR blocks for additional NSG ingress rules.
The VNET CIDRs used to provision the VM Cluster will be added by default.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.INsgCidr[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OcpuCount
The number of OCPU cores to enable on the cloud VM cluster.
Only 1 decimal place is allowed for the fractional part.

```yaml
Type: System.Single
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
CloudVmCluster resource definition

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.ICloudVMCluster
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScanListenerPortTcp
The TCP Single Client Access Name (SCAN) port.
The default port is 1521.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScanListenerPortTcpSsl
The TCPS Single Client Access Name (SCAN) port.
The default port is 2484.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshPublicKey
The public key portion of one or more key pairs used for SSH access to the cloud VM cluster.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
Client subnet

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemVersion
Operating system version of the image.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZone
The time zone of the cloud VM cluster.
For details, see [Exadata Infrastructure Time Zones](/Content/Database/References/timezones.htm).

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetId
VNET for network connectivity

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneId
The OCID of the zone the cloud VM cluster is associated with.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.ICloudVMCluster

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.ICloudVMCluster

## NOTES

## RELATED LINKS

