### Example 1: Run SKU Recommendation on given SQL Server using connection string
```powershell
PS C:\> Get-AzDataMigrationSkuRecommendation -DisplayResult
```

```output
Starting SKU recommendation...

Performing aggregation for instance AALAB03-2K8...
Aggregation complete. Calculating SKU recommendations...
Instance name: AALAB03-2K8
SKU recommendation: Azure SQL Managed Instance:
Compute: Gen5 - GeneralPurpose - 4 cores
Storage: 64 GB
Recommendation reasons:
        According to the performance data collected, we estimate that your SQL server instance has a requirement for 0.16 vCores of CPU. For greater flexibility, based on your scaling factor of 100.00%, we are making a recommendation based on 0.16 vCores. Based on all the other factors, including memory, storage, and IO, this is the smallest compute sizing that will satisfy all of your needs.
        This SQL Server instance requires 0.44 GB of memory, which is within this SKU's limit of 20.40 GB.
        This SQL Server instance requires 32.37 GB of storage for data files. We recommend provisioning 64 GB of storage, which is the closest valid amount that can be provisioned that meets your requirement.
        This SQL Server instance requires 0.00 MB/second of combined read/write IO throughput. This is a relatively idle instance, so IO latency is not considered.
        Assuming the database uses the Full Recovery Model, this SQL Server instance requires 1 IOPS for data and log files. 
        This is the most cost-efficient offering among all the performance eligible SKUs.


Finishing SKU recommendations...
Event and Error Logs Folder Path: C:\Users\vmanhas\AppData\Local\Microsoft\SqlAssessment\Logs
```

This command runs Run SKU Recommendation on given SQL Server using the connection string.


### Example 2: Run Run SKU Recommendation on given SQL Server using assessment config file
```powershell
PS C:\> Get-AzDataMigrationSkuRecommendation -ConfigFilePath "C:\Users\user\document\config.json"
```

```output
Starting SKU recommendation...

Performing aggregation for instance AALAB03-2K8...
Aggregation complete. Calculating SKU recommendations...
Instance name: AALAB03-2K8
SKU recommendation: Azure SQL Managed Instance:
Compute: Gen5 - GeneralPurpose - 4 cores
Storage: 64 GB
Recommendation reasons:
        According to the performance data collected, we estimate that your SQL server instance has a requirement for 0.16 vCores of CPU. For greater flexibility, based on your scaling factor of 100.00%, we are making a recommendation based on 0.16 vCores. Based on all the other factors, including memory, storage, and IO, this is the smallest compute sizing that will satisfy all of your needs.
        This SQL Server instance requires 0.44 GB of memory, which is within this SKU's limit of 20.40 GB.
        This SQL Server instance requires 32.37 GB of storage for data files. We recommend provisioning 64 GB of storage, which is the closest valid amount that can be provisioned that meets your requirement.
        This SQL Server instance requires 0.00 MB/second of combined read/write IO throughput. This is a relatively idle instance, so IO latency is not considered.
        Assuming the database uses the Full Recovery Model, this SQL Server instance requires 1 IOPS for data and log files. 
        This is the most cost-efficient offering among all the performance eligible SKUs.


Finishing SKU recommendations...
Event and Error Logs Folder Path: C:\Users\vmanhas\AppData\Local\Microsoft\SqlAssessment\Logs
```

This command runs Run SKU Recommendation on given SQL Server using the config file.


