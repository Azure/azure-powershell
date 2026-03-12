### Example 1: Create or update model container
```powershell
Update-AzMLWorkspaceModelContainer -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name modelcontainerpwsh01 -Description "code container for test, changed"
```

```output
Description                  : code container for test, changed
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/models/modelcontainerpwsh01
IsArchived                   : False
LatestVersion                : 
Name                         : modelcontainerpwsh01
NextVersion                  : 1
ProvisioningState            : Succeeded
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/5/2025 10:04:53 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 10:06:16 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : M
```

This command creates or update model container.
