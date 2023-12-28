### Example 1: Get SAP sizing recommendations by providing SAPS for application tier and memory required for database tier
```powershell
Invoke-AzWorkloadsSapSizingRecommendation -Location eastus -AppLocation eastus -DatabaseType HANA -DbMemory 256 -DeploymentType SingleServer -Environment NonProd -SapProduct S4HANA -Sap 10000 -DbScaleMethod ScaleUp
```

```output
DeploymentType VMSku
-------------- -----
SingleServer   Standard_E32ds_v4
```

The command will take input of the Deployment type, region, SAPS number and Database memory size requirement for the SAP system and help you understand the right size and count of Azure SKUs that you should use for the App server instance, Central service instance and Database instance while deploying your SAP system with Azure Center for SAP solutions.


