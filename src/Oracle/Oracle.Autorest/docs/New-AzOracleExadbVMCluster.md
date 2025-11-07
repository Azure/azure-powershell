---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/new-azoracleexadbvmcluster
schema: 2.0.0
---

# New-AzOracleExadbVMCluster

## SYNOPSIS
Create a ExadbVmCluster

## SYNTAX

### CreateExpanded (Default)
```
New-AzOracleExadbVMCluster -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-BackupSubnetCidr <String>] [-ClusterName <String>]
 [-DataCollectionOptionIsDiagnosticsEventsEnabled] [-DataCollectionOptionIsHealthMonitoringEnabled]
 [-DataCollectionOptionIsIncidentLogsEnabled] [-DisplayName <String>] [-Domain <String>]
 [-EnabledEcpuCount <Int32>] [-ExascaleDbStorageVaultId <String>] [-GridImageOcid <String>]
 [-Hostname <String>] [-LicenseModel <String>] [-NodeCount <Int32>] [-NsgCidr <INsgCidr[]>]
 [-PrivateZoneOcid <String>] [-ScanListenerPortTcp <Int32>] [-ScanListenerPortTcpSsl <Int32>]
 [-Shape <String>] [-ShapeAttribute <String>] [-SshPublicKey <String[]>] [-SubnetId <String>]
 [-SystemVersion <String>] [-Tag <Hashtable>] [-TimeZone <String>] [-TotalEcpuCount <Int32>]
 [-VMFileSystemStorageTotalSizeInGb <Int32>] [-VnetId <String>] [-Zone <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzOracleExadbVMCluster -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzOracleExadbVMCluster -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a ExadbVmCluster

## EXAMPLES

### Example 1: Create a ExaDb VM Cluster resource
```powershell
$subscriptionId = "00000000-0000-0000-0000-000000000000"
$resourceGroup = "PowerShellTestRg"

$vnetName = "PSTestVnet"
$vnetId = "/subscriptions/$($subscriptionId)/resourceGroups/$($resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($vnetName)"

$subnetName = "delegated"
$subnetId = "/subscriptions/$($subscriptionId)/resourceGroups/$($resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($vnetName)/subnets/$($subnetName)"
    
$sshPublicKey = "ssh-rsa xxx"

$resourceGroup = "PowerShellTestRg"
$exascaleStorageVaultName = "OFake_PowerShellTestExaScaleStorage"
$exascaleDbStorageVault = Get-AzOracleExascaleDbStorageVault -Name $exascaleStorageVaultName -ResourceGroupName $resourceGroup
$exascaleDbStorageVaultId = $exascaleDbStorageVault.Id

$exadbVmClusterName = "OFake_PowerShellTestExadbVmCluster"
New-AzOracleExadbVMCluster -Name $exadbVmClusterName -ResourceGroupName $resourceGroup -Location "eastus" -DisplayName $exadbVmClusterName -HostName "host" -totalEcpuCount 8 -exascaleDbStorageVaultId $exascaleDbStorageVaultId -SshPublicKey $sshPublicKey -VnetId $vnetId -SubnetId $subnetId -LicenseModel "LicenseIncluded" -shape "ExaDbXS" -enabledEcpuCount 8 -TimeZone "UTC" -nodeCount 1 
```

```output
....

