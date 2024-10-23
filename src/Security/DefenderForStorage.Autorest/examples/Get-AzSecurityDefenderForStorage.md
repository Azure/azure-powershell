### Example 1: Get Defender for Storage V2 settings on a storage account
```powershell
Get-AzSecurityDefenderForStorage -ResourceId "/subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>"
```

```output
Id                                                 : /subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>
IsEnabled                                          : True
MalwareScanningOperationStatusCode                 :
MalwareScanningOperationStatusMessage              :
MalwareScanningScanResultsEventGridTopicResourceId :
Name                                               : current
OnUploadCapGbPerMonth                              : 5000
OnUploadIsEnabled                                  : True
OverrideSubscriptionLevelSetting                   : False
ResourceGroupName                                  : <ResourceGroupName>
SensitiveDataDiscoveryIsEnabled                    : True
SensitiveDataDiscoveryOperationStatusCode          :
SensitiveDataDiscoveryOperationStatusMessage       :
Type                                               : Microsoft.Security/defenderForStorageSettings
```

