$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzExtension.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzExtension' {
    It 'CreateExpanded' {
        {
            $config = New-AzExtension -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -Name $env.extensionNameEUAP1 -ResourceGroupName $env.resourceGroupEUAP -ExtensionType Microsoft.Arcdataservices
            $config.Name | Should -Be $env.extensionNameEUAP1
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-Azextension -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroupEUAP
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-Azextension -Name $env.extensionNameEUAP1 -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroupEUAP
            $config.Name | Should -Be $env.extensionNameEUAP1
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-Azextension -Name $env.extensionNameEUAP1 -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroupEUAP
        } | Should -Not -Throw
    }
}
