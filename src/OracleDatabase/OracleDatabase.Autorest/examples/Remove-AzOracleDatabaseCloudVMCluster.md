### Example 1: Delete a Cloud VM Cluster resource
```powershell
Remove-AzOracleDatabaseCloudVMCluster -NoWait -Name "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg"
```

```output
Target                                                                                                                  
------                                                                                                                  
https://management.azure.com/subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/providers/Oracle.Database/locations/EASTUS/operationStatuses/a6742d9f-d4fe-4d66-94b4-6df3a1322228*817681FB618A6DF40A3F1658F2C75D4747E1A72F75C4EC15E2D4F9297675979E?api-vers…
```

Delete a Cloud VM Cluster resource.
For more information, execute `Get-Help Remove-AzOracleDatabaseCloudVMCluster`.