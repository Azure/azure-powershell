### Example 1: Remove a VM from a Cloud VM Cluster resource
```powershell
$resourceGroup = "PowerShellTestRg"

$dbServerList = Get-AzOracleDbServer -Cloudexadatainfrastructurename "OFake_PowerShellTestExaInfra" -ResourceGroupName $resourceGroup
$dbServerOcid1 = $dbServerList[0].Ocid
$dbServersToRemove = @($dbServerOcid1)

Remove-AzOracleCloudVMClusterVM -Cloudvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg" -DbServer $dbServersToRemove
```

Remove a VM from a Cloud VM Cluster resource.
For more information, execute `Get-Help Remove-AzOracleCloudVMClusterVM`.