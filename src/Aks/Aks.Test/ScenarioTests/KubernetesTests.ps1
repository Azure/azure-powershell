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
    $nodeVmSize = "standard_a2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location 'eastus'

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
    $nodeVmSize = "standard_a2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        New-AzContainerRegistry -ResourceGroupName $resourceGroupName -Name $acrName -Sku Standard
                
        $credObject = $(createTestCredential "8184c03b-75cb-4c66-8686-8c171ab2f522" "Sanitized")

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
    $kubeVersion = "1.32.7"
    $nodeVmSize = "standard_a2_v2"
    $maxPodCount = 30
    $nodeName = "defnode"
    $nodeCount = 3
    $nodeMinCount = 2
    $nodeMaxCount = 10
    $nodeDiskSize = 32
    $nodeVmSetType = "VirtualMachineScaleSets"
    $nodeOsType = "Linux"
    $enableAutoScaling = $true
    $enableRbac = $true
    $loadBalancerSku = "Standard"
    $linuxAdminUser = "linuxuser"
    $dnsNamePrefix = "mypre"
    $updatedKubeVersion = "1.32.7"

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
    $nodeVmSize = "standard_a2_v2"
    $ServicePrincipalId = "8184c03b-75cb-4c66-8686-8c171ab2f522"
    $credObject = $(createTestCredential $ServicePrincipalId "Sanitized")

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize `
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
    $nodeVmSize = "standard_a2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location 'eastus'

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -AddOnNameToBeEnabled AzurePolicy -NodeVmSize $nodeVmSize
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual $true $cluster.AddonProfiles['azurepolicy'].Enabled

        $cluster = $cluster | Disable-AzAksAddon -Name AzurePolicy
        Assert-AreEqual $false $cluster.AddonProfiles['azurepolicy'].Enabled
        $cluster = $cluster | Enable-AzAksAddon -Name AzurePolicy
        Assert-AreEqual $true $cluster.AddonProfiles['azurepolicy'].Enabled
        $cluster | Remove-AzAksCluster -Force
    }
    finally
    {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-EnableAndDisableAzAksAddons
{
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $kubeClusterName2 = Get-RandomClusterName
    $nodeVmSize = "standard_a2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location 'eastus'

        $cluster = New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize
        Assert-Null $cluster.AddonProfiles

        $cluster = $cluster | Enable-AzAksAddon -Name AzurePolicy
        Assert-AreEqual $true $cluster.AddonProfiles['azurepolicy'].Enabled
        $cluster = $cluster | Disable-AzAksAddon -Name AzurePolicy
        Assert-AreEqual $false $cluster.AddonProfiles['azurepolicy'].Enabled

        $cluster2 = New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName2 -NodeVmSize $nodeVmSize
        Assert-Null $cluster2.AddonProfiles
        #$workspace = New-AzOperationalInsightsWorkspace -Location $location -Name 'akstestws' -ResourceGroupName $resourceGroupName
        #$workspaceId = $workspace.ResourceId
        $workspaceId = '/subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.OperationalInsights/workspaces/akstestws'

        $cluster2 = Enable-AzAksAddon -Name 'Monitoring' -WorkspaceResourceId $workspaceId -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName2
        Assert-AreEqual $true $cluster2.AddonProfiles['omsagent'].Enabled
        $cluster2 = Disable-AzAksAddon -Name 'Monitoring' -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName2
        Assert-AreEqual $false $cluster2.AddonProfiles['omsagent'].Enabled
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
    $nodeVmSize = "standard_a2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location 'eastus'
        
        $credObject = $(createTestCredential "8184c03b-75cb-4c66-8686-8c171ab2f522" "Sanitized")
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ServicePrincipalIdAndSecret $credObject
        
        $newCred = $(createTestCredential "aa0f0dd4-d00c-4a4f-8d22-1f5ea397a8b2" "Sanitized")
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
    $nodeVmSize = "standard_a2_v2"
    $kubeVersion = "1.32.7"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location 'eastus'
        
        $credObject = $(createTestCredential "8184c03b-75cb-4c66-8686-8c171ab2f522" "Sanitized")
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
    $nodeVmSize = "standard_a2_v2"
    $loadBalancerManagedOutboundIpCount = 4

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        $credObject = $(createTestCredential "8184c03b-75cb-4c66-8686-8c171ab2f522" "Sanitized")
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -ServicePrincipalIdAndSecret $credObject `
                         -LoadBalancerAllocatedOutboundPort 24 -LoadBalancerSku standard -LoadBalancerManagedOutboundIpCount $loadBalancerManagedOutboundIpCount -LoadBalancerIdleTimeoutInMinute 40
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual $loadBalancerManagedOutboundIpCount $cluster.NetworkProfile.LoadBalancerProfile.EffectiveOutboundIPs.Count

        $loadBalancerManagedOutboundIpCount = 8
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -LoadBalancerManagedOutboundIpCount $loadBalancerManagedOutboundIpCount
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual $loadBalancerManagedOutboundIpCount $cluster.NetworkProfile.LoadBalancerProfile.EffectiveOutboundIPs.Count
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
    $nodeVmSize = "standard_a2_v2"
    $loadBalancerManagedOutboundIpCount = 16

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        $credObject = $(createTestCredential "8184c03b-75cb-4c66-8686-8c171ab2f522" "Sanitized")
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
    $nodeVmSize = "standard_a2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        # prepare UserAssignedIdentity
        #$resourceGroupName='AKS_TEST_RG'
        #$identityName='aks_test_mi'
        #$location='eastus'
        #$identity = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupName -Name $identityName -Location $location
        #$identityId = $identity.Id
        $identityId = '/subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourcegroups/AKS_TEST_RG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/aks_test_mi'
        
        $credObject = $(createTestCredential "8184c03b-75cb-4c66-8686-8c171ab2f522" "Sanitized")
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $userAssignedkubeClusterName -ServicePrincipalIdAndSecret $credObject -EnableManagedIdentity -AssignIdentity $identityId -NodeVmSize $nodeVmSize
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $userAssignedkubeClusterName
        Assert-NotNull $cluster.identity
        Assert-AreEqual 'UserAssigned' $cluster.identity.Type

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $setUserAssignedkubeClusterName -ServicePrincipalIdAndSecret $credObject -NodeVmSize $nodeVmSize
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $setUserAssignedkubeClusterName
        Assert-Null $cluster.identity
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $setUserAssignedkubeClusterName -EnableManagedIdentity -AssignIdentity $identityId
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $setUserAssignedkubeClusterName
        Assert-NotNull $cluster.identity
        Assert-AreEqual 'UserAssigned' $cluster.identity.Type
        
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $systemAssignedkubeClusterName -ServicePrincipalIdAndSecret $credObject -EnableManagedIdentity -NodeVmSize $nodeVmSize
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
    $nodeVmSize = "standard_a2_v2"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -NodeOsSKU "Mariner"
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 'default' $cluster.AgentPoolProfiles.Name
        Assert-AreEqual 'Linux' $cluster.AgentPoolProfiles.OsType
        Assert-AreEqual 'Mariner' $cluster.AgentPoolProfiles.OsSKU

        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name "pool2" -OsType "Windows" -OsSKU "Windows2022" -Count 1 -VmSetType VirtualMachineScaleSets
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-AreEqualArray "Linux" ($pools | where {$_.Name -eq "default"}).OsType
        Assert-AreEqualArray "Mariner" ($pools | where {$_.Name -eq "default"}).OsSKU
        Assert-AreEqualArray "Windows" ($pools | where {$_.Name -eq "pool2"}).OsType
        Assert-AreEqualArray "Windows2022" ($pools | where {$_.Name -eq "pool2"}).OsSKU

        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-AreEqualArray "Linux" ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).OsType
        Assert-AreEqualArray "Mariner" ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).OsSKU
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
    $nodeVmSize = "standard_a2_v2"

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
    $nodeVmSize = "standard_a2_v2"

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
    # not all vmSize support EnableEncryptionAtHost. For more information, see: https://learn.microsoft.com/azure/aks/enable-host-encryption 
    $nodeVmSize = "Standard_D2s_v3"

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
    $location = 'southeastasia'
    # not all vmSize support EnableEncryptionAtHost. For more information, see: https://learn.microsoft.com/en-us/azure/virtual-machines/disks-enable-ultra-ssd?tabs=azure-portal
    $nodeVmSize = "Standard_D2as_v4"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -AvailabilityZone @(1,3)  -EnableUltraSSD -Location $location
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-True {$cluster.AgentPoolProfiles[0].EnableUltraSSD}
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count
        Assert-True {$pools[0].EnableUltraSSD}

        # create a 2nd nodepool
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSize $nodeVmSize -Count 1 -AvailabilityZone @(1,3) -EnableUltraSSD
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
    $nodeVmSize = "standard_a2_v2"

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
    $nodeVmSize = "standard_a2_v2"

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
    $nodeVmSize = "standard_a2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        # prepare PPG
        #$ppg = New-AzProximityPlacementGroup -Location $location -Name "test_ppg" -ResourceGroupName $resourceGroupName -ProximityPlacementGroupType Standard
        #$ppgId = $ppg.Id

        $ppgId = "/subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.Compute/proximityPlacementGroups/test_ppg"
        
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
    $nodeVmSize = "standard_a2_v2"

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

