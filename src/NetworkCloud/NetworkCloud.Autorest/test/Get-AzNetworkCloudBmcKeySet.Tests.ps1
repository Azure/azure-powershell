if (($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkCloudBmcKeySet')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudBmcKeySet.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkCloudBmcKeySet' {
    It 'ListByParent' {
        {
            $bmcksconfig = $global:config.AzNetworkCloudBmcKeySet
            Get-AzNetworkCloudBmcKeySet -ResourceGroupName $bmcksconfig.bmcksrg `
                -ClusterName  $bmcksconfig.clusterName -Subscription $bmcksconfig.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        {
            $bmcksconfig = $global:config.AzNetworkCloudBmcKeySet
            Get-AzNetworkCloudBmcKeySet -Name $bmcksconfig.bmcKeySetName `
                -ResourceGroupName $bmcksconfig.bmcksrg -ClusterName  $bmcksconfig.clusterName -Subscription $bmcksconfig.subscriptionId } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
