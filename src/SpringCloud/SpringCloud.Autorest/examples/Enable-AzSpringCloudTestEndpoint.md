### Example 1: Enable test endpoint functionality for a Service
```powershell
Enable-AzSpringCloudTestEndpoint -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service -debug
```

```output
Enabled PrimaryKey  PrimaryTestEndpoint
------- ----------  -------------------
True    *******     https://primary:EZ0RH3NEDunYBmnAiK7LebCGpruoO…
```

Enable test endpoint functionality for a Service.

### Example 2: Enable test endpoint functionality for a Service by pipeline
```powershell
Get-AzSpringCloud -ResourceGroupName lucas-rg-test -Name springapp-pwsh01 | Disable-AzSpringCloudTestEndpoint 
```

```output
Enabled PrimaryKey                                                       PrimaryTestEndpoint
------- ----------                                                       -------------------
True    **************************************************************** https://primary:EZ0RH3NEDunYBmnAiK7LebCGpruoO…
```

Enable test endpoint functionality for a Service by pipeline.

