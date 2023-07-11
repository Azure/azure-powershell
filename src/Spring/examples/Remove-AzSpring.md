### Example 1: Remove Spring Cloud Service by name
```powershell
Remove-AzSpring -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service 
```

```output
```

Remove Spring Cloud Service by name.

### Example 2: Remove Spring Cloud Service by pipeline
```powershell
Get-AzSpring -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service | Remove-AzSpring
```

```output
```

Remove Spring Cloud Service by pipeline.