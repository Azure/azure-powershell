### Example 1: Update a Cloud VM Cluster resource
```powershell
$tagHashTable = @{'tagName'="tagValue"}
Update-AzOracleCloudVMCluster -Name "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg" -Tag $tagHashTable
```

```output
BackupSubnetCidr                               : 
CloudExadataInfrastructureId                   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/cloudExadataInfrastructures/OFake_PowerShellTestExaInfra
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
DbServer                                       : {ocid1.dbserver.oc1.iad.anuwcljrowjpydqaoklexltoygidco5rxfo5zusgnblo2ayvaczyqg7sqtjq, ocid1.dbserver.oc1.iad.anuwcljrowjpydqar5ljy52di4siacvp4h4hzwp6jcz7yrmkiaglyi7nfwdq}
DiskRedundancy                                 : High
DisplayName                                    : OFake_PowerShellTestVmCluster
Domain                                         : ocidelegated.ocipstestvnet.oraclevcn.com
GiVersion                                      : 19.9.0.0.0
Hostname                                       : host-wq5t6
Id                                             : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/cloudVmClusters/OFake_PowerShellTestVmCluster
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
NsgUrl                                         : https://cloud.oracle.com/networking/vcns/ocid1.vcn.oc1.iad.amaaaaaanirvylqaltsnipqfdbwlimfznzto7vjto23cqahcu3k3g673z7ma/network-security-groups/ocid1.networksecuritygroup.oc1.iad.aaaaaaaas45h3bfix5lxcyvi
                                                 4x5wxlrrt62r4pa5we63r6drzcgdwktdobba?region=us-ashburn-1
OciUrl                                         : https://cloud.oracle.com/dbaas/cloudVmClusters/ocid1.cloudvmcluster.oc1.iad.anuwcljrnirvylqanh37nglmlhotsnvzwivsfnomoa6lc7t6l5gwwocoovcq?region=us-ashburn-1&tenant=orpsandbox3&compartmentId=ocid1.compart
                                                 ment.oc1..aaaaaaaazcet2jt2uowjtgxsae5uositfy2thngqgokwdifyzmyygdpckeua
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
SshPublicKey                                   : {ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDKJkePl4prXTs6cZ77AS9kGs5TO1EdfDdQZAtD7cfBVJ8X4wN+aOvLhk+u74D3qXad2OdQ/ij5q+xVzoXLXNBIZFQjB8JqWpgvOrOCAakFGc0OatJhSVlmJKW7JboQcUu7AzABfu+Ciso1QQTqlc2+awoZzPhfP9sgDM
                                                 N6zI15Q9wSuxERor8oMSc78NW652wMzl97zO+bYdO9vIjBu27/WYZN/OpFJ0Ss4AzW/V9r2h6FFCkG+GXzhZArk3NeEstCSO2bjv3vO40+M0vfRD2jQrOSKhaLolk+crLGamaclY0YYCVB23rk6gCimWbVuvpHn+x1QSvN2d19xAmrIsHdTv/1lCEJetMA96pBq/jbljPwV
                                                 KPFfVkyC8Ivt5rkbYizmUlYAbDMksGMUR4ncjScY7o/S0JKs14HihOnCoSGVXhH1dDgc8AsI+Ujs+GGR4U8IXJGEpZmhdnLa6mDymvr1tLWdQaI2y5FuWxsy4diKjEsPxCrnqfxlZxFBbQ29AU= generated-by-azure}
StorageSizeInGb                                : 196608
SubnetId                                       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/subnets/delegated
SubnetOcid                                     : ocid1.subnet.oc1.iad.aaaaaaaatodiqebvhyea45s6nyip4d7u7zizkc6soxbmsymuo2vu4zxosxaq
SystemDataCreatedAt                            : 04/07/2024 15:52:12
SystemDataCreatedBy                            : example@oracle.com
SystemDataCreatedByType                        : User
SystemDataLastModifiedAt                       : 06/07/2024 15:39:06
SystemDataLastModifiedBy                       : example@oracle.com
SystemDataLastModifiedByType                   : User
SystemVersion                                  : 
Tag                                            : {
                                                   "tagName": "tagValue"
                                                 }
TimeCreated                                    : 04/07/2024 16:09:39
TimeZone                                       : UTC
Type                                           : oracle.database/cloudvmclusters
VipId                                          : 
VnetId                                         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
ZoneId                                         : ocid1.dns-zone.oc1.iad.aaaaaaaah4rwrfuscditbdg7yjutywp3xpwyuqmcj2bymvb4dn47xoxmvenq
```

Update a Cloud VM Cluster resource.
For more information, execute `Get-Help Update-AzOracleCloudVMCluster`.