### Example 1: Get information about a file workspace
```powershell
Get-AzSupportFileWorkspace -Name "testworkspace"
```

```output
CreatedOn                    : 2/8/2024 3:51:36 PM
ExpirationTime               : 2/9/2024 3:51:36 PM
Id                           : /subscriptions/3bb7379e-e102-4603-a59c-60f5ca39ec55/providers/Microsoft.Support/fileWorkspaces/testworkspace
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

Gets details for a specific file workspace in an Azure subscription.

### Example 1: Get information about a file workspace for a support ticket
```powershell
Get-AzSupportFileWorkspace -Name "2402084010005835"
```

```output
CreatedOn                    : 2/8/2024 3:51:36 PM
ExpirationTime               : 8/9/2024 3:51:36 PM
Id                           : /subscriptions/3bb7379e-e102-4603-a59c-60f5ca39ec55/providers/Microsoft.Support/fileWorkspaces/2402084010005835
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

Gets details for a specific file workspace under a support ticket in an Azure subscription.