### Example 1: Update a Exascale DbStorage Vault resource
```powershell
$tagHashTable = @{'tagName'="tagValue"}
Update-AzOracleExadbVMCluster -Name "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg" -Tag $tagHashTable
```

```output
id                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/exascaleDbStorageVaults/OFake_PowerShellTestExaScaleDbStorage
name                        : OFake_PowerShellTestExaScaleDbStorage
type                        : oracle.database/exascaledbstoragevaults
location                    : eastus
zones                       : 3
tags                        : {
                                        "tagName": "tagValue"
                               }
createdBy                   : user
createdByType               : User
createdAt                   : 2025-05-20T22:01:55.819243Z
lastModifiedBy              : 85cb9edf-cccf-4ba9-a0ac-2a3394be2449
lastModifiedByType          : Application
lastModifiedAt              : 2025-05-20T22:04:20.0220552Z
additionalFlashCacheInPercent: 0
description                 : OFake_PowerShellTestExaScaleDbStorage
displayName                 : OFake_PowerShellTestExaScaleDbStorage
highCapacityDatabaseStorage.totalSizeInGbs: 300
highCapacityDatabaseStorageInput.totalSizeInGbs: 300
timeZone                    : UTC
provisioningState           : Succeeded
lifecycleState              : Available
vmClusterCount              : 0
ocid                        : ocid1.exascaledbstoragevault.oc1.iad.anuwcljrboqpjsqajsz5vw4xxtwlbiqdow3xvcerg7hbmkp4s3774xq7xciq
ociUrl                      : https://cloud.oracle.com/dbaas/exadb-xs/exascaleStorageVaults/ocid1.exascaledbstoragevault.oc1.iad.anuwcljrboqpjsqajsz5vw4xxtwlbiqdow3xvcerg7hbmkp4s3774xq7xciq?region=us-ashburn-1&tenant=orpsandbox2&compartmentId=ocid1.compartment.oc1..aaaaaaaasnfbmmlxikpz5p7gneqbqe7yvlzfx6gt2cr2y3xumxjy72gemi6q
```

Get a Oracle Exa ScaleDb Storage Vault resource.
For more information, execute `Get-Help Update-AzOracleExascaleDbStorageVault`.
