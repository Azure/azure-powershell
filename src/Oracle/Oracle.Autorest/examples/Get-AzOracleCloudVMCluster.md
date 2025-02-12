### Example 1: Get a list of the Cloud VM Cluster resources
```powershell
Get-AzOracleCloudVMCluster
```

```output
...
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
SshPublicKey                                   : {ssh-rsa xxx}
StorageSizeInGb                                : 196608
SubnetId                                       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/sub
                                                 nets/delegated
SubnetOcid                                     : ocid1.subnet.oc1.iad.aaaaaaaatodiqebvhyea45s6nyip4d7u7zizkc6soxbmsymuo2vu4zxosxaq
SystemDataCreatedAt                            : 04/07/2024 15:52:12
SystemDataCreatedBy                            : example@oracle.com
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
VnetId                                         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
ZoneId                                         : ocid1.dns-zone.oc1.iad.aaaaaaaah4rwrfuscditbdg7yjutywp3xpwyuqmcj2bymvb4dn47xoxmvenq
```

Get a Cloud VM Cluster resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleCloudVMCluster`.