function Test-EnableFIPS {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "standard_a2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -EnableFIPS
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-True {$cluster.AgentPoolProfiles[0].EnableFIPS}
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count
        Assert-True {$pools[0].EnableFIPS}

        # create a 2nd nodepool
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSize $nodeVmSize -Count 1 -EnableFIPS
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-True {$cluster.AgentPoolProfiles[0].EnableFIPS}
        Assert-True {$cluster.AgentPoolProfiles[1].EnableFIPS}
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-True {$pools[0].EnableFIPS}
        Assert-True {$pools[1].EnableFIPS}

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-AutoScalerProfile {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "standard_a2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        # create aks cluster with default nodepool
        $aksParameters=@{
	        ResourceGroupName = $resourceGroupName
	        Name = $kubeClusterName
	        NodeVmSize = $nodeVmSize
	        NodeMinCount = 1
	        NodeMaxCount = 3
        }
        $AutoScalerProfile=@{
            ScanInterval="30s"
            Expander="least-waste"
            MaxTotalUnreadyPercentage="50"
            NewPodScaleUpDelay="800s"
        }
        $AutoScalerProfile=[Microsoft.Azure.Management.ContainerService.Models.ManagedClusterPropertiesAutoScalerProfile]$AutoScalerProfile
        New-AzAksCluster @aksParameters -EnableNodeAutoScaling -AutoScalerProfile $AutoScalerProfile
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual "30s" $cluster.AutoScalerProfile.ScanInterval
        Assert-AreEqual "least-waste" $cluster.AutoScalerProfile.Expander
        Assert-AreEqual "50" $cluster.AutoScalerProfile.MaxTotalUnreadyPercentage
        Assert-AreEqual "800s" $cluster.AutoScalerProfile.NewPodScaleUpDelay

        # update aks cluster
        $AutoScalerProfile2=@{
            ScanInterval="40s"
            Expander="most-pods"
            MaxTotalUnreadyPercentage="45"
            NewPodScaleUpDelay="600s"
        }
        $AutoScalerProfile2=[Microsoft.Azure.Management.ContainerService.Models.ManagedClusterPropertiesAutoScalerProfile]$AutoScalerProfile2
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -AutoScalerProfile $AutoScalerProfile2
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual "40s" $cluster.AutoScalerProfile.ScanInterval
        Assert-AreEqual "most-pods" $cluster.AutoScalerProfile.Expander
        Assert-AreEqual "45" $cluster.AutoScalerProfile.MaxTotalUnreadyPercentage
        Assert-AreEqual "600s" $cluster.AutoScalerProfile.NewPodScaleUpDelay

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-GpuInstanceProfile {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "standard_nd92is_h100_v5"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -GpuInstanceProfile MIG1g
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual "MIG1g" $cluster.AgentPoolProfiles[0].GpuInstanceProfile
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count
        Assert-AreEqual "MIG1g" $pools[0].GpuInstanceProfile

        # create a 2nd nodepool
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSize $nodeVmSize -Count 1 -GpuInstanceProfile MIG3g
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual "MIG1g" ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).GpuInstanceProfile
        Assert-AreEqual "MIG3g" ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).GpuInstanceProfile
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-AreEqual "MIG1g" ($pools | where {$_.Name -eq "default"}).GpuInstanceProfile
        Assert-AreEqual "MIG3g" ($pools | where {$_.Name -eq "pool2"}).GpuInstanceProfile

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-EnableUptimeSLA {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeCount 1 -EnableUptimeSLA
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual "Base" $cluster.Sku.Name
        Assert-AreEqual "Standard" $cluster.Sku.Tier

        # update the aks cluster
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -EnableUptimeSLA:$false
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual "Base" $cluster.Sku.Name
        Assert-AreEqual "Free" $cluster.Sku.Tier

        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -EnableUptimeSLA
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual "Base" $cluster.Sku.Name
        Assert-AreEqual "Standard" $cluster.Sku.Tier

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-EdgeZone {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "standard_a2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeCount 1 -EdgeZone 'microsoftnewyork1' -Location $location -NodeVmSize $nodeVmSize
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -Location $location
        Assert-AreEqual "microsoftnewyork1" $cluster.ExtendedLocation.Name
        Assert-AreEqual "edgezone" $cluster.ExtendedLocation.Type

        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-AadProfile {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    #$AdGroupName = 'TestAksGroup'

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        #New-AzADGroup -DisplayName $AdGroupName -MailNickname $AdGroupName
        #$adGroup = Get-AzADGroup -DisplayName $AdGroupName
        #$adGroupId = $adGroup.Id
        $adGroupId = 'b3fc4683-180a-4e39-a60d-4291707f1db9'
        $AadProfile=@{
            managed=$true
            enableAzureRBAC=$false
            adminGroupObjectIDs=[System.Collections.Generic.List[string]]@($adGroupId)
        }
        $AadProfile=[Microsoft.Azure.Management.ContainerService.Models.ManagedClusterAADProfile]$AadProfile

        # create aks cluster with AadProfile
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeCount 1 -AadProfile $AadProfile -DisableLocalAccount
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-ObjectEquals $AadProfile.managed $cluster.AadProfile.managed
        Assert-ObjectEquals $AadProfile.enableAzureRBAC $cluster.AadProfile.enableAzureRBAC
        Assert-ObjectEquals $AadProfile.adminGroupObjectIDs $cluster.AadProfile.adminGroupObjectIDs
        Assert-ObjectEquals '213e87ed-8e08-4eb4-a63c-c073058f7b00' $cluster.AadProfile.TenantID
        Assert-ObjectEquals $true $cluster.DisableLocalAccounts
        $cluster = $cluster | Set-AzAksCluster -DisableLocalAccount:$false
        Assert-ObjectEquals $false $cluster.DisableLocalAccounts
        $cluster | Remove-AzAksCluster -Force

        # create aks cluster without AadProfile
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeCount 1
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-Null $cluster.AadProfile
        Assert-Null $cluster.DisableLocalAccounts
        # update the aks cluster with AadProfile
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -AadProfile $AadProfile
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-ObjectEquals $AadProfile.managed $cluster.AadProfile.managed
        #Assert-ObjectEquals $AadProfile.enableAzureRBAC $cluster.AadProfile.enableAzureRBAC
        Assert-ObjectEquals "" $cluster.AadProfile.enableAzureRBAC
        Assert-ObjectEquals $AadProfile.adminGroupObjectIDs $cluster.AadProfile.adminGroupObjectIDs
        Assert-ObjectEquals '213e87ed-8e08-4eb4-a63c-c073058f7b00' $cluster.AadProfile.TenantID
        Assert-Null $cluster.DisableLocalAccounts
        $cluster = $cluster | Set-AzAksCluster -DisableLocalAccount
        Assert-ObjectEquals $true $cluster.DisableLocalAccounts
        $cluster | Remove-AzAksCluster -Force
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
        #Remove-AzADGroup -DisplayName $AdGroupName
    }
}

function Test-HostGroupID {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        #prepare a Dedicated Host and a user-assigned Identity

        #$resourceGroupName='AKS_TEST_RG'
        #$hostGroupName='aks_test_hostgroup'
        #$location='eastus'
        #$hostName='aks_test_host'
        #$identityName='aks_test_mi'

        #New-AzResourceGroup -Name $resourceGroupName -Location $location

        #$hostGroup = New-AzHostGroup -ResourceGroupName $resourceGroupName -Name $hostGroupName -Location $location -PlatformFaultDomain 1 -SupportAutomaticPlacement $true
        #$hostSku = (Get-AzComputeResourceSku -Location $location | where ResourceType -eq "hostGroups/hosts")[0].Name 
        #New-AzHost -ResourceGroupName $resourceGroupName -HostGroupName $hostGroupName -Name $hostName -Location $location -Sku DSv3-Type1
        #$azHost = Get-AzHost -ResourceGroupName $resourceGroupName -HostGroupName $hostGroupName -Name $hostName -InstanceView
        #$nodeVmSize = ($azHost.InstanceView.AvailableCapacity.AllocatableVMs | Sort-Object -Property Count -Descending)[0].VmSize

        #$identity = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupName -Name $identityName -Location $location
        #$roleAssignment = New-AzRoleAssignment -ObjectId $identity.PrincipalId -RoleDefinitionName Contributor -Scope $hostGroup.Id

        #$hostGroupId = $hostGroup.Id
        #$identityId = $identity.Id

        $hostGroupId = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/AKS_TEST_RG/providers/Microsoft.Compute/hostGroups/aks_test_hostgroup"
        $identityId = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/AKS_TEST_RG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/aks_test_mi"
        $nodeVmSize = "Standard_D2s_v3"

        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -NodeHostGroupID $hostGroupId -EnableManagedIdentity -AssignIdentity $identityId
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual $hostGroupId $cluster.AgentPoolProfiles[0].hostGroupID
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual $hostGroupId $pools[0].hostGroupID

        # create the 2nd nodepool
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSize $nodeVmSize -Count 1 -HostGroupID $hostGroupId
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual $hostGroupId $cluster.AgentPoolProfiles[0].hostGroupID
        Assert-AreEqual $hostGroupId $cluster.AgentPoolProfiles[1].hostGroupID
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual $hostGroupId $pools[0].hostGroupID
        Assert-AreEqual $hostGroupId $pools[1].hostGroupID
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-PodSubnetID {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "standard_a2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        # prepare subnets
        #$resourceGroupName='AKS_TEST_RG'
        #$location='eastus'
        #
        #New-AzResourceGroup -Name $resourceGroupName -Location $location
        #
        #$subnet1 = New-AzVirtualNetworkSubnetConfig -Name "subnet1" -AddressPrefix "10.0.1.0/24"
        #$subnet2  = New-AzVirtualNetworkSubnetConfig -Name "subnet2" -AddressPrefix "10.0.2.0/24"
        #$subnet3  = New-AzVirtualNetworkSubnetConfig -Name "subnet3" -AddressPrefix "10.0.3.0/24"
        #$virtualNetwork = New-AzVirtualNetwork -Name "test_vn" -ResourceGroupName $resourceGroupName -Location $location -AddressPrefix "10.0.0.0/16" -Subnet $subnet1,$subnet2,$subnet3
        #
        #$subnetID1 = $virtualNetwork.Subnets[0].Id
        #$subnetID2 = $virtualNetwork.Subnets[1].Id
        #$subnetID3 = $virtualNetwork.Subnets[2].Id

        $subnetID1 = '/subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.Network/virtualNetworks/test_vn/subnets/subnet1'
        $subnetID2 = '/subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.Network/virtualNetworks/test_vn/subnets/subnet2'
        $subnetID3 = '/subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.Network/virtualNetworks/test_vn/subnets/subnet3'

        # create aks cluster with default nodepool
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -NodePodSubnetID $subnetID1 -NodeVnetSubnetID $subnetID2 -ServiceCidr "10.20.30.0/24" -DnsServiceIP "10.20.30.10"
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 1 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual $subnetID1 $cluster.AgentPoolProfiles[0].PodSubnetID
        Assert-AreEqual $subnetID2 $cluster.AgentPoolProfiles[0].VnetSubnetID
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 1 $pools.Count

        Assert-AreEqual $subnetID1 $pools[0].PodSubnetID
        Assert-AreEqual $subnetID2 $pools[0].VnetSubnetID

        # create a 2nd nodepool
        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSize $nodeVmSize -Count 1 -PodSubnetID $subnetID3
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
        Assert-AreEqual $subnetID1 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).PodSubnetID
        Assert-AreEqual $subnetID2 ($cluster.AgentPoolProfiles | where {$_.Name -eq "default"}).VnetSubnetID
        Assert-AreEqual $subnetID3 ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).PodSubnetID
        Assert-AreEqual $subnetID2 ($cluster.AgentPoolProfiles | where {$_.Name -eq "pool2"}).VnetSubnetID
        $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
        Assert-AreEqual 2 $pools.Count
        Assert-AreEqual $subnetID1 ($pools | where {$_.Name -eq "default"}).PodSubnetID
        Assert-AreEqual $subnetID2 ($pools | where {$_.Name -eq "default"}).VnetSubnetID
        Assert-AreEqual $subnetID3 ($pools | where {$_.Name -eq "pool2"}).PodSubnetID
        Assert-AreEqual $subnetID2 ($pools | where {$_.Name -eq "pool2"}).VnetSubnetID
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-EnableOidcIssuer {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName1 = Get-RandomClusterName
    $kubeClusterName2 = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "standard_a2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName1 -NodeVmSize $nodeVmSize -NodeCount 1 -EnableOidcIssuer
        $cluster1 = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName1
        Assert-True {$cluster1.OidcIssuerProfile.Enabled}
        Assert-True {$cluster1.OidcIssuerProfile.IssuerURL.StartsWith("https://eastus.oic.prod-aks.azure.com")}
        
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName2 -NodeCount 1
        $cluster2 = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName2
        Assert-False {$cluster2.OidcIssuerProfile.Enabled}
        Assert-Null $cluster2.OidcIssuerProfile.IssuerURL
        
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName2 -EnableOidcIssuer
        $cluster2 = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName2
        Assert-True {$cluster2.OidcIssuerProfile.Enabled}
        Assert-True {$cluster2.OidcIssuerProfile.IssuerURL.StartsWith("https://eastus.oic.prod-aks.azure.com")}

    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-OutboundType {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'
    $nodeVmSize = "standard_a2_v2"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -OutboundType managedNATGateway
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 'managedNATGateway' $cluster.NetworkProfile.OutboundType
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-EnableAHUB {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        $SecurePassword = ConvertTo-SecureString 'Sanitized@Sanitized' -AsPlainText -Force
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeCount 1 -WindowsProfileAdminUserName azure -WindowsProfileAdminUserPassword $SecurePassword -EnableAHUB
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-AreEqual 'Windows_Server' $cluster.WindowsProfile.LicenseType
        $cluster = Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -EnableAHUB:$false
        Assert-AreEqual 'None' $cluster.WindowsProfile.LicenseType

        
        $kubeClusterName = Get-RandomClusterName
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeCount 1
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
        Assert-Null $cluster.WindowsProfile.LicenseType
        $cluster = $cluster | Set-AzAksCluster -EnableAHUB
        Assert-AreEqual 'Windows_Server' $cluster.WindowsProfile.LicenseType
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-API20250801-WithoutMSI {
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'

    $nodeVmSize = "standard_d4_v4"
    $nodeMessageOfTheDay = [Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes("Welcome to AKS Cluster"))
    $NodeTaint = @("CriticalAddonsOnly=true:NoSchedule")

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -Location $location -NodeMessageOfTheDay $nodeMessageOfTheDay -NodeTaint $NodeTaint -NodeOSDiskType Managed -NodePodIPAllocationMode DynamicIndividual -NodeEnableSecureBoot -NodeEnableVtpm -NodeSshAccess Disabled -DisableApiServerRunCommand -EnableApiServerVnetIntegration -NodeOSAutoUpgradeChannel SecurityPatch -BootstrapArtifactSource Direct -EnableAdvancedNetworking -EnableAdvancedNetworkingObservability -AdvancedNetworkingSecurityPolicy None -IPFamily IPv4 -LoadBalancerBackendPoolType NodeIP -LoadBalancerManagedOutboundIpCountIPv6 0 -LoadBalancerManagedOutboundIpCount 11 -NATGatewayIdleTimeoutInMinute 22 -NATGatewayManagedOutboundIpCount 12 -NetworkDataplane azure -NetworkPluginMode overlay -EnableStaticEgressGateway -NodeProvisioningDefaultPool Auto -NodeProvisioningMode Manual -NodeResourceGroupRestrictionLevel Unrestricted -EnablePublicNetworkAccess -EnableImageCleaner -ImageCleanerIntervalHour 36 -EnableWorkloadIdentity -EnableOidcIssuer -SupportPlan KubernetesOfficial -EnableKEDA -EnableVerticalPodAutoscaler

        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName

        Assert-AreEqual $cluster.AgentPoolProfiles[0].MessageOfTheDay $nodeMessageOfTheDay 
        Assert-AreEqual $cluster.AgentPoolProfiles[0].NodeTaints $NodeTaint 
        Assert-AreEqual $cluster.AgentPoolProfiles[0].OsDiskType Managed 
        Assert-AreEqual $cluster.AgentPoolProfiles[0].PodIPAllocationMode DynamicIndividual 
        Assert-AreEqual $cluster.AgentPoolProfiles[0].SecurityProfile.EnableSecureBoot $true 
        Assert-AreEqual $cluster.AgentPoolProfiles[0].SecurityProfile.EnableVtpm $true 
        Assert-AreEqual $cluster.AgentPoolProfiles[0].SecurityProfile.SshAccess Disabled 
        Assert-AreEqual $cluster.ApiServerAccessProfile.DisableRunCommand $true
        Assert-AreEqual $cluster.ApiServerAccessProfile.EnableVnetIntegration $true
        Assert-AreEqual $cluster.AutoUpgradeProfile.NodeOSUpgradeChannel SecurityPatch
        Assert-AreEqual $cluster.BootstrapProfile.ArtifactSource Direct
        Assert-AreEqual $cluster.NetworkProfile.AdvancedNetworking.Enabled $true
        Assert-AreEqual $cluster.NetworkProfile.AdvancedNetworking.Observability.Enabled $true
        Assert-AreEqual $cluster.NetworkProfile.AdvancedNetworking.Security.Enabled $false
        Assert-AreEqual $cluster.NetworkProfile.AdvancedNetworking.Security.AdvancedNetworkPolicies None
        Assert-AreEqual $cluster.NetworkProfile.IpFamilies[0] IPv4
        $cluster.NetworkProfile | ConvertTo-Json | Out-File -FilePath .\NetworkProfile.json -Force
        Assert-AreEqual $cluster.NetworkProfile.LoadBalancerProfile.BackendPoolType NodeIP
        # return by server
        Assert-AreEqual $cluster.NetworkProfile.LoadBalancerProfile.ManagedOutboundIPs.CountIPv6 $null
        Assert-AreEqual $cluster.NetworkProfile.LoadBalancerProfile.ManagedOutboundIPs.Count 11
        Assert-AreEqual $cluster.NetworkProfile.NatGatewayProfile.IdleTimeoutInMinutes 22
        # return by server
        Assert-AreEqual $cluster.NetworkProfile.NatGatewayProfile.ManagedOutboundIPProfile $null
        Assert-AreEqual $cluster.NetworkProfile.NetworkDataplane azure
        Assert-AreEqual $cluster.NetworkProfile.NetworkPluginMode overlay
        Assert-AreEqual $cluster.NetworkProfile.StaticEgressGatewayProfile.Enabled $true
        Assert-AreEqual $cluster.NodeProvisioningProfile.DefaultNodePools Auto
        Assert-AreEqual $cluster.NodeResourceGroupProfile.RestrictionLevel Unrestricted
        Assert-AreEqual $cluster.PublicNetworkAccess Enabled
        Assert-AreEqual $cluster.SecurityProfile.ImageCleaner.Enabled $true
        Assert-AreEqual $cluster.SecurityProfile.ImageCleaner.IntervalHours 36
        Assert-AreEqual $cluster.SecurityProfile.WorkloadIdentity.Enabled $true
        Assert-AreEqual $cluster.SupportPlan KubernetesOfficial
        Assert-AreEqual $cluster.WorkloadAutoScalerProfile.Keda.Enabled $true
        Assert-AreEqual $cluster.WorkloadAutoScalerProfile.VerticalPodAutoscaler.Enabled $true

        New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -VmSize $nodeVmSize -Count 1 -GPUDriver None -MessageOfTheDay $nodeMessageOfTheDay -OSDiskType Managed -PodIPAllocationMode DynamicIndividual -ScaleDownMode Delete -EnableSecureBoot -EnableVtpm -SshAccess Disabled -DrainTimeoutInMinute 22 -MaxUnavailable '60%' -MaxSurge 0 -NodeSoakDurationInMinute 25 -UndrainableNodeBehavior Schedule -WorkloadRuntime OCIContainer
        $nodepool = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2

        Assert-AreEqual $nodepool.GpuProfile.Driver None
        Assert-AreEqual $nodepool.MessageOfTheDay $nodeMessageOfTheDay 
        Assert-AreEqual $nodepool.OsDiskType Managed 
        Assert-AreEqual $nodepool.PodIPAllocationMode DynamicIndividual 
        Assert-AreEqual $nodepool.ScaleDownMode Delete 
        Assert-AreEqual $nodepool.SecurityProfile.EnableSecureBoot $true 
        Assert-AreEqual $nodepool.SecurityProfile.EnableVtpm $true 
        Assert-AreEqual $nodepool.SecurityProfile.SshAccess Disabled 
        Assert-AreEqual $nodepool.UpgradeSettings.DrainTimeoutInMinutes 22 
        Assert-AreEqual $nodepool.UpgradeSettings.MaxUnavailable '60%' 
        Assert-AreEqual $nodepool.UpgradeSettings.MaxSurge 0 
        Assert-AreEqual $nodepool.UpgradeSettings.NodeSoakDurationInMinutes 25
        Assert-AreEqual $nodepool.UpgradeSettings.UndrainableNodeBehavior Schedule
        Assert-AreEqual $nodepool.WorkloadRuntime OCIContainer

        $nodepool = Update-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name pool2 -DrainTimeoutInMinute 18 -MaxUnavailable '80%' -NodeSoakDurationInMinute 23

        Assert-AreEqual $nodepool.UpgradeSettings.DrainTimeoutInMinutes 18 
        Assert-AreEqual $nodepool.UpgradeSettings.MaxUnavailable '80%' 
        Assert-AreEqual $nodepool.UpgradeSettings.NodeSoakDurationInMinutes 23
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-API20250801-WithMSI {
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'

    $nodeVmSize = "standard_a2_v2"
    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        # prepare UserAssignedIdentity
        # $resourceGroupName='AKS_TEST_RG'
        # $identityName1='aks_test_mi'
        # $identity1 = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupName -Name $identityName1 -Location $location
        # $identityId1 = $identity1.Id

        # $identityName2='aks_test_mi_2'
        # $identity2 = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupName -Name $identityName2 -Location $location
        # $identityId2 = $identity2.Id
        $identityId1 = '/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourcegroups/AKS_TEST_RG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/aks_test_mi'
        $identityId2 = '/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourcegroups/AKS_TEST_RG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/aks_test_mi_2'

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -Location $location  -AssignKubeletIdentity $identityId2  -EnableManagedIdentity -AssignIdentity $identityId1 -EnableAIToolchainOperator -EnableMonitorMetric -EnableCostAnalysis -EnableUptimeSLA

        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName

    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function Test-API20250801-WithMSI-Set {
    $resourceGroupName = Get-RandomResourceGroupName
    $kubeClusterName = Get-RandomClusterName
    $location = 'eastus'

    $nodeVmSize = "standard_a2_v2"
    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        # prepare UserAssignedIdentity
        # $resourceGroupName='AKS_TEST_RG'
        # $identityName1='aks_test_mi'
        # $identity1 = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupName -Name $identityName1 -Location $location
        # $identityId1 = $identity1.Id

        # $identityName2='aks_test_mi_2'
        # $identity2 = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupName -Name $identityName2 -Location $location
        # $identityId2 = $identity2.Id
        $identityId1 = '/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourcegroups/AKS_TEST_RG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/aks_test_mi'
        $identityId2 = '/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourcegroups/AKS_TEST_RG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/aks_test_mi_2'

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize -NodeCount 1 -Location $location  -EnableManagedIdentity -AssignIdentity $identityId1
        
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName

        $cluster =  $cluster | Set-AzAksCluster -AssignKubeletIdentity $identityId2
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}