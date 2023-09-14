### Example 1: {{ Add title here }}
```powershell
$location="west us 2"
$name="testname"
Test-AzHdInsightOnAksLocationNameAvailability -Location $location -Name $name -Type Microsoft.HDInsight/clusterPools/clusters
```

```output
Message                                                   NameAvailable Reason
-------                                                   ------------- ------
Cluster name must follow the 'clusterpool/cluster' format False         Invalid
```

Check the availability of the cluster pool name in West Us 2.
