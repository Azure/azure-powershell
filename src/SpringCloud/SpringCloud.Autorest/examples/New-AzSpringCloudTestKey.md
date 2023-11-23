### Example 1: Regenerate a test key for a Service
```powershell
New-AzSpringCloudTestKey -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service -KeyType Primary
```

```output
Enabled PrimaryKey                                                       PrimaryTestEndpoint
------- ----------                                                       -------------------
True    **************************************************************** https://primary:***********************…
```

Regenerate a test key for a Service.

