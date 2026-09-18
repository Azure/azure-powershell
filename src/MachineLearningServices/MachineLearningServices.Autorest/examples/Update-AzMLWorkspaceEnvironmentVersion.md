### Example 1: Update an EnvironmentVersion.
```powershell
Update-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name commandjobenv -Version 1 -Description "Test command job"
```

```output
AutoRebuild                  : Disabled
BuildContextUri              : 
BuildDockerfilePath          : 
CondaFile                    : 
Description                  : Test command job
EnvironmentType              : UserCreated
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/environments/commandjobenv/versions/1
Image                        : library/python:latest
IsAnonymou                   : False
IsArchived                   : False
LivenessRoutePath            : 
LivenessRoutePort            : 0
Name                         : 1
OSType                       : Linux
ProvisioningState            : Succeeded
ReadinessRoutePath           : 
ReadinessRoutePort           : 0
ResourceBaseProperty         : {
                                 "azureml.labels": "latest"
                               }
ResourceGroupName            : ml-test
ScoringRoutePath             : 
ScoringRoutePort             : 0
Stage                        : Development
SystemDataCreatedAt          : 11/5/2025 9:40:49 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 9:40:49 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/environments/versions
XmsAsyncOperationTimeout     : 
```

This command updates an EnvironmentVersion.