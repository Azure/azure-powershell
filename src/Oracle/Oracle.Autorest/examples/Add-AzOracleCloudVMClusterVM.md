### Example 1: Add a VM to a Cloud VM Cluster resource
```powershell
$resourceGroup = "PowerShellTestRg"

$dbServerList = Get-AzOracleDbServer -Cloudexadatainfrastructurename "OFake_PowerShellTestExaInfra" -ResourceGroupName $resourceGroup
$dbServerOcid1 = $dbServerList[0].Ocid
$dbServersToAdd = @($dbServerOcid1)

Add-AzOracleCloudVMClusterVM -Cloudvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName $resourceGroup -DbServer $dbServersToAdd
```

Add a VM to a Cloud VM Cluster resource.
For more information, execute `Get-Help Add-AzOracleCloudVMClusterVM`.