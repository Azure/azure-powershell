### Example 1: Remove Spring Cloud App by name
```powershell
Remove-AzSpringApp -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway 
```

Remove Spring Cloud App by name.

### Example 2: Remove Spring Cloud App by pipeline
```powershell
Get-AzSpringApp -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway | Remove-AzSpringApp
```

Remove Spring Cloud App by pipeline.