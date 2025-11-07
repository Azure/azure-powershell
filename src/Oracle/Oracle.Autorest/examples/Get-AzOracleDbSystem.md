### Example 1: Get a list of the DbSystem resources
```powershell
Get-AzOracleDbSystem
```

```output
...
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
SystemDataLastModifiedAt                      : 06/07/2024 09:19:26
SystemDataLastModifiedBy                      : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                  : Application
TimeCreated                                   : 05/07/2024 13:44:18
```

Get a DbSystem resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleDbSystem`.

### Example 2: Get a DbSystem by name and resource group name
```powershell
Get-AzOracleDbSystem -ResourceGroupName PowerShellTestRg -Name OFake_PowerShellTestDbSystem
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
SystemDataLastModifiedAt                      : 06/07/2024 09:19:26
SystemDataLastModifiedBy                      : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                  : Application
TimeCreated                                   : 05/07/2024 13:44:18
```

Gets a specific DbSystem resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleDbSystem`.
