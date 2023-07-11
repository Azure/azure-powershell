### Example 1: List test keys for a Service
```powershell
Get-AzSpringTestKey -ResourceGroupName Spring-gp-junxi -Name Spring-service
```

```output
Enabled PrimaryKey                                                       PrimaryTestEndpoint
------- ----------                                                       -------------------
True    **************************************************************** https://primary:*****************
```

List test keys for a Service.
