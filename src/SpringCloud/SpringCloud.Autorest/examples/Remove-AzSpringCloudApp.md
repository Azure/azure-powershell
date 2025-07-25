### Example 1: Remove Spring Cloud App by name
```powershell
Remove-AzSpringCloudApp -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway 
```

Remove Spring Cloud App by name.

### Example 2: Remove Spring Cloud App by pipeline
```powershell
Get-AzSpringCloudApp -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway | Remove-AzSpringCloudApp
```

Remove Spring Cloud App by pipeline.