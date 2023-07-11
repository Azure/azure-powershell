### Example 1: Enable test endpoint functionality for a Service
```powershell
Enable-AzSpringTestEndpoint -ResourceGroupName Spring-gp-junxi -Name Spring-service -debug
```

```output
Enabled PrimaryKey  PrimaryTestEndpoint
------- ----------  -------------------
True    *******     https://primary:EZ0RH3NEDunYBmnAiK7LebCGpruoO…
```

Enable test endpoint functionality for a Service.

### Example 2: Enable test endpoint functionality for a Service by pipeline
```powershell
Get-AzSpring -ResourceGroupName lucas-rg-test -Name springapp-pwsh01 | Disable-AzSpringTestEndpoint 
```

```output
Enabled PrimaryKey                                                       PrimaryTestEndpoint
------- ----------                                                       -------------------
True    **************************************************************** https://primary:EZ0RH3NEDunYBmnAiK7LebCGpruoO…
```

Enable test endpoint functionality for a Service by pipeline.

