### Example 1: Enable Defender for Storage V2 and Scanning Services
```powershell
Update-AzSecurityDefenderForStorage -ResourceId "/subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>" -IsEnabled -OnUploadIsEnabled -OnUploadCapGbPerMonth 7000 -SensitiveDataDiscoveryIsEnabled
```

```output
Id                                                 : /subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>
IsEnabled                                          : True
MalwareScanningOperationStatusCode                 : Succeeded
MalwareScanningOperationStatusMessage              :
MalwareScanningScanResultsEventGridTopicResourceId :
Name                                               : current
OnUploadCapGbPerMonth                              : 7000
OnUploadIsEnabled                                  : True
OverrideSubscriptionLevelSetting                   : False
ResourceGroupName                                  : <ResourceGroupName>
SensitiveDataDiscoveryIsEnabled                    : True
SensitiveDataDiscoveryOperationStatusCode          : Succeeded
SensitiveDataDiscoveryOperationStatusMessage       :
Type                                               : Microsoft.Security/defenderForStorageSettings
```


### Example 2: Disable Defender for Storage V2 when Scanning Services are enabled
```powershell
Update-AzSecurityDefenderForStorage -ResourceId "/subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>" -IsEnabled:$false -OnUploadIsEnabled:$false -SensitiveDataDiscoveryIsEnabled:$false
```

```output
Id                                                 : /subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>
IsEnabled                                          : False
MalwareScanningOperationStatusCode                 : Succeeded
MalwareScanningOperationStatusMessage              :
MalwareScanningScanResultsEventGridTopicResourceId :
Name                                               : current
OnUploadCapGbPerMonth                              : -1
OnUploadIsEnabled                                  : False
OverrideSubscriptionLevelSetting                   : False
ResourceGroupName                                  : <ResourceGroupName>
SensitiveDataDiscoveryIsEnabled                    : False
SensitiveDataDiscoveryOperationStatusCode          : Succeeded
SensitiveDataDiscoveryOperationStatusMessage       :
Type                                               : Microsoft.Security/defenderForStorageSettings
```

Note that when Scanning Services are enabled, disabling them explicitly is required in order to disable Defender for Storage V2 (-IsEnabled:$false is not enough).

