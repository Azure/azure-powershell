### Example 1: 
```powershell
Get-AzStackHciCluster -ResourceGroupName test-rg
```

```output
Location   Name       Resource Group
--------   ----       -----------------
eastus     myCluster3 test-rg
eastus     myCluster  test-rg
westeurope myCluster2 test-rg
```

Gets all the clusters in a RG 

### Example 2: 
```powershell
Get-AzStackHciCluster -ResourceGroupName test-rg -ClusterName myCluster
```

```output
Location Name      Resource Group
-------- ----      -----------------
eastus   myCluster test-rg
```

Gets the details of a particular cluster. To see the details use : "Write-Host( $cluster | Format-List | Out-String)"

