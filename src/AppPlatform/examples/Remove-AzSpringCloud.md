### Example 1: Remove Spring Cloud Service by name.
```powershell
PS C:\> Remove-AzSpringCloud -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service
```

Remove Spring Cloud Service by name.

### Example 2: Remove Spring Cloud Service from pipe.
```powershell
PS C:\> Get-AzSpringCloud -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service | Remove-AzSpringCloud
```

Remove Spring Cloud Service from pipe.
