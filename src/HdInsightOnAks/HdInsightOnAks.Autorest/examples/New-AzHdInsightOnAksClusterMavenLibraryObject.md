### Example 1: Create a library object for maven.
```powershell
New-AzHdInsightOnAksClusterMavenLibraryObject -GroupId "com.azure.resourcemanager" -Name "azure-resourcemanager-hdinsight-containers" -Version "1.0.0-beta.2" -Remark "Maven lib"
```

```output
Name                         : 
PropertiesType               : maven
Property                     : {
                                 "type": "maven",
                                 "remarks": "Maven lib",
                                 "groupId": "com.azure.resourcemanager",
                                 "name": "azure-resourcemanager-hdinsight-containers",
                                 "version": "1.0.0-beta.2"
                               }
Remark                       : Maven lib
```

Create a library object for maven.

