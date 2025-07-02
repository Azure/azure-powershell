### Example 1: Stop a VM in a Exa Db  Cluster Node resource
```powershell
$vmClusterName = "OFake_PowerShellTestVmCluster"
$resourceGroup = "PowerShellTestRg"
$stopActionName = "Stop"
            
$dbNodeList = Get-AzOracleExascaleDbNode -Exadbvmclustername $vmClusterName -ResourceGroupName $resourceGroup
$dbNodeOcid1 = $dbNodeList[0].Name
            
Invoke-AzOracleActionExascaleDbNode -ExadbVMClusterName $vmClusterName -ExascaleDbNodeName $dbNodeOcid1 -ResourceGroupName $resourceGroup -Action $stopActionName
```

```output
ocid                        : ocid1.dbnode.oc1..aaaaa3klq
additionalDetails           : zjvaydzrzxrmtiolutkhyfumql
cpuCoreCount                : 25
dbNodeStorageSizeInGbs      : 7
faultDomain                 : bgtzblfwbdooaj
hostname                    : nmbmxqpkdqueswkwystaupanqrn
lifecycleState              : Available
ProvisioningState           : Stopping
maintenanceType             : ncsgznwyxmzcrqnmzbn
memorySizeInGbs             : 29
softwareStorageSizeInGb     : 14
timeMaintenanceWindowEnd    : 2024-12-09T21:02:38.078Z
timeMaintenanceWindowStart  : 2024-12-09T21:02:38.078Z
totalCpuCoreCount           : 26
id                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Oracle.Database/exadbVmClusters/vmCluster/dbNodes/dbNodeName
name                        : lkjpzwgzy
type                        : zdrljrxhtseejhwvzox
createdBy                   : ilrpjodjmvzhybazxipoplnql
createdByType               : User
createdAt                   : 2024-12-09T21:02:12.592Z
lastModifiedBy              : lhjbxchqkaia
lastModifiedByType          : User
lastModifiedAt              : 2024-12-09T21:02:12.592Z
```

Get a list of the Database Nodes for a Cloud VM Cluster resource.
For more information, execute `Get-Help Invoke-AzOracleExascaleDbNode`
