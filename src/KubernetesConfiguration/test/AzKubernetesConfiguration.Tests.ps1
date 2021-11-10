$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzKubernetesConfiguration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzKubernetesConfiguration' {
    It 'CreateExpanded' {
        {
            $config = New-AzKubernetesConfiguration -Name $env.kubernetesConfigurationNameCUS1 -ClusterName $env.clusterNameCUS -ResourceGroupName $env.resourceGroupCUS -RepositoryUrl http://github.com/xxxx
            $config.ProvisioningState | Should -Be 'Succeeded'

            $config = New-AzKubernetesConfiguration -Name $env.kubernetesConfigurationNameCUS2 -ClusterName $env.clusterNameCUS -ResourceGroupName $env.resourceGroupCUS -RepositoryUrl http://github.com/xxxx -OperatorNamespace namespace-t01
            $config.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }
        
    It 'List' {
        {
            $config = Get-AzKubernetesConfiguration -ResourceGroupName $env.resourceGroupCUS -ClusterName $env.clusterNameCUS -ClusterType ConnectedClusters
            $config.Count | Should -Be 2
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzKubernetesConfiguration -ResourceGroupName $env.resourceGroupCUS -ClusterName $env.clusterNameCUS -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationNameCUS1
            $config.Name | Should -Be $env.kubernetesConfigurationNameCUS1
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzKubernetesConfiguration -ResourceGroupName $env.resourceGroupCUS -ClusterName $env.clusterNameCUS -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationNameCUS1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzKubernetesConfiguration -ResourceGroupName $env.resourceGroupCUS -ClusterName $env.clusterNameCUS -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationNameCUS2
            Remove-AzKubernetesConfiguration -InputObject $config
            
            $config = Get-AzKubernetesConfiguration -ResourceGroupName $env.resourceGroupCUS -ClusterName $env.clusterNameCUS -ClusterType ConnectedClusters
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'K8sCreateExpanded' {
        {
            $config = New-AzK8sConfiguration -Name $env.kubernetesConfigurationNameCUS1 -ClusterName $env.clusterNameCUS -ResourceGroupName $env.resourceGroupCUS -RepositoryUrl http://github.com/xxxx
            $config.ProvisioningState | Should -Be 'Succeeded'

            $config = New-AzK8sConfiguration -Name $env.kubernetesConfigurationNameCUS2 -ClusterName $env.clusterNameCUS -ResourceGroupName $env.resourceGroupCUS -RepositoryUrl http://github.com/xxxx -OperatorNamespace namespace-t01
            $config.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }
        
    It 'K8sList' {
        {
            $config = Get-AzK8sConfiguration -ResourceGroupName $env.resourceGroupCUS -ClusterName $env.clusterNameCUS -ClusterType ConnectedClusters
            $config.Count | Should -Be 2
        } | Should -Not -Throw
    }

    It 'K8sGet' {
        {
            $config = Get-AzK8sConfiguration -ResourceGroupName $env.resourceGroupCUS -ClusterName $env.clusterNameCUS -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationNameCUS1
            $config.Name | Should -Be $env.kubernetesConfigurationNameCUS1
        } | Should -Not -Throw
    }

    It 'K8sDelete' {
        {
            Remove-AzK8sConfiguration -ResourceGroupName $env.resourceGroupCUS -ClusterName $env.clusterNameCUS -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationNameCUS1
        } | Should -Not -Throw
    }

    It 'K8sDeleteViaIdentity' {
        {
            $config = Get-AzK8sConfiguration -ResourceGroupName $env.resourceGroupCUS -ClusterName $env.clusterNameCUS -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationNameCUS2
            Remove-AzK8sConfiguration -InputObject $config
            
            $config = Get-AzK8sConfiguration -ResourceGroupName $env.resourceGroupCUS -ClusterName $env.clusterNameCUS -ClusterType ConnectedClusters
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }
}
