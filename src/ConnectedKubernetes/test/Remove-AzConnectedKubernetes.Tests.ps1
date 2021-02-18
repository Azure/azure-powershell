$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConnectedKubernetes.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzConnectedKubernetes' {
    # The cmdlet does not support the playback model because it uses helm and kubectl
    It 'Delete' -skip {
        Remove-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup -Name $env.connaksName00
        $connaksList =  Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup
        $connaksList.Name | Should -Not -Contain $env.connaksName00

    }

    It 'DeleteViaIdentity' -skip {
        $connaks = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup -Name $env.connaksName01
        Remove-AzConnectedKubernetes -InputObject $connaks
        $connaksList =  Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup
        $connaksList.Name | Should -Not -Contain $env.connaksName01
    }
}
