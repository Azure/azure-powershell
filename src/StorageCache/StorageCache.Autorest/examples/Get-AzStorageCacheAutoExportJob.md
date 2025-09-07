### Example 1: List all auto export jobs for an AML filesystem
```powershell
Get-AzStorageCacheAutoExportJob -AmlFilesystemName 'myamlfilesystem' -ResourceGroupName 'myresourcegroup'
```

```output
AdminStatus                                    : Enable
AutoExportPrefix                               : {/path1}
AzureAsyncOperation                            :
Id                                             : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myresourcegroup/providers/Microsoft.Storag
                                                 eCache/amlFilesystems/myamlfilesystem/autoExportJobs/myautoexportjob
Location                                       : eastus
Name                                           : myautoexportjob
ProvisioningState                              : Succeeded
ResourceGroupName                              : myresourcegroup
StatusCode                                     :
StatusCurrentIterationFilesDiscovered          : 0
StatusCurrentIterationFilesExported            : 0
StatusCurrentIterationFilesFailed              : 0
StatusCurrentIterationMiBDiscovered            : 0
StatusCurrentIterationMiBExported              : 0
StatusExportIterationCount                     : 0
StatusLastCompletionTimeUtc                    :
StatusLastStartedTimeUtc                       :
StatusLastSuccessfulIterationCompletionTimeUtc :
StatusMessage                                  :
StatusState                                    : InProgress
StatusTotalFilesExported                       : 0
StatusTotalFilesFailed                         : 0
StatusTotalMiBExported                         : 0
SystemDataCreatedAt                            :
SystemDataCreatedBy                            :
SystemDataCreatedByType                        :
SystemDataLastModifiedAt                       :
SystemDataLastModifiedBy                       :
SystemDataLastModifiedByType                   :
Tag                                            : {
                                                 }
Type                                           : Microsoft.StorageCache/amlFilesystems/autoExportJobs
```

Lists all auto export jobs for the specified AML filesystem.

