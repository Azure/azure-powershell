### Example 1: Deletes a Cloud Exadata Infrastructure resource
```powershell
Remove-AzOracleDatabaseCloudExadataInfrastructure -NoWait -Name "OFake_PowerShellTestExaInfra" -ResourceGroupName "PowerShellTestRg"
```

```output
Target                                                                                                                  
------                                                                                                                  
https://management.azure.com/subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/providers/Oracle.Database/locations/EASTUS/operationStatuses/adefb987-d10e-4d60-a429-43a6d8737e05*7E12B459C6B67811D263DD78E1675324D775BC3CF19E526B0227B852F7F50997?api-vers…
```

Deletes a Cloud Exadata Infrastructure resource