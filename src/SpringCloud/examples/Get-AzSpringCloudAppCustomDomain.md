### Example 1: Get the custom domain of all lifecycle applications
```powershell
 Get-AzSpringCloudAppCustomDomain -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway
```

```output
Name                                      
          
----                               
springcloud-service.azuremicroservices.io
```

Get the custom domain of all lifecycle applications.

### Example 2: Get the custom domain of one lifecycle application
```powershell
Get-AzSpringCloudAppCustomDomain -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway -Name springcloud-service.azuremicroservices.io
```

```output
Name                                      
          
----                               
springcloud-service.azuremicroservices.io
```

Get the custom domain of one lifecycle application.

