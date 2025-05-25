Invoke-LiveTestScenario -Name "Test_AKS_CRUD" -Description "Test AKS cluster CRUD and node pool CRU" -Platform Linux -PowerShellVersion Latest -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "eastus"

    $kubeName = New-LiveTestResourceName
    $sysNodeName = New-LiveTestRandomName -Option StartWithLetter -MaxLength 5
    $usrNodeName = New-LiveTestRandomName -Option StartWithLetter -MaxLength 5

    $vnetName = New-LiveTestResourceName
    $snetName = New-LiveTestResourceName
    $nsgName = New-LiveTestResourceName
    $pipName = New-LiveTestResourceName

    # step 1: create an aks cluster with a node pool
    'y' | ssh-keygen -t rsa -f id_rsa -q -N '"123456"'
    $sshKeyValue = Get-Content id_rsa.pub -Raw

    $kvName = "LiveTestKeyVault"
    $aksSPIdKey = "AKSSPId"
    $aksSPSecretKey = "AKSSPSecret"
    $ServicePrincipalId = Get-AzKeyVaultSecret -VaultName $kvName -Name $aksSPIdKey -AsPlainText
    $ServicePrincipalSecret = Get-AzKeyVaultSecret -VaultName $kvName -Name $aksSPSecretKey -AsPlainText
    $servicePrincipalSecureSecret = ConvertTo-SecureString -String $ServicePrincipalSecret -AsPlainText -Force
    $servicePrincipalCredential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $ServicePrincipalId, $servicePrincipalSecureSecret

    $nsgRuleHighRiskPorts = New-AzNetworkSecurityRuleConfig -Name "DenyHighRiskPorts" -Direction Inbound -Priority 101 -Protocol Tcp -SourceAddressPrefix Internet -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 22, 3389 -Access Deny
    $nsg = New-AzNetworkSecurityGroup -ResourceGroupName $rgName -Name $nsgName -Location $location -SecurityRules $nsgRuleHighRiskPorts
    $snetCfg = New-AzVirtualNetworkSubnetConfig -Name $snetName -AddressPrefix 10.10.1.0/24 -DefaultOutboundAccess $false -NetworkSecurityGroup $nsg
    New-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName -Location $location -AddressPrefix 10.10.0.0/16 -Subnet $snetCfg

    $snet = Get-AzVirtualNetwork -ResourceGroupName $rgName -Name $vnetName | Get-AzVirtualNetworkSubnetConfig -Name $snetName

    $ipTag = New-AzPublicIpTag -IpTagType FirstPartyUsage -Tag "/NonProd"
    $pip = New-AzPublicIpAddress -ResourceGroupName $rgName -Name $pipName -Location $location -AllocationMethod Static -Sku Standard -IpTag $ipTag

    $kubeVersion = (Get-AzAksVersion -Location $location).OrchestratorVersion | Sort-Object -Descending | Select-Object -Skip 2 -First 1

    Write-Host "##[section]Start creating AKS cluster : New-AzAksCluster"

    New-AzAksCluster -ResourceGroupName $rgName -Name $kubeName -Location $location -SshKeyValue $sshKeyValue -ServicePrincipalIdAndSecret $servicePrincipalCredential -KubernetesVersion $kubeVersion -NodeName $sysNodeName -NodePoolMode System -NodeOsSKU AzureLinux -NodeVmSize Standard_D2s_v3 -AutoUpgradeChannel node-image -NodeCount 2 -EnableNodeAutoScaling -NodeMinCount 1 -NodeMaxCount 3 -NetworkPlugin azure -NodeVnetSubnetID $snet.Id -LoadBalancerOutboundIp $pip.Id

    Write-Host "##[section]Finished creating AKS cluster : New-AzAksCluster"

    $cluster = Get-AzAksCluster -ResourceGroupName $rgName -Name $kubeName

    Assert-NotNull $cluster
    Assert-NotNull $cluster.NodeResourceGroup
    Assert-AreEqual $rgName $cluster.ResourceGroupName
    Assert-AreEqual $kubeName $cluster.Name
    Assert-AreEqual $kubeVersion $cluster.KubernetesVersion
    Assert-AreEqual "Succeeded" $cluster.ProvisioningState
    Assert-AreEqual "node-image" $cluster.AutoUpgradeProfile.UpgradeChannel

    $agentPool = $cluster.AgentPoolProfiles

    Assert-NotNull $agentPool
    Assert-AreEqual 1 @($agentPool).Length
    Assert-AreEqual $sysNodeName $agentPool.Name
    Assert-AreEqual $kubeVersion $agentPool.OrchestratorVersion
    Assert-AreEqual "Linux" $agentPool.OsType
    Assert-AreEqual "AzureLinux" $agentPool.OsSKU
    Assert-AreEqual "System" $agentPool.Mode
    Assert-AreEqual "VirtualMachineScaleSets" $agentPool.Type
    Assert-AreEqual $snet.Id $agentPool.VnetSubnetID
    Assert-AreEqual "Succeeded" $agentPool.ProvisioningState
    Assert-AreEqual "True" $agentPool.EnableAutoScaling

    $nodePool = Get-AzAksNodePool -ResourceGroupName $rgName -ClusterName $kubeName

    Assert-NotNull $nodePool
    Assert-AreEqual 1 @($nodePool).Length
    Assert-AreEqual $sysNodeName $nodePool.Name
    Assert-AreEqual $kubeVersion $nodePool.OrchestratorVersion
    Assert-AreEqual "Linux" $nodePool.OsType
    Assert-AreEqual "AzureLinux" $nodePool.OsSKU
    Assert-AreEqual "System" $nodePool.Mode
    Assert-AreEqual "VirtualMachineScaleSets" $nodePool.AgentPoolType
    Assert-AreEqual $snet.Id $nodePool.VnetSubnetID
    Assert-AreEqual "Succeeded" $nodePool.ProvisioningState
    Assert-AreEqual "True" $nodePool.EnableAutoScaling

    # step 2: update the aks cluster
    Write-Host "##[section]Start to update AKS cluster : Set-AzAksCluster"

    $cluster = $cluster | Set-AzAksCluster -NodeName $sysNodeName -NodeCount 4 -EnableNodeAutoScaling:$false

    Write-Host "##[section]Finished updating AKS cluster : Set-AzAksCluster"

    Assert-NotNull $cluster
    Assert-AreEqual "False" $cluster.AgentPoolProfiles.EnableAutoScaling
    Assert-AreEqual 4 $($cluster.AgentPoolProfiles).Count

    # step 3: create the second node pool
    Write-Host "##[section]Start to create AKS node pool : New-AzAksNodePool"

    New-AzAksNodePool -ResourceGroupName $rgName -ClusterName $kubeName -Name $usrNodeName -Mode User -OsType Windows -OsSKU Windows2022 -VmSize Standard_D2s_v3 -VmSetType VirtualMachineScaleSets -Count 2

    Write-Host "##[section]Finished creating AKS node pool : New-AzAksNodePool"

    $nodePools = Get-AzAksNodePool -ResourceGroupName $rgName -ClusterName $kubeName
    $sysPool = $nodePools | Where-Object Name -eq $sysNodeName
    $usrPool = $nodePools | Where-Object Name -eq $usrNodeName

    Assert-NotNull $nodePools
    Assert-AreEqual 2 @($nodePools).Length

    Assert-NotNull $sysPool
    Assert-AreEqual $sysNodeName $sysPool.Name
    Assert-AreEqual "System" $sysPool.Mode
    Assert-AreEqual "Linux" $sysPool.OsType
    Assert-AreEqual "AzureLinux" $sysPool.OsSKU

    Assert-NotNull $usrPool
    Assert-AreEqual $usrNodeName $usrPool.Name
    Assert-AreEqual "User" $usrPool.Mode
    Assert-AreEqual "Windows" $usrPool.OsType
    Assert-AreEqual "Windows2022" $usrPool.OsSKU

    # step4: update the second node pool
    $labels = @{"someId" = 127; "tier" = "frontend"; "environment" = "qa" }
    $tags = @{"dept" = "MM"; "costcenter" = 7777; "Admin" = "Cindy" }

    Write-Host "##[section]Start to update Aks node pool : Update-AzAksNodePool"

    Update-AzAksNodePool -ResourceGroupName $rgName -ClusterName $kubeName -Name $usrNodeName -NodeLabel $labels -Tag $tags

    Write-Host "##[section]Finished updating Aks node pool : Update-AzAksNodePool"

    $cluster = Get-AzAksCluster -ResourceGroupName $rgName -Name $kubeName
    $sysPool = $cluster.AgentPoolProfiles | Where-Object Name -eq $sysNodeName
    $usrPool = $cluster.AgentPoolProfiles | Where-Object Name -eq $usrNodeName

    Assert-NotNull $cluster
    Assert-AreEqual 2 @($cluster.AgentPoolProfiles).Length

    Assert-NotNull $sysPool
    Assert-Null $sysPool.NodeLabels
    Assert-Null $sysPool.Tags

    Assert-NotNull $usrPool
    Assert-AreEqual 127 $usrPool.NodeLabels.someId
    Assert-AreEqual "frontend" $usrPool.NodeLabels.tier
    Assert-AreEqual "qa" $usrPool.NodeLabels.environment
    Assert-AreEqual "MM" $usrPool.Tags.dept
    Assert-AreEqual 7777 $usrPool.Tags.costcenter
    Assert-AreEqual "Cindy" $usrPool.Tags.Admin

    $nodePools = Get-AzAksNodePool -ResourceGroupName $rgName -ClusterName $kubeName
    $sysPool = $nodePools | Where-Object Name -eq $sysNodeName
    $usrPool = $nodePools | Where-Object Name -eq $usrNodeName

    Assert-NotNull $nodePools
    Assert-AreEqual 2 @($nodePools).Length

    Assert-NotNull $sysPool
    Assert-AreEqual $sysPool.NodeLabels
    Assert-AreEqual $sysPool.Tags

    Assert-NotNull $usrPool
    Assert-AreEqual 127 $usrPool.NodeLabels.someId
    Assert-AreEqual "frontend" $usrPool.NodeLabels.tier
    Assert-AreEqual "qa" $usrPool.NodeLabels.environment
    Assert-AreEqual "MM" $usrPool.Tags.dept
    Assert-AreEqual 7777 $usrPool.Tags.costcenter
    Assert-AreEqual "Cindy" $usrPool.Tags.Admin

    # step 5: remove the AKS cluster
    Write-Host "##[section]Start to remove Aks cluster : Remove-AzAksCluster"

    $cluster | Remove-AzAksCluster -Force

    Write-Host "##[section]Finished removing Aks cluster : Remove-AzAksCluster"

    $cluster = Get-AzAksCluster -ResourceGroupName $rgName -Name $kubeName -ErrorAction SilentlyContinue
    Assert-Null $cluster
}
