$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzConnectedKubernetes.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzConnectedKubernetes' {
    It 'UpdateExpanded' {
        Update-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup -Name $env.connaksName02 -Tag @{'key1'= 1; 'key2'= 2}
        $connaks = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup -Name $env.connaksName02
        $connaks.Tag.Count | Should -Be 2
    }

    It 'UpdateViaIdentityExpanded' {
        $connaks = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup -Name $env.connaksName02
        Update-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup -Name $env.connaksName02 -Tag @{'key1'= 1; 'key2'= 2; 'key3'= 3}
        $connaks = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroup -Name $env.connaksName02
        $connaks.Tag.Count | Should -Be 3
    }
}
