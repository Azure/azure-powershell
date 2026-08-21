### Example 1: Create or update component container
```powershell
New-AzMLWorkspaceComponentContainer -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name component-pwsh01 -IsArchived:$false
```

```output
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/components/component-pwsh01
IsArchived                   : False
LatestVersion                : 
Name                         : component-pwsh01
NextVersion                  : 2025-11-05-02-46-14-0608497
ProvisioningState            : Succeeded
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/4/2025 6:19:22 AM
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 11/5/2025 2:46:14 AM
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/components
XmsAsyncOperationTimeout     : 
```

This command creates component container.
