Invoke-LiveTestScenario -Name "Test_AKS_CURD" -Description "Test AKS Cluster CRUD and node pool CRU" -ScenarioScript `
{
    param ($rg)

    $resourceGroupName = $rg.ResourceGroupName

    # Generate random resource name if necessary
    $kubeClusterName = New-LiveTestResourceName
	
    # step 1: create a default aks cluster with default node pool
    New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
    $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
    Assert-NotNull $cluster.Fqdn
    Assert-NotNull $cluster.KubernetesVersion
    Assert-NotNull $cluster.DnsPrefix
    Assert-NotNull $cluster.NodeResourceGroup
    Assert-AreEqual "Succeeded" $cluster.ProvisioningState
    Assert-AreEqual 100 $cluster.MaxAgentPools
    Assert-AreEqual $cluster.CurrentKubernetesVersion $cluster.KubernetesVersion
    Assert-AreEqual "default" $cluster.AgentPoolProfiles.Name
    Assert-AreEqual 1 $cluster.AgentPoolProfiles.Length
    Assert-AreEqual 3 $cluster.AgentPoolProfiles[0].Count
    Assert-NotNull $cluster.AgentPoolProfiles[0].NodeImageVersion
    
    $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
    Assert-NotNull $pools.VmSize
    Assert-NotNull $pools.OsDiskSizeGB
    Assert-NotNull $pools.OrchestratorVersion
    Assert-NotNull $pools.NodeImageVersion
    Assert-NotNull $pools.Id
    Assert-AreEqual "Managed" $pools.OsDiskType
    Assert-AreEqual "OS" $pools.KubeletDiskType
    Assert-AreEqual 30 $pools.MaxPods
    Assert-AreEqual "Linux" $pools.OsType
    Assert-AreEqual "Ubuntu" $pools.OsSKU
    Assert-AreEqual "System" $pools.Mode
    Assert-AreEqual "VirtualMachineScaleSets" $pools.AgentPoolType
    Assert-AreEqual $pools.CurrentOrchestratorVersion $pools.OrchestratorVersion
    Assert-AreEqual "Succeeded" $pools.ProvisioningState
    Assert-AreEqual "Running" $pools.PowerState.Code
    Assert-AreEqual 0 $pools.Tags.Count
    Assert-AreEqual 0 $pools.NodeLabels.Count
    Assert-AreEqual 0 $pools.NodeTaints.Count
    Assert-AreEqual "Microsoft.ContainerService/managedClusters/agentPools" $pools.Type
    Assert-AreEqual 3 $pools.Count
    Assert-Null $pools.VnetSubnetID
    Assert-Null $pools.PodSubnetID
    Assert-Null $pools.MaxCount
    Assert-Null $pools.MinCount
    Assert-Null $pools.EnableAutoScaling
    Assert-Null $pools.UpgradeSettings
    Assert-Null $pools.EnableNodePublicIP
    Assert-Null $pools.ScaleSetPriority
    Assert-Null $pools.ScaleSetEvictionPolicy
    Assert-Null $pools.NodePublicIPPrefixID
    Assert-Null $pools.SpotMaxPrice
    Assert-Null $pools.ProximityPlacementGroupID
    Assert-Null $pools.KubeletConfig
    Assert-Null $pools.LinuxOSConfig
    Assert-Null $pools.EnableEncryptionAtHost
    Assert-Null $pools.EnableUltraSSD
    Assert-Null $pools.GpuInstanceProfile
    Assert-Null $pools.CreationData
    Assert-Null $pools.HostGroupID
    Assert-False {$pools.EnableFIPS}
    
    # step 2: update the aks cluster
    $cluster = $cluster | Set-AzAksCluster -NodeCount 4 -EnableUptimeSLA
    Assert-AreEqual 4 $cluster.AgentPoolProfiles[0].Count
    Assert-AreEqual "Basic" $cluster.Sku.Name
    Assert-AreEqual "Paid" $cluster.Sku.Tier
    
    # step 3: create the second node pool
    $pool1Name = "default"
    $pool2Name = "pool2"
    New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name $pool2Name -OsType "Windows" -OsSKU "Windows2022" -Count 1 -VmSetType VirtualMachineScaleSets
    $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
    Assert-AreEqual 2 $pools.Count
    Assert-AreEqualArray "Linux" ($pools | where {$_.Name -eq $pool1Name}).OsType
    Assert-AreEqualArray "Ubuntu" ($pools | where {$_.Name -eq $pool1Name}).OsSKU
    Assert-AreEqualArray "Windows" ($pools | where {$_.Name -eq $pool2Name}).OsType
    Assert-AreEqualArray "Windows2022" ($pools | where {$_.Name -eq $pool2Name}).OsSKU
    
    # step4: update the second node pool
    $labels = @{"someId" = 127; "tier" = "frontend"; "environment" = "qa" }
    $tags = @{"dept"="MM"; "costcenter"=7777; "Admin"="Cindy"}
    Update-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name $pool2Name -NodeLabel $labels -Tag $tags
    $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
    Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
    Assert-AreEqual 0 ($cluster.AgentPoolProfiles | where {$_.Name -eq $pool1Name}).NodeLabels.Count
    Assert-AreEqual 0 ($cluster.AgentPoolProfiles | where {$_.Name -eq $pool1Name}).Tags.Count
    Assert-AreEqual 127 ($cluster.AgentPoolProfiles | where {$_.Name -eq $pool2Name}).NodeLabels.someId
    Assert-AreEqual frontend ($cluster.AgentPoolProfiles | where {$_.Name -eq $pool2Name}).NodeLabels.tier
    Assert-AreEqual qa ($cluster.AgentPoolProfiles | where {$_.Name -eq $pool2Name}).NodeLabels.environment
    Assert-AreEqual MM ($cluster.AgentPoolProfiles | where {$_.Name -eq $pool2Name}).Tags.dept
    Assert-AreEqual 7777 ($cluster.AgentPoolProfiles | where {$_.Name -eq $pool2Name}).Tags.costcenter
    Assert-AreEqual Cindy ($cluster.AgentPoolProfiles | where {$_.Name -eq $pool2Name}).Tags.Admin
    $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
    Assert-AreEqual 2 $pools.Count
    Assert-AreEqual 0 ($pools | where {$_.Name -eq $pool1Name}).NodeLabels.Count
    Assert-AreEqual 0 ($pools | where {$_.Name -eq $pool1Name}).Tags.Count
    Assert-AreEqual 127 ($pools | where {$_.Name -eq $pool2Name}).NodeLabels.someId
    Assert-AreEqual frontend ($pools | where {$_.Name -eq $pool2Name}).NodeLabels.tier
    Assert-AreEqual qa ($pools | where {$_.Name -eq $pool2Name}).NodeLabels.environment
    Assert-AreEqual MM ($pools | where {$_.Name -eq $pool2Name}).Tags.dept
    Assert-AreEqual 7777 ($pools | where {$_.Name -eq $pool2Name}).Tags.costcenter
    Assert-AreEqual Cindy ($pools | where {$_.Name -eq $pool2Name}).Tags.Admin
    
    $cluster | Remove-AzAksCluster -Force

}