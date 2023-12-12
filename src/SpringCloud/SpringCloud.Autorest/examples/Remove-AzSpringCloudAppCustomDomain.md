### Example 1: Delete the custom domain of one lifecycle application
```powershell
Remove-AzSpringCloudAppCustomDomain -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway -Name springcloud-service.azuremicroservices.io
```

```output
```

Delete the custom domain of one lifecycle application.

### Example 2: Delete the custom domain of one lifecycle application by pipeline
```powershell
Get-AzSpringCloudAppCustomDomain -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway -Name springcloud-service.azuremicroservices.io  |  Remove-AzSpringCloudAppCustomDomain
```

```output
```

Delete the custom domain of one lifecycle application.

