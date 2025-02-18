if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudServicesNetwork')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudServicesNetwork.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudServicesNetwork' {
    It 'Create' {
        { $cnsconfig = $global:config.AzNetworkCloudServicesNetwork
            $common = $global:config.common
            $tagHash = @{
                tag1 = $cnsconfig.tags
            }
            $endpointEgressList = @()
            $endpointList = @()
            $endpoint = New-AzNetworkCloudEndpointDependencyObject `
                -DomainName $cnsconfig.domainName `
                -Port $cnsconfig.port
            $endpointList += $endpoint
            $additionalEgressEndpoint = New-AzNetworkCloudEgressEndpointObject `
                -Category $cnsconfig.category `
                -Endpoint $endpointList
            $endpointEgressList += $additionalEgressEndpoint
            New-AzNetworkCloudServicesNetwork -CloudServicesNetworkName $cnsconfig.cnsName `
                -ResourceGroupName $cnsconfig.resourceGroup `
                -ExtendedLocationName $common.extendedLocation `
                -ExtendedLocationType $common.customLocationType `
                -Location $common.Location -Tag $tagHash `
                -AdditionalEgressEndpoint $endpointEgressList `
                -EnableDefaultEgressEndpoint $cnsconfig.enableDefaultEgressEndpoint `
                -Subscription $cnsconfig.subscriptionId
        } | Should -Not -Throw
    }
}
