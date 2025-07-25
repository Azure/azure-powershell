### Example 1: List all scan runs within a scan instance of a data source
```powershell
Get-AzPurviewScanResultScanHistory -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -ScanName 'Scan1ForDemo' | Format-List
```

```output
AssetsClassified            : 62
AssetsDiscovered            : 97
Code                        :
DataSourceType              : AzureStorage
Detail                      :
DiagnosticExceptionCountMap : {
                              }
DiagnosticNotification      : {}
EndTime                     : 2/15/2022 2:42:22 PM
ErrorMessage                :
Id                          : 758a0499-b45e-40e3-9c06-408e2f3ac050
Message                     :
ParentId                    :
PipelineStartTime           : 2/15/2022 2:36:21 PM
QueuedTime                  : 2/15/2022 2:34:06 PM
ResourceId                  : /subscriptions/xxxxxxxx-ffc5-465d-b5dd-xxxxxxxx/resourceGroups/datascan-dev-tests/providers/Microsoft.Storage/storageAccounts/datascan
RunType                     : Manual
ScanLevelType               : Full
ScanRulesetType             : System
ScanRulesetVersion          : 4
StartTime                   : 2/15/2022 2:34:06 PM
Status                      : Succeeded
Target                      :

AssetsClassified            : 62
AssetsDiscovered            : 97
Code                        :
DataSourceType              : AzureStorage
Detail                      :
DiagnosticExceptionCountMap : {
                              }
DiagnosticNotification      : {}
EndTime                     : 2/13/2022 3:23:53 PM
ErrorMessage                :
Id                          : a81d7a0f-149b-4c57-80ae-0f4640ee5a29
Message                     :
ParentId                    :
PipelineStartTime           : 2/13/2022 3:17:02 PM
QueuedTime                  : 2/13/2022 3:16:34 PM
ResourceId                  : /subscriptions/xxxxxxxx-ffc5-465d-b5dd-xxxxxxxx/resourceGroups/datascan-dev-tests/providers/Microsoft.Storage/storageAccounts/datascan
RunType                     : Manual
ScanLevelType               : Full
ScanRulesetType             : System
ScanRulesetVersion          : 4
StartTime                   : 2/13/2022 3:16:34 PM
Status                      : Succeeded
Target                      :
```

List all scan runs within a scan instance of a data source