name                       : OFake_PowerShellTestExadbVmCluster
type                       : oracle.database/exadbvmclusters
location                   : eastus
zones                      : 3
clusterName                : OFake_PowerShellTestExadbVmCluster
nsgUrl                     : https://cloud.oracle.com/networking/vcns/ocid1.vcn.oc1.iad.amaaaaaaboqpjsqa6goluo2oze7brbcturrhjp4dbiqynybygcaowysqh4vq/network-security-groups/ocid1.networksecuritygroup.oc1.iad.aaaaaaaapab43hogjh77qaduxsbbormuyoxrnpzydaueyeqhhnipykd3obxa?region=us-ashburn-1
provisioningState          : Succeeded
lifecycleState             : Available
vnetId                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
subnetId                   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/sub
displayName                : OFake_PowerShellTestExadbVmCluster
domain                     : ocidelegated.ocivnettestexa.oraclevcn.com
enabledEcpuCount           : 16
exascaleDbStorageVaultId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/providers/Oracle.Database/exascaleDbStorageVaults/OFake_PowerShellTestExaScaleStorage
gridImageOcid              : ocid1.dbpatch.oc1.iad.anuwcljrt5t4sqqarmom7cvfg5oy47ccceplnqx6qugb7vyfdfjrrp7rz4nq
gridImageType              : ReleaseUpdate
giVersion                  : 23.8.0.25.04
hostname                   : theo
licenseModel               : LicenseIncluded
memorySizeInGbs            : 44
nodeCount                  : 2
scanListenerPortTcp        : 1521
scanListenerPortTcpSsl     : 2484
listenerPort               : 1521
shape                      : EXADBXS
sshPublicKeys              : ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQD2uOXC283JO8ig2dd2oxGie0KzgtDs/z1V2JHQXYRs3pRzr3WESSEvQgANhYBFC5BkxDQQvURTGRYkaLirs0OdxnuUNm2TZHB0T+u5UK4nKC0mUCWL++sbI+VYP+dzovJRa8e61xDMboheuqolxeJf6kyfIiJA3GJeYtQKSig0+DOfCrEFjp1hiqfr0eUxDItLn5BoG3d5IVG0DE4Z5gy9dtjG6AkJE6Gh+n3WxQbJu8/gkJYVmcjlFGyw9Wd3FTQ/4EocBwW9RXoTCfyqmidxwDeq34i9L1yYcnTDjFWwQ3xfaKuWeRugucl2ogjFVbU8Op/ODhs1h8eZLg/qezl3B4iI3De1FXWVhEuuNsbntuRgZZ2JFvsIgzBTUKLKTsibxbSWiMIIbIDmPuswkZvy70yukv7t/hTaX+cIxo4kgGVFET4HjOqqdWm7fiDX6rAcoRSYOp29CWYFcFkKZQ4rwD51JkOKUA4xNtQHFrWuaEjjxqfEdPuI0hjWyW6IJ40= generated-by-azure
systemVersion              : 19.2.12.0.0.200317
timeZone                   : UTC
totalEcpuCount             : 16
vmFileSystemStorage        : totalSizeInGbs: 560
scanDnsName                : fakeScanDnsName
scanIpIds                  :
scanDnsRecordId            : ocid1.vcndnsrecord.oc1.iad.anuwcljrhnge2iqaycryvslv72somguxmjxgd3fxbk5tzwoksiekg4dguljq
snapshotFileSystemStorage  : totalSizeInGbs: 0
totalFileSystemStorage     : totalSizeInGbs: 560
vipIds                     :
zoneOcid                   : ocid1.dns-zone.oc1.iad.aaaaaaaafla3b2uh67e4qxqcsl4mzoqh4nckbb243lvvy2ukgqpxubn5trra
```

Create a ExaDb VM Cluster resource.
For more information, execute `Get-Help New-AzOracleExaDbVMCluster`.

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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The cluster name for Exadata VM cluster on Exascale Infrastructure.
The cluster name must begin with an alphabetic character, and may contain hyphens (-).
Underscores (_) are not permitted.
The cluster name can be no longer than 11 characters and is not case sensitive.

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

### -DataCollectionOptionIsDiagnosticsEventsEnabled
Indicates whether diagnostic collection is enabled for the VM cluster/Cloud VM cluster/VMBM DBCS.

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

### -DataCollectionOptionIsHealthMonitoringEnabled
Indicates whether health monitoring is enabled for the VM cluster / Cloud VM cluster / VMBM DBCS.

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

### -DataCollectionOptionIsIncidentLogsEnabled
Indicates whether incident logs and trace collection are enabled for the VM cluster / Cloud VM cluster / VMBM DBCS.

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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Domain
A domain name used for the Exadata VM cluster on Exascale Infrastructure

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

### -EnabledEcpuCount
The number of ECPUs to enable for an Exadata VM cluster on Exascale Infrastructure.

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

### -ExascaleDbStorageVaultId
The Azure Resource ID of the Exadata Database Storage Vault.

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

### -GridImageOcid
Grid Setup will be done using this Grid Image OCID.
Can be obtained using giMinorVersions API

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

### -Hostname
The hostname for the Exadata VM cluster on Exascale Infrastructure.

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
The Oracle license model that applies to the Exadata VM cluster on Exascale Infrastructure.
The default is LICENSE_INCLUDED.

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
The name of the ExadbVmCluster

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ExadbVMClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeCount
The number of nodes in the Exadata VM cluster on Exascale Infrastructure.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.INsgCidr[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateZoneOcid
The OCID of the zone the Exadata VM cluster on Exascale Infrastructure is associated with.

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

### -ScanListenerPortTcp
The TCP Single Client Access Name (SCAN) port.
The default port is 1521.

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

### -ScanListenerPortTcpSsl
The TCPS Single Client Access Name (SCAN) port.
The default port is 2484.

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

### -Shape
The shape of the Exadata VM cluster on Exascale Infrastructure resource

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

### -ShapeAttribute
The type of Exascale storage used for Exadata VM cluster.

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

### -SshPublicKey
The public key portion of one or more key pairs used for SSH access to the Exadata VM cluster on Exascale Infrastructure.

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

### -SubnetId
Client subnet

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

### -SystemVersion
Operating system version of the image.

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

### -TimeZone
The time zone of the Exadata VM cluster on Exascale Infrastructure.
For details, see [Exadata Infrastructure Time Zones](/Content/Database/References/timezones.htm).

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

### -TotalEcpuCount
The number of Total ECPUs for an Exadata VM cluster on Exascale Infrastructure.

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

### -VMFileSystemStorageTotalSizeInGb
Total Capacity

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

### -VnetId
VNET for network connectivity

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

### -Zone
The availability zones.

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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IExadbVMCluster

## NOTES

## RELATED LINKS

