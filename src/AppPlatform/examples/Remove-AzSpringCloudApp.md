### Example 1: Remove Spring Cloud App by name.
```powershell
PS C:\> Remove-AzSpringCloudApp -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway
```

Remove Spring Cloud App by name.

### Example 2: Remove Spring Cloud App from pipe.
```powershell
PS C:\> Get-AzSpringCloudApp -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway | Remove-AzSpringCloudApp
```

Remove Spring Cloud App from pipe.
