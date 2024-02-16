### Example 1: Create and upload a file to a file workspace
```powershell
New-AzSupportFileAndUploadNoSubscription -WorkspaceName "testworkspace" -FilePath "C:\path\to\file\test.txt"
```

```output
ChunkSize                    : 4
CreatedOn                    : 2/9/2024 4:06:13 PM
FileSize                     : 4
Id                           : /providers/Microsoft.Support/fileWorkspaces/testworkspace/files/test.txt
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

Create a new file and upload content in a file workspace.

### Example 2: Create and upload a file to a support ticket
```powershell
New-AzSupportFileAndUploadNoSubscription -WorkspaceName "2402084010005835" -FilePath "C:\path\to\file\test.txt"
```

```output
ChunkSize                    : 4
CreatedOn                    : 2/9/2024 4:06:13 PM
FileSize                     : 4
Id                           : /providers/Microsoft.Support/fileWorkspaces/2402084010005835/files/test.txt
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

Create a new file and upload content to a support ticket.

