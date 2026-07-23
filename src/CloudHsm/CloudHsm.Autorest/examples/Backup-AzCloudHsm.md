### Example 1:  Backup a Cloud HSM.
```powershell
Backup-AzCloudHsm -ClusterName chsm1 -ResourceGroupName group -BlobContainerUri "https://{accountName}.blob.core.windows.net/{containerName}"
```

```output
AdditionalInfo               :
AzureStorageBlobContainerUri : https://backup.blob.core.windows.net/testbackup
BackupId                     : cloudhsm-eb0e0bf9-9d12-4201-b38c-567c8a452dd5-2025061208354444
Code                         :
Detail                       :
EndTime                      : 12/06/2025 8:35:54 am
JobId                        : 472f1c6185d74e78bf796c9a8e993a42
Message                      :
StartTime                    : 12/06/2025 8:35:44 am
Status                       : Succeeded
StatusDetail                 : HSM Backup Time: 6/12/2025 8:17:27 AM +00:00 UTC.
Target                       :
XmsRequestId                 : 378da564-737d-4f40-86f5-9623e19c74e1
```

The cmdlet will create a folder (typically named `cloudhsm-{guid}-{timestamp}`) in the storage container, store the backup in that folder and output the folder URI.

