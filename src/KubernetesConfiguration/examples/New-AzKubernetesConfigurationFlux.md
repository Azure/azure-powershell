### Example 1: Create a new Kubernetes Flux Configuration.
```powershell
PS C:\> New-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp -Namespace namespace-t01 -Scope 'cluster' -GitRepositoryUrl https://github.com/fluxcd/flux2-kustomize-helm-example -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false

Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azpstest_gp
```

Create a new Kubernetes Flux Configuration.