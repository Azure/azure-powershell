### Example 1: Removes a VM from a Cloud VM Cluster resource
```powershell
$resourceGroup = "PowerShellTestRg"

$dbServerList = Get-AzOracleDatabaseDbServer -Cloudexadatainfrastructurename "OFake_PowerShellTestExaInfra" -ResourceGroupName $resourceGroup
$dbServerOcid1 = $dbServerList[0].Ocid
$dbServersToRemove = @($dbServerOcid1)

Remove-AzOracleDatabaseCloudVMClusterVM -Cloudvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg" -DbServer $dbServersToRemove
```

Removes a VM from a Cloud VM Cluster resource.
For more information, execute `Get-Help Remove-AzOracleDatabaseCloudVMClusterVM`