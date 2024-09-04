### Example 1: Get the SAP Disk Configuration Layout for prod/non-prod SAP System
```powershell
Invoke-AzWorkloadsSapDiskConfiguration -Location eastus -AppLocation eastus -DatabaseType HANA -DbVMSku Standard_M32ts -DeploymentType SingleServer -Environment NonProd -SapProduct S4HANA
```

```output
Keys                 : {hana/data, hana/log, hana/shared, usr/sap...}
Values               : {{
                         "recommendedConfiguration": {
                           "sku": {
                             "name": "Premium_LRS"
                           },
                           "count": 4,
                           "sizeGB": 128
                         },
                         "supportedConfigurations": [
                           {
                             "sku": {
                               "name": "Premium_LRS"
                             },
                             "sizeGB": 128,
                             "minimumSupportedDiskCount": 4,
                             "maximumSupportedDiskCount": 5,
                             "iopsReadWrite": 500,
                             "mbpsReadWrite": 100,
                             "diskTier": "P10"
                           }
                         ]
                       }}
```

This command will help you understand the default disk configuration that will b deployed for the SAP system for a selected deployment type. You can customize this when you are deploying your SAP system from Azure Center for SAP solutions 


