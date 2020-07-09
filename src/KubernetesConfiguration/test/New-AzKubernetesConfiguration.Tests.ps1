$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzKubernetesConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzKubernetesConfiguration' {
    It 'CreateExpanded' {
        $kubConf = New-AzKubernetesConfiguration -Name $env.kubConf01 -ClusterName $env.kubernetesName01 -ResourceGroupName $env.resourceGroup -RepositoryUrl http://github.com/xxxx
        $kubConf.ProvisioningState | Should -Be 'Succeeded'
    }
}
