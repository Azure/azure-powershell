if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudL2Network')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudL2Network.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudL2Network' {
    It 'Create' {
        { New-AzNetworkCloudL2Network -Name $global:config.AzNetworkCloudL2Network.l2NetworkName `
                -ResourceGroupName $global:config.AzNetworkCloudL2Network.resourceGroup `
                -ExtendedLocationName $global:config.common.extendedLocation `
                -ExtendedLocationType $global:config.common.customLocationType `
                -L2IsolationDomainId  $global:config.AzNetworkCloudL2Network.l2IsolationDomainId `
                -Location  $global:config.common.Location `
                -InterfaceName $global:config.AzNetworkCloudL2Network.interfaceName `
                -Subscription $global:config.AzNetworkCloudL2Network.subscriptionId `
                -Tag @{tags = $global:config.AzNetworkCloudL2Network.tags }`
        } | Should -Not -Throw

    }
}
