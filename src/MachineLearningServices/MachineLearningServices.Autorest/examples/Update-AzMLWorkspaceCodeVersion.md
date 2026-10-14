### Example 1: Update code version
```powershell
Update-AzMLWorkspaceCodeVersion -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name cli-hello-example -Version 1 -Description "Test"
```

```output
CodeUri                      : https://mltestaccount03.blob.core.windows.net/azureml-blobstore-11111111-2222-3333-4444-123456789103/code
Description                  : Test
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/codes/cli-hello-example/versions/1
IsAnonymou                   : False
IsArchived                   : False
Name                         : 1
ProvisioningState            : Succeeded
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/5/2025 3:14:04 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 3:25:16 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/codes/versions
XmsAsyncOperationTimeout     : 
```

This command updates code version.
