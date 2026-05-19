### Example 1: Update data container
```powershell
Update-AzMLWorkspaceDataContainer -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name datacontainer-pwsh01 -IsArchived
```

```output
DataType                     : uri_file
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/data/datacontainer-pwsh01
IsArchived                   : True
LatestVersion                : 
Name                         : datacontainer-pwsh01
NextVersion                  : 1
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/5/2025 8:38:23 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 8:38:23 AM
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/data
XmsAsyncOperationTimeout     : 
```

This command updates data container.
