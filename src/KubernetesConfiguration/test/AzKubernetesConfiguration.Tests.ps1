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
            $config = New-AzKubernetesConfiguration -Name $env.kubernetesConfigurationName1 -ClusterName $env.clusterName -ResourceGroupName $env.resourceGroup -RepositoryUrl http://github.com/xxxx -ClusterType ConnectedClusters
            $config.ProvisioningState | Should -Be 'Succeeded'

            $config = New-AzKubernetesConfiguration -Name $env.kubernetesConfigurationName2 -ClusterName $env.clusterName -ResourceGroupName $env.resourceGroup -RepositoryUrl http://github.com/xxxx -OperatorNamespace namespace-t01 -ClusterType ConnectedClusters
            $config.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }
        
    It 'List' {
        {
            $config = Get-AzKubernetesConfiguration -ResourceGroupName $env.resourceGroup -ClusterName $env.clusterName -ClusterType ConnectedClusters
            $config.Count | Should -Be 2
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzKubernetesConfiguration -ResourceGroupName $env.resourceGroup -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationName1
            $config.Name | Should -Be $env.kubernetesConfigurationName1
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzKubernetesConfiguration -ResourceGroupName $env.resourceGroup -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationName1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzKubernetesConfiguration -ResourceGroupName $env.resourceGroup -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationName2
            Remove-AzKubernetesConfiguration -InputObject $config
            
            $config = Get-AzKubernetesConfiguration -ResourceGroupName $env.resourceGroup -ClusterName $env.clusterName -ClusterType ConnectedClusters
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'K8sCreateExpanded' {
        {
            $config = New-AzK8sConfiguration -Name $env.kubernetesConfigurationName1 -ClusterName $env.clusterName -ResourceGroupName $env.resourceGroup -RepositoryUrl http://github.com/xxxx -ClusterType ConnectedClusters
            $config.ProvisioningState | Should -Be 'Succeeded'

            $config = New-AzK8sConfiguration -Name $env.kubernetesConfigurationName2 -ClusterName $env.clusterName -ResourceGroupName $env.resourceGroup -RepositoryUrl http://github.com/xxxx -OperatorNamespace namespace-t01 -ClusterType ConnectedClusters
            $config.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }
        
    It 'K8sList' {
        {
            $config = Get-AzK8sConfiguration -ResourceGroupName $env.resourceGroup -ClusterName $env.clusterName -ClusterType ConnectedClusters
            $config.Count | Should -Be 2
        } | Should -Not -Throw
    }

    It 'K8sGet' {
        {
            $config = Get-AzK8sConfiguration -ResourceGroupName $env.resourceGroup -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationName1
            $config.Name | Should -Be $env.kubernetesConfigurationName1
        } | Should -Not -Throw
    }

    It 'K8sDelete' {
        {
            Remove-AzK8sConfiguration -ResourceGroupName $env.resourceGroup -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationName1
        } | Should -Not -Throw
    }

    It 'K8sDeleteViaIdentity' {
        {
            $config = Get-AzK8sConfiguration -ResourceGroupName $env.resourceGroup -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name $env.kubernetesConfigurationName2
            Remove-AzK8sConfiguration -InputObject $config
            
            $config = Get-AzK8sConfiguration -ResourceGroupName $env.resourceGroup -ClusterName $env.clusterName -ClusterType ConnectedClusters
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }
}
