### Example 1: Delete a Cloud Exadata Infrastructure resource
```powershell
Remove-AzOracleCloudExadataInfrastructure -NoWait -Name "OFake_PowerShellTestExaInfra" -ResourceGroupName "PowerShellTestRg"
```

```output
Target                                                                                                                  
------                                                                                                                  
https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/providers/Oracle.Database/locations/EASTUS/operationStatuses/adefb987-d10e-4d60-a429-43a6d8737e05*7E12B459C6B67811D263DD78E1675324D775BC3CF19E526B0227B852F7F50997?api-vers…
```

Delete a Cloud Exadata Infrastructure resource.
For more information, execute `Get-Help Remove-AzOracleCloudExadataInfrastructure`.