### Example 1: Remove Spring Cloud Service by name
```powershell
Remove-AzSpringCloud -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service 
```

```output
```

Remove Spring Cloud Service by name.

### Example 2: Remove Spring Cloud Service by pipeline
```powershell
Get-AzSpringCloud -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service | Remove-AzSpringCloud
```

```output
```

Remove Spring Cloud Service by pipeline.