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
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "6wx8Q~6JrPOhO3Ycfoqj7K1iReTHJYQjoQGUKc2~")

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-NotNull $cluster.Fqdn
        Assert-NotNull $cluster.DnsPrefix
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Length
        Assert-AreEqual 3 $cluster.AgentPoolProfiles[0].Count;
        Assert-NotNull $cluster.AgentPoolProfiles[0].NodeImageVersion

        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 3 $pools.Count
        Assert-NotNull $pools.NodeImageVersion

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
                
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "xSc8Q~kVbSNvv5aqTbbAnXLieQsc~ZlEw2GbtdrX")

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ServicePrincipalIdAndSecret $credObject -AcrNameToAttach $acrName
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
    $kubeVersion = "1.24.3"
    $nodeVmSize = "Standard_D2_v2"
    $maxPodCount = 25
    $nodeName = "defnode"
    $nodeCount = 2
    $nodeMinCount = 1
    $nodeMaxCount = 10
    $nodeDiskSize = 32
    $nodeVmSetType = "VirtualMachineScaleSets"
    $nodeOsType = "Linux"
    $enableAutoScaling = $true
    $enableRbac = $true
    $loadBalancerSku = "Standard"
    $linuxAdminUser = "linuxuser"
    $dnsNamePrefix = "mypre"
    $updatedKubeVersion = "1.24.3"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName `
            -KubernetesVersion $kubeVersion -EnableRbac -LoadBalancerSku $loadBalancerSku -LinuxProfileAdminUserName $linuxAdminUser -DnsNamePrefix $dnsNamePrefix `
            -NodeName $nodeName -EnableNodeAutoScaling -NodeCount $nodeCount -NodeOsDiskSize $nodeDiskSize -NodeVmSize $nodeVmSize `
            -NodeMaxCount $nodeMaxCount -NodeMinCount $nodeMinCount -NodeMaxPodCount $maxPodCount -NodeSetPriority Regular -NodeScaleSetEvictionPolicy Deallocate -NodeVmSetType VirtualMachineScaleSets
            
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-NotNull $cluster.Fqdn
        Assert-AreEqual $dnsNamePrefix $cluster.DnsPrefix
        Assert-AreEqual $kubeVersion $cluster.KubernetesVersion
        Assert-AreEqual $enableRbac $cluster.EnableRBAC
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
    $ServicePrincipalId = "a6148f60-19b8-49b8-a5a5-54945aec926e"
    $credObject = $(createTestCredential $ServicePrincipalId "xSc8Q~kVbSNvv5aqTbbAnXLieQsc~ZlEw2GbtdrX")

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

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -AddOnNameToBeEnabled HttpApplicationRouting
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
        
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "xSc8Q~kVbSNvv5aqTbbAnXLieQsc~ZlEw2GbtdrX")
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ServicePrincipalIdAndSecret $credObject
        
        $newCred = $(createTestCredential "aa0f0dd4-d00c-4a4f-8d22-1f5ea397a8b2" "Acc7Q~FB5apzrf4yHFar~PtiJzZ_c2y0xGhTC")
        Set-AzAksClusterCredential -ResourceGroupName $resourceGroupName -Name $kubeClusterName -ServicePrincipalIdAndSecret $newCred -force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-UpgradeKubernetesVersion
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = Get-ProviderLocation "Microsoft.ContainerService/managedClusters"
    $nodeVmSize = "Standard_D2_v2"
    $kubeVersion = "1.24.3"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location 'eastus'
        
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "xSc8Q~kVbSNvv5aqTbbAnXLieQsc~ZlEw2GbtdrX")
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ServicePrincipalIdAndSecret $credObject -NodeVmSetType VirtualMachineScaleSets
        #New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSetType VirtualMachineScaleSets
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -KubernetesVersion $kubeVersion -ControlPlaneOnly
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeImageOnly
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual $kubeVersion $cluster.KubernetesVersion
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-LoadBalancer
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "Standard_D2_v2"
    $loadBalancerManagedOutboundIpCount = 16

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "xSc8Q~kVbSNvv5aqTbbAnXLieQsc~ZlEw2GbtdrX")
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ServicePrincipalIdAndSecret $credObject `
                         -LoadBalancerAllocatedOutboundPort 24 -LoadBalancerSku standard -LoadBalancerManagedOutboundIpCount $loadBalancerManagedOutboundIpCount -LoadBalancerIdleTimeoutInMinute 40
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual $loadBalancerManagedOutboundIpCount $cluster.NetworkProfile.LoadBalancerProfile.EffectiveOutboundIPs.Count
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -LoadBalancerManagedOutboundIpCount 24
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 24 $cluster.NetworkProfile.LoadBalancerProfile.EffectiveOutboundIPs.Count
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-ApiServiceAccess
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $kubeClusterName2 = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "Standard_D2_v2"
    $loadBalancerManagedOutboundIpCount = 16

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "xSc8Q~kVbSNvv5aqTbbAnXLieQsc~ZlEw2GbtdrX")
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ServicePrincipalIdAndSecret $credObject `
                        -EnableApiServerAccessPrivateCluster
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual $true $cluster.ApiServerAccessProfile.EnablePrivateCluster
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName2 -NodeVmSize $nodeVmSize -ServicePrincipalIdAndSecret $credObject `
                        -ApiServerAccessAuthorizedIpRange "127.0.0.0/24"
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName2
        Assert-AreEqual "127.0.0.0/24" $cluster.ApiServerAccessProfile.AuthorizedIPRanges
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}



