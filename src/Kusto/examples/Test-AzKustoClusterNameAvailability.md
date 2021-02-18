### Example 1: Check the availability of a Kusto cluster name which is in use
```powershell
PS C:\> Test-AzKustoClusterNameAvailability -Name testnewkustocluster -Location 'East US' -Type Microsoft.Kusto/clusters

Message                                                                                       Name                NameAvailable Reason
-------                                                                                       ----                ------------- ------
Name 'testnewkustocluster' with type Engine is already taken. Please specify a different name testnewkustocluster False
```

The above command returns whether or not a Kusto cluster named "testnewkustocluster" exists in the "East US" region.

### Example 2: Check the availability of a Kusto cluster name which is not in use
```powershell
PS C:\> Test-AzKustoClusterNameAvailability -Name availablekustocluster -Location 'East US' -Type Microsoft.Kusto/clusters

Message Name                  NameAvailable Reason
------- ----                  ------------- ------
        availablekustocluster True
```

The above command returns whether or not a Kusto cluster named "availablekustocluster" exists in the "East US" region.
