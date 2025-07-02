### Example 1:   Restores a Cloud HSM from backup.
```powershell
Restore-AzCloudHsm -ClusterName chsm1 -ResourceGroupName group -BlobContainerUri "https://{accountName}.blob.core.windows.net/{containerName}" -BackupId cloudhsm-eb0e0bf9-9d12-4201-b38c-567c8a452dd5-2025052912032456
```

```output
AdditionalInfo               :
Code                         :
Detail                       :
EndTime                      : 12/06/2025 8:35:54 am
JobId                        : 472f1c6185d74e78bf796c9a8e993a42
Message                      :
StartTime                    : 12/06/2025 8:35:44 am
Status                       : Succeeded
Target                       :
XmsRequestId                 : 378da564-737d-4f40-86f5-9623e19c74e1
```

The example restores a backup stored in a folder named "cloudhsm-eb0e0bf9-9d12-4201-b38c-567c8a452dd5-2025052912032456" of a storage container "https://{accountName}.blob.core.windows.net/{containerName}"


