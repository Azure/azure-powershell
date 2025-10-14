### Example 1: Create a new auto export job
```powershell
New-AzStorageCacheAutoExportJob -AmlFilesystemName 'myamlfilesystem' -Name 'myautoexportjob' -ResourceGroupName 'myresourcegroup' -Location 'East US' -AutoExportPrefix @('/path1')
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

Creates a new auto export job for the specified AML filesystem with the given auto export prefix.

