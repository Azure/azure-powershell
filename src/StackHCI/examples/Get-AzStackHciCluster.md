### Example 1: 
```powershell
Get-AzStackHciCluster -ResourceGroupName test-rg
```

```output
Location Name
-------- ----
eastus   myCluster
eastus   myCluster2
```

Gets all the clusters in a RG 

### Example 2: 
Get-AzStackHciCluster -ResourceGroupName test-rg -ClusterName myCluster
```

```output
Location Name
-------- ----
eastus   myCluster
```

Gets the details of a particular cluster. To see the details use : "Write-Host( $cluster | Format-List | Out-String)"

