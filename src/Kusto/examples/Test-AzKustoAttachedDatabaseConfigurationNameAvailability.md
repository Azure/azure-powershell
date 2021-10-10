### Example 1: Checks whether the attached database configuration name is available in the given cluster
```powershell
PS C:\> Test-AzKustoAttachedDatabaseConfigurationNameAvailability -ResourceGroupName "testrg" -ClusterName "mycluster" -Name "testdatabase"

Message Name               NameAvailable Reason
------- ----               ------------- ------
        testdatabase       True
```

The above command returns whether or not an attached database configuration name is available in the cluster named "mycluster" in resource group "testrg".
