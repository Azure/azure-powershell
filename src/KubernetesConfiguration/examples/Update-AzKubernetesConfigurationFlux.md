### Example 1: Update an existing Kubernetes Flux Configuration.
```powershell
Update-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azps_test_group -GitRepositoryUrl https://github.com/fluxcd/flux2-kustomize-helm-example -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false
```

```output
Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azps_test_group
```

Update an existing Kubernetes Flux Configuration.

### Example 2: Update an existing Kubernetes Flux Configuration.
```powershell
Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azps_test_group | Update-AzKubernetesConfigurationFlux -GitRepositoryUrl https://github.com/fluxcd/flux2-kustomize-helm-example -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false
```

```output
Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azps_test_group
```

Update an existing Kubernetes Flux Configuration.