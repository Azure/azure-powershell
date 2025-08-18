### Example 1: Create a node profile with SKU and worker count.
```powershell
$vmSize="Standard_E8ads_v5";
$workerCount=5;
$nodeProfile = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count $workerCount -VMSize $vmSize
```

Create a profile with SKU Standard_E8ads_v5 and 5 worker nodes.
