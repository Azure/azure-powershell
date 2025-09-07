### Example 1: List all import jobs for an AML filesystem
```powershell
Get-AzStorageCacheImportJob -AmlFilesystemName 'myamlfilesystem' -ResourceGroupName 'myresourcegroup'
```

```output
AdminStatus                  : Active
AzureAsyncOperation          :
ConflictResolutionMode       : Fail
Id                           : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myresourcegroup/providers/Microsoft.StorageCache/amlFilesyst
                               ems/myamlfilesystem/importJobs/myimportjob
ImportPrefix                 : {/}
Location                     : eastus
MaximumError                 : 0
Name                         : myimportjob
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
StatusBlobsImportedPerSecond : 0
StatusBlobsWalkedPerSecond   : 0
StatusImportedDirectory      :
StatusImportedFile           :
StatusImportedSymlink        :
StatusLastCompletionTime     : 9/4/2025 4:38:00 AM
StatusLastStartedTime        : 9/4/2025 4:37:54 AM
StatusMessage                :
StatusPreexistingDirectory   :
StatusPreexistingFile        :
StatusPreexistingSymlink     :
StatusState                  : Completed
StatusTotalBlobsImported     : 0
StatusTotalBlobsWalked       : 0
StatusTotalConflict          : 0
StatusTotalError             : 0
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.StorageCache/amlFilesystems/importJobs
```

Lists all import jobs for the specified AML filesystem.

