
function Test-NewNodePool
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $kubeVersion = "1.24.3"
    $nodeVmSize = "Standard_A2"
    $nodeVmSetType = "VirtualMachineScaleSets"
    $nodeOsType = "Linux"
    $networkPlugin = "azure"
    $nodeVmSetType = "VirtualMachineScaleSets"
    $winAdminUser = "winuser"
    $winPassword = ConvertTo-SecureString -AsPlainText "Password!!123Length" -Force
    $winNodeName = "windef"
    $winNodeOsType = "Windows"
    $updatedNodePoolSize = 5

    $poolKubeVersion = "1.24.3"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        $cred = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "xSc8Q~kVbSNvv5aqTbbAnXLieQsc~ZlEw2GbtdrX")
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -ServicePrincipalIdAndSecret $cred -NetworkPlugin $networkPlugin `
            -KubernetesVersion $kubeVersion -NodeVmSetType $nodeVmSetType -WindowsProfileAdminUserName $winAdminUser `
            -WindowsProfileAdminUserPassword $winPassword


        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual $networkPlugin $cluster.NetworkProfile.NetworkPlugin
        Assert-AreEqual $nodeOsType $cluster.AgentPoolProfiles[0].OsType
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count

        #add new windows cluster
        $cluster | New-AzAksNodePool -Name $winNodeName -VmSize $nodeVmSize -OsType $winNodeOsType -VmSetType $nodeVmSetType -KubernetesVersion $poolKubeVersion

        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        
        $winPool = $cluster | Get-AzAksNodePool -Name $winNodeName
        Assert-AreEqual $nodeVmSize $winPool.VmSize
        Assert-AreEqual $winNodeOsType $winPool.OsType
        Assert-AreEqual $nodeVmSetType $winPool.AgentPoolType
        Assert-AreEqual $poolKubeVersion $winPool.OrchestratorVersion

        $updatedWinPool = $winPool | Update-AzAksNodePool -KubernetesVersion $kubeVersion -NodeCount $updatedNodePoolSize
        Assert-AreEqual $kubeVersion $updatedWinPool.OrchestratorVersion
        Assert-AreEqual $updatedNodePoolSize $updatedWinPool.Count

        $updatedWinPool | Remove-AzAksNodePool -Force
        $cluster | Remove-AzAksCluster -Force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}
