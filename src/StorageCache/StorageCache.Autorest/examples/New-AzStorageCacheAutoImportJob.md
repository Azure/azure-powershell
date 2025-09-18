### Example 1: Create a new auto import job
```powershell
New-AzStorageCacheAutoImportJob -AmlFilesystemName 'myamlfilesystem' -Name 'myautoimportjob' -ResourceGroupName 'myresourcegroup' -Location 'East US' -AutoImportPrefix @('/path1', '/path2')
```

```output
AdminStatus                  : Enable
AutoImportPrefix             : {/path1, /path2}
AzureAsyncOperation          :
ConflictResolutionMode       : Fail
EnableDeletion               : False
Id                           : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myresourcegroup/providers/Microsoft.StorageCache/amlFilesyst
                               ems/myamlfilesystem/autoImportJobs/myautoimportjob
Location                     : eastus
MaximumError                 : 0
Name                         : myautoimportjob
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
Status                       : {
                                 "blobSyncEvents": {
                                   "importedFiles": 0,
                                   "importedDirectories": 0,
                                   "importedSymlinks": 0,
                                   "preexistingFiles": 0,
                                   "preexistingDirectories": 0,
                                   "preexistingSymlinks": 0,
                                   "totalBlobsImported": 0,
                                   "rateOfBlobImport": 0,
                                   "totalErrors": 0,
                                   "totalConflicts": 0,
                                   "deletions": 0
                                 },
                                 "state": "InProgress",
                                 "totalBlobsWalked": 0,
                                 "rateOfBlobWalk": 0,
                                 "totalBlobsImported": 0,
                                 "rateOfBlobImport": 0,
                                 "importedFiles": 0,
                                 "importedDirectories": 0,
                                 "importedSymlinks": 0,
                                 "preexistingFiles": 0,
                                 "preexistingDirectories": 0,
                                 "preexistingSymlinks": 0,
                                 "totalErrors": 0,
                                 "totalConflicts": 0,
                                 "lastStartedTimeUTC": "2025-09-06T02:29:26.4888208Z"
                               }
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.StorageCache/amlFilesystems/autoImportJobs
```

Creates a new auto import job for the specified AML filesystem with the given auto import prefixes.

