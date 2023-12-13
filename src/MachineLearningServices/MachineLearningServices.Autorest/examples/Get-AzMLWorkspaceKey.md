### Example 1: Lists all the keys associated with this workspace.This includes keys for the storage account, app insights and password for container regist
```powershell
Get-AzMLWorkspaceKey  -ResourceGroupName ml-rg-test -Name mlworkspace-cli01
```

```output
AppInsightsInstrumentationKey        UserStorageKey                                                                           UserStorageResourceId
-----------------------------        --------------                                                                           ---------------------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
```

 Lists all the keys associated with this workspace.This includes keys for the storage account, app insights and password for container regist

