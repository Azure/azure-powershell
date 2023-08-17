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
            $config = New-AzKubernetesExtension -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name $env.extensionName -ResourceGroupName $env.resourceGroup -ExtensionType azuremonitor-containers
            $config.Name | Should -Be $env.extensionName
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzKubernetesExtension -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzKubernetesExtension -Name $env.extensionName -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.extensionName
        } | Should -Not -Throw
    }

    It 'Update' {
        {
            $config = Update-AzKubernetesExtension -Name $env.extensionName -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup -ConfigurationProtectedSetting @{"aa"="bb"}
            $config.Name | Should -Be $env.extensionName
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzKubernetesExtension -Name $env.extensionName -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'K8sCreateExpanded' {
        {
            $config = New-AzK8sExtension -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name $env.extensionName -ResourceGroupName $env.resourceGroup -ExtensionType azuremonitor-containers
            $config.Name | Should -Be $env.extensionName
        } | Should -Not -Throw
    }

    It 'K8sList' {
        {
            $config = Get-AzK8sExtension -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'K8sGet' {
        {
            $config = Get-AzK8sExtension -Name $env.extensionName -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.extensionName
        } | Should -Not -Throw
    }

    It 'K8sUpdate' {
        {
            $config = Update-AzK8sExtension -Name $env.extensionName -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup -ConfigurationProtectedSetting @{"aa"="bb"}
            $config.Name | Should -Be $env.extensionName
        } | Should -Not -Throw
    }

    It 'K8sDelete' {
        {
            Remove-AzK8sExtension -Name $env.extensionName -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
