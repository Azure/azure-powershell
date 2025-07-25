### Example 1: Create a Cloud Exadata Infrastructure resource
```powershell
New-AzOracleCloudExadataInfrastructure -Name "OFake_PowerShellTestExaInfra" -ResourceGroupName "PowerShellTestRg" -Location "eastus" -Zone @("2") -Shape "Exadata.X9M" -ComputeCount 3 -StorageCount 3 -DisplayName "OFake_PowerShellTestExaInfra"
```

```output
...
Name                                                      : OFake_PowerShellTestExaInfra
NextMaintenanceRunId                                      : 
OciUrl                                                    : https://cloud.oracle.com/dbaas/cloudExadataInfrastructures/ocid1.cloudexadatainfrastructure.oc1.iad.anuwcljrnirvylqajp6lgcommbx5qbu
                                                            uk7dsm4y5ioehfdqa6l66htw7mj6q?region=us-ashburn-1&tenant=orpsandbox3&compartmentId=ocid1.compartment.oc1..aaaaaaaazcet2jt2uowjtgxsa
                                                            e5uositfy2thngqgokwdifyzmyygdpckeua
Ocid                                                      : ocid1.cloudexadatainfrastructure.oc1.iad.anuwcljrnirvylqajp6lgcommbx5qbuuk7dsm4y5ioehfdqa6l66htw7mj6q
ProvisioningState                                         : Succeeded
ResourceGroupName                                         : PowerShellTestRg
Shape                                                     : Exadata.X9M
StorageCount                                              : 3
StorageServerVersion                                      : 21.1.0.0.0
SystemDataCreatedAt                                       : 04/07/2024 13:20:00
SystemDataCreatedBy                                       : example@oracle.com
SystemDataCreatedByType                                   : User
SystemDataLastModifiedAt                                  : 06/07/2024 08:49:18
SystemDataLastModifiedBy                                  : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                              : Application
Tag                                                       : {
                                                            }
TimeCreated                                               : 2024-07-04T13:20:13.877Z
TotalStorageSizeInGb                                      : 196608
Type                                                      : oracle.database/cloudexadatainfrastructures
Zone                                                      : {2}
```

Create a Cloud Exadata Infrastructure resource.
For more information, execute `Get-Help New-AzOracleCloudExadataInfrastructure`.