if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudAgentPool')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudAgentPool.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudAgentPool' {
    It 'Create' {
        {
            $l3NetworkAttachment = New-AzNetworkCloudL3NetworkAttachmentConfigurationObject `
            -NetworkId $global:config.AzNetworkCloudAgentPool.l3NetworkId `
            -IpamEnabled $global:config.AzNetworkCloudAgentPool.ipamEnabled `
            -PluginType $global:config.AzNetworkCloudAgentPool.pluginType
            
            $labels = @{
            Key   = $global:config.AzNetworkCloudAgentPool.labelsKey
            Value = $global:config.AzNetworkCloudAgentPool.labelsValue
            }
            $taints = @{
            Key   = $global:config.AzNetworkCloudAgentPool.taintsKey
            Value = $global:config.AzNetworkCloudAgentPool.taintsValue
            }
            $sshPublicKey = @{
            KeyData = $global:config.AzNetworkCloudAgentPool.sshPublicKeyData
            }
   
            $newAgentPoolCommand = New-AzNetworkCloudAgentPool -KubernetesClusterName $global:config.AzNetworkCloudAgentPool.clusterName `
            -Name $global:config.AzNetworkCloudAgentPool.agentPoolName `
            -ResourceGroupName $global:config.AzNetworkCloudAgentPool.agentPoolRg `
            -Count $global:config.AzNetworkCloudAgentPool.count `
            -Location $global:config.AzNetworkCloudAgentPool.location `
            -Mode $global:config.AzNetworkCloudAgentPool.mode `
            -VMSkuName $global:config.AzNetworkCloudAgentPool.vmSkuName `
            -SubscriptionId $global:config.AzNetworkCloudAgentPool.subscriptionId `
            -AdministratorConfigurationAdminUsername $global:config.AzNetworkCloudAgentPool.adminUsername `
            -AdministratorConfigurationSshPublicKey $sshPublicKey `
            -AgentOptionHugepagesCount $global:config.AzNetworkCloudAgentPool.hugepagesCount `
            -AgentOptionHugepagesSize $global:config.AzNetworkCloudAgentPool.hugepagesSize `
            -AvailabilityZone $global:config.AzNetworkCloudAgentPool.availabilityZones `
            -ExtendedLocationName $global:config.AzNetworkCloudAgentPool.clusterExtendedLocation `
            -ExtendedLocationType $global:config.common.customLocationType `
            -Tag @{tags = $global:config.AzNetworkCloudAgentPool.tags } `
            -UpgradeSettingMaxSurge $global:config.AzNetworkCloudAgentPool.maxSurge `
            -Label $labels -Taint $taints 

            $newAgentPoolCommand } | Should -Not -Throw
    }
}
