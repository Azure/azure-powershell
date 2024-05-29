### Example 1: List hosts by zone in a cluster
```powershell
Get-AzVMwareClusterZone -PrivateCloudName SDDC2 -ResourceGroupName TestSddc-rg -ClusterName Cluster-1
```
```output
Host                                                                                                                              Zone
----                                                                                                                              ----
{esx09-r09.p01.canadacentral.avs.azure.com, esx02-r06.p01.canadacentral.avs.azure.com, esx20-r08.p01.canadacentral.avs.azure.com} 3
```

List hosts by zone in a cluster