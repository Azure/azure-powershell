### Example 1: Remove a VM from a Cloud VM Cluster resource
```powershell
$resourceGroup = "PowerShellTestRg"

$dbNodeList = Get-AzOracleExascaleDbNode -Exadbvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName $resourceGroup
$dbNodeOcid1 = $dbNodeList[0].Ocid
$dbNodeToRemove = @($dbNodeOcid1)

Remove-AzOracleExadbVMClusterVM -Exadbvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName $resourceGroup -DbNode $dbNodeToRemove
```

Remove a VM from a Cloud VM Cluster resource.
For more information, execute `Get-Help Remove-AzOracleCloudVMClusterVM`.