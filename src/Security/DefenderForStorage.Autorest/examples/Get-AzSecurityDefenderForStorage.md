### Example 1: Get Defender for Storage V2 settings on a storage account
```powershell
Get-AzSecurityDefenderForStorage -ResourceId "/subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>"
```

```output
Id                                                 : String
IsEnabled                                          : Bool
MalwareScanningOperationStatusCode                 :
MalwareScanningOperationStatusMessage              :
MalwareScanningScanResultsEventGridTopicResourceId : String
Name                                               : current
OnUploadCapGbPerMonth                              : Int
OnUploadIsEnabled                                  : Bool
OverrideSubscriptionLevelSetting                   : Bool
ResourceGroupName                                  : String
SensitiveDataDiscoveryIsEnabled                    : Bool
SensitiveDataDiscoveryOperationStatusCode          :
SensitiveDataDiscoveryOperationStatusMessage       :
Type                                               : Microsoft.Security/defenderForStorageSettings
```
