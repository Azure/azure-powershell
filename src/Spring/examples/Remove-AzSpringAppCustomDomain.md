### Example 1: Delete the custom domain of one lifecycle application
```powershell
Remove-AzSpringAppCustomDomain -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName gateway -Name Spring-service.azuremicroservices.io
```

Delete the custom domain of one lifecycle application.

### Example 2: Delete the custom domain of one lifecycle application by pipeline
```powershell
Get-AzSpringAppCustomDomain -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName gateway -Name Spring-service.azuremicroservices.io  |  Remove-AzSpringAppCustomDomain
```

Delete the custom domain of one lifecycle application.