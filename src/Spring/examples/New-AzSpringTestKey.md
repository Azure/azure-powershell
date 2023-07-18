### Example 1: Regenerate a test key for a Service
```powershell
New-AzSpringTestKey -ResourceGroupName Spring-gp-junxi -Name Spring-service -KeyType Primary
```

```output
Enabled PrimaryKey                                                       PrimaryTestEndpoint
------- ----------                                                       -------------------
True    **************************************************************** https://primary:***********************…
```

Regenerate a test key for a Service.