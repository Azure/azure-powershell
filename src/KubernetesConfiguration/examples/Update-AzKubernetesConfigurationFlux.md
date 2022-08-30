### Example 1: Update an existing Kubernetes Flux Configuration.
```powershell
PS C:\> Update-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp -GitRepositoryUrl https://github.com/fluxcd/flux2-kustomize-helm-example -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false

Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azpstest_gp
```

Update an existing Kubernetes Flux Configuration.

### Example 2: Update an existing Kubernetes Flux Configuration.
```powershell
PS C:\> Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp | Update-AzKubernetesConfigurationFlux -GitRepositoryUrl https://github.com/fluxcd/flux2-kustomize-helm-example -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false

Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azpstest_gp
```

Update an existing Kubernetes Flux Configuration.