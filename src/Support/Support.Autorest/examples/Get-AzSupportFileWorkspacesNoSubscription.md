### Example 1: Get a file workspace
```powershell
Get-AzSupportFileWorkspacesNoSubscription -Name "testworkspace"
```

```output
CreatedOn                    : 2/8/2024 4:25:38 PM
ExpirationTime               : 2/9/2024 4:25:38 PM
Id                           : /providers/Microsoft.Support/fileWorkspaces/testworkspace
Name                         : testworkspace
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Support/fileWorkspaces
```

Gets details for a specific file workspace.

### Example 1: Get information about a file workspace for a support ticket
```powershell
Get-AzSupportFileWorkspace -Name "2402084010005835"
```

```output
CreatedOn                    : 2/8/2024 3:51:36 PM
ExpirationTime               : 8/9/2024 3:51:36 PM
Id                           : /providers/Microsoft.Support/fileWorkspaces/2402084010005835
Name                         : 2402084010005835
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Support/fileWorkspaces
```

Gets details for a specific file workspace under a support ticket.
