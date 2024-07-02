### Example 1: Disable the default Application Configuration Service
```powershell
Remove-AzSpringCloudConfigurationService -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service
```

Disable the default Application Configuration Service.

### Example 2: Disable the default Application Configuration Service by pipeline
```powershell
Get-AzSpringCloudConfigurationService -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service | Remove-AzSpringCloudConfigurationService
```

Disable the default Application Configuration Service by pipeline.