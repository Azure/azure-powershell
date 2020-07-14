$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKubernetesConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzKubernetesConfiguration' {
    It 'List' {
        $kubConfList = Get-AzKubernetesConfiguration -ClusterName $env.kubernetesName00 -ResourceGroupName $env.resourceGroup -ClusterRp 'Microsoft.Kubernetes' -ClusterType 'ConnectedClusters'
        $kubConfList.Count | Should -Be 1
    }

    It 'Get' {
        $kubConf = Get-AzKubernetesConfiguration -Name $env.kubConf00 -ClusterName $env.kubernetesName00 -ResourceGroupName $env.resourceGroup -ClusterRp 'Microsoft.Kubernetes' -ClusterType 'ConnectedClusters'
        $kubConf.Name | Should -Be $env.kubConf00
    }

    It 'GetViaIdentity'  {
        $kubConf = Get-AzKubernetesConfiguration -Name $env.kubConf00 -ClusterName $env.kubernetesName00 -ResourceGroupName $env.resourceGroup -ClusterRp 'Microsoft.Kubernetes' -ClusterType 'ConnectedClusters'
        $kubConf = Get-AzKubernetesConfiguration -InputObject $kubConf
        $kubConf.Name | Should -Be $env.kubConf00
    }
}
