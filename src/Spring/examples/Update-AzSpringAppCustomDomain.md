### Example 1: Update custom domain of one lifecycle application
```powershell
Update-AzSpringAppCustomDomain -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName gateway -Name Spring-service.azuremicroservices.io
```

```output
Name                                     

----                    
Spring-service.azuremicroservices.io
```

Update custom domain of one lifecycle application.

### Example 2: Update custom domain of one lifecycle application by pipeline
```powershell
Get-AzSpringAppCustomDomain -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName gateway -Name Spring-service.azuremicroservices.io | Update-AzSpringAppCustomDomain
```

```output
Name                                     

----                    
Spring-service.azuremicroservices.io
```

Update custom domain of one lifecycle application by pipeline.