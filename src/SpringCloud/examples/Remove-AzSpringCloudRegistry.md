### Example 1: Disable the default Service Registry
```powershell
Remove-AzSpringCloudRegistry -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -Name default
```

```output
```

Disable the default Service Registry.

### Example 2: Disable the default Service Registry by pipeline
```powershell
Get-AzSpringCloudRegistry -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -Name default | Remove-AzSpringCloudRegistry
```

```output
```

Disable the default Service Registry by pipeline.
