### Example 1: Lists all model containers under a workspace
```powershell
Get-AzMLWorkspaceModelContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01
```

```output
Name                                                     SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
----                                                     -------------------  -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
azureml_plucky_collar_5x0ds0fgb3_output_mlflow_log_model 5/18/2022 7:47:43 AM UserName (Example)         User                    5/18/2022 7:47:43 AM     UserName (Example)         User                         ml-rg-test
sklearn-iris-example                                     5/18/2022 7:57:36 AM UserName (Example)         User                    5/18/2022 7:57:36 AM     UserName (Example)         User                         ml-rg-test
azureml_ivory_beard_fsbkdw8n77_output_mlflow_log_model   5/18/2022 8:06:06 AM UserName (Example)         User                    5/18/2022 8:06:06 AM     UserName (Example)         User                         ml-rg-test
sklearn-iris-cli                                         5/18/2022 8:35:26 AM UserName (Example)         User                    5/18/2022 8:35:26 AM     UserName (Example)         User                         ml-rg-test
a99089c5-23a6-4431-9ecd-37c70f01c9bc                     5/19/2022 2:51:55 AM UserName (Example)         User                    5/19/2022 2:51:55 AM     UserName (Example)         User                         ml-rg-test
87ec6e92-9253-4e3a-99f2-415dc3301102                     5/20/2022 7:35:06 AM UserName (Example)         User                    5/20/2022 7:35:06 AM     UserName (Example)         User                         ml-rg-test
modelcontaonerpwsh01                                     5/24/2022 9:21:21 AM UserName (Example)         User                    5/24/2022 9:21:21 AM     UserName (Example)         User                         ml-rg-test
c9436a28-a25c-4e36-ab9d-43be313629fc                     6/1/2022 6:18:34 AM  UserName (Example)         User                    6/1/2022 6:18:34 AM      UserName (Example)         User                         ml-rg-test
```

Lists all model containers under a workspace

### Example 2: Gets a model container by name
```powershell
Get-AzMLWorkspaceModelContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name azureml_plucky_collar_5x0ds0fgb3_output_mlflow_log_model
```

```output
Name                                                     SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
----                                                     -------------------  -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
azureml_plucky_collar_5x0ds0fgb3_output_mlflow_log_model 5/18/2022 7:47:43 AM UserName (Example)         User                    5/18/2022 7:47:43 AM     UserName (Example)         User                         ml-rg-test
```

Gets a model container by name