function Test-ManagedIdentity
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $userAssignedkubeClusterName = Get-RandomClusterName
    $systemAssignedkubeClusterName = Get-RandomClusterName
    $setUserAssignedkubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "Standard_D2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "xSc8Q~kVbSNvv5aqTbbAnXLieQsc~ZlEw2GbtdrX")
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $userAssignedkubeClusterName -ServicePrincipalIdAndSecret $credObject -EnableManagedIdentity -AssignIdentity '/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/yantest/providers/Microsoft.ManagedIdentity/userAssignedIdentities/yanMI'
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $userAssignedkubeClusterName
        Assert-NotNull $cluster.identity
        Assert-AreEqual 'UserAssigned' $cluster.identity.Type

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $setUserAssignedkubeClusterName -ServicePrincipalIdAndSecret $credObject  
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $setUserAssignedkubeClusterName
        Assert-Null $cluster.identity
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $setUserAssignedkubeClusterName -EnableManagedIdentity -AssignIdentity '/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/yantest/providers/Microsoft.ManagedIdentity/userAssignedIdentities/yanMI'
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $setUserAssignedkubeClusterName
        Assert-NotNull $cluster.identity
        Assert-AreEqual 'UserAssigned' $cluster.identity.Type
        
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $systemAssignedkubeClusterName -ServicePrincipalIdAndSecret $credObject -EnableManagedIdentity
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $systemAssignedkubeClusterName
        Assert-NotNull $cluster.identity
        Assert-AreEqual 'SystemAssigned' $cluster.identity.Type
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-OSSku
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "Standard_D2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -NodeOsSKU "CBLMariner"
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 'default' $cluster.AgentPoolProfiles.Name
        Assert-AreEqual 'Linux' $cluster.AgentPoolProfiles.OsType
        Assert-AreEqual 'CBLMariner' $cluster.AgentPoolProfiles.OsSKU

        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name "pool2" -OsType "Windows" -OsSKU "Windows2022" -Count 1 -VmSetType VirtualMachineScaleSets
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-AreEqualArray "Linux" ($pools | where {$_.Name -eq "default"}).OsType
        Assert-AreEqualArray "CBLMariner" ($pools | where {$_.Name -eq "default"}).OsSKU
        Assert-AreEqualArray "Windows" ($pools | where {$_.Name -eq "pool2"}).OsType
        Assert-AreEqualArray "Windows2022" ($pools | where {$_.Name -eq "pool2"}).OsSKU

        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-AreEqualArray "Linux" ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).OsType
        Assert-AreEqualArray "CBLMariner" ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).OsSKU
        Assert-AreEqualArray "Windows" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).OsType
        Assert-AreEqualArray "Windows2022" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).OsSKU

        $cluster | Remove-AzAksCluster -Force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-NodeLabels-Tags {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "Standard_D2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        # create aks cluster with default nodepool
        $labels1 = @{"someId" = 123; "app" = "test" }
        $tags1 = @{"dept"="IT"; "costcenter"=9999}
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -NodePoolLabel $labels1 -NodePoolTag $tags1
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-HashTableEquals $labels1 $cluster.AgentPoolProfiles[0].NodeLabels
        Assert-HashTableEquals $tags1 $cluster.AgentPoolProfiles[0].Tags
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count
        Assert-HashTableEquals $labels1 $pools[0].NodeLabels
        Assert-HashTableEquals $tags1 $pools[0].Tags

        # update aks cluster default nodepool
        $labels2 = @{"someId" = 124; "app" = "test"; "environment" = "dev" }
        $tags2 = @{"dept"="Finance"; "costcenter"=8888}
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodePoolLabel $labels2 -NodePoolTag $tags2
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-HashTableEquals $labels2 $cluster.AgentPoolProfiles[0].NodeLabels
        Assert-HashTableEquals $tags2 $cluster.AgentPoolProfiles[0].Tags
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count
        Assert-HashTableEquals $labels2 $pools[0].NodeLabels
        Assert-HashTableEquals $tags2 $pools[0].Tags

        # create a 2nd nodepool
        $labels3 = @{"someId" = 125; "tier" = "frontend" }
        $tags3 = @{"dept"="Finance"; "costcenter"=8888; "Admin"="Alice"}
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name "pool2" -Count 1 -NodeLabel $labels3 -Tag $tags3
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-HashTableEquals $labels2 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).NodeLabels
        Assert-HashTableEquals $tags2 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).Tags
        Assert-HashTableEquals $labels3 ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).NodeLabels
        Assert-HashTableEquals $tags3 ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).Tags
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-HashTableEquals $labels2 ($pools | where {$_.Name -eq "default"}).NodeLabels
        Assert-HashTableEquals $tags2 ($pools | where {$_.Name -eq "default"}).Tags
        Assert-HashTableEquals $labels3 ($pools | where {$_.Name -eq "pool2"}).NodeLabels
        Assert-HashTableEquals $tags3 ($pools | where {$_.Name -eq "pool2"}).Tags

        # update the 2nd nodepool
        $labels4 = @{"someId" = 126; "app" = "test"; "environment" = "qa" }
        $tags4 = @{"dept"="HR"; "costcenter"=6666; "Admin"="Bruce"}
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeName "pool2" -NodePoolLabel $labels4  -NodePoolTag $tags4
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-HashTableEquals $labels2 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).NodeLabels
        Assert-HashTableEquals $tags2 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).Tags
        Assert-HashTableEquals $labels4 ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).NodeLabels
        Assert-HashTableEquals $tags4 ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).Tags
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-HashTableEquals $labels2 ($pools | where {$_.Name -eq "default"}).NodeLabels
        Assert-HashTableEquals $tags2 ($pools | where {$_.Name -eq "default"}).Tags
        Assert-HashTableEquals $labels4 ($pools | where {$_.Name -eq "pool2"}).NodeLabels
        Assert-HashTableEquals $tags4 ($pools | where {$_.Name -eq "pool2"}).Tags

        # update the default nodepool
        $labels5 = @{"someId" = 127; "tier" = "frontend"; "environment" = "qa" }
        $tags5 = @{"dept"="MM"; "costcenter"=7777; "Admin"="Cindy"}
        Update-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name "default" -NodeLabel $labels5 -Tag $tags5
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-HashTableEquals $labels5 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).NodeLabels
        Assert-HashTableEquals $tags5 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).Tags
        Assert-HashTableEquals $labels4 ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).NodeLabels
        Assert-HashTableEquals $tags4 ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).Tags
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-HashTableEquals $labels5 ($pools | where {$_.Name -eq "default"}).NodeLabels
        Assert-HashTableEquals $tags5 ($pools | where {$_.Name -eq "default"}).Tags
        Assert-HashTableEquals $labels4 ($pools | where {$_.Name -eq "pool2"}).NodeLabels
        Assert-HashTableEquals $tags4 ($pools | where {$_.Name -eq "pool2"}).Tags

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-NodeTaints {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "Standard_D2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual 0 $cluster.AgentPoolProfiles[0].NodeTaints.Count
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count
        Assert-AreEqual 0 $pools.NodeTaints.Count

        # create a 2nd nodepool
        $nodetains = @("sku=gpu:NoSchedule")
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name "pool2" -Count 1 -NodeTaint $nodetains
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual 0 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).NodeTaints.Count
        Assert-AreEqualArray $nodetains ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).NodeTaints
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-AreEqual 0 ($pools | where {$_.Name -eq "default"}).NodeTaints.Count
        Assert-AreEqualArray $nodetains ($pools | where {$_.Name -eq "pool2"}).NodeTaints

        # update the 2nd nodepool
        $nodetains2 = @("CriticalAddonsOnly=true:NoSchedule")
        Update-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name "pool2" -NodeTaint $nodetains2
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual 0 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).NodeTaints.Count
        Assert-AreEqualArray $nodetains2 ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).NodeTaints
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-AreEqual 0 ($pools | where {$_.Name -eq "default"}).NodeTaints.Count
        Assert-AreEqualArray $nodetains2 ($pools | where {$_.Name -eq "pool2"}).NodeTaints

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-EnableEncryptionAtHost {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    # not all vmSize support EnableEncryptionAtHost. For more information, see: https://docs.microsoft.com/azure/aks/enable-host-encryption 
    $nodeVmSize = "Standard_D2_v5"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -EnableEncryptionAtHost
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-True {$cluster.AgentPoolProfiles[0].EnableEncryptionAtHost}
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count
        Assert-True {$pools[0].EnableEncryptionAtHost}

        # create a 2nd nodepool
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name "pool2" -VmSize $nodeVmSize -Count 1 -EnableEncryptionAtHost
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-True {$cluster.AgentPoolProfiles[0].EnableEncryptionAtHost}
        Assert-True {$cluster.AgentPoolProfiles[1].EnableEncryptionAtHost}
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-True {$pools[0].EnableEncryptionAtHost}
        Assert-True {$pools[1].EnableEncryptionAtHost}

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-EnableUltraSSD {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    # not all vmSize support EnableEncryptionAtHost. For more information, see: https://learn.microsoft.com/en-us/azure/virtual-machines/disks-enable-ultra-ssd?tabs=azure-portal
    $nodeVmSize = "Standard_D2_v5"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -AvailabilityZone @(1,2, 3)  -EnableUltraSSD
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-True {$cluster.AgentPoolProfiles[0].EnableUltraSSD}
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count
        Assert-True {$pools[0].EnableUltraSSD}

        # create a 2nd nodepool
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSize $nodeVmSize -Count 1 -AvailabilityZone @(1,2, 3) -EnableUltraSSD
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-True {$cluster.AgentPoolProfiles[0].EnableUltraSSD}
        Assert-True {$cluster.AgentPoolProfiles[1].EnableUltraSSD}
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-True {$pools[0].EnableUltraSSD}
        Assert-True {$pools[1].EnableUltraSSD}

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-LinuxOSConfig {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "Standard_D2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        # create aks cluster with default nodepool
       $linuxOsConfigJsonStr = @'
            {
             "transparentHugePageEnabled": "madvise",
             "transparentHugePageDefrag": "defer+madvise",
             "swapFileSizeMB": 1500,
             "sysctls": {
              "netCoreSomaxconn": 163849,
              "netIpv4TcpTwReuse": true,
              "netIpv4IpLocalPortRange": "32000 60000"
             }
            }
'@
        $linuxOsConfig = [Microsoft.Azure.Management.ContainerService.Models.LinuxOSConfig] ($linuxOsConfigJsonStr | ConvertFrom-Json)
        $kubeletConfigStr = @'
            {
             "failSwapOn": false
            }
'@
        $kubeletConfig = [Microsoft.Azure.Management.ContainerService.Models.KubeletConfig] ($kubeletConfigStr | ConvertFrom-Json)

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -NodeLinuxOSConfig $linuxOsConfig -NodeKubeletConfig $kubeletConfig
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-ObjectEquals $linuxOsConfig $cluster.AgentPoolProfiles[0].LinuxOSConfig
        Assert-ObjectEquals $kubeletConfig $cluster.AgentPoolProfiles[0].KubeletConfig
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count
        Assert-ObjectEquals $linuxOsConfig $pools[0].LinuxOSConfig
        Assert-ObjectEquals $kubeletConfig $pools[0].KubeletConfig

        # create a 2nd nodepool
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSize $nodeVmSize -Count 1 -LinuxOSConfig $cluster.AgentPoolProfiles[0].LinuxOSConfig -KubeletConfig $cluster.AgentPoolProfiles[0].KubeletConfig
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-ObjectEquals $linuxOsConfig $cluster.AgentPoolProfiles[0].LinuxOSConfig
        Assert-ObjectEquals $kubeletConfig $cluster.AgentPoolProfiles[0].KubeletConfig
        Assert-ObjectEquals $linuxOsConfig $cluster.AgentPoolProfiles[1].LinuxOSConfig
        Assert-ObjectEquals $kubeletConfig $cluster.AgentPoolProfiles[1].KubeletConfig
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-ObjectEquals $linuxOsConfig $pools[0].LinuxOSConfig
        Assert-ObjectEquals $kubeletConfig $pools[0].KubeletConfig
        Assert-ObjectEquals $linuxOsConfig $pools[1].LinuxOSConfig
        Assert-ObjectEquals $kubeletConfig $pools[1].KubeletConfig

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-MaxSurge {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "Standard_D2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -NodeMaxSurge 1
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual 1 $cluster.AgentPoolProfiles[0].UpgradeSettings.MaxSurge
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count
        Assert-AreEqual 1 $pools[0].UpgradeSettings.MaxSurge

        # create a 2nd nodepool
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSize $nodeVmSize -Count 1 -MaxSurge "50%"
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual 1 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).UpgradeSettings.MaxSurge
        Assert-AreEqual "50%" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).UpgradeSettings.MaxSurge
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-AreEqual 1 ($pools | where {$_.Name -eq "default"}).UpgradeSettings.MaxSurge
        Assert-AreEqual "50%" ($pools | where {$_.Name -eq "pool2"}).UpgradeSettings.MaxSurge

        # update the 2nd nodepool
        Update-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -MaxSurge "100%"
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual 1 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).UpgradeSettings.MaxSurge
        Assert-AreEqual "100%" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).UpgradeSettings.MaxSurge
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-AreEqual 1 ($pools | where {$_.Name -eq "default"}).UpgradeSettings.MaxSurge
        Assert-AreEqual "100%" ($pools | where {$_.Name -eq "pool2"}).UpgradeSettings.MaxSurge

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-PPG {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "Standard_D2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        #$ppg = New-AzProximityPlacementGroup -Location $location -Name "test_ppg" -ResourceGroupName $resourceGroupName -ProximityPlacementGroupType Standard
        #$ppgId = $ppg.Id
        $ppgId = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/rgps5787/providers/Microsoft.Compute/proximityPlacementGroups/test_ppg"
        
        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -PPG $ppgId
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual $ppgId $cluster.AgentPoolProfiles[0].ProximityPlacementGroupID
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count
        Assert-AreEqual $ppgId $pools[0].ProximityPlacementGroupID

        # create a 2nd nodepool
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSize $nodeVmSize -Count 1 -PPG $ppgId
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual $ppgId $cluster.AgentPoolProfiles[0].ProximityPlacementGroupID
        Assert-AreEqual $ppgId $cluster.AgentPoolProfiles[1].ProximityPlacementGroupID
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-AreEqual $ppgId $pools[0].ProximityPlacementGroupID
        Assert-AreEqual $ppgId $pools[1].ProximityPlacementGroupID

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-Spot {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "Standard_D2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1

        # create a 2nd nodepool
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSize $nodeVmSize -Count 1 -ScaleSetPriority Spot -SpotMaxPrice 0.577
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual "Spot" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).scaleSetPriority
        Assert-AreEqual "Delete" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).scaleSetEvictionPolicy
        Assert-AreEqual 0.57699 ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).spotMaxPrice
        Assert-AreEqual "spot" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).nodeLabels["kubernetes.azure.com/scalesetpriority"]
        Assert-AreEqual 1 ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).nodeTaints.Count
        Assert-AreEqual "kubernetes.azure.com/scalesetpriority=spot:NoSchedule" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).nodeTaints[0]
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-AreEqual "Spot" ($pools | where {$_.Name -eq "pool2"}).scaleSetPriority
        Assert-AreEqual "Delete" ($pools | where {$_.Name -eq "pool2"}).scaleSetEvictionPolicy
        Assert-AreEqual 0.57699 ($pools | where {$_.Name -eq "pool2"}).spotMaxPrice
        Assert-AreEqual "spot" ($pools | where {$_.Name -eq "pool2"}).nodeLabels["kubernetes.azure.com/scalesetpriority"]
        Assert-AreEqual 1 ($pools | where {$_.Name -eq "pool2"}).nodeTaints.Count
        Assert-AreEqual "kubernetes.azure.com/scalesetpriority=spot:NoSchedule" ($pools | where {$_.Name -eq "pool2"}).nodeTaints[0]

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}