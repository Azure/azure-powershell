### Example 1: Check that the script name which is not in use
```powershell
PS C:\> Test-AzKustoScriptNameAvailability -ClusterName testnewkustocluster -DatabaseName mykustodatabase -ResourceGroupName testrg -Name newkustoscript

Message Name           NameAvailable Reason
------- ----           ------------- ------
        newkustoscript True
```

The above command checks that the script name which is not in use.

### Example 2: Check that the script name which is not valid
```powershell
PS C:\> Test-AzKustoScriptNameAvailability -ClusterName testnewkustocluster -DatabaseName mykustodatabase -ResourceGroupName testrg -Name newkustoscript!

Message                                                                                                           Name            NameAvailable Reason
-------                                                                                                           ----            ------------- ------
Script: Name='newkustoscript!' does not comply with naming rules (contains invalid characters or format mismatch) newkustoscript! False
```

The above command checks that the script name which is not valid.
