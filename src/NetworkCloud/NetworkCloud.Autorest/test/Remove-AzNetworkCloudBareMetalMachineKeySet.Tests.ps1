$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkCloudBareMetalMachineKeySet.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzNetworkCloudBareMetalMachineKeySet' {
    It 'Delete' {
        {
            $bmmksconfig = $global:config.AzNetworkCloudBareMetalMachineKeySet

            Remove-AzNetworkCloudBareMetalMachineKeySet -Name $bmmksconfig.bmmKeySetName `
                -ResourceGroupName $bmmksconfig.bmmksrg  -ClusterName $bmmksconfig.clusterName`
                -Subscription $bmmksconfig.subscriptionId
        }  | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
