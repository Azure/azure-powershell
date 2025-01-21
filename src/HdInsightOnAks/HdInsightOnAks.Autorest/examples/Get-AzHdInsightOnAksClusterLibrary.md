### Example 1: List all custom libraries on the cluster.
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "flinkcluster"
Get-AzHdInsightOnAksClusterLibrary -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -Category custom
```

```output
Id                           : 
Message                      : 
Name                         : 
PropertiesType               : pypi
Property                     : {
                                 "type": "pypi",
                                 "remarks": "",
                                 "status": "INSTALLING",
                                 "name": "pandas"
                               }
Remark                       : 
Status                       : INSTALLING
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Timestamp                    : 
Type                         :
```

List all custom libraries on the cluster.

### Example 2: List all predefined libraries on the cluster.
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "flinkcluster"
Get-AzHdInsightOnAksClusterLibrary -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -Category preddfine
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
---- ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
```

List all predefined libraries on the cluster.

