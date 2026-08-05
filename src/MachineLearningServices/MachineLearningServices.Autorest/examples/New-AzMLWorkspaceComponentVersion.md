### Example 1: Create or update component version
```powershell
$componentHash = @{
      "name"= "train_data_component";
      "version"= "1";
      "display_name"= "train_data";
      "is_deterministic"= "True";
      "type"= "command";
      "code"= "/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/codes/cli-hello-example/versions/1";
      "environment"= "azureml:/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/environments/openmpi4_1_0-ubuntu22_04/versions/1";
      "command"= "python train.py"
    }
New-AzMLWorkspaceComponentVersion -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name componentpwsh01 -Version 1 -ComponentSpec $componentHash
```

```output
ComponentSpec                : {
                                 "name": "componentpwsh01",
                                 "version": "1",
                                 "display_name": "train_data",
                                 "is_deterministic": "True",
                                 "type": "command",
                                 "code": "azureml:/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/codes/cli-hello-example/versions/1",
                                 "environment": "azureml:/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/environments/openmpi4_1_0-ubuntu22_04/versions/1",       
                                 "resources": {
                                   "instance_count": "1"
                                 },
                                 "command": "python train.py"
                               }
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/components/componentpwsh01/versions/1
IsAnonymou                   : False
IsArchived                   : False
Name                         : 1
ProvisioningState            : Succeeded
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/5/2025 7:48:02 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 7:48:02 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/components/versions
XmsAsyncOperationTimeout     : 
```

Create or update component version
