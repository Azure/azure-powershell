### Example 1: Disable test endpoint functionality for a Service
```powershell
Disable-AzSpringTestEndpoint -ResourceGroupName Spring-gp-junxi -Name Spring-service
```

```output
```

Disable test endpoint functionality for a Service.

### Example 2: Disable test endpoint functionality for a Service by pipeline
```powershell
Get-AzSpring -ResourceGroupName lucas-rg-test -Name springapp-pwsh01 | Disable-AzSpringTestEndpoint 
```

```output
```

Disable test endpoint functionality for a Service by pipeline.

