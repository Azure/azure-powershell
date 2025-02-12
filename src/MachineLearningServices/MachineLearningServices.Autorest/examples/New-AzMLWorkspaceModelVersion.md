### Example 1: Create or update model version
```powershell
New-AzMLWorkspaceModelVersion  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name modelcontainerpwsh01 -Version 1 -ModelType "mlflow_model" -ModelUri "azureml://subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/workspaces/mlworkspace-cli01/datastores/workspaceartifactstore/paths/ExperimentRun/dcid.plucky_collar_5x0ds0fgb3/model"
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
---- ------------------- -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
1    6/1/2022 4:29:14 PM UserName (Example)         User                    6/1/2022 4:29:14 PM      UserName (Example)         User                         ml-rg-test
```

Create or update model version

