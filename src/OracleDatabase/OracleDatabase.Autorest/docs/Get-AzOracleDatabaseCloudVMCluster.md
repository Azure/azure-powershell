---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/get-azoracledatabasecloudvmcluster
schema: 2.0.0
---

# Get-AzOracleDatabaseCloudVMCluster

## SYNOPSIS
Get a CloudVmCluster

## SYNTAX

### List (Default)
```
Get-AzOracleDatabaseCloudVMCluster [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzOracleDatabaseCloudVMCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDatabaseCloudVMCluster -InputObject <IOracleDatabaseIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzOracleDatabaseCloudVMCluster -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a CloudVmCluster

## EXAMPLES

### Example 1: Gets a list of the Cloud VM Cluster resources
```powershell
Get-AzOracleDatabaseCloudVMCluster
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

Gets a list of the Cloud VM Cluster resources.
For more information, execute `Get-Help Get-AzOracleDatabaseCloudVMCluster`

### Example 2: Gets a Cloud VM Cluster resource by name and resource group name
```powershell
Get-AzOracleDatabaseCloudVMCluster -Name "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg"
```

```output
BackupSubnetCidr                               : 
CloudExadataInfrastructureId                   : /subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/resourceGroups/PowerShellTestRg/providers/Oracle.Database/cloudExadataInfrastructures/OFak
                                                 e_PowerShellTestExaInfra
ClusterName                                    : TestVMC
CompartmentId                                  : ocid1.compartment.oc1..aaaaaaaazcet2jt2uowjtgxsae5uositfy2thngqgokwdifyzmyygdpckeua
ComputeNode                                    : 
CpuCoreCount                                   : 4
DataCollectionOptionIsDiagnosticsEventsEnabled : False
DataCollectionOptionIsHealthMonitoringEnabled  : False
DataCollectionOptionIsIncidentLogsEnabled      : False
DataStoragePercentage                          : 80
DataStorageSizeInTb                            : 2
DbNodeStorageSizeInGb                          : 180
DbServer                                       : {ocid1.dbserver.oc1.iad.anuwcljrowjpydqaoklexltoygidco5rxfo5zusgnblo2ayvaczyqg7sqtjq, 
                                                 ocid1.dbserver.oc1.iad.anuwcljrowjpydqar5ljy52di4siacvp4h4hzwp6jcz7yrmkiaglyi7nfwdq}
DiskRedundancy                                 : High
DisplayName                                    : OFake_PowerShellTestVmCluster
Domain                                         : ocidelegated.ocipstestvnet.oraclevcn.com
GiVersion                                      : 19.9.0.0.0
Hostname                                       : host-wq5t6
Id                                             : /subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/resourceGroups/PowerShellTestRg/providers/Oracle.Database/cloudVmClusters/OFake_PowerShell
                                                 TestVmCluster
IormConfigCacheDbPlan                          : 
IormConfigCacheLifecycleDetail                 : 
IormConfigCacheLifecycleState                  : 
IormConfigCacheObjective                       : 
IsLocalBackupEnabled                           : False
IsSparseDiskgroupEnabled                       : False
LastUpdateHistoryEntryId                       : 
LicenseModel                                   : LicenseIncluded
LifecycleDetail                                : 
LifecycleState                                 : Available
ListenerPort                                   : 1521
Location                                       : eastus
MemorySizeInGb                                 : 90
Name                                           : OFake_PowerShellTestVmCluster
NodeCount                                      : 2
NsgCidr                                        : 
NsgUrl                                         : https://cloud.oracle.com/networking/vcns/ocid1.vcn.oc1.iad.amaaaaaanirvylqaltsnipqfdbwlimfznzto7vjto23cqahcu3k3g673z7ma/network-security-group
                                                 s/ocid1.networksecuritygroup.oc1.iad.aaaaaaaas45h3bfix5lxcyvi4x5wxlrrt62r4pa5we63r6drzcgdwktdobba?region=us-ashburn-1
OciUrl                                         : https://cloud.oracle.com/dbaas/cloudVmClusters/ocid1.cloudvmcluster.oc1.iad.anuwcljrnirvylqanh37nglmlhotsnvzwivsfnomoa6lc7t6l5gwwocoovcq?regio
                                                 n=us-ashburn-1&tenant=orpsandbox3&compartmentId=ocid1.compartment.oc1..aaaaaaaazcet2jt2uowjtgxsae5uositfy2thngqgokwdifyzmyygdpckeua
Ocid                                           : ocid1.cloudvmcluster.oc1.iad.anuwcljrnirvylqanh37nglmlhotsnvzwivsfnomoa6lc7t6l5gwwocoovcq
OcpuCount                                      : 4
ProvisioningState                              : Succeeded
ResourceGroupName                              : PowerShellTestRg
ScanDnsName                                    : host-wq5t6-scan.ocidelegated.ocipstestvnet.oraclevcn.com
ScanDnsRecordId                                : 
ScanIPId                                       : {}
ScanListenerPortTcp                            : 1521
ScanListenerPortTcpSsl                         : 2484
Shape                                          : Exadata.X9M
SshPublicKey                                   : {ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDKJkePl4prXTs6cZ77AS9kGs5TO1EdfDdQZAtD7cfBVJ8X4wN+aOvLhk+u74D3qXad2OdQ/ij5q+xVzoXLXNBIZFQjB8JqWpgvOrOCA
                                                 akFGc0OatJhSVlmJKW7JboQcUu7AzABfu+Ciso1QQTqlc2+awoZzPhfP9sgDMN6zI15Q9wSuxERor8oMSc78NW652wMzl97zO+bYdO9vIjBu27/WYZN/OpFJ0Ss4AzW/V9r2h6FFCkG+GX
                                                 zhZArk3NeEstCSO2bjv3vO40+M0vfRD2jQrOSKhaLolk+crLGamaclY0YYCVB23rk6gCimWbVuvpHn+x1QSvN2d19xAmrIsHdTv/1lCEJetMA96pBq/jbljPwVKPFfVkyC8Ivt5rkbYizm
                                                 UlYAbDMksGMUR4ncjScY7o/S0JKs14HihOnCoSGVXhH1dDgc8AsI+Ujs+GGR4U8IXJGEpZmhdnLa6mDymvr1tLWdQaI2y5FuWxsy4diKjEsPxCrnqfxlZxFBbQ29AU= 
                                                 generated-by-azure}
StorageSizeInGb                                : 196608
SubnetId                                       : /subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/sub
                                                 nets/delegated
SubnetOcid                                     : ocid1.subnet.oc1.iad.aaaaaaaatodiqebvhyea45s6nyip4d7u7zizkc6soxbmsymuo2vu4zxosxaq
SystemDataCreatedAt                            : 04/07/2024 15:52:12
SystemDataCreatedBy                            : jamie.c.cheung@oracle.com
SystemDataCreatedByType                        : User
SystemDataLastModifiedAt                       : 06/07/2024 09:04:17
SystemDataLastModifiedBy                       : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                   : Application
SystemVersion                                  : 
Tag                                            : {
                                                 }
TimeCreated                                    : 04/07/2024 16:09:39
TimeZone                                       : UTC
Type                                           : oracle.database/cloudvmclusters
VipId                                          : 
VnetId                                         : /subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
ZoneId                                         : ocid1.dns-zone.oc1.iad.aaaaaaaah4rwrfuscditbdg7yjutywp3xpwyuqmcj2bymvb4dn47xoxmvenq
```

Gets a Cloud VM Cluster resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleDatabaseCloudVMCluster`

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
CloudVmCluster name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: Cloudvmclustername

Required: True
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
Parameter Sets: Get, List1
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
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.ICloudVMCluster

## NOTES

## RELATED LINKS

