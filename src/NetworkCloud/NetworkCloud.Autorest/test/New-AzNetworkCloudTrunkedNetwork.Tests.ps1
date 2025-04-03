if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudTrunkedNetwork')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudTrunkedNetwork.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudTrunkedNetwork' {
    It 'Create' {
        {
            $config = $global:config.AzNetworkCloudTrunkedNetwork
            $global = $global:config.common

            New-AzNetworkCloudTrunkedNetwork -Name $config.trunkedNetworkName -ResourceGroupName $config.trunkedNetworkRg -SubscriptionId $config.subscriptionId -ExtendedLocationName $config.extendedLocation -ExtendedLocationType $global.customLocationType -Location $global.location -Vlan $config.vlans -IsolationDomainId $config.isolationDomainId -InterfaceName $config.interfaceName -Tag @{ tag = $config.tag }
        } | Should -Not -Throw
    }
}
