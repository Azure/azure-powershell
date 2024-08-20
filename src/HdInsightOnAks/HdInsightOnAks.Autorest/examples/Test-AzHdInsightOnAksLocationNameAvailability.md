### Example 1: Check the availability of the cluster pool name.
```powershell
$location="west us 2"
$name="pool/testname"
Test-AzHdInsightOnAksLocationNameAvailability -Location $location -Name $name -Type Microsoft.HDInsight/clusterPools/clusters
```

```output
Message                                                   NameAvailable Reason
-------                                                   ------------- ------
Cluster name must follow the 'clusterpool/cluster' format False         Invalid
```

Check the availability of the cluster pool name in West Us 2.
