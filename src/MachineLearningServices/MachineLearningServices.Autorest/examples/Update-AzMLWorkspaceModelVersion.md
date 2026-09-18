### Example 1: Create or update model version
```powershell
Update-AzMLWorkspaceModelVersion -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name heart-classifier-mlflow -Version 1 -Description "Test heart-classifier"
```

```output
Description                  : Test heart-classifier
Flavor                       : {
                                 "python_function": {
                                   "data": {
                                     "env": "conda.yaml",
                                     "loader_module": "mlflow.sklearn",
                                     "model_path": "model.pkl",
                                     "python_version": "3.8.5"
                                   }
                                 },
                                 "sklearn": {
                                   "data": {
                                     "pickled_model": "model.pkl",
                                     "serialization_format": "cloudpickle",
                                     "sklearn_version": "1.1.2"
                                   }
                                 }
                               }
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/models/heart-classifier-mlflow/versions/1
IsAnonymou                   : False
IsArchived                   : False
JobName                      : 
ModelType                    : mlflow_model
ModelUri                     : azureml://subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/workspaces/mlworkspace-test2/datastores/workspaceblobstore/paths/heart-classifier 
                               -mlflow
Name                         : 1
ProvisioningState            : Succeeded
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
Stage                        : Development
SystemDataCreatedAt          : 11/5/2025 10:16:48 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 10:18:16 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/models/versions
XmsAsyncOperationTimeout     : 
```

This command updates model version

