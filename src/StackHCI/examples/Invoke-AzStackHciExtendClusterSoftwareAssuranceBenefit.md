### Example 1: 
```powershell
Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit -ClusterName "test-clus" -ResourceGroupName "test-rg"
```

```output
```

Enable Software Assurance on a cluster, by default the intent is "enable". 

### Example 2: 
```powershell
Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit -ClusterName "test-clus" -ResourceGroupName "test-rg" -SoftwareAssuranceIntent "Disable"
```

```output
```

Disable Software Assurance on a cluster. 


