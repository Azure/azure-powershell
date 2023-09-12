$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkCloudBareMetalMachineKeySet.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzNetworkCloudBareMetalMachineKeySet' {
    It 'ListByParent' {
        {
            $bmmksconfig = $global:config.AzNetworkCloudBareMetalMachineKeySet
            Get-AzNetworkCloudBareMetalMachineKeySet -ResourceGroupName $bmmksconfig.bmmksrg `
                -ClusterName  $bmmksconfig.clusterName -Subscription $bmmksconfig.subscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        {
            $bmmksconfig = $global:config.AzNetworkCloudBareMetalMachineKeySet
            Get-AzNetworkCloudBareMetalMachineKeySet -Name $bmmksconfig.bmmKeySetName `
                -ResourceGroupName $bmmksconfig.bmmksrg -ClusterName $bmmksconfig.clusterName -Subscription $bmmksconfig.subscriptionId } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
