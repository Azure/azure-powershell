### Example 1: Add a VM to a Cloud VM Cluster resource
```powershell
$resourceGroup = "PowerShellTestRg"

$dbServerList = Get-AzOracleDatabaseDbServer -Cloudexadatainfrastructurename "OFake_PowerShellTestExaInfra" -ResourceGroupName $resourceGroup
$dbServerOcid1 = $dbServerList[0].Ocid
$dbServersToAdd = @($dbServerOcid1)

Add-AzOracleDatabaseCloudVMClusterVM -Cloudvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName $resourceGroup -DbServer $dbServersToAdd
```

Add a VM to a Cloud VM Cluster resource.
For more information, execute `Get-Help Add-AzOracleDatabaseCloudVMClusterVM`.