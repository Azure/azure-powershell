if(($null -eq $TestName) -or ($TestName -contains 'AzKubernetesConfigurationFlux'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzKubernetesConfigurationFlux.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzKubernetesConfigurationFlux' {
    It 'CreateExpanded' {
        {
            $kustomizations = @{
                infra=@{
                    Name = "infra"
                    Path = "./infrastructure"
                    Prune = "true"
                };
                apps=@{
                    Name = "apps"
                    Path = "./apps/staging"
                    Prune = "true"
                    DependsOn = @("infra")
                }
            }
            $config = New-AzKubernetesExtension -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name flux -ResourceGroupName $env.resourceGroup -ExtensionType microsoft.flux -AutoUpgradeMinorVersion -ReleaseNamespace flux-system -IdentityType 'SystemAssigned'
            $config.Name | Should -Be "flux"

            $config = New-AzKubernetesConfigurationFlux -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name $env.flux1 -ResourceGroupName $env.resourceGroup -Namespace namespace-t01 -Scope 'cluster' -GitRepositoryUrl https://github.com/Azure/gitops-flux2-kustomize-helm-mt -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false -Kustomization $kustomizations
            $config.Name | Should -Be $env.flux1
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzKubernetesConfigurationFlux -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzKubernetesConfigurationFlux -Name $env.flux1 -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.flux1
        } | Should -Not -Throw
    }

    It 'GetAzKubernetesConfigFluxOperationStatus' {
        {
            $config = Get-AzKubernetesConfigFluxOperationStatus -FluxConfigurationName $env.flux1 -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup -OperationId e9871335-7ba8-4100-8cb4-73b3464eb863
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
    
    It 'UpdateExpanded' {
        {
            $config = Update-AzKubernetesConfigurationFlux -Name $env.flux1 -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup -GitRepositoryUrl https://github.com/Azure/gitops-flux2-kustomize-helm-mt -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false
            $config.Name | Should -Be $env.flux1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzKubernetesConfigurationFlux -Name $env.flux1 -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
            $config = Update-AzKubernetesConfigurationFlux -InputObject $config -GitRepositoryUrl https://github.com/Azure/gitops-flux2-kustomize-helm-mt -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false
            $config.Name | Should -Be $env.flux1
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzKubernetesConfigurationFlux -Name $env.flux1 -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'K8sCreateExpanded' {
        {
            $kustomizations = @{
                infra=@{
                    Name = "infra"
                    Path = "./infrastructure"
                    Prune = "true"
                };
                apps=@{
                    Name = "apps"
                    Path = "./apps/staging"
                    Prune = "true"
                    DependsOn = @("infra")
                }
            }
            $config = New-AzK8sConfigurationFlux -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name $env.flux2 -ResourceGroupName $env.resourceGroup -Namespace namespace-t01 -Scope 'cluster' -GitRepositoryUrl https://github.com/Azure/gitops-flux2-kustomize-helm-mt -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false -Kustomization $kustomizations
            $config.Name | Should -Be $env.flux2
        } | Should -Not -Throw
    }

    It 'K8sList' {
        {
            $config = Get-AzK8sConfigurationFlux -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'K8sGet' {
        {
            $config = Get-AzK8sConfigurationFlux -Name $env.flux2 -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.flux2
        } | Should -Not -Throw
    }

    It 'K8sGetAzK8sConfigFluxOperationStatus' {
        {
            $config = Get-AzK8sConfigFluxOperationStatus -FluxConfigurationName $env.flux2 -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup -OperationId e9871335-7ba8-4100-8cb4-73b3464eb863
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
    
    It 'K8sUpdateExpanded' {
        {
            $config = Update-AzK8sConfigurationFlux -Name $env.flux2 -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup -GitRepositoryUrl https://github.com/Azure/gitops-flux2-kustomize-helm-mt -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false
            $config.Name | Should -Be $env.flux2
        } | Should -Not -Throw
    }

    It 'K8sUpdateViaIdentityExpanded' {
        {
            $config = Get-AzK8sConfigurationFlux -Name $env.flux2 -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
            $config = Update-AzK8sConfigurationFlux -InputObject $config -GitRepositoryUrl https://github.com/Azure/gitops-flux2-kustomize-helm-mt -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false
            $config.Name | Should -Be $env.flux2
        } | Should -Not -Throw
    }

    It 'K8sDeleteViaIdentity' {
        {
            $config = Get-AzK8sConfigurationFlux -Name $env.flux2 -ClusterName $env.clusterName -ClusterType ConnectedClusters -ResourceGroupName $env.resourceGroup
            Remove-AzK8sConfigurationFlux -InputObject $config

            Remove-AzK8sExtension -ClusterName $env.clusterName -ClusterType ConnectedClusters -Name flux -ResourceGroupName $env.resourceGroup 
        } | Should -Not -Throw
    }
}
