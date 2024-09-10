Invoke-LiveTestScenario -Name "Test_AKS_CURD" -Description "Test AKS Cluster CRUD and node pool CRU" -Platform Linux -PowerShellVersion Latest -ScenarioScript `
{
    param ($rg)

    $resourceGroupName = $rg.ResourceGroupName

    # Generate random resource name if necessary
    $kubeClusterName = New-LiveTestResourceName

    # step 1: create a default aks cluster with default node pool
    'y' | ssh-keygen -t rsa -f id_rsa -q -N '"123456"'
    $sshKeyValue = Get-Content id_rsa.pub -Raw

    $kvName = "LiveTestKeyVault"
    $aksSPIdKey = "AKSSPId"
    $aksSPSecretKey = "AKSSPSecret"
    $ServicePrincipalId = Get-AzKeyVaultSecret -VaultName $kvName -Name $aksSPIdKey -AsPlainText
    $ServicePrincipalSecret = Get-AzKeyVaultSecret -VaultName $kvName -Name $aksSPSecretKey -AsPlainText
    $servicePrincipalSecureSecret = ConvertTo-SecureString -String $ServicePrincipalSecret -AsPlainText -Force
    $servicePrincipalCredential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $ServicePrincipalId, $servicePrincipalSecureSecret

    Write-Host "##[section]Start to create Aks cluster : New-AzAksCluster"
    New-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName -SshKeyValue $sshKeyValue -ServicePrincipalIdAndSecret $servicePrincipalCredential -AutoUpgradeChannel node-image
    Write-Host "##[section]Finished creating Aks cluster : New-AzAksCluster"

    Write-Host "##[section]Start to retrieve Aks cluster : Get-AzAksCluster"
    $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
    Write-Host "##[section]Finished retrieving Aks cluster : Get-AzAksCluster"

    Assert-NotNull $cluster.Fqdn
    Assert-NotNull $cluster.KubernetesVersion
    Assert-NotNull $cluster.DnsPrefix
    Assert-NotNull $cluster.NodeResourceGroup
    Assert-AreEqual "Succeeded" $cluster.ProvisioningState
    Assert-AreEqual 100 $cluster.MaxAgentPools
    Assert-AreEqual "default" $cluster.AgentPoolProfiles.Name
    Assert-AreEqual 1 $cluster.AgentPoolProfiles.Length
    Assert-AreEqual 3 $cluster.AgentPoolProfiles[0].Count
    Assert-NotNull $cluster.AgentPoolProfiles[0].NodeImageVersion

    Write-Host "##[section]Start to retrieve Aks node pool : Get-AzAksNodePool"
    $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
    Write-Host "##[section]Finished retrieving Aks node pool : Get-AzAksNodePool"

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
    Assert-False { $pools.EnableFIPS }

    # step 2: update the aks cluster
    Write-Host "##[section]Start to update Aks cluster : Set-AzAksCluster"
    $cluster = $cluster | Set-AzAksCluster -NodeCount 4 -EnableUptimeSLA
    Write-Host "##[section]Finished updating Aks cluster : Set-AzAksCluster"

    Assert-AreEqual 4 $cluster.AgentPoolProfiles[0].Count
    #Assert-AreEqual "Basic" $cluster.Sku.Name
    #Assert-AreEqual "Paid" $cluster.Sku.Tier

    # step 3: create the second node pool
    $pool1Name = "default"
    $pool2Name = "pool2"

    Write-Host "##[section]Start to create Aks node pool : New-AzAksNodePool"
    New-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name $pool2Name -OsType "Windows" -OsSKU "Windows2022" -Count 1 -VmSetType VirtualMachineScaleSets
    Write-Host "##[section]Finished creating Aks node pool : New-AzAksNodePool"

    Write-Host "##[section]Start to retrieve Aks node pool : Get-AzAksNodePool"
    $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
    Write-Host "##[section]Finished retrieving Aks node pool : Get-AzAksNodePool"

    Assert-AreEqual 2 $pools.Count
    Assert-AreEqualArray "Linux" ($pools | where { $_.Name -eq $pool1Name }).OsType
    Assert-AreEqualArray "Ubuntu" ($pools | where { $_.Name -eq $pool1Name }).OsSKU
    Assert-AreEqualArray "Windows" ($pools | where { $_.Name -eq $pool2Name }).OsType
    Assert-AreEqualArray "Windows2022" ($pools | where { $_.Name -eq $pool2Name }).OsSKU

    # step4: update the second node pool
    $labels = @{"someId" = 127; "tier" = "frontend"; "environment" = "qa" }
    $tags = @{"dept" = "MM"; "costcenter" = 7777; "Admin" = "Cindy" }

    Write-Host "##[section]Start to update Aks node pool : Update-AzAksNodePool"
    Update-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName -Name $pool2Name -NodeLabel $labels -Tag $tags
    Write-Host "##[section]Finished updating Aks node pool : Update-AzAksNodePool"

    Write-Host "##[section]Start to retrieve Aks cluster : Get-AzAksCluster"
    $cluster = Get-AzAksCluster -ResourceGroupName $resourceGroupName -Name $kubeClusterName
    Write-Host "##[section]Finished retrieving Aks cluster : Get-AzAksCluster"

    Assert-AreEqual 2 $cluster.AgentPoolProfiles.Count
    Assert-AreEqual 0 ($cluster.AgentPoolProfiles | where { $_.Name -eq $pool1Name }).NodeLabels.Count
    Assert-AreEqual 0 ($cluster.AgentPoolProfiles | where { $_.Name -eq $pool1Name }).Tags.Count
    Assert-AreEqual 127 ($cluster.AgentPoolProfiles | where { $_.Name -eq $pool2Name }).NodeLabels.someId
    Assert-AreEqual frontend ($cluster.AgentPoolProfiles | where { $_.Name -eq $pool2Name }).NodeLabels.tier
    Assert-AreEqual qa ($cluster.AgentPoolProfiles | where { $_.Name -eq $pool2Name }).NodeLabels.environment
    Assert-AreEqual MM ($cluster.AgentPoolProfiles | where { $_.Name -eq $pool2Name }).Tags.dept
    Assert-AreEqual 7777 ($cluster.AgentPoolProfiles | where { $_.Name -eq $pool2Name }).Tags.costcenter
    Assert-AreEqual Cindy ($cluster.AgentPoolProfiles | where { $_.Name -eq $pool2Name }).Tags.Admin

    Write-Host "##[section]Start to retrieve Aks node pool : Get-AzAksNodePool"
    $pools = Get-AzAksNodePool -ResourceGroupName $resourceGroupName -ClusterName $kubeClusterName
    Write-Host "##[section]Finished retrieving Aks node pool : Get-AzAksNodePool"

    Assert-AreEqual 2 $pools.Count
    Assert-AreEqual 0 ($pools | where { $_.Name -eq $pool1Name }).NodeLabels.Count
    Assert-AreEqual 0 ($pools | where { $_.Name -eq $pool1Name }).Tags.Count
    Assert-AreEqual 127 ($pools | where { $_.Name -eq $pool2Name }).NodeLabels.someId
    Assert-AreEqual frontend ($pools | where { $_.Name -eq $pool2Name }).NodeLabels.tier
    Assert-AreEqual qa ($pools | where { $_.Name -eq $pool2Name }).NodeLabels.environment
    Assert-AreEqual MM ($pools | where { $_.Name -eq $pool2Name }).Tags.dept
    Assert-AreEqual 7777 ($pools | where { $_.Name -eq $pool2Name }).Tags.costcenter
    Assert-AreEqual Cindy ($pools | where { $_.Name -eq $pool2Name }).Tags.Admin

    Write-Host "##[section]Start to remove Aks cluster : Remove-AzAksCluster"
    $cluster | Remove-AzAksCluster -Force
    Write-Host "##[section]Finished removing Aks cluster : Remove-AzAksCluster"
}
