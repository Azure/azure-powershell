
function Test-NewNodePool
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $kubeVersion = "1.25.5"
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

    $poolKubeVersion = "1.25.5"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        $cred = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "EmN8Q~mLAb~WBrSOQPvaY3FX4RA~4l5-KDEC6cR8")
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

function Test-NodePoolMode
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "Standard_D2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        # creat default pool, mode=system
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1
        
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName        
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual "default" $cluster.AgentPoolProfiles[0].Name
        Assert-AreEqual "System" $cluster.AgentPoolProfiles[0].Mode
        
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual "default" $pools.Name
        Assert-AreEqual "System" $pools.Mode

        
        # create the 2nd nodepool, default mode, mode=User
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name "pool2" -Count 1
        
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual "System" ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).Mode
        Assert-AreEqual "User" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).Mode
        
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-AreEqual "System" ($pools | where {$_.Name -eq "default"}).Mode
        Assert-AreEqual "User" ($pools | where {$_.Name -eq "pool2"}).Mode

        # create the 3rd nodepool, mode=System
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name "pool3" -Count 1 -Mode System

        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 3 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual "System" ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).Mode
        Assert-AreEqual "User" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).Mode
        Assert-AreEqual "System" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool3"}).Mode

        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 3 $pools.Count
        Assert-AreEqual "System" ($pools | where {$_.Name -eq "default"}).Mode
        Assert-AreEqual "User" ($pools | where {$_.Name -eq "pool2"}).Mode
        Assert-AreEqual "System" ($pools | where {$_.Name -eq "pool3"}).Mode

        # update the 3rd nodepool, mode=User
        Update-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name "pool3" -Mode User

        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 3 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual "System" ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).Mode
        Assert-AreEqual "User" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).Mode
        Assert-AreEqual "User" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool3"}).Mode

        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 3 $pools.Count
        Assert-AreEqual "System" ($pools | where {$_.Name -eq "default"}).Mode
        Assert-AreEqual "User" ($pools | where {$_.Name -eq "pool2"}).Mode
        Assert-AreEqual "User" ($pools | where {$_.Name -eq "pool3"}).Mode

        # update the 2nd nodepool, mode=System
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeName "pool2" -NodePoolMode System

        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 3 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual "System" ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).Mode
        Assert-AreEqual "System" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).Mode
        Assert-AreEqual "User" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool3"}).Mode

        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 3 $pools.Count
        Assert-AreEqual "System" ($pools | where {$_.Name -eq "default"}).Mode
        Assert-AreEqual "System" ($pools | where {$_.Name -eq "pool2"}).Mode
        Assert-AreEqual "User" ($pools | where {$_.Name -eq "pool3"}).Mode

        $cluster | Remove-AzAksCluster -Force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}