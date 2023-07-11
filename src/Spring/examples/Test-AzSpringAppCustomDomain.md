### Example 1: Check the resource name is valid as well as not in use
```powershell
Test-AzSpringAppCustomDomain -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service-01 -Name Spring-service-01.azuremicroservices.io -AppName tools
```

```output
IsValid Message
------- -------
True
```

Check the resource name is valid as well as not in use.

### Example 2: Check the resource name is valid as well as not in use by pipeline
```powershell
Get-AzSpringAppCustomDomain -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service-01 -Name Spring-service-01.azuremicroservices.io -AppName tools | Test-AzSpringAppCustomDomain
```

```output
IsValid Message
------- -------
True
```

Check the resource name is valid as well as not in use by pipeline.

