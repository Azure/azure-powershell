<#
.SYNOPSIS
Test Kubernetes stuff
#>
function Test-NewAzAksSimple
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = Get-ProviderLocation "Microsoft.ContainerService/managedClusters"
    $nodeVmSize = "Standard_A2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        if (IsLive) {
            $cred = $(createTestCredential "Unicorns" "Puppies")
            New-AzAks -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ClientIdAndSecret $cred
        } else {
            New-AzAks -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize
        }
        $cluster = Get-AzAks -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-NotNull $cluster.Fqdn
        Assert-NotNull $cluster.DnsPrefix
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Length
        Assert-AreEqual 3 $cluster.AgentPoolProfiles[0].Count;
        $cluster = $cluster | Set-AzAks -NodeCount 2
        Assert-AreEqual 2 $cluster.AgentPoolProfiles[0].Count;
        $cluster | Import-AzAksCredential -Force
        $cluster | Remove-AzAks -Force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-NewAzAksWithAcr
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $acrName = Get-RandomRegistryName
    $location = Get-ProviderLocation "Microsoft.ContainerService/managedClusters"
    $nodeVmSize = "Standard_A2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        New-AzContainerRegistry -ResourceGroupName $resourceGroupName -Name $acrName -Sku Standard

        if (IsLive) {
            $cred = $(createTestCredential "Unicorns" "Puppies")
            New-AzAks -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ClientIdAndSecret $cred -AcrNameToAttach $acrName
        } else {
            New-AzAks -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -AcrNameToAttach $acrName
        }
        $cluster = Get-AzAks -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-NotNull $cluster.Fqdn
        Assert-NotNull $cluster.DnsPrefix
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Length
        Assert-AreEqual 3 $cluster.AgentPoolProfiles[0].Count;
        $cluster = $cluster | Set-AzAks -NodeCount 2
        Assert-AreEqual 2 $cluster.AgentPoolProfiles[0].Count;
        $cluster | Import-AzAksCredential -Force
        $cluster | Remove-AzAks -Force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-NewAzAks
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = Get-ProviderLocation "Microsoft.ContainerService/managedClusters"
    $kubeVersion = "1.15.7"
    $nodeVmSize = "Standard_A2"
    $maxPodCount = 25
    $nodeName = "defnode"
    $nodeCount = 2
    $nodeMinCount = 1
    $nodeMaxCount = 30
    $nodeDiskSize = 100
    $nodeVmSetType = "VirtualMachineScaleSets"
    $nodeOsType = "Linux"
    $enableAutoScaling = $true
    $enableRbac = $true
    $networkPlugin = "kubenet"
    $loadBalancerSku = "Standard"
    $linuxAdminUser = "linuxuser"
    $dnsNamePrefix = "mypre"
    $updatedKubeVersion = "1.15.10"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        if (IsLive) {
            $cred = $(createTestCredential "Unicorns" "Puppies")
            New-AzAks -ResourceGroupName $resourceGroupName -Name $kubeClusterName -ClientIdAndSecret $cred -NetworkPlugin $networkPlugin `
                -KubernetesVersion $kubeVersion -EnableRbac -LoadBalancerSku $loadBalancerSku -LinuxProfileAdminUserName $linuxAdminUser -DnsNamePrefix $dnsNamePrefix `
                -NodeName $nodeName -NodeOsType $nodeOsType -EnableNodeAutoScaling -NodeCount $nodeCount -NodeOsDiskSize $nodeDiskSize -NodeVmSize $nodeVmSize `
                -NodeMaxCount $nodeMaxCount -NodeMinCount $nodeMinCount -NodeMaxPodCount $maxPodCount -NodeSetPriority Regular -NodeScaleSetEvictionPolicy Deallocate -NodeVmSetType VirtualMachineScaleSets
         } else {
            New-AzAks -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NetworkPlugin $networkPlugin `
                -KubernetesVersion $kubeVersion -EnableRbac -LoadBalancerSku $loadBalancerSku -LinuxProfileAdminUserName $linuxAdminUser -DnsNamePrefix $dnsNamePrefix `
                -NodeName $nodeName -NodeOsType $nodeOsType -EnableNodeAutoScaling -NodeCount $nodeCount -NodeOsDiskSize $nodeDiskSize -NodeVmSize $nodeVmSize `
                -NodeMaxCount $nodeMaxCount -NodeMinCount $nodeMinCount -NodeMaxPodCount $maxPodCount -NodeSetPriority Regular -NodeScaleSetEvictionPolicy Deallocate -NodeVmSetType VirtualMachineScaleSets
        }
        $cluster = Get-AzAks -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-NotNull $cluster.Fqdn
        Assert-AreEqual $dnsNamePrefix $cluster.DnsPrefix
        Assert-AreEqual $kubeVersion $cluster.KubernetesVersion
        Assert-AreEqual $enableRbac $cluster.EnableRBAC
        Assert-AreEqual $networkPlugin $cluster.NetworkProfile.NetworkPlugin
        Assert-AreEqual $loadBalancerSku $cluster.NetworkProfile.LoadBalancerSku
        Assert-AreEqual $linuxAdminUser $cluster.LinuxProfile.AdminUsername
        Assert-AreEqual $nodeName $cluster.AgentPoolProfiles[0].Name
        Assert-AreEqual $nodeVmSize $cluster.AgentPoolProfiles[0].VmSize
        Assert-AreEqual $maxPodCount $cluster.AgentPoolProfiles[0].MaxPods
        Assert-AreEqual $nodeCount $cluster.AgentPoolProfiles[0].Count
        Assert-AreEqual $nodeMinCount $cluster.AgentPoolProfiles[0].MinCount
        Assert-AreEqual $nodeMaxCount $cluster.AgentPoolProfiles[0].MaxCount
        Assert-AreEqual $nodeDiskSize $cluster.AgentPoolProfiles[0].OsDiskSizeGB
        Assert-AreEqual $nodeVmSetType $cluster.AgentPoolProfiles[0].Type
        Assert-AreEqual $nodeOsType $cluster.AgentPoolProfiles[0].OsType
        Assert-AreEqual $enableAutoScaling $cluster.AgentPoolProfiles[0].EnableAutoScaling

        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Length
        $cluster = $cluster | Set-AzAks -NodeName $nodeName -NodeMinCount 2 -NodeMaxCount 28 -KubernetesVersion $updatedKubeVersion
        Assert-AreEqual 2 $cluster.AgentPoolProfiles[0].MinCount
        Assert-AreEqual 28 $cluster.AgentPoolProfiles[0].MaxCount;
        Assert-AreEqual $updatedKubeVersion $cluster.KubernetesVersion
        $cluster | Import-AzAksCredential -Force
        $cluster | Remove-AzAks -Force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}
