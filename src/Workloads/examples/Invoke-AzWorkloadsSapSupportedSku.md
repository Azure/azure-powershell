### Example 1: Get SAP sizing recommendations by providing input SAPS for application tier and memory required for database tier
```powershell
Invoke-AzWorkloadsSapSupportedSku -Location eastus -AppLocation eastus -DatabaseType HANA -DeploymentType ThreeTier -Environment Prod -SapProduct S4HANA
```

```output
IsAppServerCertified IsDatabaseCertified VMSku
-------------------- ------------------- -----
True                 False               Standard_D16ds_v4
True                 False               Standard_D16ds_v5
True                 False               Standard_D32ds_v4
True                 False               Standard_D32ds_v5
True                 False               Standard_D48ds_v4
True                 False               Standard_D48ds_v5
```

This command helps you understand the list of SAP certified Azure SKUs supported for the SAP deployment type you want to deploy and for the region in which you want to deploy the SAP system with Azure Center for SAP solutions


