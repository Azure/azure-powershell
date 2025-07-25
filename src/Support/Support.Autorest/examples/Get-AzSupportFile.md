### Example 1: List all files from a file workspace
```powershell
Get-AzSupportFile -WorkspaceName "testworkspace"
```

```output
Name      CreatedOn           ChunkSize FileSize
----      ---------           --------- --------
test.txt  2/9/2024 3:53:15 PM 4         4
test2.txt 2/9/2024 3:53:29 PM 4         4
```

Lists all the Files information under a workspace for an Azure subscription.

### Example 2: Get details of a file in a file workspace
```powershell
Get-AzSupportFile -Name "test.txt" -WorkspaceName "testworkspace"
```

```output
ChunkSize                    : 4
CreatedOn                    : 2/9/2024 3:53:15 PM
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

Returns details of a specific file in a workspace.

### Example 3: List all files from a support ticket
```powershell
Get-AzSupportFile -WorkspaceName "2402084010005835"
```

```output
Name      CreatedOn           ChunkSize FileSize
----      ---------           --------- --------
test.txt  2/9/2024 3:53:15 PM 4         4
test2.txt 2/9/2024 3:53:29 PM 4         4
```

Lists all the Files information under a support ticket for an Azure subscription.

### Example 2: Get details of a file under a support ticket
```powershell
Get-AzSupportFile -Name "test.txt" -WorkspaceName "2402084010005835"
```

```output
ChunkSize                    : 4
CreatedOn                    : 2/9/2024 3:53:15 PM
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

Returns details of a specific file under a support ticket.

