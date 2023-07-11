### Example 1: Get the custom domain of all lifecycle applications
```powershell
 Get-AzSpringAppCustomDomain -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName gateway
```

```output
Name                                      
          
----                               
Spring-service.azuremicroservices.io
```

Get the custom domain of all lifecycle applications.

### Example 2: Get the custom domain of one lifecycle application
```powershell
Get-AzSpringAppCustomDomain -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName gateway -Name Spring-service.azuremicroservices.io
```

```output
Name                                      
          
----                               
Spring-service.azuremicroservices.io
```

Get the custom domain of one lifecycle application.

