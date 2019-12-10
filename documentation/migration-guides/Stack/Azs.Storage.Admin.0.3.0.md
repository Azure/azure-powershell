# Table of Contents
1. [Summary](#summary)
2. [Breaking changes in storage admin module](#Breaking-changes-in-storage-admin-module)

## Summary
The module version 0.3.0 of AzureStack SRP brings in many breaking changes. The support version of SRP is upgraded from 2015-12-01-preview to 2019-08-08-preview. Some of the commands and the concept of **FARM** are removed to simplify the usage of SRP. The metrics is also removed from SRP to MDM.

## Breaking changes in storage admin module

**Deprecated Cmdlets**

- ```Get-AzsStorageFarmMetric```, ```Get-AzsStorageFarmMetricDefinition```, ```Get-AzsQueueServiceMetric```, ```Get-AzsQueueServiceMetricDefinition```, ```Get-AzsBlobServiceMetric```,  ```Get-AzsBlobServiceMetricDefinition```, ```Get-AzsTableServiceMetric```, ```Get-AzsTableServiceMetricDefinition```, ```Get-AzsStorageShareMetric```, ```Get-AzsStorageShareMetricDefinition``` are deprecated. Farm is removed in 2019-08-08-preview. All the other metrics are moved to MDM. You can get the original metrics by the following commands:
```powershell
    # Step 1. Get resource under "Microsoft.Storage.Admin/StorageServices"
    $allResourceIds = (Get-AzureRmResource -ResourceType "Microsoft.Storage.Admin/storageservices").ResourceId
    # Step 2. Choose the one you need to check the mdm metrics, you can replace *table* with *blockblob* or *pageblob* or *queue*
    $resourceId = $allResourceIds | ?{$_ -like "*table*"}
    # Step 3. Get metric defintions
    $metricDefinitions = Get-AzureRmMetricDefinition -ResourceId $resourceId
    # Step 4. Get metric based on metric definition
    $metric = Get-AzureRmMetric -ResourceId $resourceId -MetricName $metricDefinitions.Name.Value -StartTime XXXX -EndTime XXXX
```

- ```Get-AzsStorageShare```, ```Get-AzsStorageDestinationShare``` are deprecated. You can use ```Get-AzsVolume``` to get information of share. For detailed information, you can refer to https://docs.microsoft.com/en-us/powershell/module/azs.fabric.admin/get-azsvolume?view=azurestackps-1.7.2.

- ```Get-AzsBlobService```, ```Get-AzsStorageFarm```, ```Get-AzsTableService```, ```Get-AzsQueueService``` are deprecated. These commands shows some uneditable settings and are almost not invoked by customer so that they are deprecated to simplify the usage of SRP.

- ```Get-AzsStorageContainer```, ```Get-AzsStorageContainerMigrationStatus```, ```Start-AzsStorageContainerMigration```, ```Stop-AzsStorageContainerMigration``` are deprecated. Container migration cannot mitigate disk full issue effectively. You can use ```Start-AzsDiskMigrationJob``` to do migration for managed disks. A new version of tool to migrate unmanaged disks will be available in later versions.

- ```Get-AzsReclaimStorageCapacityStatus``` is deprecated. You can check the gc status directly by the return value of command ```Start-AzsReclaimStorageCapacity -AsJob```

**Parameter Changes**<br>

- No need to specify ```FarmName``` in ```Get-AzsStorageAccount```, ```Get-AzStorageAcquisition```, ```Start-ReclaimStorageCapacity```, ```Restore-AzsStorageAccount```. The farm concept is removed in 2019-08-08-preview. Take Get-AzsStorageAccount as example, you can use it like following:
```powershell
        #Old
        Get-AzsStorageAccount -FarmName XXXXXXXX
        #New
        Get-AzsStorageAccount
```

**New Commands** <br>

- ```Get-AzsStorageSettings```, ```Update-AzsStorageSettings``` are added to the new powershell in order to get and update settings like retention policy. You can use it as following:

```powershell
        #Get storage settings
        Get-AzsStorageSettings
        #Update storage settings (retention period for deleted storage account)
        Update-AzsStorageSetting -RetentionPeriodForDeletedStorageAccountsInDays 2
```