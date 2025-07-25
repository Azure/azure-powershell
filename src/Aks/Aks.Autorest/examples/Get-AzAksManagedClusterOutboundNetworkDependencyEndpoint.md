### Example 1: List egress endpoints (network endpoints of all outbound dependencies) in the specified managed cluster
```powershell
$result = Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint -ResourceGroupName mygroup -ResourceName mycluster
$result | select Category,Endpoint
```

```output
Category                  Endpoint
--------                  --------
azure-resource-management {management.azure.com, login.microsoftonline.com}
images                    {mcr.microsoft.com, *.data.mcr.microsoft.com}
artifacts                 {packages.microsoft.com, acs-mirror.azureedge.net}
time-sync                 {ntp.ubuntu.com}
ubuntu-optional           {security.ubuntu.com, azure.archive.ubuntu.com, changelogs.ubuntu.com}
apiserver                 {aks0b1f-idb7vuoi.hcp.eastus.azmk8s.io}
```


