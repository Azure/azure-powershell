### Example 1: Create a DbSystem
```powershell
New-AzOracleDbSystem `
  -ResourceGroupName PowerShellTestRg `
  -Name OFake_PowerShellTestDbSystem `
  -Location eastus2 `
  -Shape VM.Standard3.Flex `
  -AdminPassword (ConvertTo-SecureString 'password' -AsPlainText -Force)
```

```output
Name                                          : OFake_PowerShellTestDbSystem
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/dbSystems/OFake_PowerShellTestDbSystem
Type                                          : oracle.database/dbsystems
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/dbaas/dbsystems/ocid1.dbsystem.oc1.iad.aaaaaaaexample?region=us-ashbur
                                                n-1&tenant=orpsandbox3&compartmentId=ocid1.compartment.oc1..aaaaaaaazcet2jt2uowjtgxsae5uositfy2thngqgokwdifyzmyygdpckeua
Ocid                                          : ocid1.dbsystem.oc1.iad.aaaaaaaexample
Shape                                         : VM.Standard3.Flex
CpuCoreCount                                  : 4
DataStorageSizeInGb                           : 256
SubnetId                                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/subn
                                                ets/delegated
ProvisioningState                             : Succeeded
Hostname                                      : psdbs01
Tag                                           : {
                                                }
SystemDataCreatedAt                           : 05/07/2024 13:40:35
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 05/07/2024 13:40:35
SystemDataLastModifiedBy                      : example@oracle.com
SystemDataLastModifiedByType                  : User
TimeCreated                                   : 05/07/2024 13:40:35
```

Creates a DbSystem in the specified resource group and location. For more information, execute `Get-Help New-AzOracleDbSystem`.

### Example 2: Create a DbSystem with tags
```powershell
New-AzOracleDbSystem `
  -ResourceGroupName PowerShellTestRg `
  -Name OFake_PowerShellTestDbSystem `
  -Location eastus2 `
  -Shape VM.Standard3.Flex `
  -Tag @{ env="test"; owner="example@oracle.com" } `
  -AdminPassword (ConvertTo-SecureString 'password' -AsPlainText -Force)
```

```output
Name                                          : OFake_PowerShellTestDbSystem
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/dbSystems/OFake_PowerShellTestDbSystem
Type                                          : oracle.database/dbsystems
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/dbaas/dbsystems/ocid1.dbsystem.oc1.iad.aaaaaaaexample?region=us-ashbur
                                                n-1&tenant=orpsandbox3&compartmentId=ocid1.compartment.oc1..aaaaaaaazcet2jt2uowjtgxsae5uositfy2thngqgokwdifyzmyygdpckeua
Ocid                                          : ocid1.dbsystem.oc1.iad.aaaaaaaexample
Shape                                         : VM.Standard3.Flex
CpuCoreCount                                  : 4
DataStorageSizeInGb                           : 256
SubnetId                                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/subn
                                                ets/delegated
ProvisioningState                             : Succeeded
Hostname                                      : psdbs01
Tag                                           : {
                                                  env=test
                                                  owner=example@oracle.com
                                                }
SystemDataCreatedAt                           : 05/07/2024 13:42:10
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 05/07/2024 13:42:10
SystemDataLastModifiedBy                      : example@oracle.com
SystemDataLastModifiedByType                  : User
TimeCreated                                   : 05/07/2024 13:42:10
```

Creates a DbSystem and assigns tags. For more information, execute `Get-Help New-AzOracleDbSystem`.
