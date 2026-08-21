### Example 1: List all environment containers under a workspace
```powershell
Get-AzMLWorkspaceEnvironmentContainer -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2
```

```output
Name                                                SystemDataCreatedAt  SystemDataCreatedBy                     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----                                                -------------------  -------------------                     ----------------------- ------------------------ ------------------------          
DefaultNcdEnv-mlflow-ubuntu20-04-py38-cpu-inference 11/4/2025 9:30:32 AM 11111111-2222-3333-4444-123456789102    Application             11/4/2025 9:30:32 AM     11111111-2222-3333-4444-123456789102
commandjobenv1                                      11/4/2025 6:18:47 AM User Name (Example)                     User                    11/4/2025 6:18:47 AM     UserName (Example)
batchenv1                                           11/4/2025 6:18:41 AM User Name (Example)                     User                    11/4/2025 6:18:41 AM     UserName (Example)
openmpi4_1_0-ubuntu22_04                            11/4/2025 6:02:17 AM User Name (Example)                     User                    11/4/2025 6:02:17 AM     UserName (Example)
AzureML-ACPT-pytorch-1.13-py38-cuda11.7-gpu         1/24/2023 2:27:55 AM Microsoft                               User                    1/24/2023 2:27:55 AM     Microsoft
```

List all environment containers under a workspace

### Example 2: Gets a environment container by name
```powershell
Get-AzMLWorkspaceEnvironmentContainer -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name openmpi4_1_0-ubuntu22_04
```

```output
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/environments/openmpi4_1_0-ubuntu22_04
IsArchived                   : False
LatestVersion                : 1
Name                         : openmpi4_1_0-ubuntu22_04
NextVersion                  : 2
ProvisioningState            : Succeeded
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/4/2025 6:02:17 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/4/2025 6:02:17 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/environments
XmsAsyncOperationTimeout     : 
```

Gets a environment container by name
