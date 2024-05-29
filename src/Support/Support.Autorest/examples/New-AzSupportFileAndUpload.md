### Example 1: Create and upload a file to a file workspace
```powershell
New-AzSupportFileAndUpload -WorkspaceName "testworkspace" -FilePath "C:\path\to\file\test.txt"
```

```output
ChunkSize                    : 4
CreatedOn                    : 2/9/2024 4:06:13 PM
FileSize                     : 4
Id                           : /subscriptions/3bb7379e-e102-4603-a59c-60f5ca39ec55/providers/Microsoft.Support/fileWorkspaces/testworkspace/files/test.txt
Name                         : test.txt
NumberOfChunk                : 1
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Support/files
```

Create a new file and upload content in a file workspace for an Azure subscription.

### Example 2: Create and upload a file to a support ticket
```powershell
New-AzSupportFileAndUpload -WorkspaceName "2402084010005835" -FilePath "C:\path\to\file\test.txt"
```

```output
ChunkSize                    : 4
CreatedOn                    : 2/9/2024 4:06:13 PM
FileSize                     : 4
Id                           : /subscriptions/3bb7379e-e102-4603-a59c-60f5ca39ec55/providers/Microsoft.Support/fileWorkspaces/2402084010005835/files/test.txt
Name                         : test.txt
NumberOfChunk                : 1
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Support/files
```

Create a new file and upload content to a support ticket in an Azure subscription.

