if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudKubernetesCluster')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudKubernetesCluster.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudKubernetesCluster' {
    It 'Create' {
        {
            $kubernetesClusterConfig = $global:config.AzNetworkCloudKubernetesCluster
            $common = $global:config.common
            $password = ConvertTo-SecureString "********" -AsPlainText -Force
            $sshPublicKey = @{
                KeyData = $kubernetesClusterConfig.sshPublicKey
            }

            $agentPoolConfiguration = New-AzNetworkCloudInitialAgentPoolConfigurationObject `
                -Count $kubernetesClusterConfig.nodeCount `
                -Mode $kubernetesClusterConfig.agentPoolMode `
                -Name $kubernetesClusterConfig.agentPoolName `
                -VmSkuName $kubernetesClusterConfig.vmSkuName `
                -AdministratorConfigurationAdminUsername $kubernetesClusterConfig.administratorConfigurationUsername `
                -AdministratorConfigurationSshPublicKey $sshPublicKey

            $ipAddressPools = New-AzNetworkCloudIpAddressPoolObject `
                -Address $kubernetesClusterConfig.bgpIpAddressPool `
                -Name $kubernetesClusterConfig.bgpIpAddressPoolName `
                -AutoAssign $kubernetesClusterConfig.bgpIpAddressPoolAutoAssign `
                -OnlyUseHostIp $kubernetesClusterConfig.bgpIpAddressPoolOnlyUseHostIp

            $serviceLoadBalancerBgpPeer = New-AzNetworkCloudServiceLoadBalancerBgpPeerObject `
                -Name $kubernetesClusterConfig.bgpPeerName `
                -PeerAddress $kubernetesClusterConfig.bgpPeerAddress `
                -PeerAsn $kubernetesClusterConfig.bgpPeerAsn `
                -BfdEnabled $kubernetesClusterConfig.bgpPeerBfdEnabled `
                -BgpMultiHop $kubernetesClusterConfig.bgpPeerBgpMultiHop `
                -HoldTime $kubernetesClusterConfig.bgpPeerHoldTime `
                -KeepAliveTime $kubernetesClusterConfig.bgpPeerKeepAliveTime `
                -MyAsn $kubernetesClusterConfig.bgpPeerMyAsn `
                -Password $password `
                -PeerPort $kubernetesClusterConfig.bgpPeerPort

            $bgpAdvertisement = New-AzNetworkCloudBgpAdvertisementObject `
                -IPAddressPool $kubernetesClusterConfig.bgpIpAddressPool `
                -Community $kubernetesClusterConfig.bgpCommunity `
                -Peer $kubernetesClusterConfig.bgpPeer

            $bgpPeer = New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject `
                -BgpAdvertisement $bgpAdvertisement `
                -BgpPeer $serviceLoadBalancerBgpPeer `
                -FabricPeeringEnabled $kubernetesClusterConfig.bgpFabricPeeringEnabled `
                -IpAddressPool $ipAddressPools

            New-AzNetworkCloudKubernetesCluster -ResourceGroupName $kubernetesClusterConfig.resourceGroup `
                -KubernetesClusterName $kubernetesClusterConfig.kubernetesClusterName -Location  $common.location `
                -ExtendedLocationName $kubernetesClusterConfig.extendedLocation `
                -ExtendedLocationType $common.customLocationType `
                -KubernetesVersion $kubernetesClusterConfig.kubernetesVersion `
                -AadConfigurationAdminGroupObjectId $kubernetesClusterConfig.adminGroupObjectIds `
                -AdminUsername $kubernetesClusterConfig.adminUsername `
                -SshPublicKey $sshPublicKey `
                -InitialAgentPoolConfiguration $agentPoolConfiguration `
                -NetworkConfigurationCloudServicesNetworkId $kubernetesClusterConfig.cnsId `
                -NetworkConfigurationCniNetworkId $kubernetesClusterConfig.cniId `
                -ControlPlaneNodeConfigurationCount $kubernetesClusterConfig.nodeCount `
                -ControlPlaneNodeConfigurationVMSkuName $kubernetesClusterConfig.vmSkuName `
                -SubscriptionId $kubernetesClusterConfig.subscriptionId `
                -Tag @{tags = $kubernetesClusterConfig.tags } `
                -BgpAdvertisement $bgpAdvertisement 
        } | Should -Not -Throw
    }
}
