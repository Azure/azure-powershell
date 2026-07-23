### Example 1: Update a Exadb VM Cluster resource
```powershell
$tagHashTable = @{'tagName'="tagValue"}
Update-AzOracleExadbVMCluster -Name "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg" -Tag $tagHashTable
```

```output
name                       : OFake_PowerShellTestExadbVmCluster
type                       : oracle.database/exadbvmclusters
location                   : eastus
zones                      : 3
Tag                        : {
                                    "tagName": "tagValue"
                             }
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
For more information, execute `Get-Help Update-AzOracleExaDbVMCluster`.