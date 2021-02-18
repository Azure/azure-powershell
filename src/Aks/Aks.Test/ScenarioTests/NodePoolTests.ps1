
function Test-NewNodePool
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = Get-ProviderLocation "Microsoft.ContainerService/managedClusters"
    $kubeVersion = "1.15.11"
    $nodeVmSize = "Standard_A2"
    $nodeVmSetType = "VirtualMachineScaleSets"
    $nodeOsType = "Linux"
    $networkPlugin = "azure"
    $nodeVmSetType = "VirtualMachineScaleSets"
    $winAdminUser = "winuser"
    $winPassword = ConvertTo-SecureString -AsPlainText "Password!!123" -Force
    $winNodeName = "windef"
    $winNodeOsType = "Windows"

    $poolKubeVersion = "1.15.11"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        #new cluster
        if (IsLive) {
            $cred = $(createTestCredential "Unicorns" "Puppies")
            New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -ClientIdAndSecret $cred -NetworkPlugin $networkPlugin `
                -KubernetesVersion $kubeVersion -NodeVmSetType $nodeVmSetType -WindowsProfileAdminUserName $winAdminUser `
                -WindowsProfileAdminUserPassword $winPassword
        } else {
            New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NetworkPlugin $networkPlugin -KubernetesVersion $kubeVersion
        }

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

        $updatedWinPool = $winPool | Update-AzAksNodePool -KubernetesVersion $kubeVersion
        Assert-AreEqual $kubeVersion $updatedWinPool.OrchestratorVersion

        $updatedWinPool | Remove-AzAksNodePool -Force
        $cluster | Remove-AzAksCluster -Force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}
