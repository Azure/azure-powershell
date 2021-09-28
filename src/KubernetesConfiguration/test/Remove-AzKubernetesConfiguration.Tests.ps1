$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKubernetesConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzKubernetesConfiguration' {
    It 'Delete' {
        Remove-AzKubernetesConfiguration -Name $env.kubConf00 -ClusterName $env.kubernetesName00 -ResourceGroupName $env.resourceGroup -ClusterType 'ConnectedClusters'
        $kubConfList = Get-AzKubernetesConfiguration -ClusterName $env.kubernetesName00 -ResourceGroupName $env.resourceGroup -ClusterRp 'Microsoft.Kubernetes' -ClusterType 'ConnectedClusters'
        $kubConfList.Name | Should -Not -Contain  $env.kubConf00
    }

    It 'DeleteViaIdentity' {
        $kubConf = Get-AzKubernetesConfiguration -Name $env.kubConf01 -ClusterName $env.kubernetesName01 -ResourceGroupName $env.resourceGroup -ClusterRp 'Microsoft.Kubernetes' -ClusterType 'ConnectedClusters'
        Remove-AzKubernetesConfiguration -InputObject $kubConf
        $kubConfList = Get-AzKubernetesConfiguration -ClusterName $env.kubernetesName01 -ResourceGroupName $env.resourceGroup -ClusterRp 'Microsoft.Kubernetes' -ClusterType 'ConnectedClusters'
        $kubConfList.Name | Should -Not -Contain  $env.kubConf01
    }
}
