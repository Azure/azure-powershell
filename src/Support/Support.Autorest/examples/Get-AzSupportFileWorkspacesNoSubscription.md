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
