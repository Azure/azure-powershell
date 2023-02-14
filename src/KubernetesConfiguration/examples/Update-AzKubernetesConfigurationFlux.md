### Example 1: Update an existing Kubernetes Flux Configuration.
```powershell
<<<<<<< HEAD
Update-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp -GitRepositoryUrl https://github.com/fluxcd/flux2-kustomize-helm-example -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false
```

```output
=======
PS C:\> Update-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp -GitRepositoryUrl https://github.com/fluxcd/flux2-kustomize-helm-example -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azpstest_gp
```

Update an existing Kubernetes Flux Configuration.

### Example 2: Update an existing Kubernetes Flux Configuration.
```powershell
<<<<<<< HEAD
Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp | Update-AzKubernetesConfigurationFlux -GitRepositoryUrl https://github.com/fluxcd/flux2-kustomize-helm-example -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false
```

```output
=======
PS C:\> Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp | Update-AzKubernetesConfigurationFlux -GitRepositoryUrl https://github.com/fluxcd/flux2-kustomize-helm-example -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azpstest_gp
```

Update an existing Kubernetes Flux Configuration.