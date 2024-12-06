### Example 1: Getting a list of 
```powershell
Get-AzKustoClusterFollowerDatabaseGet -ResourceGroupName rg1 -ClusterName cluster1 -SubscriptionId subid
```

```output
AttachedDatabaseConfigurationName                   : 77789349-86f5-437e-a965-cf02fed0fa9e
ClusterResourceId                                   : /capacity/12c6162d-0e45-4315-890d-3b4e8cfab277
                                                      /workspace/339aaf03-e7f1-4028-982c-79e05f84499
                                                      5/artifact/77789349-86f5-437e-a965-cf02fed0fa9
                                                      e
DatabaseName                                        : db1
DatabaseShareOrigin                                 : Direct
TableLevelSharingPropertyExternalTablesToExclude    :
TableLevelSharingPropertyExternalTablesToInclude    :
TableLevelSharingPropertyFunctionsToExclude         :
TableLevelSharingPropertyFunctionsToInclude         :
TableLevelSharingPropertyMaterializedViewsToExclude :
TableLevelSharingPropertyMaterializedViewsToInclude :
TableLevelSharingPropertyTablesToExclude            :
TableLevelSharingPropertyTablesToInclude            :

AttachedDatabaseConfigurationName                   : 6370858a-ae02-4e97-9c87-0163226bdef7
ClusterResourceId                                   : /capacity/12c6162d-0e45-4315-890d-3b4e8cfab277
                                                      /workspace/339aaf03-e7f1-4028-982c-79e05f84499
                                                      5/artifact/6370858a-ae02-4e97-9c87-0163226bdef
                                                      7
DatabaseName                                        : db1
DatabaseShareOrigin                                 : Direct
TableLevelSharingPropertyExternalTablesToExclude    :
TableLevelSharingPropertyExternalTablesToInclude    :
TableLevelSharingPropertyFunctionsToExclude         :
TableLevelSharingPropertyFunctionsToInclude         :
TableLevelSharingPropertyMaterializedViewsToExclude :
TableLevelSharingPropertyMaterializedViewsToInclude :
TableLevelSharingPropertyTablesToExclude            :
TableLevelSharingPropertyTablesToInclude            :
```

The above command lists all the databases that are owned by this cluster and are followed by another cluster.

