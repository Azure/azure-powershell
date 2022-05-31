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
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "uJa7Q~pyzJpxnv7it0f0Co~SL8qQWFL2t45DW")

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -NodeVmSize $nodeVmSize
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
                
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "uJa7Q~pyzJpxnv7it0f0Co~SL8qQWFL2t45DW")

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
    $kubeVersion = "1.19.11"
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
    $updatedKubeVersion = "1.19.11"

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
    $credObject = $(createTestCredential $ServicePrincipalId "uJa7Q~pyzJpxnv7it0f0Co~SL8qQWFL2t45DW")

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
        
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "uJa7Q~pyzJpxnv7it0f0Co~SL8qQWFL2t45DW")
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
    $kubeVersion = "1.23.3"

    try
    {
        New-AzResourceGroup -Name $resourceGroupName -Location 'eastus'
        
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "xde7Q~bVRBoBzggfXn3Zw1uCqzRuLduEFPJXw")
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
        
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "xde7Q~bVRBoBzggfXn3Zw1uCqzRuLduEFPJXw")
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
        
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "xde7Q~bVRBoBzggfXn3Zw1uCqzRuLduEFPJXw")
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
        
        $credObject = $(createTestCredential "a6148f60-19b8-49b8-a5a5-54945aec926e" "xde7Q~bVRBoBzggfXn3Zw1uCqzRuLduEFPJXw")
        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $userAssignedkubeClusterName -ServicePrincipalIdAndSecret $credObject -EnableManagedIdentity -AssignIdentity '/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/wyunchi/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity'
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $userAssignedkubeClusterName
        Assert-NotNull $cluster.identity
        Assert-AreEqual 'UserAssigned' $cluster.identity.Type

        New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $setUserAssignedkubeClusterName -ServicePrincipalIdAndSecret $credObject  
        $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $setUserAssignedkubeClusterName
        Assert-Null $cluster.identity
        Set-AzAksCluster -ResourceGroupName $resourceGroupName -Name $setUserAssignedkubeClusterName -EnableManagedIdentity -AssignIdentity '/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/wyunchi/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity'
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