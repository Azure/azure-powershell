$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzKubernetesExtension.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzKubernetesExtension' {
    It 'CreateExpanded' {
        {
            $config = New-AzKubernetesExtension -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -Name $env.extensionNameEUAP1 -ResourceGroupName $env.resourceGroupEUAP -ExtensionType Microsoft.Arcdataservices
            $config.Name | Should -Be $env.extensionNameEUAP1
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzKubernetesExtension -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroupEUAP
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzKubernetesExtension -Name $env.extensionNameEUAP1 -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroupEUAP
            $config.Name | Should -Be $env.extensionNameEUAP1
        } | Should -Not -Throw
    }

    It 'Update' {
        {
            $config = Update-AzKubernetesExtension -Name $env.extensionNameEUAP1 -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroupEUAP -ConfigurationProtectedSetting @{"aa"="bb"}
            $config.Name | Should -Be $env.extensionNameEUAP1
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzKubernetesExtension -Name $env.extensionNameEUAP1 -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroupEUAP
        } | Should -Not -Throw
    }

    It 'K8sCreateExpanded' {
        {
            $config = New-AzK8sExtension -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -Name $env.extensionNameEUAP1 -ResourceGroupName $env.resourceGroupEUAP -ExtensionType Microsoft.Arcdataservices
            $config.Name | Should -Be $env.extensionNameEUAP1
        } | Should -Not -Throw
    }

    It 'K8sList' {
        {
            $config = Get-AzK8sExtension -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroupEUAP
            $config.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'K8sGet' {
        {
            $config = Get-AzK8sExtension -Name $env.extensionNameEUAP1 -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroupEUAP
            $config.Name | Should -Be $env.extensionNameEUAP1
        } | Should -Not -Throw
    }

    It 'K8sUpdate' {
        {
            $config = Update-AzK8sExtension -Name $env.extensionNameEUAP1 -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroupEUAP -ConfigurationProtectedSetting @{"aa"="bb"}
            $config.Name | Should -Be $env.extensionNameEUAP1
        } | Should -Not -Throw
    }

    It 'K8sDelete' {
        {
            Remove-AzK8sExtension -Name $env.extensionNameEUAP1 -ClusterName $env.clusterNameEUAP -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroupEUAP
        } | Should -Not -Throw
    }
}
