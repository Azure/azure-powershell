### Example 1: Update custom domain of one lifecycle application
```powershell
Update-AzSpringCloudAppCustomDomain -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway -Name springcloud-service.azuremicroservices.io
```

```output
Name                                     

----                    
springcloud-service.azuremicroservices.io
```

Update custom domain of one lifecycle application.

### Example 2: Update custom domain of one lifecycle application by pipeline
```powershell
Get-AzSpringCloudAppCustomDomain -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway -Name springcloud-service.azuremicroservices.io | Update-AzSpringCloudAppCustomDomain
```

```output
Name                                     

----                    
springcloud-service.azuremicroservices.io
```

Update custom domain of one lifecycle application by pipeline.

