### Example 1: Create or update component container
```powershell
Update-AzMLWorkspaceComponentContainer -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name component-pwsh01 -IsArchived:$true
```

```output
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/components/component-pwsh01
IsArchived                   : True
LatestVersion                : 
Name                         : component-pwsh01
NextVersion                  : 2025-11-05-02-54-56-5218255
ProvisioningState            : Succeeded
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/4/2025 6:19:22 AM
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 11/5/2025 2:54:56 AM
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/components
XmsAsyncOperationTimeout     : 
```

This command updates component container.
