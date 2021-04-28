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
    $nodeVmSize = "Standard_D2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location 'eastus'
        $credObject = $(createTestCredential "e65d50b0-0853-48a9-82d3-77d800f4a9bc" "V8-S-y6Er8jXy-.aM_WT95BF89N~X23lqb")

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ServicePrincipalIdAndSecret $credObject
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-NotNull $cluster.Fqdn
        Assert-NotNull $cluster.DnsPrefix
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Length
        Assert-AreEqual 3 $cluster.AgentPoolProfiles[0].Count;
        $cluster = $cluster | Set-AzAksCluster -NodeCount 2
        Assert-AreEqual 2 $cluster.AgentPoolProfiles[0].Count;
        $cluster | Import-AzAksCredential -Force
        $cluster | Remove-AzAksCluster -Force
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
    $nodeVmSize = "Standard_D2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        New-AzContainerRegistry -ResourceGroupName $resourceGroupName -Name $acrName -Sku Standard
                
        $cred = $(createTestCredential "e65d50b0-0853-48a9-82d3-77d800f4a9bc" "V8-S-y6Er8jXy-.aM_WT95BF89N~X23lqb")

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ServicePrincipalIdAndSecret $cred -AcrNameToAttach $acrName
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-NotNull $cluster.Fqdn
        Assert-NotNull $cluster.DnsPrefix
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Length
        Assert-AreEqual 3 $cluster.AgentPoolProfiles[0].Count;
        $cluster = $cluster | Set-AzAks -NodeCount 2
        Assert-AreEqual 2 $cluster.AgentPoolProfiles[0].Count;
        $cluster | Import-AzAksCredential -Force
        $cluster | Remove-AzAksCluster -Force
        $roleAssignment = Get-AzRoleAssignment -ResourceGroupName $resourceGroupName | Where-Object { ($_.RoleDefinitionName -eq 'AcrPull') -and ($_.DisplayName -eq $acrName) }
        Assert-NotNull $roleAssignment
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -AcrNameToDetach $acrName
        $roleAssignment = Get-AzRoleAssignment -ResourceGroupName $resourceGroupName | Where-Object { ($_.RoleDefinitionName -eq 'AcrPull') -and ($_.DisplayName -eq $acrName) }
        Assert-Null $roleAssignment
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -AcrNameToAttach $acrName
        $roleAssignment = Get-AzRoleAssignment -ResourceGroupName $resourceGroupName | Where-Object { ($_.RoleDefinitionName -eq 'AcrPull') -and ($_.DisplayName -eq $acrName) }
        Assert-NotNull $roleAssignment
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
    $location = "eastus"
    $kubeVersion = "1.18.10"
    $nodeVmSize = "Standard_D2_v2"
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
    $updatedKubeVersion = "1.18.14"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NetworkPlugin $networkPlugin `
            -KubernetesVersion $kubeVersion -EnableRbac -LoadBalancerSku $loadBalancerSku -LinuxProfileAdminUserName $linuxAdminUser -DnsNamePrefix $dnsNamePrefix `
            -NodeName $nodeName -EnableNodeAutoScaling -NodeCount $nodeCount -NodeOsDiskSize $nodeDiskSize -NodeVmSize $nodeVmSize `
            -NodeMaxCount $nodeMaxCount -NodeMinCount $nodeMinCount -NodeMaxPodCount $maxPodCount -NodeSetPriority Regular -NodeScaleSetEvictionPolicy Deallocate -NodeVmSetType VirtualMachineScaleSets

        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
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
        $cluster = $cluster | Set-AzAksCluster -NodeName $nodeName -NodeMinCount 2 -NodeMaxCount 28 -KubernetesVersion $updatedKubeVersion
        Assert-AreEqual 2 $cluster.AgentPoolProfiles[0].MinCount
        Assert-AreEqual 28 $cluster.AgentPoolProfiles[0].MaxCount;
        Assert-AreEqual $updatedKubeVersion $cluster.KubernetesVersion
        $cluster | Import-AzAksCredential -Force
        $cluster | Remove-AzAksCluster -Force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-NewAzAksByServicePrincipal
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = "eastus"

    $ServicePrincipalId = "e65d50b0-0853-48a9-82d3-77d800f4a9bc"
    $credObject = $(createTestCredential $ServicePrincipalId "V8-S-y6Er8jXy-.aM_WT95BF89N~X23lqb")

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName `
                -ServicePrincipalIdAndSecret $credObject
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual $ServicePrincipalId $cluster.ServicePrincipalProfile.ClientId

        $cluster | Import-AzAksCredential -Force
        $cluster | Remove-AzAksCluster -Force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-NewAzAksAddons
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = Get-ProviderLocation "Microsoft.ContainerService/managedClusters"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location 'eastus'

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -AddOnNameToBeEnabled KubeDashboard,HttpApplicationRouting
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual $true $cluster.AddonProfiles['httpapplicationrouting'].Enabled

        $cluster = $cluster | Disable-AzAksAddon -Name HttpApplicationRouting
        Assert-AreEqual $false $cluster.AddonProfiles['httpapplicationrouting'].Enabled
        $cluster = $cluster | Enable-AzAksAddon -Name HttpApplicationRouting
        Assert-AreEqual $true $cluster.AddonProfiles['httpapplicationrouting'].Enabled
        $cluster | Remove-AzAksCluster -Force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}


<#
.SYNOPSIS
Test Kubernetes stuff
#>
function Test-ResetAzureKubernetesServicePrincipal
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = Get-ProviderLocation "Microsoft.ContainerService/managedClusters"
    $nodeVmSize = "Standard_D2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location 'eastus'

        $credObject = $(createTestCredential "e65d50b0-0853-48a9-82d3-77d800f4a9bc" "75_4.yHJFjkKaRUUb535aH2d.ty4RG~uax")
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ServicePrincipalIdAndSecret $credObject
        
        $newCred = $(createTestCredential "6f277dd3-e481-4518-8aab-35c31662bad9" "XITofmnbbyU34uR_Yqx_4TI13OJ9--0C3m")
        Set-AzAksClusterCredential -ResourceGroupName $resourceGroupName -Name $kubeClusterName -ServicePrincipalIdAndSecret $newCred -force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}