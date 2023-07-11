### Example 1: Disable the default Application Configuration Service
```powershell
Remove-AzSpringConfigurationService -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service
```

```output
```

Disable the default Application Configuration Service.

### Example 2: Disable the default Application Configuration Service by pipeline
```powershell
Get-AzSpringConfigurationService -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service | Remove-AzSpringConfigurationService
```

```output
```

Disable the default Application Configuration Service by pipeline.

