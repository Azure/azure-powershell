### Example 1: Disable test endpoint functionality for a Service
```powershell
Disable-AzSpringCloudTestEndpoint -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service
```

```output
```

Disable test endpoint functionality for a Service.

### Example 2: Disable test endpoint functionality for a Service by pipeline
```powershell
Get-AzSpringCloud -ResourceGroupName lucas-rg-test -Name springapp-pwsh01 | Disable-AzSpringCloudTestEndpoint 
```

```output
```

Disable test endpoint functionality for a Service by pipeline.

