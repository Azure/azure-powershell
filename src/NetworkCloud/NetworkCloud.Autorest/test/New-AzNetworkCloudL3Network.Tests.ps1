if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudL3Network')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudL3Network.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudL3Network' {
    It 'Create' {
        { New-AzNetworkCloudL3Network -ResourceGroupName $global:config.AzNetworkCloudL3Network.resourceGroup `
                -Name $global:config.AzNetworkCloudL3Network.l3networkName -Location  $global:config.common.location `
                -ExtendedLocationName $global:config.common.extendedLocation `
                -ExtendedLocationType $global:config.common.customLocationType `
                -Vlan  $global:config.AzNetworkCloudL3Network.vlan  `
                -L3IsolationDomainId  $global:config.AzNetworkCloudL3Network.l3IsolationDomainId `
                -Ipv4ConnectedPrefix  $global:config.AzNetworkCloudL3Network.ipv4Prefix `
                -Ipv6ConnectedPrefix  $global:config.AzNetworkCloudL3Network.ipv6Prefix `
                -Subscription $global:config.AzNetworkCloudL3Network.subscriptionId `
                -Tag @{tags = $global:config.AzNetworkCloudL3Network.tags }`
        } | Should -Not -Throw
    }
}
