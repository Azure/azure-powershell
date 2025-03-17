if (($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkCloudServicesNetwork')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkCloudServicesNetwork.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkCloudServicesNetwork' {
    It 'Update' {
        { $cnsconfig = $global:config.AzNetworkCloudServicesNetwork
            $common = $global:config.common
            $tagUpdatedHash = @{
                tag1 = $global:config.AzNetworkCloudServicesNetwork.tags
                tag2 = $global:config.AzNetworkCloudServicesNetwork.tagsUpdate
            }
            $endpointEgressList = @()
            $endpointList = @()
            $endpoint = @{
                domainName = $cnsconfig.domainName
                port       = $cnsconfig.port
            }
            $endpointList += $endpoint
            $additionalEgressEndpoint = @{
                category = $cnsconfig.category
                endpoint = $endpointList
            }
            $endpointEgressList += $additionalEgressEndpoint
            Update-AzNetworkCloudServicesNetwork -ResourceGroupName $cnsconfig.resourceGroup `
                -Subscription $cnsconfig.subscriptionId `
                -Name $cnsconfig.cnsName -Tag $tagUpdatedHash `
                -AdditionalEgressEndpoint $endpointEgressList `
                -EnableDefaultEgressEndpoint $cnsconfig.enableDefaultEgressEndpoint `
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
